using Mentor.Services.Catalog.Dtos;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto category);
    }
}
