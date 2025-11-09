using Microsoft.AspNetCore.Mvc;
using Valora.DTOs;
using Valora.Models;
using Valora.Repositories;
using Valora.ViewModels;

namespace Valora.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository,ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(CartItemViewModel item)
        {
  

            _cartRepository.AddToCart(item.USerId,item.cartId, item.productId, item.quantity);

            return View();
        }


        public IActionResult ShowTheCart(int cartId)
        {
            CartDTO cartDTO = new CartDTO();
            cartDTO.UserId = "5";
            cartDTO.CartId = 1;
            cartDTO.Items.Add(new CartItemDTO { ProductId = 1, Quantity =2 });
            _cartRepository.ShowTheCart(cartId);
            return View(cartDTO);
        }
    }
}
