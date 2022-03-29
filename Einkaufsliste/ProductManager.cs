using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class ProductManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Products.json";
        private ReadValues readValues = new ReadValues();
        public void createProduct()
        {
            string name;
            double price;
            string priceString;
            FluentProduct product = new FluentProduct();
            List<Product> products = getProductList();
            
            Console.WriteLine("Gib den Produktnamen ein:");
            name = readValues.ReadString();

            Console.WriteLine("Gib den Preis ein:");
            price = readValues.ReadDouble();

            product.NameOfTheProduct(name).PriceOfTheProduct(price);

            Console.WriteLine(product);

            products.Add(product.product);
            saveProductList(products);
        }

        public void deleteProduct(string name)
        {
            List<Product> products = getProductList();
            Product product = products.Find(x => x.Name == name);

            products.Remove(product);

            saveProductList(products);
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
        public void readProductList()
        {
            List<Product> products = getProductList();
            foreach (Product product in products)
            {
                Console.WriteLine("Name: " + product.Name + " Preis: " + product.Price);
            }
        }

        public void saveProductList(List<Product> products)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonProducts = JsonSerializer.Serialize(products);
                streamWriter.Write(jsonProducts);
            }
        }
    }
}
