using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime ShippedDay { get; set; }
        public string CustomerId { get; set; }
        public ICollection<Order_Product> Order_Products { get; set; }
    }
}
