using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface IRecipeManager
    {
        Recipe createRecipe(string name, List<Guid> foods, string description);
        Recipe addFoodToRecipe(Recipe recipe, Guid food);
        ShoppingList addRecipeToShoppingList(Recipe recipe, ShoppingList list);
    }
}
