using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Json
{
    public interface ShoppingListPluginRepository
    {
        void saveShoppingList(ShoppingList shoppingList);
        void deleteShoppingList(string name);
        ShoppingList getShoppingList(string name);
    }
}
