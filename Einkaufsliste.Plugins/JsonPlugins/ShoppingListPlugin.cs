using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins
{
    public class ShoppingListPlugin : ShoppingListPluginRepository
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
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

                if (shoppingList.Id == null)
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    int count = dir.GetFiles().Length;
                    shoppingList.Id = Guid.NewGuid();

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
    }
}
