using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class FluentShoppingList
    {
        public ShoppingList shoppingList = new ShoppingList();

        public FluentShoppingList NameOfTheList(string name)
        {
            shoppingList.Name = name;
            return this;
        }
        public FluentShoppingList FoodsOfTheList(List<Food> foods)
        {
            shoppingList.Foods = foods;
            return this;
        }
        public FluentShoppingList ProductsOfTheList(List<Product> products)
        {
            shoppingList.Products = products;
            return this;
        }
    }
}
