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

            await _cartServices.addToCart(item.USerId, item.cartId, item.productId, item.quantity);

             return RedirectToAction(nameof(ShowTheCart), new { cartId = item.cartId });
        }

        public async Task<IActionResult> ShowTheCart(int cartId)
        {
            var cartDTO = await _cartServices.showTheCart(cartId);
            return View(cartDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            await _cartServices.Delete(cartId);
            return RedirectToAction(nameof(Index));
        }
    }
}
