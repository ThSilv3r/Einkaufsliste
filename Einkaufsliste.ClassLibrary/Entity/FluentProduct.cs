using Einkaufsliste.ClassLibrary.ValueObject;
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
        public FluentProduct IdOfTheProduct(Guid guid)
        {
            product.Id = guid;
            return this;
        }

        public FluentProduct NameOfProduct(string name)
        {
            product.Name = name;
            return this;
        }

        public FluentProduct PriceOfProduct(Price price)
        {
            product.Price = price;
            return this;    
        }
    }
}
