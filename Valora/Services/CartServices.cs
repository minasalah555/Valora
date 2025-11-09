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
        public void addToCart(int cartId, int productId, int quantity)
        {
 _cartRepository.AddToCart(cartId, productId, quantity);

        }



    }
}
