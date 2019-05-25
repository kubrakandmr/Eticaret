using Eticaret.BLL.Abstract;
using Eticaret.DAL.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Categories> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
