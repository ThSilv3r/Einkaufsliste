using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    internal interface IShoppingListBuilder
    {
        void BuildName(string  name);
        void BuildId(Guid guid);
        void BuildFood(List<Food> foods);
        void BuildProducts(List<Product> products);
        ShoppingList GetShoppingList();
    }
}
