using MVC_Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDBContext context;

        public CategoryRepository(ProductDBContext context)
        {
            this.context = context;
        }
        public int CreateCategory(Category category)
        {
            context.Add(category);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Remove(GetCategory(id));
            return context.SaveChanges();
        }

        public int EditCategory(Category category)
        {
            var FindCategory = context.Categories.FirstOrDefault(el=>el.CategoryId==category.CategoryId);
            
            FindCategory.CategoryId = category.CategoryId;
            FindCategory.Name = category.Name;
            context.Categories.Update(FindCategory);
            return context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
        public List<Category> ListCategory()
        {
            return context.Categories.ToList();
        }

        public List<Product> Products(int id)
        {
            return context.Products.ToList().FindAll(p => p.CategoryId == id);
        }

    }
}
