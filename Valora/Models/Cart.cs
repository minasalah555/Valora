using System.ComponentModel.DataAnnotations.Schema;

namespace Valora.Models
{
    public class Cart : Models.BaseModel
    {
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
