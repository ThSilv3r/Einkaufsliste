using Einkaufsliste.Adapters;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class ProductView
    {
        string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Products.json";
        ProductOutputs productOutputs = new ProductOutputs();
        ProductPlugin productPlugin = new ProductPlugin();
        ProductViewAdapter productAdapter = new ProductViewAdapter();
        UserInputs userInputs = new UserInputs();
        public void createProduct()
        {
            Price price = new Price();
            double priceDouble;
            string name;
            List<Product> products = productPlugin.getProductList();

             
            name = userInputs.getName();

            price = userInputs.getPrice();


            Product product = productAdapter.createProduct(name, price);
            products.Add(product);
            productPlugin.saveProductList(products);
        }


        public void readProductList(List<Product> products = null)
        {
            if (products == null)
            {
                products = productPlugin.getProductList();
            }
            foreach (Product product in products)
            {
                productOutputs.writeProduct(product);
            }
        }
    }
}
