using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface RecipeRepository
    {
        Recipe createRecipe(string name, List<Food> foods, string description);
        //void createRecipe(string name);
        //void readRecipe(string name);
        Recipe addFood(Recipe recipe, Food food);
        //void addFood(string recipeName);
        ShoppingList addToShoppingList(Recipe recipe, ShoppingList list);
        //void addToShoppingList(string recipeName, string listName);
    }
}
