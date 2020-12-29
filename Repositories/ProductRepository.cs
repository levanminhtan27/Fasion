using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC_Fashion.Models;
using MVC_Fashion.Models.ViewModel;
using MVC_Fashion.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext context;
        private readonly IWebHostEnvironment webHost;

        public ProductRepository(ProductDBContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public int CreateProduct(ProductViewModel product)
        {
                    Product products = new Product()
                    {
                        NameProduct = product.NameProduct,
                        Description = product.AddDescription,
                        Price = product.Price,
                        CategoryId = product.CategotyId
                    };
                    string FileImage = null;
                    if (product.AvataPast != null)
                    {
                        string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                        FileImage = Guid.NewGuid().ToString() + "_" + product.AvataPast.FileName;
                        string filePath = Path.Combine(uploadsFolder, FileImage);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            product.AvataPast.CopyTo(fileStream);
                        }
                    }
                    products.Avata = FileImage;

                    context.Add(products);
                    return context.SaveChanges();
        }


        public int EditProduct(EditProductViewModel model)
        {
            var edit = GetProduct(model.Id);
            edit.NameProduct = model.NameProduct;
            edit.Price = model.Price;
            edit.ProductId = model.Id;
            edit.Description = model.AddDescription;
            edit.CategoryId = model.CategoryId;
            string FileImage = null;
            if (model.AvataPast != null)
            {
                if (!string.IsNullOrEmpty(edit.Avata) && (edit.Avata != "none-avatar.png"))
                {
                    string delFile = Path.Combine(webHost.WebRootPath, "images", edit.Avata);
                    System.IO.File.Delete(delFile);

                }
                string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                FileImage = Guid.NewGuid().ToString() + "_" + model.AvataPast.FileName;
                string filePath = Path.Combine(uploadsFolder, FileImage);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.AvataPast.CopyTo(fileStream);
                }

                edit.Avata = FileImage;

            }
            return context.SaveChanges();
        }


        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public int DeleteProduct(int id)
        {
            var product = context.Products.ToList().Find(p => p.ProductId == id);
            string delFile = Path.Combine(webHost.WebRootPath, "images", product.Avata);
            System.IO.File.Delete(delFile);
            context.Products.Remove(product);
            return context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public List<Product> GetListProduct()
        {
            return context.Products.ToList();
        }

        public List<Product> SearchProduct(string Search)
        {
            return context.Products.Where(e => e.NameProduct.Contains(Search)).ToList();
        }
    }
}

