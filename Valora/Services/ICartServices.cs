using Valora.DTOs;

namespace Valora.Services
{
    public interface ICartServices
    {
        public void addToCart(string UserID, int cartId, int productId, int quantity);
        public CartDTO showTheCart(int cartId);
        public void deleteFromCart(int cartId);
 


        }
    }
