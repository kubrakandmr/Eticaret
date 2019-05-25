using Eticaret.BLL.Abstract;
using Eticaret.Entities.Concrete;
using Eticaret.MvcWEBUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Products(),
                Categories = _categoryService.GetAll()

        };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Products product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", String.Format("Product was successfully added!"));
            }

            return RedirectToAction("Add");
        }

        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories=_categoryService.GetAll()
            };
            return View();
        }

        [HttpPost]
        public ActionResult Update(Products product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", String.Format("Product was successfully updated!"));
            }

            return RedirectToAction("Update");
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", String.Format("Product was successfully deleted!"));
            return RedirectToAction("Index");
        }

    }
}
