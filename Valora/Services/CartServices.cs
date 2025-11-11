using Valora.DTOs;
using Valora.Repositories;

namespace Valora.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public CartServices(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public void addToCart( string UserID,int cartId, int productId, int quantity)
        {
                _cartRepository.AddToCart(UserID, cartId, productId, quantity);

        }




        public CartDTO showTheCart(int cartId)
        {
         CartDTO cartDTO= _cartRepository.ShowTheCart(cartId);
            return cartDTO;

        }
        public void deleteFromCart(int cartId) { 
        
        }
    }
}
