using Einkaufsliste.ClassLibrary;
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
        [TestMethod]
        public void CreateListCommand()
        {
            //arrange
            string command = "createShoppingList test";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void GetListCommand()
        {
            //arrange
            string command = "getShoppingList";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void DeleteListCommand()
        {
            //arrange
            string command = "deleteShoppingList";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void addProductToListCommand()
        {
            //arrange
            string command = "addProductToShoppingList";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void addFoodToListCommand()
        {
            //arrange
            string command = "addFoodToShoppingList";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void WrongArgument()
        {
            //arrange
            string command = "Product";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.AreEqual("Kein echter Befehl\r\n", output);
        }

        private ProcessStartInfo createStartInfo(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "Einkaufsliste.exe",
                Verb = "runas",
                Arguments = command,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            return startInfo;
        }
    }
}
