using Mentor.Services.Catalog.Dtos;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto category);
    }
}
