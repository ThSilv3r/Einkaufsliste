using Einkaufsliste.Plugins.Views;
using System;

namespace Einkaufslist
{
    internal class Program
    {
        static CommandView commandView;
        static void Main(string[] args)
        {
            commandView = new CommandView();
            bool enteredCommand = false;
            while (!enteredCommand)
            {
                Console.WriteLine("Please enter a command");
                string command = Console.ReadLine();
                if (command.Length <= 0) //Checking the Length helps avoid NullReferenceException at args[0]
                {
                    Console.WriteLine("Please enter a command");
                }
                else
                {
                    enteredCommand = true;
                    if (command.Contains("Food"))
                    {
                        commandView.foodCommands(command);
                    }
                    if (command.Contains("Product"))
                    {
                        commandView.productCommand(command);
                    }
                    if (command.Contains("Recipe"))
                    {
                        commandView.recipeCommand(command);
                    }
                    if (command.Contains("ShoppingList"))
                    {
                        commandView.listCommands(command);
                    }
                    else
                    {
                        Console.WriteLine("No existing command");
                        enteredCommand = false;
                    }
                }
            }
        }
    }
}
