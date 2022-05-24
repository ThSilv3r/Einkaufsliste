﻿using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class ProductEngineer
    {
        private IProductBuilder productBuilder;

        public ProductEngineer(IProductBuilder productBuilder)
        {
            this.productBuilder = productBuilder;
        }

        public Product GetProduct()
        {
            return productBuilder.GetProduct();
        }

        public void constructProduct(string name, Price price)
        {
            this.productBuilder.BuildName(name);
            this.productBuilder.BuildPrice(price);
            this.productBuilder.BuildId(Guid.NewGuid());
        }
    }
}
