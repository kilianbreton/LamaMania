using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAMAMAnia;

namespace LamaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ManiaParseTest()
        {
            ManiaColors colors = new ManiaColors();
            Assert.AreEqual(colors.getText("$o$fffKilian $000BT"), "Kilian BT");
        }

        [TestMethod]
        public void ParseTimeTest()
        {
            int h, m, s;
            Lama.parseTime(323, out h, out m, out s);
            Assert.AreEqual(0, h);
            Assert.AreEqual(5, m);
            Assert.AreEqual(23, s);

        }
    }
}
