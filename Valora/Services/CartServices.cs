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
      public async Task<int> addToCart( string UserID,int cartId, int productId, int quantity)
      {
          // repository now returns the actual cart id (new or existing)
          var resultingCartId = await  _cartRepository.AddToCart(UserID, cartId, productId, quantity);
          // persist any pending changes
          await _cartRepository.SaveChanges();
          return resultingCartId;

      }

        public async Task deleteFromCart(int cartId) { 
        await    _cartRepository.Delete(cartId);
        
        }

        public async Task<CartDTO> showTheCart(int cartId)
        {
         return await _cartRepository.ShowTheCart(cartId);
         }

        public async Task RemoveItemFromCart(int cartId, int productId)
        {
            // Load cart, remove matching item entirely and persist
            var cart = await _cartRepository.GetById(cartId);
            if (cart == null) return;
            cart.CartItems ??= new List<CartItem>();
            var existing = cart.CartItems.FirstOrDefault(ci => ci.ProductID == productId);
            if (existing != null)
            {
                cart.CartItems.Remove(existing);
                _cartRepository.Update(cart);
                await _cartRepository.SaveChanges();
            }
        }

        public async Task Add(Cart cart)
        {
            await _cartRepository.Add(cart);  }

        public async Task Update(Cart cart)
        {

              _cartRepository.Update(cart);
        }

        public async Task Delete(int id)
        {
           await _cartRepository.Delete(id);        }
 
        public async Task Save()
        {
            await _cartRepository.SaveChanges();
        }

        public async Task<CartDTO> showTheCartPerUser(string UserID)
        {
            Cart cart =  await _cartRepository.GetCartByUserId(UserID);
            return new CartDTO
            {
                CartId = cart.ID,
                UserId = cart.UserID,
                Items = (cart.CartItems ?? new List<CartItem>()).Select(ci => new CartItemDTO
                {
                    ProductId = ci.ProductID,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }

        public async Task<int> GetCartItemCountForUser(string userId)
        {
            var cart = await _cartRepository.GetCartByUserId(userId);
            return (cart.CartItems ?? new List<CartItem>()).Sum(ci => ci.Quantity);
        }
    }
}
