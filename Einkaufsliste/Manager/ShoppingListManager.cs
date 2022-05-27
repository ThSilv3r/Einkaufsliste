using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class ShoppingListManager : IShoppingListManager
    {
        ShoppingListBuilder shoppingListBuilder;
        ShoppingListEngineer shoppingListEngineer;
        ShoppingList shoppingList;
        public ShoppingList createShoppingList(string name)
        {
            shoppingListBuilder = new ShoppingListBuilder();
            shoppingListEngineer = new ShoppingListEngineer(shoppingListBuilder);
            shoppingList = new ShoppingList();
            List<Guid> foods = new List<Guid>();
            List<Guid> products = new List<Guid>();

            if(name != null && name != "")
            {
                shoppingListEngineer.constructShoppingList(name, products, foods);
                shoppingList = shoppingListEngineer.GetShoppingList();
                return shoppingList;
            }
            return null;
        }

        public ShoppingList addFoodToShoppingList(ShoppingList list, Guid foodId)
        {

            list.Foods.Add(foodId);
            return list;
        }

        public ShoppingList addProductToShoppingList(ShoppingList list, Guid productId)
        {
            list.Products.Add(productId);
            return list;
        }
    }
}
