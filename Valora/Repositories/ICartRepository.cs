using Valora.DTOs;
using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {

        public Task AddToCart(string userId, int cartId, int productId, int quantity);
       public Task< CartDTO> ShowTheCart(int cartId);
        public Task RemoveFromCart(int cartId, int productId, int quantity);

        Task<Cart> GetCartByUserId(string userId);
    }
}
