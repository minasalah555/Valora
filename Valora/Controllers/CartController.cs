using Microsoft.AspNetCore.Mvc;
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
    }
}
