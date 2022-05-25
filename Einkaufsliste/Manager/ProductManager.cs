using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class ProductManager : ProductRepository
    {
        //string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Products.json";
        //ReadValuesRepository readValues;
        //OutputValuesRepository outputValues;
        //ProductOutputRepository productOutputs;
        //ProductPluginRepository productPlugin;
        //public ProductManager(ProductPluginRepository productPlugin, ReadValuesRepository readValues, 
        //    OutputValuesRepository outputValues, ProductOutputRepository productOutput)
        //{
        //    this.productOutputs = productOutput;
        //    this.readValues = readValues;
        //    this.outputValues = outputValues;
        //    this.productPlugin = productPlugin;
        //}
        public Product createProduct(string name, Price price)
        {
            //Price price = new Price();
            double priceDouble;
            Product product = new Product();
            ProductBuilder productBuilder = new ProductBuilder();
            ProductEngineer productEngineer = new ProductEngineer(productBuilder);
            //List<Product> products = productPlugin.getProductList();

            //productOutputs.enterPriceMessage();
            //priceDouble = readValues.ReadDouble();
            //price.price = priceDouble;

            if(name != null)
            {
                productEngineer.constructProduct(name, price);
                product = productEngineer.GetProduct();
                //productOutputs.writeProduct(product);

                //products.Add(product);
                //productPlugin.saveProductList(products);
            }
            return product;
        }

        
        //public void readProductList(List<Product> products = null)
        //{
        //    if(products == null)
        //    {
        //        products = productPlugin.getProductList();
        //    }
        //    foreach (Product product in products)
        //    {
        //        productOutputs.writeProduct(product);
        //    }
        //}

        public Product getById(Guid guid, List<Product> products)
        {
            //List<Product> products = productPlugin.getProductList();
            Product product = products.Find(x => x.Id == guid);
            return product;
        }
    }
}
