using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class ShoppingListManager : ShoppingListRepository
    {
        //OutputValuesRepository outputValues;
        //ProductOutputRepository productOutputs;
        //FoodOutputRepository foodOutputs;
        //ShoppingListOutputRepository shoppingListOutputs;
        //ReadValuesRepository readValues;
        //ShoppingListPluginRepository shoppingListPlugin;
        //ProductPluginRepository productPlugin;
        //FoodRepository foodManager;

        //public ShoppingListManager(ShoppingListPluginRepository shoppingListPlugin, OutputValuesRepository outputValues,
        //    ProductOutputRepository productOutput, FoodOutputRepository foodOutput,
        //    ShoppingListOutputRepository shoppingListOutput, ReadValuesRepository readValues,
        //    ProductPluginRepository productPlugin, FoodRepository foodManager)
        //{
        //    this.shoppingListPlugin = shoppingListPlugin;
        //    this.productOutputs = productOutput;
        //    this.shoppingListOutputs = shoppingListOutput;
        //    this.foodOutputs = foodOutput;
        //    this.readValues = readValues;
        //    this.outputValues = outputValues;
        //    this.productOutputs = productOutput;
        //    this.productPlugin = productPlugin;
        //    this.foodManager = foodManager;
        //}
        public ShoppingList createShoppingList(string name)
        {
            ShoppingListBuilder shoppingListBuilder = new ShoppingListBuilder();
            ShoppingListEngineer shoppingListEngineer = new ShoppingListEngineer(shoppingListBuilder);
            ShoppingList shoppingList = new ShoppingList();
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();

            if(name != null && name != "")
            {
                shoppingListEngineer.constructShoppingList(name, products, foods);
                shoppingList = shoppingListEngineer.GetShoppingList();
                return shoppingList;
                //shoppingListPlugin.saveShoppingList(shoppingList);
            }
            return null;
        }
        //public void readShoppingList(string name)
        //{
        //    ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
        //    shoppingListOutputs.productsMessage();
        //    foreach (Product product in shoppingList.Products)
        //    {
        //        productOutputs.writeProduct(product);
        //    }

        //    shoppingListOutputs.foodsMessage();
        //    foreach(Food food in shoppingList.Foods)
        //    {
        //        foodOutputs.writeFood(food);
        //    }
        //}

        public ShoppingList addFood(ShoppingList list, Food food)
        {
            //ShoppingList list = shoppingListPlugin.getShoppingList(listName);
            //FoodPlugin foodPlugin = new FoodPlugin();
            //string food = "";
            //List<Food> foods = new List<Food>();
            //List<Food> foodList = foodPlugin.getFoodList();

            //foods.AddRange(list.Foods);
            //foodOutputs.chooseFoodMessage();
            //if (foodList.Count == 0)
            //{
            //    foodOutputs.noFoodWarning();
            //}
            //else
            //{
            //    foreach (var fd in foodList)
            //    {
            //        foodOutputs.writeFood(fd);
            //    }
            //    while (food != null && food != "q")
            //    {
            //        food = readValues.ReadString();
            //        if (food != null && food != "q")
            //        {
            //            var addedFood = foodList.FirstOrDefault(f => f.Name == food);
            //            foods.Add(addedFood);
            //            outputValues.closeEntryMessage();
            //        }
            //    }
            //}

            list.Foods.Add(food);
            //shoppingListPlugin.saveShoppingList(list);
            return list;
        }

        public ShoppingList addProduct(ShoppingList list, Product product)
        {
            //ShoppingList list = shoppingListPlugin.getShoppingList(listName);
            //Product productItem = new Product();
            //string product = "";
            //List<Product> products = new List<Product>();
            //List<Product> productList = productPlugin.getProductList();
            //products.AddRange(list.Products);
            //productOutputs.chooseProductMessage();

            //if(productList.Count == 0)
            //{
            //    productOutputs.noProductWarning();
            //}
            //else
            //{
            //    foreach (var pr in productList)
            //    {
            //        productOutputs.writeProduct(pr);
            //    }
            //    while (product != null && product != "q")
            //    {
            //        product = readValues.ReadString();
            //        if (product != null && product != "q")
            //        {
            //            var addedProduct = productList.FirstOrDefault(f => f.Name == product);
            //            products.Add(addedProduct);
            //            outputValues.closeEntryMessage();
            //        }
            //    }
            //}


            list.Products.Add(product);
            return list;
        }
    }
}
