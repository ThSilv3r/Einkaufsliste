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
                foodManager.createFood();
            }
            else if(args[0] == "deleteFood")
            {
                foodManager.deleteFood(args[1]);
            }
            else if (args[0] == "getFoodList")
            {
                foodManager.getFoodList();
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
                Console.WriteLine("Creating ShoppingList");
                listManager.createShoppingList();
            }
            else if (args[0] == "getShoppingList")
            {
                listManager.GetShoppingList(args[1]);
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
                productManager.createProduct();
            }
            else if (args[0] == "deleteProduct")
            {
                productManager.deleteProduct(args[1]);
            }
            else if (args[0] == "getProductList")
            {
                productManager.getProductList();
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
                recipeManager.createRecipe();

            }
            else if (args[0] == "GetRecipe")
            {
                recipeManager.GetRecipe(args[1]);
            }
            else if (args[0] == "deleteRecipe")
            {
                recipeManager.deleteRecipe(args[1]);
            }
            else if (args[0] == "addRecipeToList")
            {
                recipeManager.addToShoppingList();
            }
            else
            {
                Console.WriteLine("Kein echter Befehl");
            }
        }
    }
}
