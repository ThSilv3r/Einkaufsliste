using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface RecipeRepository
    {
        void createRecipe(string name);
        void readRecipe(string name);
        void addFood(string recipeName);
        void addToShoppingList(string recipeName, string listName);
    }
}
