using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class CommandManager
    {
        public void foodCommands(string[] args)
        {
            FoodManager foodManager = new FoodManager();
            if (args[0] == "createFood")
            {
                //if (args[1] == "test")
                //{
                //    Console.WriteLine("This is a test");
                //    return;
                //}
                foodManager.createFood();
            }
            else if(args[0] == "deleteFood")
            {
                foodManager.deleteFood(args[1]);
            }
            else if (args[0] == "getFoodList")
            {
                foodManager.readFoodList();
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
        public void listCommands(string[] args)
        {
            ShoppingListManager listManager = new ShoppingListManager();
            if (args[0] == "createShoppingList")
            {
                //if (args[1] == "test")
                //{
                //    Console.WriteLine("This is a test");
                //    return;
                //}
                Console.WriteLine("Creating ShoppingList");
                listManager.createShoppingList();
            }
            else if (args[0] == "getShoppingList")
            {
                listManager.readShoppingList(args[1]);
            }
            else if (args[0] == "deleteShoppingList")
            {
                listManager.deleteShoppingList(args[1]);
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
                Console.WriteLine("Kein echter Befehl");
            }
        }
        public void productCommand(string[] args)
        {
            ProductManager productManager = new ProductManager();
            if (args[0] == "createProduct")
            {
                //if (args[1] == "test")
                //{
                //    Console.WriteLine("This is a test");
                //    return;
                //}
                productManager.createProduct();
            }
            else if (args[0] == "deleteProduct")
            {
                productManager.deleteProduct(args[1]);
            }
            else if (args[0] == "getProductList")
            {
                productManager.readProductList();
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
        public void recipeCommand(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            if (args[0] == "createRecipe")
            {
                //if (args[1] == "test")
                //{
                //    Console.WriteLine("This is a test");
                //    return;
                //}
                recipeManager.createRecipe();

            }
            else if (args[0] == "getRecipe")
            {
                recipeManager.readRecipe(args[1]);
            }
            else if (args[0] == "deleteRecipe")
            {
                recipeManager.deleteRecipe(args[1]);
            }
            else if (args[0] == "addRecipeToList")
            {
                //if (args[1] == "test")
                //{
                //    Console.WriteLine("This is a test");
                //    return;
                //}
                recipeManager.addToShoppingList();
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
