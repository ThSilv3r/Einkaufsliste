using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class OutputValues : OutputValuesRepository
    {
        public void enterNameMessage()
        {
            Console.WriteLine("Please enter a name.");
        }
        public void closeEntryMessage()
        {
            Console.WriteLine("Enter q to finish.");
        }
        public void nameWarning()
        {
            Console.WriteLine("Please enter a name next time");
        }
    }
}
