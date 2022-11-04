
namespace UnitTests
{
    [TestClass]
    public class WhatName
    {
        [TestMethod]
        public void TestMethod1()
        {
            string name = "x1";
            int currectpos = 0, global = 0;
            Assert.AreEqual("!x1", SLE.WhatsName(name, currectpos, global));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string name = "x1";
            int currectpos = 0, global = 1;
            Assert.AreEqual("x1", SLE.WhatsName(name, currectpos, global));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string name = "x1";
            int currectpos = 1, global = 0;
            Assert.AreEqual("!x1", SLE.WhatsName(name, currectpos, global));
        }
        [TestMethod]
        public void TestMethod4()
        {
            string name = "x1";
            int currectpos = 1, global = 3;
            Assert.AreEqual("x1", SLE.WhatsName(name, currectpos, global));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string name = "x1";
            int currectpos = 3, global = 14;
            Assert.AreEqual("x1", SLE.WhatsName(name, currectpos, global));
        }
        [TestMethod]
        public void TestMethod6()
        {
            string name = "x1";
            int currectpos = 3, global = 6;
            Assert.AreEqual("!x1", SLE.WhatsName(name, currectpos, global));
        }

    }
}