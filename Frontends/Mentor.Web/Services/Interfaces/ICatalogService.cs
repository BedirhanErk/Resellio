using Mentor.Web.Models.Catalog;

namespace Mentor.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCourse();
        Task<CourseViewModel> GetCourseById(string id);
        Task<List<CourseViewModel>> GetAllCourseByUserIdId(string userId);
        Task<bool> CreateCourse(CourseCreateInput courseCreateInput);
        Task<bool> UpdateCourse(CourseUpdateInput courseUpdateInput);
        Task<bool> DeleteCourse(string id);
    }
}
