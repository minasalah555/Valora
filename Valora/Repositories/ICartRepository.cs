using Valora.DTOs;
using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {

        public Task AddToCart(string userId, int productId);
         public Task< CartDTO> ShowTheCart(int cartId);
        public Task RemoveFromCart(string userID, int productId);
        public Task<CartDTO> ShowTheCartByUserId(string userId);
        public   Task cancellTheItem(int cardID, int producID);
       public Task<Cart> GetCartByUserId(string userId);
        public Task saveTheCart();
    }
}
