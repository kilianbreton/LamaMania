﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LamaMania;
using System.Collections.Generic;
using TMXmlRpcLib;
using System.Reflection;
using LamaPlugin;

namespace LamaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ManiaParseTest()
        {
            Assert.AreEqual("Kilian BT", ManiaColors.getText("$o$fffKilian $000BT"));
            Assert.AreEqual("$", ManiaColors.getText("$$"));
            Assert.AreEqual("Drk", ManiaColors.getText("$s$i$09FD$07Fr$05Fk$03F$fff"));
        }

        [TestMethod]
        public void ParseTimeTest()
        {
            StaticMethods.parseTime(323, out int h, out int m, out int s);
            Assert.AreEqual(0, h);
            Assert.AreEqual(5, m);
            Assert.AreEqual(23, s);
      

        }

        [TestMethod]
        public void GetKeyFromValueTest()
        {
            Dictionary<string, int> test = new Dictionary<string, int> {
                {"A", 1 },
                {"B", 2 },
                {"C", 3 },
                {"D", 4 },
                {"E", 5 },
                {"F", 6 },
                {"G", 7 },
            };

            Assert.AreEqual("A", test.getKeyFromValue(1));
            Assert.AreEqual("B", test.getKeyFromValue(2));
            Assert.AreEqual("C", test.getKeyFromValue(3));
            Assert.AreEqual("D", test.getKeyFromValue(4));
            Assert.AreEqual("E", test.getKeyFromValue(5));
            Assert.AreEqual("F", test.getKeyFromValue(6));
            Assert.AreEqual("G", test.getKeyFromValue(7));
        }

        [TestMethod]
        public void GetTypeTest()
        {
            Assert.AreEqual(0, StaticMethods.getType("test"));
            Assert.AreEqual(1, StaticMethods.getType(1));
            Assert.AreEqual(3, StaticMethods.getType(0.1));
            Assert.AreEqual(2, StaticMethods.getType(true));
            Assert.AreEqual(-1, StaticMethods.getType(new Random()));
        }

        public void test()
        {
       
        }
    }

}
