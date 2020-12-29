using MVC_Fashion.Models;
using MVC_Fashion.Models.ViewModel;
using MVC_Fashion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Repositories
{
    public interface IProductRepository
    {
        int CreateProduct(ProductViewModel product);

        Product GetProduct(int id);
        //int UpdateProduct(Product product);
        int EditProduct(EditProductViewModel model);

        int DeleteProduct(int id);
        void Save();

        List<Product> GetListProduct();
        List<Product> SearchProduct(string Search);
    }
}
