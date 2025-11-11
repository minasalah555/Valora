using Microsoft.AspNetCore.Mvc;
using Valora.DTOs;
using Valora.Models;
using Valora.Repositories;
using Valora.Services;
using Valora.ViewModels;

namespace Valora.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public IActionResult Index()
        {
            return View();
        }

         public async Task<IActionResult> AddToCart(CartItemViewModel item)
        {
            if (item == null || item.quantity <= 0)
                return BadRequest();

            await _cartServices.AddToCartAsync(item.USerId, item.productId);

             return RedirectToAction(nameof(ShowTheCart), new { cartId = item.cartId });
        }

        public async Task<IActionResult> ShowTheCart(int cartId)
        {
            var cartDTO = await _cartServices.ShowCartAsync(cartId);
            return View(cartDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            await _cartServices.DeleteCartAsync(cartId);
            return RedirectToAction(nameof(Index));
        }
    }
}
