using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class RecipeOutputs : RecipeOutputRepository
    {
        public void enterListNameMessage()
        {
            Console.WriteLine("Enter the name of the shoppinglist.");
        }
        public void enterRecipeNameMessage()
        {
            Console.WriteLine("Enter the recipe name.");
        }
        public void foodsMessage()
        {
            Console.WriteLine("Foods:");
        }
        public void enterDescriptionMessage()
        {
            Console.WriteLine("Please enter the description:");
        }
    }
}
