﻿using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.ViewModels
{
    public class CategoryListViewModel
    {
        public List<Categories> Categories { get;internal set; }
        public int CurrentCategory { get;internal set; }
    }
}
