using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class ShoppingListBuilder : IShoppingListBuilder
    {
        private ShoppingList shoppingList;

        public ShoppingListBuilder()
        {
            shoppingList = new ShoppingList();
        }
        public void BuildName(string name)
        {
            shoppingList.Name = name;
        }
        public void BuildFood(List<Guid> foodIds)
        {
            shoppingList.Foods = foodIds;
        }
        public void BuildProducts(List<Guid> productIds)
        {
            shoppingList.Products = productIds;
        }
        public void BuildId(Guid guid)
        {
            shoppingList.Id = guid;
        }
        public ShoppingList GetShoppingList()
        {
            return shoppingList;
        }
    }
}
