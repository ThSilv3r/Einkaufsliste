using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface ShoppingListRepository
    {
        void createShoppingList(string name);
        void readShoppingList(string name);
        void addFood(string listName);
        void addProduct(string listName);
    }
}
