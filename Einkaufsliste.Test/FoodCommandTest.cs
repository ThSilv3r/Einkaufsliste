using Einkaufsliste.ClassLibrary;
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
        [TestMethod]
        public void CreateFoodCommand()
        {
            //arrange
            string command = "createFood test";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void GetFoodCommand()
        {
            //arrange
            string command = "getFoodList";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void DeleteFoodCommand()
        {
            //arrange
            string command = "deleteFood";

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
            string command = "Food";

            var startInfo = createStartInfo(command);

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void NoArguments()
        {
            //arrange
            var startInfo = new ProcessStartInfo
            {
                FileName = "Einkaufsliste.exe",
                Verb = "runas",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            //act
            var cmd = Process.Start(startInfo);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();

            //assert
            Assert.IsNotNull(output);
        }

        private ProcessStartInfo createStartInfo(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "Einkaufsliste.exe",
                Verb = "runas",
                Arguments = command,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            return startInfo;
        }
    }
}
