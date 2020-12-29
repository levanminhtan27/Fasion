using Microsoft.AspNetCore.Http;
using MVC_Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.ViewModel
{
    public class ProductViewModel
    {
        public string NameProduct { get; set; }
        public string AddDescription { get; set; }
        public double Price { get; set; }
        public int CategotyId { get; set; }
        public IFormFile AvataPast { get; set; }
    }
}
