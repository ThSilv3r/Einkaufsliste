using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class ShoppingListEngineer
    {
        private IShoppingListBuilder listBuilder;

        public ShoppingListEngineer(IShoppingListBuilder listBuilder)
        {
            this.listBuilder = listBuilder;
        }

        public ShoppingList GetShoppingList()
        {
            return listBuilder.GetShoppingList();
        }

        public void constructShoppingList(string name, List<Guid> products, List<Guid> foods)
        {
            this.listBuilder.BuildName(name);
            this.listBuilder.BuildProducts(products);
            this.listBuilder.BuildFood(foods);
            this.listBuilder.BuildId(Guid.NewGuid());
        }
    }
}
