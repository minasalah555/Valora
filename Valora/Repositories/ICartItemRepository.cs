using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        public async Task<List<Product>> getItemsInCart(int categoryId);
    }
}