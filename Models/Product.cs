using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string NameProduct { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Avata { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Order_Product> Order_Products { get; set; }

    }
}
