using Valora.DTOs;
using Valora.Models;

namespace Valora.Services
{
    public interface ICartServices
    {
        Task<CartDTO> ShowCartAsync(int cartId);
        Task<CartDTO> ShowCartForUserAsync(string userId);
        Task<CartDTO> AddToCartAsync(string userId, int productID);
        Task<CartDTO> RemoveItemAsync(string userId, int productID);
        Task DeleteCartAsync(int cartId);
        Task SaveChangesAsync();







    }
}
