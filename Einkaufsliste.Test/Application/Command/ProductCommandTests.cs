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
    public class ProductCommandTest
    {
        CommandViewMock commandViewMock;

        [TestInitialize]
        public void Startup()
        {
            commandViewMock = new CommandViewMock();
        }
        [TestMethod]
        public void CreateProductCommand()
        {
            //arrange
            string command = "createProduct";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.productCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void GetProductCommand()
        {
            //arrange
            string command = "getProductList";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.productCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void DeleteProductCommand()
        {
            //arrange
            string command = "deleteProduct";
            string output = "";
            string expected = "true\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.productCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void WrongArgument()
        {
            //arrange
            string command = "Product";
            string output = "";
            string expected = "Kein echter Befehl\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                commandViewMock.productCommand(command);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
