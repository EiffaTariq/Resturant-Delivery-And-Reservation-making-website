namespace FoodDeliveryReservation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string billingAddress { get; set; }
        public string phoneNumber { get; set; }
    }
}
