using Einkaufsliste.Adapters;
using Einkaufsliste.Adapters.Interfaces;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Test.Adapter
{
    public class ProductViewAdapterMock : IProductAdapter
    {
        public Product createProduct(string name, Price price)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };
            return product;
        }
        public Product getProductById(Guid productId, List<Product> products)
        {
            Product product = new Product
            {
                Id = productId,
                Name = "Test",
                Price = new Price { price = 1}
            };
            return product;
        }
    }
}
