using Resellio.Shared.Services;
using Resellio.Web.Models.Catalog;
using Resellio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Resellio.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public ProductController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _catalogService.GetAllProductsByUserId(_sharedIdentityService.UserId);

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInput productCreateInput)
        {
            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            if (!ModelState.IsValid)
                return View();

            productCreateInput.UserId = _sharedIdentityService.UserId;

            await _catalogService.CreateProduct(productCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var product = await _catalogService.GetProductById(id);

            if (product == null)
                return RedirectToAction(nameof(Index));

            var productUpdateInput = new ProductUpdateInput();
            productUpdateInput.Id = product.Id;
            productUpdateInput.UserId = product.UserId;
            productUpdateInput.CategoryId = product.CategoryId;
            productUpdateInput.Name = product.Name;
            productUpdateInput.Price = product.Price;
            productUpdateInput.Picture = product.Picture;
            productUpdateInput.Description = product.Description;

            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(productUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateInput productUpdateInput)
        {
            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name", productUpdateInput.CategoryId);

            if (!ModelState.IsValid)
                return View();

            productUpdateInput.UserId = _sharedIdentityService.UserId;

            await _catalogService.UpdateProduct(productUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
