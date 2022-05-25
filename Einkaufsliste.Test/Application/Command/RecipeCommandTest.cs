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
    public class RecipeCommandTest
    {

        CommandViewMock commandViewMock;

        [TestInitialize]
        public void Startup()
        {
            commandViewMock = new CommandViewMock();
        }
        [TestMethod]
        public void CreateRecipeCommand()
        {
            //arrange
            string command = "createRecipe";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.recipeCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void GetRecipeCommand()
        {
            //arrange
            string command = "getRecipe";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.recipeCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void DeleteRecipeCommand()
        {
            //arrange
            string command = "deleteRecipe";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.recipeCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void AddRecipeToListCommand()
        {
            //arrange
            string command = "addRecipeToList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.recipeCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void WrongArgument()
        {
            //arrange
            string command = "Recipe";
            string output = "";
            string expected = "Kein echter Befehl\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.recipeCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
