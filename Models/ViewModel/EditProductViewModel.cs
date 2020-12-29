using MVC_Fashion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models.ViewModel
{
    public class EditProductViewModel: ProductViewModel
    {
        public int Id { get; set; }
        public string AvatarPaths { get; set; }
        Category Categorys { get; set; }
        public int CategoryId { get; set; }
    }
}
