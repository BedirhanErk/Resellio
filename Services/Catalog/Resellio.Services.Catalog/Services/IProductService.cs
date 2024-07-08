using Resellio.Services.Catalog.Dtos;
using Resellio.Shared.Dtos;

namespace Resellio.Services.Catalog.Services
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetByIdAsync(string id);
        Task<Response<List<ProductDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);
        Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
