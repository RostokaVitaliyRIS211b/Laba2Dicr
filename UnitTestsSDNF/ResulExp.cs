
namespace UnitTestsSDNF
{
    [TestClass]
    public class ResulExp
    {
        [TestMethod]
        public void TestMethod1()
        {
            string exp = "1 * 0 * 1 * 1";
            Assert.AreEqual(0,SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string exp = "1 + 0 + 1 + 1";
            Assert.AreEqual(1, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string exp = "1 -> 0 + 0 + 0";
            Assert.AreEqual(0, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod4()
        {
            string exp = "1 * 0 + 1 * 0";
            Assert.AreEqual(0, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string exp = "1 * 0 + 1 != 0 * 1";
            Assert.AreEqual(1, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod6()
        {
            string exp = "1 * 0 + 1 != 1 -> 0";
            Assert.AreEqual(1, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod7()
        {
            string exp = "1 * 0 + 1 != 1 -> 1 == 0";
            Assert.AreEqual(0, SDNF.ResultExp(exp));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string exp = "1 * 0 !+ 1 != 1 -> 0 !+ 0";
            Assert.AreEqual(1, SDNF.ResultExp(exp));
        }
    }
}
