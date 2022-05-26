using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class OutputValuesTest
    {
        IOutputValues outputValues;
        [TestInitialize]
        public void Startup()
        {
            outputValues = new OutputValues();
        }
        [TestMethod]
        public void EnterNameMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Please enter a name.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                outputValues.enterNameMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void CloseEntryMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Enter q to finish.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                outputValues.closeEntryMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
