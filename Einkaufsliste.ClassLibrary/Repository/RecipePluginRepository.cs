using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Json
{
    public interface RecipePluginRepository
    {
        void saveRecipe(Recipe recipe);
        void deleteRecipe(string name);
        Recipe getRecipe(string name);
    }
}
