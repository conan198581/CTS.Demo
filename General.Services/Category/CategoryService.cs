using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Entites;
using General.Entites.Category;

namespace General.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly GeneralDbContext generalDbContext;
        public CategoryService(GeneralDbContext generalDbContext)
        {
            this.generalDbContext = generalDbContext;
        }
        public List<Entites.Category.Category> GetAll()
        {
            return this.generalDbContext.Categories.ToList();
        }
    }
}
