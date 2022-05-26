using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class ShoppingListOutputs : IShoppingListOutput
    {
        public void foodsMessage()
        {
            Console.WriteLine("Foods:");
        }
        public void productsMessage()
        {
            Console.WriteLine("Products:");
        }
        public void createListMessage()
        {
            Console.WriteLine("Created ShoppingList");
        }
    }
}
