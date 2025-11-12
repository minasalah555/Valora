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

        public async Task<int> AddToCart(string UserID, int cartId, int productId, int quantity)
        {

            var cart = await GetById(cartId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserID = UserID,
                    CartItems = new List<CartItem>()
                };
                await Add(cart);
                // Persist immediately to generate a real ID so we can add items safely
                await SaveChanges();
            }
            cart.CartItems ??= new List<CartItem>();
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
            // Attach changes (works for both new and existing carts/items)
            Update(cart);
            // Return the actual cart ID so callers can use it (e.g., redirect to ShowTheCart)
            return cart.ID;
        }

        public async Task<CartDTO> ShowTheCart(int cartId)
        {
            var cart = await GetById(cartId);
            if (cart != null)
            {
                var cartDTO = new CartDTO
                {
                    UserId = cart.UserID,
                    CartId = cart.ID,
                    Items = (cart.CartItems ?? Enumerable.Empty<CartItem>()).Select(item => new CartItemDTO
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
                Items = (cart.CartItems ?? Enumerable.Empty<CartItem>()).Select(item => new CartItemDTO
                {
                    ProductId = item.ProductID,
                    Quantity = item.Quantity
                }).ToList()
            };
        }


        public async Task RemoveFromCart(int cartId, int productId, int quantity)
        {
            var cart = await GetById(cartId);
            if (cart == null) return;
            cart.CartItems ??= new List<CartItem>();
            var existingItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity -= quantity;
                if (existingItem.Quantity <= 0)
                {
                    cart.CartItems.Remove(existingItem);
                }
                Update(cart);
                await SaveChanges();
            }
        }
        public override async Task<Cart?> GetById(int id)
        {
            return await Query().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.ID == id && !c.IsDeleted);
        }



        public async Task saveTheCart()
        {
            await SaveChanges();
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var cart = await Query()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserID == userId && !c.IsDeleted);
            if (cart != null)
            {
                return cart;
            }
            // If no cart exists for this user, create and persist one so all callers observe the same cart
            var newCart = new Cart
            {
                UserID = userId,
                CartItems = new List<CartItem>()
            };
            await Add(newCart);
            await SaveChanges();
            return newCart;
        }


    }
    
    }
