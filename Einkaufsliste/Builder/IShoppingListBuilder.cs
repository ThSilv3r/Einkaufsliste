using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public interface IShoppingListBuilder
    {
        void BuildShoppingListName(string  name);
        void BuildShoppingListId(Guid guid);
        void BuildShoppingListFood(List<Guid> foodIds);
        void BuildShoppingListProducts(List<Guid> productIds);
        ShoppingList GetShoppingList();
    }
}
