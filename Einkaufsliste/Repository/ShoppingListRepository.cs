using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface ShoppingListRepository
    {
        //void createShoppingList(string name);
        ShoppingList createShoppingList(string name);
        //void readShoppingList(string name);
        ShoppingList addFood(ShoppingList list, Food food);
        //void addFood(string listName);
        ShoppingList addProduct(ShoppingList list, Product product);
        //void addProduct(string listName);
    }
}
