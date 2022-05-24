using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface ProductRepository
    {
        void createProduct(string name);
        void readProductList(List<Product> products = null);
        Product getById(Guid guid);
    }
}
