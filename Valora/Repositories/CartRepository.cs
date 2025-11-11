using Valora.Models;
using Microsoft.EntityFrameworkCore;
using Valora.DTOs;
using System.Threading.Tasks;


namespace Valora.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(Context context) : base(context)
        {
        }

        public   async Task AddToCart(string UserID, int cartId, int productId, int quantity)
        {

            var cart =  await GetById(cartId);
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

        public async Task<CartDTO> ShowTheCart(int cartId)
        {
            var cart =  await GetById(cartId);
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
        public async Task RemoveFromCart(int cartId, int productId, int quantity)
        {
            var cart =  await GetById(cartId);
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
        public override async Task<Cart> GetById(int id)
        {
           return await Query().
                   Include(c => c.CartItems)
                   .FirstOrDefaultAsync(c => c.ID == id);
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
