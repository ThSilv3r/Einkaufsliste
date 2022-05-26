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
        public ShoppingList addFoodToShoppingList(ShoppingList list, Guid foodId)
        {
            return listManager.addFoodToShoppingList(list, foodId);
        }
        public ShoppingList addProductToShoppingList(ShoppingList list, Guid productId)
        {
            return listManager.addProductToShoppingList(list, productId);
        }
    }
}
