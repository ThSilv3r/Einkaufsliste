using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Manager.Abstract
{
    internal interface IShoppingListManager
    {
        void createShoppingList();
        void readShoppingList(string name);
        ShoppingList getShoppingList(string name);
        void saveShoppingList(ShoppingList shoppingList);
        void deleteShoppingList(string name);
        void addFood(string listName);
        void addProduct(string listName);
    }
}
