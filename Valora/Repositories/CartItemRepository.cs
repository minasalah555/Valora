using Microsoft.EntityFrameworkCore;
using Valora.Models;
namespace Valora.Repositories

{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(Context context) : base(context)
        {
        }

        public IQueryable<CartItem> getItemsInCart(int cartID)
        {
            return Query().Where(c => c.CartID == cartID);
                            
        }
    }
}
