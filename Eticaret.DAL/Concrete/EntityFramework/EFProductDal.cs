using Eticaret.DAL.Abstract;
using Eticaret.DataAccess.EntityFramework;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DAL.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityReporsitoryBase<Products, EticaretContext>, IProductDal
    {
    }
}
