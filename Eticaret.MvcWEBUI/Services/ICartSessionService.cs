using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart(); //sessiondan okumak için.
        void SetCart(Cart cart); //sessiona yazmak için.
    }
}
