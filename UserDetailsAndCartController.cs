using FoodDeliveryReservation.Models;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;
using System.Text.Json;
using System.Diagnostics;
using System;

namespace FoodDeliveryReservation.Controllers
{
    public class UserDetailsAndCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddToCart()
        {
            return View();
        }
        public IActionResult UserDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(Menu menu)
        {
            List<Menu> menus;

            if (HttpContext.Session.TryGetValue("menus", out _))
            {

                string jsonNote = HttpContext.Session.GetString("menus");
                if (!string.IsNullOrEmpty(jsonNote))
                {
                    menus = JsonSerializer.Deserialize<List<Menu>>(jsonNote);
                    if (menus == null)
                    {
                        menus = new List<Menu>();
                    }
                }
                else
                {
                    menus = new List<Menu>();
                }
            }
            else
            {
                menus = new List<Menu>();
            }

            menus.Add(menu);
            //update session data
            string jsonString = JsonSerializer.Serialize(menus);
            HttpContext.Session.SetString("menus", jsonString);

            return RedirectToAction("ViewNote");
        }

        public IActionResult UserDetails(User user)
        {
            List<User> users;

            if (HttpContext.Session.TryGetValue("users", out _))
            {

                string jsonNote = HttpContext.Session.GetString("users");
                if (!string.IsNullOrEmpty(jsonNote))
                {
                    users = JsonSerializer.Deserialize<List<User>>(jsonNote);
                    if (users == null)
                    {
                        users = new List<User>();
                    }
                }
                else
                {
                    users = new List<User>();
                }
            }
            else
            {
                users = new List<User>();
            }

            users.Add(user);
            //update session data
            string jsonString = JsonSerializer.Serialize(users);
            HttpContext.Session.SetString("users", jsonString);

            return RedirectToAction("ViewNote");
        }

        [HttpGet]
        public IActionResult ViewNote()
        {
            List<Menu> menus = new List<Menu>();

            if (HttpContext.Session.TryGetValue("menus", out _))
            {
                string jsonNote = HttpContext.Session.GetString("menus");
                menus = !string.IsNullOrEmpty(jsonNote)
                ? JsonSerializer.Deserialize<List<Menu>>(jsonNote) ?? new List<Menu>()
                    : new List<Menu>();
            }

            return View(menus);
        }

        [HttpGet]
        public IActionResult ViewUser()
        {
            List<User> users = new List<User>();
            if(HttpContext.Session.TryGetValue("users", out _))
            {
                string jsonNote = HttpContext.Session.GetString("users");
                users = !string.IsNullOrEmpty(jsonNote)
                ? JsonSerializer.Deserialize<List<User>>(jsonNote) ?? new List<User>()
                    : new List<User>();
            }
            return View(users);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



