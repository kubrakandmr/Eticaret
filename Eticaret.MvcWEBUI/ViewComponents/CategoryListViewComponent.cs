using Eticaret.BLL.Abstract;
using Eticaret.MvcWEBUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent 
    {
        //bir sınıfın viewcomponent olabilmesi için viewvomponentten türemesi 
        //ve Invoke'a ihtiyacımız var.
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),

                //mecvut kategori göstermek için
                //mevcut kategoriyi root datasından yakalamamız lazım.
                CurrentCategory =Convert.ToInt32(HttpContext.Request.Query["category"])
            };
            return View(model);
        }
    }
}
