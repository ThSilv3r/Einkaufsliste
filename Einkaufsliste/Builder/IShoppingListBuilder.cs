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
        void BuildName(string  name);
        void BuildId(Guid guid);
        void BuildFood(List<Guid> foodIds);
        void BuildProducts(List<Guid> productIds);
        ShoppingList GetShoppingList();
    }
}
