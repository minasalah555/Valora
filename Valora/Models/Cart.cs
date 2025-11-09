namespace Valora.Models
{
    public class Cart : Models.BaseModel
    {
        public int UserID { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
