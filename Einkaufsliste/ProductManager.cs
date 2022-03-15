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
        public void createProduct()
        {
            string name;
            double price;
            string priceString;
            Product product = new Product();
            List<Product> products = getProductList();
            
            Console.WriteLine("Gib den Produktnamen ein:");
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Bitte Versuche es erneut mit einem Namen.");
                return;
            }

            product.Name = name;

            Console.WriteLine("Gib den Preis ein:");
            priceString = Console.ReadLine();
            //try
            //{
                price = Convert.ToDouble(priceString);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Bitte nur Zahlen eingeben:");
            //    priceString = Console.ReadLine();
            //    if(priceString == null)
            //    {
            //        price = 0;
            //    }
            //    price = Convert.ToDouble(priceString);
            //}

            product.Price = price;

            Console.WriteLine(product);

            products.Add(product);
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
