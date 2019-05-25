using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>(); //hiçbir ürün yokken null hatası almamak için.
        }
        public List<CartLine>CartLines { get; set; }

        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}
