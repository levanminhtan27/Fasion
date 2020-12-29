using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Fashion.Models;
using MVC_Fashion.Repositories;

namespace MVC_Fashion.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository iCategory;

        public CategoryController(ICategoryRepository ICategory)
        {
            this.iCategory = ICategory;
        }


        public IActionResult Show()
        {
            return View(iCategory.ListCategory());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                iCategory.CreateCategory(category);
                return RedirectToAction("Show", "Category");

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (iCategory.Delete(id) != 0)
            {
                return RedirectToAction("Show", "Category");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(iCategory.GetCategory(id));
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                iCategory.EditCategory(category);
                return RedirectToAction("Show", "Category");
            }
            return View();
        }
    }
}
