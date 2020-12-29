using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Fashion.Models;
using MVC_Fashion.Models.CartSessions;

namespace MVC_Fashion.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);

            if (cart == null)
                HttpContext.Session.SetObjectAsJson(CartSession, new List<CartItem>());
            else
                HttpContext.Session.SetObjectAsJson(CartSession, cart);

            return View();
        }


      
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ViewCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            HttpContext.Session.SetObjectAsJson(CartSession, cart);
            return View(cart);
        }
    }
}
