﻿using Mentor.Shared.Dtos;
using Mentor.Web.Helpers;
using Mentor.Web.Models.Catalog;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public CatalogService(HttpClient httpClient, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _httpClient = httpClient;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            var response = await _httpClient.GetAsync("course");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CourseViewModel>>>();

            foreach (var item in responseSuccess.Data)
            {
                item.PictureUrl = _photoHelper.GetPhotoUrl(item.Picture);
            }

            return responseSuccess.Data;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var response = await _httpClient.GetAsync("category");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<CourseViewModel> GetCourseById(string id)
        {
            var response = await _httpClient.GetAsync($"course/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<CourseViewModel>>();

            responseSuccess.Data.PictureUrl = _photoHelper.GetPhotoUrl(responseSuccess.Data.Picture);

            return responseSuccess.Data;
        }

        public async Task<CategoryViewModel> GetCategoryById(string id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<CategoryViewModel>>();

            return responseSuccess.Data;
        }

        public async Task<List<CourseViewModel>> GetAllCoursesByUserId(string userId)
        {
            var response = await _httpClient.GetAsync($"course/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CourseViewModel>>>();

            foreach (var item in responseSuccess.Data)
            {
                item.PictureUrl = _photoHelper.GetPhotoUrl(item.Picture);
            }

            return responseSuccess.Data;
        }

        public async Task<CourseViewModel> CreateCourse(CourseCreateInput courseCreateInput)
        {
            var resultPhoto = await _photoStockService.UploadPhoto(courseCreateInput.PhotoFormFile);

            if (resultPhoto != null)
                courseCreateInput.Picture = resultPhoto.Url;

            var response = await _httpClient.PostAsJsonAsync("course", courseCreateInput);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<CourseViewModel>>();

            return responseSuccess.Data;
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryCreateInput categoryCreateInput)
        {
            var response = await _httpClient.PostAsJsonAsync("category", categoryCreateInput);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<CategoryViewModel>>();

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateCourse(CourseUpdateInput courseUpdateInput)
        {
            var resultPhoto = await _photoStockService.UploadPhoto(courseUpdateInput.PhotoFormFile);

            if (resultPhoto != null)
            {
                await _photoStockService.DeletePhoto(courseUpdateInput.Picture);
                courseUpdateInput.Picture = resultPhoto.Url;
            }

            var response = await _httpClient.PutAsJsonAsync("course", courseUpdateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCourse(string id)
        {
            var course = await _httpClient.GetAsync($"course/{id}");

            if (!course.IsSuccessStatusCode)
                return false;

            var responseSuccess = await course.Content.ReadFromJsonAsync<Response<CourseViewModel>>();  

            await _photoStockService.DeletePhoto(responseSuccess.Data.Picture);

            var response = await _httpClient.DeleteAsync($"course/{responseSuccess.Data.Id}");

            return response.IsSuccessStatusCode;
        }
    }
}
