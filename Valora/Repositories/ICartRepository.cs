using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        void AddToCart(int cartId, int productId, int quantity);
        void ShowTheCart(int cartId);
    }
}
