using Valora.Models;
using Microsoft.EntityFrameworkCore;
using Valora.DTOs;


namespace Valora.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly Context _context;
        public CartRepository(Context context) : base(context)
        {
            _context = context;
        }

        public   async Task AddToCart(string UserID,  int productId)
        {

            var cart =  await GetCartByUserId(UserID);
           
            var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductID = productId,
                    Quantity = 1,
                    CartID = cart.ID
                };
                cart.CartItems.Add(newItem);
            }
         Update(cart);
            saveTheCart();

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
        public async Task<CartDTO> ShowTheCartByUserId(string userId)
        {
            var cart = await GetCartByUserId(userId);

            return new CartDTO
            {
                CartId = cart.ID,
                UserId = cart.UserID,
                Items = cart.CartItems.Select(item => new CartItemDTO
                {
                    ProductId = item.ProductID,
                    Quantity = item.Quantity
                }).ToList()
            };
        }


        public async Task RemoveFromCart(string userID, int productId)
        {
            var cart =  await GetCartByUserId(userID);
            if (cart != null)
            {
                var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity -= 1;
                    if (existingItem.Quantity <= 0)
                    {
                        cart.CartItems.Remove(existingItem);
                    }
                    Update(cart);
                }
            }
        }
        public async Task cancellTheItem(int cardID, int producID) {
        var cart = await GetById(cardID);
            if (cart != null)
            {
                var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == producID);
                if (existingItem != null)
                {
                    cart.CartItems.Remove(existingItem);
                    Update(cart);
                }
            }
        }
        //here was used by query to include cart items
        //public override Task<Cart> GetById(int id)
        //{
        //    return _context.Carts
        //        .Include(c => c.CartItems)
        //        .FirstOrDefaultAsync(c => c.ID == id && !c.IsDeleted);
        // }



        public async Task saveTheCart() => await SaveChanges();

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserID == userId && !c.IsDeleted);

          

            return cart;
        }


    }




    }
