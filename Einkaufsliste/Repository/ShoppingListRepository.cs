using Einkaufsliste.Domaine.Aggregate;
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
        ShoppingList addFood(ShoppingList list, Guid foodId);
        //void addFood(string listName);
        ShoppingList addProduct(ShoppingList list, Guid productId);
        //void addProduct(string listName);
    }
}
