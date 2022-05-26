using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class RecipeManager : IRecipeManager
    {
        RecipeBuilder recipeBuilder;
        RecipeEngineer recipeEngineer;
        Recipe recipe;
        public Recipe createRecipe(string name, List<Guid> foods, string description)
        {
            RecipeBuilder recipeBuilder = new RecipeBuilder();
            RecipeEngineer recipeEngineer = new RecipeEngineer(recipeBuilder);
            Recipe recipe = new Recipe();
            if (name != null && name != "")
            {
                recipeEngineer.constructRecipe(name, description, foods);
                recipe = recipeEngineer.GetRecipe();
                return recipe;
            }
            return null;
        }
        public Recipe addFoodToRecipe(Recipe recipe, Guid foodId)
        {
            recipe.Foods.Add(foodId);
            return recipe;
        }

        public ShoppingList addRecipeToShoppingList(Recipe recipe, ShoppingList list)
        {
            foreach (Guid foodId in recipe.Foods)
            {
                list.Foods.Add(foodId);
            }
            
            return list;
        }
    }
}
