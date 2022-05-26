using Einkaufsliste.Plugins.ConsolePlugins;
using Einkaufsliste.Plugins.Repository.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class CommandView : CommandViewRepository
    {
        FoodPlugin foodPlugin = new FoodPlugin();
        ProductPlugin productPlugin = new ProductPlugin();
        ShoppingListPlugin listPlugin = new ShoppingListPlugin();
        RecipePlugin recipePlugin = new RecipePlugin();
        OutputValues outputValues = new OutputValues();
        ReadValues readValues = new ReadValues();
        FoodOutputs foodOutputs = new FoodOutputs();
        ProductOutputs productOutputs = new ProductOutputs();
        ShoppingListOutputs shoppingListOutputs = new ShoppingListOutputs();
        RecipeOutputs recipeOutputs = new RecipeOutputs();
        FoodView foodView;
        ShoppingListView listView;
        RecipeView recipeView;
        ProductView productView;
        public void foodCommands(string command)
        {
            foodView = new FoodView();
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
            foodView = new FoodView();
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
                listView.addProduct();
            }
            else if (command == "addFoodToShoppingList")
            {
                listView.addFood();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void productCommand(string command)
        {
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
                recipeView.addToShoppingList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
