using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ReadValuesTest
    {

        [TestMethod]
        public void ReadStringTest()
        {
            //arrange
            ReadValues readValues = new ReadValues();
            string testString = "testString";
            

            //act
            StringReader stringReader = new StringReader(testString);
            Console.SetIn(stringReader);
            string output =  readValues.ReadString();

            //assert
            Assert.AreEqual(testString, output);
        }
        [TestMethod]
        public void ReadDoubleTest()
        {
            //arrange
            ReadValues readValues = new ReadValues();
            double testDouble = 10.00;
            StringReader doubleReader = new StringReader(testDouble.ToString());
            Console.SetIn(doubleReader);

            //act
            double output = readValues.ReadDouble();
            //assert
            Assert.AreEqual(testDouble, output);
        }
        [TestMethod]
        public void ReadIntTest()
        {
            //arrange
            ReadValues readValues = new ReadValues();
            int testInt = 10;
            StringReader intReader = new StringReader(testInt.ToString());
            Console.SetIn(intReader);

            //act
            int output = readValues.ReadInt();

            //assert
            Assert.AreEqual(testInt, output);
        }
    }
}
