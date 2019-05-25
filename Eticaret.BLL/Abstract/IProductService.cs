using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.BLL.Abstract
{
    public interface IProductService
    {
        List<Products> GetAll();
        List<Products> GetByCategory(int categoryId);
        void Add(Products product);
        void Update(Products product);
        void Delete(int productId);
        Products GetById(int productId);
    }

}
