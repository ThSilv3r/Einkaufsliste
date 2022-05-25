using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class ShoppingListView
    {
        OutputValues outputValues = new OutputValues();
        ProductOutputs productOutputs = new ProductOutputs();
        FoodOutputs foodOutputs = new FoodOutputs();
        ShoppingListOutputs shoppingListOutputs = new ShoppingListOutputs();
        ReadValues readValues = new ReadValues();
        ShoppingListPlugin shoppingListPlugin = new ShoppingListPlugin();
        ProductPlugin productPlugin = new ProductPlugin();
        FoodManager foodManager = new FoodManager();
        ShoppingListManager shoppingListManager = new ShoppingListManager();
        public void createShoppingList()
        {
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();
            string name = "";

            outputValues.enterNameMessage();
            name = readValues.ReadString();

            shoppingListManager.createShoppingList(name);
        }
        public void readShoppingList()
        {
            outputValues.enterNameMessage();
            string name = readValues.ReadString();
            if(name != "")
            {
                ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
                shoppingListOutputs.productsMessage();
                foreach (Product product in shoppingList.Products)
                {
                    productOutputs.writeProduct(product);
                }

                shoppingListOutputs.foodsMessage();
                foreach (Food food in shoppingList.Foods)
                {
                    foodOutputs.writeFood(food);
                }
            }
            else
            {
                outputValues.nameWarning();
            }
        }

        public void addFood(string name = null)
        {
            if (name == null)
            {
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
            ShoppingList list = shoppingListPlugin.getShoppingList(name);
            FoodPlugin foodPlugin = new FoodPlugin();
            string food = "";
            List<Food> foodList = foodPlugin.getFoodList();

            foodOutputs.chooseFoodMessage();
            if (foodList.Count == 0)
            {
                foodOutputs.noFoodWarning();
            }
            else
            {
                foreach (var fd in foodList)
                {
                    foodOutputs.writeFood(fd);
                }
                while (food != null && food != "q")
                {
                    food = readValues.ReadString();
                    if (food != null && food != "q")
                    {
                        var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                        if(food != null)
                        {
                            list = shoppingListManager.addFood(list, addedFood);
                        }
                        outputValues.closeEntryMessage();
                    }
                }
            }

            shoppingListPlugin.saveShoppingList(list);
        }

        public void addProduct(string name = null)
        {
            if (name == null)
            {
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
            ShoppingList list = shoppingListPlugin.getShoppingList(name);
            Product productItem = new Product();
            string product = "";
            List<Product> productList = productPlugin.getProductList();
            productOutputs.chooseProductMessage();

            if (productList.Count == 0)
            {
                productOutputs.noProductWarning();
            }
            else
            {
                foreach (var pr in productList)
                {
                    productOutputs.writeProduct(pr);
                }
                while (product != null && product != "q")
                {
                    product = readValues.ReadString();
                    if (product != null && product != "q")
                    {
                        var addedProduct = productList.FirstOrDefault(f => f.Name == product);
                        if(addedProduct != null)
                        {
                            list = shoppingListManager.addProduct(list, addedProduct);
                        }
                        outputValues.closeEntryMessage();
                    }
                }
            }


            shoppingListPlugin.saveShoppingList(list);
        }
    }
}
