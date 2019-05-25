using Eticaret.BLL.Abstract;
using Eticaret.DAL.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.BLL.Concrete
{
    public class ProductManager :IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Products product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Products { ProductId = productId });
        }

        public List<Products> GetAll()
        {
            //EFProductsDal productsDal = new EFProductsDal();
            //return productsDal.GetList();
            //burda new leyerek çağırabiliriz çalışır
            //ancak SOLİD kurallarına göre üst katman alt katmanı newleyemez.
            //kötü bir kullanımdır.Yukardaki Iproductdal kullanıyoruz.
            return _productDal.GetList();
        }

        public List<Products> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId==0);
            // categoryId == 0 yazmamızın sebebi. GetById dediğimizde herhangi bir category 
            //girilmezse bize bütün ürünleri yinede listelesin
        }

        public void Update(Products product)
        {
            _productDal.Update(product);
        }

        public Products GetById(int productId)
        {
           return _productDal.Get(p => p.ProductId == productId);
        }
    }
}
