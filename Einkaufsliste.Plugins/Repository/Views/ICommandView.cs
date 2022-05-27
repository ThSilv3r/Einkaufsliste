using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Repository.Views
{
    public interface ICommandView
    {
        void foodCommands(string command);
        void listCommands(string command);
        void productCommand(string command);
        void recipeCommand(string command);
    }
}
