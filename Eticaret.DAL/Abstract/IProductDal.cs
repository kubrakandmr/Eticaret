using Eticaret.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DAL.Abstract
{
    public interface IProductDal : IEntityRepository<Products>
    {
        //Custom Operations
        //heryerde geçerli değil sadece productta lazım.
    }
}
