using Valora.Repositories;

namespace Valora.Services
{
    public class CartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public CartServices(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public void addToCart( int UserID,int cartId, int productId, int quantity)
        {
                _cartRepository.AddToCart(UserID, cartId, productId, quantity);

        }


        public void showTheCart(int cartId)
        {
            _cartRepository.ShowTheCart( cartId);

        }
        public void deleteCart(int cartId) { 
        
        }
    }
}
