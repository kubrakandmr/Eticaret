using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Entities.Concrete;
using Eticaret.MvcWEBUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace Eticaret.MvcWEBUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        //session nesnesi controller odaklıdır.
        //o yüzden sadece controllerlarda default olarak kullanabiliriz.
        //controller olmadığı için bununla session çağırıyoruz.
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null) //sepette yoksa.
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart()); //yoksa set et. ilk kez oluştur.
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
