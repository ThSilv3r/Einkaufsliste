using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class FluentProduct
    {
        public Product product = new Product();

        public FluentProduct NameOfTheProduct(string name)
        {
            product.Name = name;
            return this;
        }

        public FluentProduct PriceOfTheProduct(double price)
        {
            product.Price = price;
            return this;    
        }
    }
}
