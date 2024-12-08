
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryReservation.Models;
using System.IO;

namespace UserLoginAndRegistration.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_userRepository.IsEmailExists(email))
            {
                User u = new User();
                var user = _userRepository.GetUsers(email, password);
                if (user != null)
                {
                    // Set a login cookie
                    Response.Cookies.Append("UserEmail", u.Email); // Store needed info

                    return RedirectToAction("Index", "Home"); // Redirect upon successful login
                }
                ViewBag.Message = "Invalid credentials";
            }
            else
            {
                ViewBag.Message = "Email does not exist";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_userRepository.IsEmailExists(user.Email))
            {
                ViewBag.Message = "Email already exists";
                return View();
            }

            _userRepository.AddUser(user);
            ViewBag.Message = "User registered successfully";

            return RedirectToAction("Login");
        }

        // CRUD Operations
        public IActionResult UserDetails(int id)
        {
            var user = _userRepository.getUserById(id);
            return View(user);
        }

        public IActionResult EditUser(int id)
        {
            var user = _userRepository.getUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _userRepository.updateUser(user);
            ViewBag.Message = "User updated successfully";
            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.deleteUser(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserEmail");
            return RedirectToAction("Login");
        }
    }
}