using System;

namespace Einkaufsliste
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandManager commandManager = new CommandManager();
            if (args.Length <= 0) //Checking the Length helps avoid NullReferenceException at args[0]
            {
                Console.WriteLine("Please enter a command");
            }
            else
            {
                if (args[0].Contains("Food"))
                {
                    commandManager.foodCommands(args);
                }
                if (args[0].Contains("Product"))
                {
                    commandManager.productCommand(args);
                }
                if (args[0].Contains("Recipe"))
                {
                    commandManager.recipeCommand(args);
                }
                if (args[0].Contains("ShoppingList"))
                {
                    commandManager.listCommands(args);
                }
                else
                {
                    Console.WriteLine(args[0]);
                    Console.WriteLine("Kein echter Befehl");
                    Console.WriteLine(args.Length);
                }
            }
        }
    }
}
