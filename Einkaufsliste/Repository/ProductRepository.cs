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
        //    void createProduct(string name);
        //    void readProductList(List<Product> products = null);
        Product getById(Guid guid, List<Product> products);
        //    Product getById(Guid guid);
    }
}
