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
        //void createRecipe(string name);
        //void readRecipe(string name);
        Recipe addFood(Recipe recipe, Guid food);
        //void addFood(string recipeName);
        ShoppingList addToShoppingList(Recipe recipe, ShoppingList list);
        //void addToShoppingList(string recipeName, string listName);
    }
}
