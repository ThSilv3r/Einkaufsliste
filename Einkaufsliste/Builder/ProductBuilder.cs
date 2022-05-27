using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class ProductBuilder : IProductBuilder
    {
        private Product product;
        public ProductBuilder()
        {
            product = new Product();
        }
        public void BuildProductId(Guid guid)
        {
            product.Id = guid;
        }

        public void BuildProductName(string name)
        {
            product.Name = name;
        }

        public void BuildProductPrice(Price price)
        {
            product.Price = price;
        }
        public Product GetProduct()
        {
            return product;
        }
    }
}
