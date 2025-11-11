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
        public async Task addToCart( string UserID,int cartId, int productId, int quantity)
        {
              await  _cartRepository.AddToCart(UserID, cartId, productId, quantity);

        }

        public async Task deleteFromCart(int cartId) { 
        await    _cartRepository.Delete(cartId);
        
        }

        public async Task<CartDTO> showTheCart(int cartId)
        {
         return await _cartRepository.ShowTheCart(cartId);
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

            Cart cartDTO =  await _cartRepository.GetCartByUserId(UserID);
            return new CartDTO();

            //Cart cart = await _cartRepository.GetCartByUserId(UserID);
            //cart.CartItems= await _cartItemRepository.GetAll();
        }
    }
}
