using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters.Interfaces
{
    public interface IProductAdapter
    {
        Product createProduct(string name, Price price); 
        Product getProductById(Guid productId, List<Product> products);
    }
}
