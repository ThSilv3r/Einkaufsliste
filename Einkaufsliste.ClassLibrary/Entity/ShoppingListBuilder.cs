using Einkaufsliste.ClassLibrary.Entity.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
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
        public void BuildFood(List<Food> foods)
        {
            shoppingList.Foods = foods;
        }
        public void BuildProducts(List<Product> products)
        {
            shoppingList.Products = products;
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
