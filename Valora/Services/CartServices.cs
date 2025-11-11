using System.Threading.Tasks;
using Valora.DTOs;
using Valora.Models;
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
        public async Task<CartDTO> ShowCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetById(cartId);
            if (cart == null) return new CartDTO();
            return MapCart(cart);
        }

        public async Task<CartDTO> ShowCartForUserAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserId(userId);
            if (cart == null) return new CartDTO();
            return MapCart(cart);
        }

        public async Task<CartDTO> AddToCartAsync(string userId,  int productId)
        {
             await _cartRepository.AddToCart(userId, productId);
             var updated = await _cartRepository.GetCartByUserId(userId);
            return updated == null ? new CartDTO() : MapCart(updated);
        }

        public async Task<CartDTO> RemoveItemAsync(string userId, int productId)
        {
            Cart cart= await _cartRepository.GetCartByUserId(userId);

            await _cartRepository.GetCartByUserId(userId);
             var updated = await _cartRepository.GetCartByUserId(userId);
            return updated == null ? new CartDTO() : MapCart(updated);
        }

        public async Task DeleteCartAsync(int cartId)
        {
            await _cartRepository.Delete(cartId);
         }

        private static CartDTO MapCart(Cart cart)
        {
            return new CartDTO
            {
                CartId = cart.ID,
                UserId = cart.UserID,
                Items = cart.CartItems.Select(ci => new CartItemDTO
                {
                    ProductId = ci.ProductID,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }
        public async Task SaveChangesAsync()
        {
            await _cartRepository.saveTheCart();
            ;
        }
    }
}
