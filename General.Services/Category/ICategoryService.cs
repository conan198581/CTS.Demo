using System;
using System.Collections.Generic;
using System.Text;
using General.Entites.Category;

namespace General.Services.Category
{
    public interface ICategoryService
    {
        List<General.Entites.Category.Category> GetAll();
    }
}
