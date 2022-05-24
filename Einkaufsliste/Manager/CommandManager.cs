
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class CommandManager
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
        public void foodCommands(string[] args)
        {
            FoodRepository foodManager = new FoodManager(foodPlugin, foodOutputs, outputValues, readValues);
            if (args[0] == "createFood")
            {
                foodManager.createFood(args[1]);
            }
            else if(args[0] == "deleteFood")
            {
                foodPlugin.deleteFood(args[1]);
            }
            else if (args[0] == "getFoodList")
            {
                foodManager.readFoodList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void listCommands(string[] args)
        {
            FoodRepository foodManager = new FoodManager(foodPlugin, foodOutputs, outputValues, readValues);
            ShoppingListRepository listManager = new ShoppingListManager(listPlugin, outputValues, productOutputs, 
                foodOutputs, shoppingListOutputs, readValues, productPlugin, foodManager);
            if (args[0] == "createShoppingList")
            {
                Console.WriteLine("Creating ShoppingList");
                listManager.createShoppingList(args[1]);
            }
            else if (args[0] == "getShoppingList")
            {
                listManager.readShoppingList(args[1]);
            }
            else if (args[0] == "deleteShoppingList")
            {
                listPlugin.deleteShoppingList(args[1]);
            }
            else if (args[0] == "addProductToShoppingList")
            {
                listManager.addProduct(args[1]);
            }
            else if (args[0] == "addFoodToShoppingList")
            {
                listManager.addFood(args[1]);
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void productCommand(string[] args)
        {
            ProductRepository productManager = new ProductManager(productPlugin, readValues, outputValues, productOutputs);
            if (args[0] == "createProduct")
            {
                productManager.createProduct(args[1]);
            }
            else if (args[0] == "deleteProduct")
            {
                productPlugin.deleteProduct(args[1]);
            }
            else if (args[0] == "getProductList")
            {
                productManager.readProductList();
            }
            else
            {
                //Console.WriteLine("Kein echter Befehl");
            }
        }
        public void recipeCommand(string[] args)
        {
            RecipeRepository recipeManager = new RecipeManager(recipePlugin, readValues, listPlugin, foodPlugin, outputValues, recipeOutputs, foodOutputs);
            if (args[0] == "createRecipe")
            {
                recipeManager.createRecipe(args[1]);

            }
            else if (args[0] == "getRecipe")
            {
                recipeManager.readRecipe(args[1]);
            }
            else if (args[0] == "deleteRecipe")
            {
                recipePlugin.deleteRecipe(args[1]);
            }
            else if (args[0] == "addRecipeToList")
            {
                recipeManager.addToShoppingList(args[1], args[2]);
            }
            else
            {
               //Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
