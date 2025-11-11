using Valora.Models;

namespace Valora.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        public IQueryable<CartItem> getItemsInCart(int cartID);
    }
}