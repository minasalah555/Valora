using Valora.DTOs;
using Valora.Models;

namespace Valora.Services
{
    public interface ICartServices
    {
        public Task addToCart(string UserID, int cartId, int productId, int quantity);
        public Task< CartDTO> showTheCart(int cartId);
        public Task deleteFromCart(int cartId);
        Task Add(Cart cart);
        Task Update(Cart cart);
        Task Delete(int id);
        Task Save();
        public Task<CartDTO> showTheCartPerUser(string UserID);







    }
}
