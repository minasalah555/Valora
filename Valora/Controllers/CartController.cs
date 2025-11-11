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
        public IActionResult AddToCart(CartItemViewModel item)
        {


            _cartServices.addToCart(item.USerId,item.cartId, item.productId, item.quantity);

            return View();
        }


        public IActionResult ShowTheCart(int cartId)
        {

            CartDTO cartDTO = new CartDTO();
            cartDTO.UserId = "5";
            cartDTO.CartId = 1;
            cartDTO.Items.Add(new CartItemDTO { ProductId = 1, Quantity =2 });
            _cartServices.showTheCart(cartId);
            return View(cartDTO);
        }
        //uncompleted
        public IActionResult DeleteCart(int cartId)
        {

        _cartServices.deleteFromCart(1); 
            return View();
        }
    }
}
