using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface ProductRepository
    {
        Product createProduct(string name, Price price);
        Product getById(Guid guid, List<Product> products);
    }
}
