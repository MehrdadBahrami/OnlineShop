namespace OnlineShop.DomainLayer.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
