using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models
{
    public class Order_Product
    {
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
