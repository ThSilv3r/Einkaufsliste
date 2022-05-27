using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface IProductManager
    {
        Product createProduct(string name, Price price);
        Product getProductById(Guid guid, List<Product> products);
    }
}
