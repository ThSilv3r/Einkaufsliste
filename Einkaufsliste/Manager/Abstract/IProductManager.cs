using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Manager.Abstract
{
    internal interface IProductManager
    {
        void createProduct();
        void deleteProduct(string name);
        List<Product> getProductList();
        void saveProductList(List<Product> producs);
        void readProductList();
    }
}
