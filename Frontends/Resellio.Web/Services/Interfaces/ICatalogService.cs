using Resellio.Web.Models.Catalog;

namespace Resellio.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<ProductViewModel> GetProductById(string id);
        Task<CategoryViewModel> GetCategoryById(string id);
        Task<List<ProductViewModel>> GetAllProductsByUserId(string userId);
        Task<ProductViewModel> CreateProduct(ProductCreateInput productCreateInput);
        Task<CategoryViewModel> CreateCategory(CategoryCreateInput categoryCreateInput);
        Task<bool> UpdateProduct(ProductUpdateInput productUpdateInput);
        Task<bool> DeleteProduct(string id);
    }
}
