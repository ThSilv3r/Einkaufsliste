using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class ProductOutputs : IProductOutput
    {
        public void enterPriceMessage()
        {
            Console.WriteLine("Please enter the Price of the product.");
        }
        public void writeProduct(Product product)
        {
            Console.WriteLine("Name: " + product.Name + " Price: " + product.Price.price);
        }
        public void chooseProductMessage()
        {
            Console.WriteLine("Choose the product:");
        }
        public void noProductWarning()
        {
            Console.WriteLine("Please add products to the product list first.");
        }
    }
}
