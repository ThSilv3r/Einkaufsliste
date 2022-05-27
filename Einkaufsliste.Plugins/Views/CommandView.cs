using Einkaufsliste.Plugins.ConsolePlugins;
using Einkaufsliste.Plugins.Repository.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class CommandView : ICommandView
    {
        FoodPlugin foodPlugin;
        ProductPlugin productPlugin;
        ShoppingListPlugin listPlugin;
        RecipePlugin recipePlugin;
        ShoppingListOutputs shoppingListOutputs;
        FoodView foodView;
        ShoppingListView listView;
        RecipeView recipeView;
        ProductView productView;
        public void foodCommands(string command)
        {
            foodView = new FoodView();
            foodPlugin = new FoodPlugin();
            if (command == "createFood")
            {
                foodView.createFood();
            }
            else if (command == "deleteFood")
            {
                foodPlugin.deleteFood();
            }
            else if (command == "getFoodList")
            {
                foodView.readFoodList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void listCommands(string command)
        {
            shoppingListOutputs = new ShoppingListOutputs();
            listPlugin = new ShoppingListPlugin();
            listView = new ShoppingListView();
            if (command == "createShoppingList")
            {
                listView.createShoppingList();
                shoppingListOutputs.createListMessage();
            }
            else if (command == "getShoppingList")
            {
                listView.readShoppingList();
            }
            else if (command == "deleteShoppingList")
            {
                listPlugin.deleteShoppingList();
            }
            else if (command == "addProductToShoppingList")
            {
                listView.addProductToShoppingList();
            }
            else if (command == "addFoodToShoppingList")
            {
                listView.addFoodToShoppingList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void productCommand(string command)
        {
            productPlugin = new ProductPlugin();
            productView = new ProductView();
            if (command == "createProduct")
            {
                productView.createProduct();
            }
            else if (command == "deleteProduct")
            {
                productPlugin.deleteProduct();
            }
            else if (command == "getProductList")
            {
                productView.readProductList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void recipeCommand(string command)
        {
            recipePlugin = new RecipePlugin();
            recipeView = new RecipeView();
            if (command == "createRecipe")
            {
                recipeView.createRecipe();

            }
            else if (command == "getRecipe")
            {
                recipeView.readRecipe();
            }
            else if (command == "deleteRecipe")
            {
                recipePlugin.deleteRecipe();
            }
            else if (command == "addRecipeToList")
            {
                recipeView.addRecipeToShoppingList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
