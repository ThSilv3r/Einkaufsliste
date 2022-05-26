using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters
{
    public class RecipeViewAdapter
    {
        RecipeManager recipeManager = new RecipeManager();
        public Recipe createRecipe(string name, List<Guid> foodIds, string desc)
        {
            return recipeManager.createRecipe(name, foodIds, desc);
        }
        public Recipe addFoodToRecipe(Recipe recipe, Guid foodId)
        {
            return recipeManager.addFoodToRecipe(recipe, foodId);
        }
        public ShoppingList addRecipeToShoppingList(Recipe recipe, ShoppingList list)
        {
            return recipeManager.addRecipeToShoppingList(recipe, list);
        }
    }
}
