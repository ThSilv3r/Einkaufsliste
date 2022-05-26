using Einkaufsliste.Plugins.Repository.Views;
using Einkaufsliste.Plugins.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Test.Application.Command
{
    public class CommandViewMock : ICommandView
    {
        public void foodCommands(string command)
        {
            if (command == "createFood")
            {
                Console.WriteLine("true");
            }
            else if (command == "deleteFood")
            {
                Console.WriteLine("true");
            }
            else if (command == "getFoodList")
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
        public void listCommands(string command)
        {
            if (command == "createShoppingList")
            {
                Console.WriteLine("true");
            }
            else if (command == "getShoppingList")
            {
                Console.WriteLine("true");
            }
            else if (command == "deleteShoppingList")
            {
                Console.WriteLine("true");
            }
            else if (command == "addProductToShoppingList")
            {
                Console.WriteLine("true");
            }
            else if (command == "addFoodToShoppingList")
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }

        public void productCommand(string command)
        {
            if (command == "createProduct")
            {
                Console.WriteLine("true");
            }
            else if (command == "deleteProduct")
            {
                Console.WriteLine("true");
            }
            else if (command == "getProductList")
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }

        public void recipeCommand(string command)
        {
            if (command == "createRecipe")
            {
                Console.WriteLine("true");

            }
            else if (command == "getRecipe")
            {
                Console.WriteLine("true");
            }
            else if (command == "deleteRecipe")
            {
                Console.WriteLine("true");
            }
            else if (command == "addRecipeToList")
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
