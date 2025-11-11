using Valora.DTOs;
using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {

        public Task AddToCart(string userId, int cartId, int productId, int quantity);
        CartDTO ShowTheCart(int cartId);
        public void RemoveFromCart(int cartId, int productId, int quantity);

        Task<Cart> GetCartByUserId(string userId);
    }
}
