using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface RecipeRepository
    {
        Recipe createRecipe(string name, List<Guid> foods, string description);
        Recipe addFood(Recipe recipe, Guid food);
        ShoppingList addToShoppingList(Recipe recipe, ShoppingList list);
    }
}
