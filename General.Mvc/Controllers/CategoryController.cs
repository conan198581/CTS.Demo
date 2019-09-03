using General.Services.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Mvc.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IActionResult GetAll()
        {
            string countNum = categoryService.GetAll().Count().ToString();
            return Content(countNum);
        }
    }
}
