using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Json
{
    public interface ProductPluginRepository
    {
        void saveProductList(List<Product> products);
        void deleteProduct(string name);
        List<Product> getProductList();
    }
}
