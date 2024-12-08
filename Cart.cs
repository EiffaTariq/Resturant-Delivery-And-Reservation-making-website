namespace FoodDeliveryReservation.Models
{
    public class Cart
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
    }
}