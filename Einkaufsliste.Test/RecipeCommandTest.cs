using Einkaufsliste.ClassLibrary;
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

        [TestMethod]
        public void GetRecipeCommand()
        {
            //arrange
            string command = "getRecipe";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void DeleteRecipeCommand()
        {
            //arrange
            string command = "deleteRecipe";

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
            string command = "Recipe";

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
                Arguments = command,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            return startInfo;
        }
    }
}
