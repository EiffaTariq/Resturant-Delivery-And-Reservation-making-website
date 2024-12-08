using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryReservation.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
