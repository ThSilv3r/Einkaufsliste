using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins
{
    public class ProductPlugin : ProductPluginRepository
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Products.json";
        public void saveProductList(List<Product> products)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonProducts = JsonSerializer.Serialize(products);
                streamWriter.Write(jsonProducts);
            }
        }
        public void deleteProduct(string name = null)
        {
            OutputValues outputValues = new OutputValues();
            if (name == null)
            {
                ReadValues readValues = new ReadValues();
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
            List<Product> products = getProductList();
            if (name != "")
            {
                Product product = products.Find(x => x.Name == name);

                products.Remove(product);

                saveProductList(products);
                Console.WriteLine("Deleted: " + product.Name);
            }
            else
            {
                outputValues.nameWarning();
            }
        }

        public List<Product> getProductList()
        {
            List<Product> products = new List<Product>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string productsString = streamReader.ReadToEnd();
                if (productsString != "")
                {
                    products = JsonSerializer.Deserialize<List<Product>>(productsString);
                }
            }

            return products;
        }
    }
}
