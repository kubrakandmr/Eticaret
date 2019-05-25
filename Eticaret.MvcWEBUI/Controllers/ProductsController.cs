using Eticaret.BLL.Abstract;
using Eticaret.MvcWEBUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Controllers
{
    public class ProductsController : Controller
    {
        //ürünleri getirmek için BLL katmanından ProductManager ı çağırmamız lazım.
        //ProductManager ın soyutu IProductService i çağırıyoruz.

        public IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page = 1, int category=0)
        {
            int pageSize = 10; //her sayfada 10 tane ürün.
            var products = _productService.GetByCategory(category);
            /* var products = _productService.GetAll(); *///tüm ürünleri listeledik.
                                                          //view de direk products döndürebilirdik.
                                                          //Ama aynı sayfada sonradan başka şeylerde görmek isteyebilir.
                                                          //Bunun için viewmodel oluşturuyoruz.
                                                          //sayfaya başka şeyler eklemek istediğimizde view model içinde istediğimizi çağırıcaz.
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                //page diyelim 3. 3 - 1 = 2 2 * 10 = 20 yani ilk 20 ürünü atla.

                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };
           
        return View(model);
           
        }

      
    }
}

