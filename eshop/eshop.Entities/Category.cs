﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation Property
        public IList<Product> Products { get; set; }
    }
}
