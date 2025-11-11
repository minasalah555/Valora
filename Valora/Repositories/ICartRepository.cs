using Valora.DTOs;
using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        void AddToCart(string UserID,int cartId, int productId, int quantity);
        CartDTO ShowTheCart(int cartId);
        public void RemoveFromCart(int cartId, int productId, int quantity);

        Task<Cart> GetCartByUserId(string userId);
    }
}
