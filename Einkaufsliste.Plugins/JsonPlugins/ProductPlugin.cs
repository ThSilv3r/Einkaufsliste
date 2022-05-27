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
        public void saveProductList(List<Product> products)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Products.json";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonProducts = JsonSerializer.Serialize(products);
                streamWriter.Write(jsonProducts);
            }
        }
        public void deleteProduct(string name = null)
        {
            ProductOutputs output = new ProductOutputs();
            OutputValues outputValues = new OutputValues();
            List<Product> products = getProductList();
            foreach (var prod in products)
            {
                output.writeProduct(prod);
            }
            if (name == null)
            {
                ReadValues readValues = new ReadValues();
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
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
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Products.json";
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
