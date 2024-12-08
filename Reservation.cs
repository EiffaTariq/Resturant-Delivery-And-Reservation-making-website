namespace FoodDeliveryReservation.Models
{
    public class Reservation
    {
        public int revId { get; set; }
        public int userId { get; set; }
        public DateTime DateTime { get; set; }
        public int guestCount { get; set; }
    }
}