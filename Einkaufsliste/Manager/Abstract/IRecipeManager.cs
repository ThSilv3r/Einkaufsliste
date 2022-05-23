using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Manager.Abstract
{
    internal interface IRecipeManager
    {
        void createRecipe();
        void saveRecipe(Recipe recipe);
        Recipe getRecipe(string name);
        void readRecipe(string name);
        void deleteRecipe(string name);
        void addFood(string recipeName);
        void addToShoppingList();
    }
}
