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
    public class FoodCommandTest
    {
        CommandViewMock commandViewMock;
        string output;
        string expected;
        [TestInitialize]
        public void Startup()
        {
            output = "";
            expected = "true\r\n";
            commandViewMock = new CommandViewMock();
        }
        [TestMethod]
        public void GetFoodCommand()
        {
            //arrange
            string command = "getFoodList";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.foodCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void DeleteFoodCommand()
        {
            //arrange
            string command = "deleteFood";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.foodCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void CreateFoodCommand()
        {
            //arrange
            string command = "createFood";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.foodCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void WrongArgument()
        {
            //arrange
            string command = "Food";
            string expected = "Kein echter Befehl\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.foodCommands(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
