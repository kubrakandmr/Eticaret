using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class CartLine
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}
