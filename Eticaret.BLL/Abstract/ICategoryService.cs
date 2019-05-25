using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.BLL.Abstract
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
    }
}
