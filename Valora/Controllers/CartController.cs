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
            // Redirect to the user's cart if authenticated, otherwise send to login
            var userId = User?.Identity?.IsAuthenticated == true ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;
            if (!string.IsNullOrEmpty(userId))
            {
                return RedirectToAction(nameof(UserCart));
            }
            return RedirectToAction("Login", "Account");
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddToCart(CartItemViewModel item)
        {
            if (item == null || item.quantity <= 0)
                return BadRequest();

            // Prefer server-side authenticated user id to avoid mismatches from client-sent values
            var userIdFromClaim = User?.Identity?.IsAuthenticated == true ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;
            var userIdToUse = !string.IsNullOrEmpty(userIdFromClaim) ? userIdFromClaim : item?.USerId;

            // addToCart now returns the actual cart id (in case item.cartId was 0 or missing)
            if (string.IsNullOrEmpty(userIdToUse))
            {
                // If we don't have a user id, send user to login (forms should normally only be shown to authenticated users)
                return RedirectToAction("Index", "Account");
            }

            var cartId = await _cartServices.addToCart(userIdToUse!, item.cartId, item.productId, item.quantity);

            // redirect to the resulting cart id (use the returned id which is persisted)
            return RedirectToAction(nameof(ShowTheCart), new { cartId });
        }

        public async Task<IActionResult> ShowTheCart(int cartId)
        {
            var cartDTO = await _cartServices.showTheCart(cartId);
            return View(cartDTO);
        }

        [HttpGet]
        public async Task<IActionResult> UserCart()
        {
            var userId = User?.Identity?.IsAuthenticated == true ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Index", "Account");
            var dto = await _cartServices.showTheCartPerUser(userId);
            return View("ShowTheCart", dto);
        }

        [HttpGet]
        public async Task<IActionResult> CartCount()
        {
            var userId = User?.Identity?.IsAuthenticated == true ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;
            if (string.IsNullOrEmpty(userId)) return Json(new { count = 0 });
            var count = await _cartServices.GetCartItemCountForUser(userId);
            return Json(new { count });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            await _cartServices.Delete(cartId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int cartId, int productId)
        {
            await _cartServices.RemoveItemFromCart(cartId, productId);
            return RedirectToAction(nameof(ShowTheCart), new { cartId });
        }
    }
}
