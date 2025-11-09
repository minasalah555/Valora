using Valora.Models;
using Microsoft.EntityFrameworkCore;


namespace Valora.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(Context context) : base(context)
        {
        }

        public void AddToCart(string UserID, int cartId, int productId, int quantity)
        {

            var cart = GetById(cartId).Result;
            if (cart == null)
            {
                cart = new Cart
                {
                    UserID = UserID,
                    CartItems = new List<CartItem>()
                };
                Add(cart);
            }
            var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
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
                    CartID = cart.ID
                };
                cart.CartItems.Add(newItem);
            }
            Update(cart);


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
        public void RemoveFromCart(int cartId, int productId, int quantity)
        {
            var cart = GetById(cartId).Result;
            if (cart != null)
            {
                var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity -= quantity;
                    if (existingItem.Quantity <= 0)
                    {
                        cart.CartItems.Remove(existingItem);
                    }
                    Update(cart);
                }
            }
        }

        //public Task<Cart> GetCartByUserId(int userId)
        //{
        //var cart = Query().Carts
        //       .Include(c => c.CartItems)
        //       .FirstOrDefaultAsync(c => c.UserID == userId);
        //return cart;
        //}

        public void saveTheCart()
        {
            SaveChanges();
        }

        public Task<Cart> GetCartByUserId(string userId)
        {
            var cart = Query().
                   Include(c => c.CartItems)
                   .FirstOrDefaultAsync(c => c.UserID == userId);
            return cart;
        }

         
    }




    }
