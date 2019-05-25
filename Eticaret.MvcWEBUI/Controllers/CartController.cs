using Eticaret.BLL.Abstract;
using Eticaret.Entities.Concrete;
using Eticaret.MvcWEBUI.Services;
using Eticaret.MvcWEBUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService; 
        private ICartService _cartService; 
        private IProductService _productService; 

        public CartController(ICartSessionService cartSessionService,ICartService cartService,IProductService productService)
        {
            _cartService = cartService;
            _cartSessionService = cartSessionService;
            _productService = productService;
        }

        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);
            //ekledikten sonra tekrar sessiona atmam gerekiyor kaybolmaması için.

            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your product,{0},was successfully added to the cart!",productToBeAdded.ProductName));
            return RedirectToAction("Index", "Products");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);

        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();//önce sessionı çektik
            _cartService.RemoveFromCart(cart, productId);//sessiondaki bilgileri productId olanı sildik.
            _cartSessionService.SetCart(cart);//cart nesnesini tekrardan sessiona yazdık.
            TempData.Add("message", String.Format("Your product was successfully removed to the cart!"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank you {0},you order is in process",shippingDetails.FirstName));
            return View();
        }
    }
}
