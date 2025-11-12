using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Valora.Models;
using Valora.Services;

namespace Valora.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductAdminController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly IWebHostEnvironment _env;

        public ProductAdminController(IProductServices productServices, CategoryServices categoryServices, IWebHostEnvironment env)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryServices.GetAll();
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryServices.GetAll();
                return View(product);
            }
            // handle file upload
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "images", "products");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }
                product.ImgUrl = $"/images/products/{fileName}";
            }

            product.CreatedAt = System.DateTime.UtcNow;
            await _productServices.Add(product);
            await _productServices.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productServices.GetById(id);
            if (product == null) return NotFound();
            ViewBag.Categories = await _categoryServices.GetAll();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? imageFile)
        {
            if (id != product.ID) return BadRequest();
            
            // load existing entity first
            var existing = await _productServices.GetById(id);
            if (existing == null) return NotFound();
            
            // update fields
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.StockQuantity = product.StockQuantity;
            existing.CategoryId = product.CategoryId;

            // handle file upload
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "images", "products");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }
                existing.ImgUrl = $"/images/products/{fileName}";
            }

            existing.UpdatedAt = System.DateTime.UtcNow;
            _productServices.Update(existing);
            await _productServices.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.Delete(id);
            await _productServices.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
