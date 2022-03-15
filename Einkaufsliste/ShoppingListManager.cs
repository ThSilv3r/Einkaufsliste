using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class ShoppingListManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
        public void createShoppingList()
        {
            ShoppingList shoppingList = new ShoppingList();
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();
            string name = "List";

            Console.WriteLine("Gib den Name der Einkaufsliste ein");
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Bitte Versuche es erneut mit einem Namen.");
                return;
            }

            shoppingList.Name = name;
            shoppingList.Products = products;
            shoppingList.Foods = foods;
            Console.WriteLine(shoppingList);
            saveShoppingList(shoppingList);
        }
        public ShoppingList GetShoppingList(string name)
        {
            ShoppingList shoppingList = new ShoppingList();

            using (StreamReader streamReader = new StreamReader(path + name + ".json"))
            {
                string shoppingListString = streamReader.ReadToEnd();
                if (shoppingListString != "")
                {
                    shoppingList = JsonSerializer.Deserialize<ShoppingList>(shoppingListString);
                }
            }

            return shoppingList;
        }
        public void saveShoppingList(ShoppingList shoppingList)
        {
            using (StreamWriter streamWriter = new StreamWriter(path + shoppingList.Name + ".json"))
            {
                if(shoppingList.Id == 0)
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    int count = dir.GetFiles().Length;
                    shoppingList.Id = count + 1;

                    string jsonList = JsonSerializer.Serialize(shoppingList);
                    streamWriter.Write(jsonList);
                }
                else
                {
                    string jsonList = JsonSerializer.Serialize(shoppingList);
                    streamWriter.Write(jsonList);
                }
            }
        }
        public void deleteShoppingList(string name)
        {
            File.Delete(path + name + ".json");
        }

        public void addFood(string listName)
        {
            ShoppingList list = GetShoppingList(listName);
            int count = 0;
            FoodManager foodManager = new FoodManager();
            Food foodItem = new Food();
            List<Food> foodList = foodManager.getFoodList();
            foreach(Food food in foodList)
            {
                Console.WriteLine(count + ".:" + food.Name);
            }
            Console.WriteLine("Please enter the food name:");
            string foodName = Console.ReadLine();
            foodItem = foodList.FirstOrDefault(x => x.Name == foodName);

            list.Foods.Add(foodItem);
            saveShoppingList(list);
        }

        public void addProduct(string listName)
        {
            ShoppingList list = GetShoppingList(listName);
            int count = 0;
            ProductManager productManager = new ProductManager();
            Product productItem = new Product();
            List<Product> productList = productManager.getProductList();
            foreach (Product product in productList)
            {
                Console.WriteLine(count + ".:" + product.Name);
            }
            Console.WriteLine("Please enter the food name:");
            string foodName = Console.ReadLine();
            productItem = productList.FirstOrDefault(x => x.Name == foodName);

            list.Products.Add(productItem);
            saveShoppingList(list);
        }
    }
}
