using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Test.Application.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ShoppingListCommandTest
    {
        CommandViewMock commandViewMock;

        [TestInitialize]
        public void Startup()
        {
            commandViewMock = new CommandViewMock();
        }
        [TestMethod]
        public void CreatListCommand()
        {
            //arrange
            string command = "createShoppingList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void GetListCommand()
        {
            //arrange
            string command = "getShoppingList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void DeleteListCommand()
        {
            //arrange
            string command = "deleteShoppingList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void addProductToListCommand()
        {
            //arrange
            string command = "addProductToShoppingList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void addFoodToListCommand()
        {
            //arrange
            string command = "addFoodToShoppingList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void WrongArgument()
        {
            //arrange
            string command = "ShoppingList";
            string output = "";
            string expected = "Kein echter Befehl\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.listCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
