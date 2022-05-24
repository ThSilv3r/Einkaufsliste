using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Einkaufsliste
{
    public class ShoppingListManager : ShoppingListRepository
    {
        OutputValuesRepository outputValues;
        ProductOutputRepository productOutputs;
        FoodOutputRepository foodOutputs;
        ShoppingListOutputRepository shoppingListOutputs;
        ReadValuesRepository readValues;
        ShoppingListPluginRepository shoppingListPlugin;
        ProductPluginRepository productPlugin;
        FoodRepository foodManager;

        public ShoppingListManager(ShoppingListPluginRepository shoppingListPlugin, OutputValuesRepository outputValues,
            ProductOutputRepository productOutput, FoodOutputRepository foodOutput,
            ShoppingListOutputRepository shoppingListOutput, ReadValuesRepository readValues,
            ProductPluginRepository productPlugin, FoodRepository foodManager)
        {
            this.shoppingListPlugin = shoppingListPlugin;
            this.productOutputs = productOutput;
            this.shoppingListOutputs = shoppingListOutput;
            this.foodOutputs = foodOutput;
            this.readValues = readValues;
            this.outputValues = outputValues;
            this.productOutputs = productOutput;
            this.productPlugin = productPlugin;
            this.foodManager = foodManager;
        }
        public void createShoppingList(string name)
        {
            ShoppingListBuilder shoppingListBuilder = new ShoppingListBuilder();
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();

            if(name != null && name != "")
            {
                shoppingListBuilder.BuildName(name);
                shoppingListBuilder.BuildFood(foods);
                shoppingListBuilder.BuildProducts(products);
                shoppingListBuilder.BuildId(Guid.NewGuid());
                ShoppingList shoppingList = shoppingListBuilder.GetShoppingList();

                shoppingListPlugin.saveShoppingList(shoppingList);
            }
        }
        public void readShoppingList(string name)
        {
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
            shoppingListOutputs.productsMessage();
            foreach (Product product in shoppingList.Products)
            {
                productOutputs.writeProduct(product);
            }

            shoppingListOutputs.foodsMessage();
            foreach(Food food in shoppingList.Foods)
            {
                foodOutputs.writeFood(food);
            }
        }

        public void addFood(string listName)
        {
            ShoppingList list = shoppingListPlugin.getShoppingList(listName);
            FoodPlugin foodPlugin = new FoodPlugin();
            string food = "";
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();

            foods.AddRange(list.Foods);
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
                        foods.Add(addedFood);
                        outputValues.closeEntryMessage();
                    }
                }
            }

            list.Foods = foods;
            shoppingListPlugin.saveShoppingList(list);
        }

        public void addProduct(string listName)
        {
            ShoppingList list = shoppingListPlugin.getShoppingList(listName);
            Product productItem = new Product();
            string product = "";
            List<Product> products = new List<Product>();
            List<Product> productList = productPlugin.getProductList();
            products.AddRange(list.Products);
            productOutputs.chooseProductMessage();

            if(productList.Count == 0)
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
                        products.Add(addedProduct);
                        outputValues.closeEntryMessage();
                    }
                }
            }


            list.Products = products;
            shoppingListPlugin.saveShoppingList(list);
        }
    }
}
