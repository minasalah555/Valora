using Valora.Models;
using Microsoft.EntityFrameworkCore;
using Valora.DTOs;


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

        public CartDTO ShowTheCart(int cartId)
        {
            var cart = GetById(cartId).Result;
            if (cart != null)
            {
                var cartDTO = new CartDTO
                {
                    UserId = cart.UserID,
                    CartId = cart.ID,
                    Items = cart.CartItems.Select(item => new CartItemDTO
                    {
                        ProductId = item.ProductID,
                        Quantity = item.Quantity
                    }).ToList()
                };
                return cartDTO;
            }
            else
            {
                return new CartDTO();

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
