using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Einkaufsliste
{
    public class ProductManager : ProductRepository
    {
        string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Products.json";
        ReadValuesRepository readValues;
        OutputValuesRepository outputValues;
        ProductOutputRepository productOutputs;
        ProductPluginRepository productPlugin;
        public ProductManager(ProductPluginRepository productPlugin, ReadValuesRepository readValues, 
            OutputValuesRepository outputValues, ProductOutputRepository productOutput)
        {
            this.productOutputs = productOutput;
            this.readValues = readValues;
            this.outputValues = outputValues;
            this.productPlugin = productPlugin;
        }
        public void createProduct(string name)
        {
            Price price = new Price();
            double priceDouble;
            FluentProduct product = new FluentProduct();
            List<Product> products = productPlugin.getProductList();

            productOutputs.enterPriceMessage();
            priceDouble = readValues.ReadDouble();
            price.price = priceDouble;

            if(name != null)
            {
                product.NameOfProduct(name).PriceOfProduct(price).IdOfTheProduct(Guid.NewGuid());
                Console.WriteLine(product);

                products.Add(product.product);
                productPlugin.saveProductList(products);
            }
        }

        
        public void readProductList()
        {
            List<Product> products = productPlugin.getProductList();
            foreach (Product product in products)
            {
                productOutputs.writeProduct(product);
            }
        }

        public Product getById(Guid guid)
        {
            List<Product> products = productPlugin.getProductList();
            Product product = products.Find(x => x.Id == guid);
            return product;
        }
    }
}
