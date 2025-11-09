using Valora.Models;
namespace Valora.Repositories

{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(Context context) : base(context)
        {
        }
    }
}
