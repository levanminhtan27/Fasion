using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Fashion.Models;
using MVC_Fashion.Models.CartSessions;
using MVC_Fashion.Repositories;

namespace MVC_Fashion.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private readonly IOrderRepository orderRepository;

        public CartController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            HttpContext.Session.SetObjectAsJson(CartSession, cart);

            return View(cart);
        }

        [Route("/Cart/AddItem/{id}/{amount}")]
        public IActionResult AddItem(int id, int amount)
        {
            CartItem item = new CartItem() { ProductId = id, Amount = amount };
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);

            if (cart.Count != 0)
            {
                if (cart.Exists(el => el.ProductId == item.ProductId))
                {
                    cart.FirstOrDefault(el => el.ProductId == item.ProductId).Amount += amount;
                    HttpContext.Session.SetObjectAsJson(CartSession, cart);
                    return Json(-1);
                }
                cart.Add(item);
                HttpContext.Session.SetObjectAsJson(CartSession, cart);

                return Json(cart.Count);
            }
            cart.Add(item);
            HttpContext.Session.SetObjectAsJson(CartSession, cart);

            return Json(cart.Count);
        }
        // đăng nhập mới đc mua hàng
        [Route("/Cart/OrderByAccount/{id}")]
        public IActionResult OrderByAccount(string id)
        {
            var order = new Order()
            {
                CustomerId = id,
                OrderTime = DateTime.Today,
                ShippedDay = DateTime.Today.AddDays(3)
            };
            orderRepository.CreateOder(order);
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);

            foreach (var item in cart)
                orderRepository.AddOrderDetailInOrder(order, item.ProductId, item.Amount);

            int result = orderRepository.GetOrderDetailsByOrderId(order.OrderId).Count;
            if (result > 0)
                HttpContext.Session.SetObjectAsJson(CartSession, new List<CartItem>());

            return Json(result);
        }

        [Route("/Cart/RemoveItem/{id}")]
        public IActionResult RemoveItem(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            int lengthCartBefor = cart.Count;

            CartItem item = cart.Find(el => el.ProductId == id);
            cart.Remove(item);

            HttpContext.Session.SetObjectAsJson(CartSession, cart);

            return Json(lengthCartBefor - cart.Count);
        }
    }
}
