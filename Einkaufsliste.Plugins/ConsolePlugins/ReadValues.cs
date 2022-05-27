using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins
{
    public class ReadValues : IReadValues
    {
        public string ReadString()
        {
            string str = Console.ReadLine();
            if (str == null || str == "")
            {
                Console.WriteLine("Please enter a text.");
                return Console.ReadLine();
            }
            return str;
        }
        public double ReadDouble()
        {
            double dbl;
            string doubleString = Console.ReadLine();
            try
            {
                dbl = Convert.ToDouble(doubleString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a decimal number");
                doubleString = Console.ReadLine();
                if (doubleString == null)
                {
                    dbl = 0;
                }
                else
                {
                    dbl = Convert.ToDouble(doubleString);
                }
            }
            return dbl;
        }
        public int ReadInt()
        {
            string weightString = Console.ReadLine();
            int number;
            try
            {
                number = Convert.ToInt32(weightString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a number without decimal place");
                weightString = Console.ReadLine();
                if (weightString == null)
                {
                    number = 0;
                }
                else
                {
                    number = Convert.ToInt32(weightString);
                }
            }
            return number;
        }
    }
}
