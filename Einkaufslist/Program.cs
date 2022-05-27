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
                    if (command.Contains("Recipe"))
                    {
                        enteredCommand = true;
                        commandView.recipeCommand(command);
                    }
                    else if (command.Contains("ShoppingList"))
                    {
                        enteredCommand = true;
                        commandView.listCommands(command);
                    }
                    else if (command.Contains("Food"))
                    {
                        enteredCommand = true;
                        commandView.foodCommands(command);
                    }
                    else if (command.Contains("Product"))
                    {
                        enteredCommand = true;
                        commandView.productCommand(command);
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
