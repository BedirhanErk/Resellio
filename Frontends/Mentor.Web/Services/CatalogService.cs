using Mentor.Web.Models;
using Mentor.Web.Models.Catalog;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<CourseViewModel>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryViewModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CourseViewModel> GetCourseById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel> GetCategoryById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseViewModel>> GetAllCoursesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseViewModel> CreateCourse(CourseCreateInput courseCreateInput)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel> CreateCategory(CategoryCreateInput courseCreateInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourse(CourseUpdateInput courseUpdateInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
