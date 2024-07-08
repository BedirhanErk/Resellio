using Resellio.Shared.Dtos;
using Resellio.Web.Helpers;
using Resellio.Web.Models.Catalog;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
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

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("product");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();

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

        public async Task<ProductViewModel> GetProductById(string id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();

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

        public async Task<List<ProductViewModel>> GetAllProductsByUserId(string userId)
        {
            var response = await _httpClient.GetAsync($"product/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();

            foreach (var item in responseSuccess.Data)
            {
                item.PictureUrl = _photoHelper.GetPhotoUrl(item.Picture);
            }

            return responseSuccess.Data;
        }

        public async Task<ProductViewModel> CreateProduct(ProductCreateInput productCreateInput)
        {
            var resultPhoto = await _photoStockService.UploadPhoto(productCreateInput.PhotoFormFile);

            if (resultPhoto != null)
                productCreateInput.Picture = resultPhoto.Url;

            var response = await _httpClient.PostAsJsonAsync("product", productCreateInput);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();

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

        public async Task<bool> UpdateProduct(ProductUpdateInput productUpdateInput)
        {
            var resultPhoto = await _photoStockService.UploadPhoto(productUpdateInput.PhotoFormFile);

            if (resultPhoto != null)
            {
                await _photoStockService.DeletePhoto(productUpdateInput.Picture);
                productUpdateInput.Picture = resultPhoto.Url;
            }

            var response = await _httpClient.PutAsJsonAsync("product", productUpdateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var product = await _httpClient.GetAsync($"product/{id}");

            if (!product.IsSuccessStatusCode)
                return false;

            var responseSuccess = await product.Content.ReadFromJsonAsync<Response<ProductViewModel>>();  

            await _photoStockService.DeletePhoto(responseSuccess.Data.Picture);

            var response = await _httpClient.DeleteAsync($"product/{responseSuccess.Data.Id}");

            return response.IsSuccessStatusCode;
        }
    }
}
