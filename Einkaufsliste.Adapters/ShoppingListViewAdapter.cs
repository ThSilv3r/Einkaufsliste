using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters
{
    public class ShoppingListAdapter
    {
        ShoppingListManager listManager = new ShoppingListManager();
        public ShoppingList createShoppingList(string name)
        {
            return listManager.createShoppingList(name);
        }
        public ShoppingList addFood(ShoppingList list, Guid foodId)
        {
            return listManager.addFood(list, foodId);
        }
        public ShoppingList addProduct(ShoppingList list, Guid productId)
        {
            return listManager.addProduct(list, productId);
        }
    }
}
