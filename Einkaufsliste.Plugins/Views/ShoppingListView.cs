using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Domaine.Aggregate;
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
        UserInputs userInputs = new UserInputs();
        FoodPlugin foodPlugin = new FoodPlugin();
        ProductManager productManager =  new ProductManager();
        public void createShoppingList()
        {
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();
            string name = "";

            name = userInputs.getName();

            ShoppingList shoppingList = shoppingListManager.createShoppingList(name);
            shoppingListPlugin.saveShoppingList(shoppingList);
        }
        public void readShoppingList()
        {
            outputValues.enterNameMessage();
            string name = readValues.ReadString();
            if(name != "")
            {
                ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
                shoppingListOutputs.productsMessage();
                List<Product> products = productPlugin.getProductList();
                List<Food> foods = foodPlugin.getFoodList();
                foreach (Guid productId in shoppingList.Products)
                {
                    Product product = productManager.getById(productId, products);
                    productOutputs.writeProduct(product);
                }

                shoppingListOutputs.foodsMessage();
                foreach (Guid foodId in shoppingList.Foods)
                {
                    Food food = foodManager.getFoodById(foodId, foods);
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

                List<Food> foods = userInputs.chooseFoods(foodList);
                foreach(Food fd in foods)
                {
                    list = shoppingListManager.addFood(list, fd.Id);
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
                            list = shoppingListManager.addProduct(list, addedProduct.Id);
                        }
                        outputValues.closeEntryMessage();
                    }
                }
            }

             
            shoppingListPlugin.saveShoppingList(list);
        }
    }
}
