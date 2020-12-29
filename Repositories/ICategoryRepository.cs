using MVC_Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Repositories
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category product);
        List<Category> ListCategory();
        List<Product> Products(int id);
        int EditCategory(Category category);
        int Delete(int id);
        Category GetCategory(int id);
    }
}
