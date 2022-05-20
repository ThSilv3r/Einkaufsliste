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
        private ReadValues readValues = new ReadValues();
        public void createShoppingList()
        {
            FluentShoppingList shoppingList = new FluentShoppingList();
            List<Food> foods = new List<Food>();
            List<Product> products = new List<Product>();
            string name = "List";

            Console.WriteLine("Gib den Name der Einkaufsliste ein");
            name = readValues.ReadString();

            if(name != null)
            {
                shoppingList.NameOfTheList(name).FoodsOfTheList(foods).ProductsOfTheList(products);
                Console.WriteLine(shoppingList);
                saveShoppingList(shoppingList.shoppingList);
            }
        }
        public void readShoppingList(string name)
        {
            ShoppingList shoppingList = getShoppingList(name);
            Console.WriteLine("Produkte:");
            foreach (Product product in shoppingList.Products)
            {
                Console.WriteLine("Name: " + product.Name + " Preis: " + product.Price);
            }

            Console.WriteLine("Lebensmittel:");
            foreach(Food food in shoppingList.Foods)
            {
                Console.WriteLine("Name: " + food.Name + " Preis: " + food.Price + " Gewicht: " + food.Weight);
            }
        }

        public ShoppingList getShoppingList(string name)
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
            ShoppingList list = getShoppingList(listName);
            int count = 0;
            FoodManager foodManager = new FoodManager();
            string food = "";
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodManager.getFoodList();

            foods.AddRange(list.Foods);
            Console.WriteLine("Choose the food:");
            if (foodList.Count == 0)
            {
                Console.WriteLine("Please add foods to the food list first.");
            }
            else
            {
                foreach (var fd in foodList)
                {
                    Console.WriteLine(fd.Name);
                }
                while (food != null)
                {
                    food = readValues.ReadString();
                    if (food != null)
                    {
                        var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                        foods.Add(addedFood);
                        Console.WriteLine("Enter nothing to close.");
                    }
                }
            }

            list.Foods = foods;
            saveShoppingList(list);
        }

        public void addProduct(string listName)
        {
            ShoppingList list = getShoppingList(listName);
            int count = 0;
            ProductManager productManager = new ProductManager();
            Product productItem = new Product();
            string product = "";
            List<Product> products = new List<Product>();
            List<Product> productList = productManager.getProductList();
            products.AddRange(list.Products);
            Console.WriteLine("Choose the product:");

            if(productList.Count == 0)
            {
                Console.WriteLine("Please add products to the porduct list first.");
            }
            else
            {
                foreach (var pr in productList)
                {
                    Console.WriteLine(pr.Name);
                }
                while (product != null)
                {
                    product = readValues.ReadString();
                    if (product != null)
                    {
                        var addedProduct = productList.FirstOrDefault(f => f.Name == product);
                        products.Add(addedProduct);
                        Console.WriteLine("Enter nothing to close.");
                    }
                }
            }


            list.Products = products;
            saveShoppingList(list);
        }
    }
}
