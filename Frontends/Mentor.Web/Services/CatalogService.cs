using Mentor.Shared.Dtos;
using Mentor.Web.Models.Catalog;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly IPhotoStockService _photoStockService;

        public CatalogService(HttpClient httpClient, IPhotoStockService photoStockService)
        {
            _httpClient = httpClient;
            _photoStockService = photoStockService;
        }

        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            var response = await _httpClient.GetAsync("course");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CourseViewModel>>>();

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
            var response = await _httpClient.PutAsJsonAsync("course", courseUpdateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCourse(string id)
        {
            var response = await _httpClient.DeleteAsync($"course/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
