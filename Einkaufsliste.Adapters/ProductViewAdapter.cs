using Einkaufsliste.Adapters.Interfaces;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters
{
    public class ProductViewAdapter : IProductAdapter
    {
        ProductManager productManager = new ProductManager();
        public Product createProduct(string name, Price price)
        {
            return productManager.createProduct(name, price);
        }
        public Product getProductById(Guid productId, List<Product> products)
        {
            return productManager.getProductById(productId, products);
        }
    }
}
