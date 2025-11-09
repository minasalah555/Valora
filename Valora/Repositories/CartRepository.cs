using Valora.Models;

namespace Valora.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(Context context) : base(context)
        {
        }

        public void AddToCart(int cartId, int productId, int quantity)
        {
            var cart = GetByIDWithTracking(cartId).Result;
            if (cart != null)
            {
                var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductID == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    var newItem = new CartItem
                    {
                        ProductID = productId,
                        Quantity = quantity,
                        CartID = cartId
                    };
                    cart.CartItems.Add(newItem);
                }
                Update(cart);
            }


        }

        public void ShowTheCart(int cartId)
        {
            var cart = GetById(cartId).Result;
            if (cart != null)
            {
                foreach (var item in cart.CartItems)
                {
                    Console.WriteLine($"Product ID: {item.ProductID}, Quantity: {item.Quantity}");
                }
            }
        }
    }
}
