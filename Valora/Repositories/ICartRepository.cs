using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        void AddToCart(string UserID,int cartId, int productId, int quantity);
        void ShowTheCart(int cartId);
        Task<Cart> GetCartByUserId(int userId);
    }
}
