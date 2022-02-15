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

            DirectoryInfo dir = new DirectoryInfo(path);
            int count = dir.GetFiles().Length;
            shoppingList.Id = count;

            Console.WriteLine("Gib den Name der Einkaufsliste ein");
            name = Console.ReadLine();
            shoppingList.Name = name;

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
                string jsonFoods = JsonSerializer.Serialize(shoppingList);
                streamWriter.Write(jsonFoods);
            }
        }
        public void deleteShoppingList(string name)
        {
            File.Delete(path + name + ".json");
        }
    }
}
