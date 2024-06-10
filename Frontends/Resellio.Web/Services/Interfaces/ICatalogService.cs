using Resellio.Web.Models.Catalog;

namespace Resellio.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCourses();
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<CourseViewModel> GetCourseById(string id);
        Task<CategoryViewModel> GetCategoryById(string id);
        Task<List<CourseViewModel>> GetAllCoursesByUserId(string userId);
        Task<CourseViewModel> CreateCourse(CourseCreateInput courseCreateInput);
        Task<CategoryViewModel> CreateCategory(CategoryCreateInput categoryCreateInput);
        Task<bool> UpdateCourse(CourseUpdateInput courseUpdateInput);
        Task<bool> DeleteCourse(string id);
    }
}
