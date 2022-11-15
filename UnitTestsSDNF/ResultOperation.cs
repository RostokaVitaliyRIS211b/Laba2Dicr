
namespace UnitTestsSDNF
{
    [TestClass]
    public class ResultOperation
    {
        [TestMethod]
        public void TestMethod1()
        {
            string oper = " 0 + 1";
            Assert.AreEqual(1,SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string oper = " 1 + 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string oper = " 0 + 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod4()
        {
            string oper = " 0 * 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string oper = " 1 * 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod6()
        {
            string oper = " 1 * 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod7()
        {
            string oper = " 0 == 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string oper = " 1 == 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod9()
        {
            string oper = " 0 == 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string oper = " 1 == 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod11()
        {
            string oper = " 0 != 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod12()
        {
            string oper = " 1 != 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod13()
        {
            string oper = " 0 != 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod14()
        {
            string oper = " 1 != 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod15()
        {
            string oper = " 0 -> 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod16()
        {
            string oper = " 1 -> 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod17()
        {
            string oper = " 0 -> 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod18()
        {
            string oper = " 1 -> 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod19()
        {
            string oper = " 0 !+ 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod20()
        {
            string oper = " 1 !+ 0";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod21()
        {
            string oper = " 0 !+ 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod22()
        {
            string oper = " 1 !+ 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod23()
        {
            string oper = " 0 !* 1";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod24()
        {
            string oper = " 1 !* 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod25()
        {
            string oper = " 0 !* 0";
            Assert.AreEqual(1, SDNF.ResultOperation(oper));
        }
        [TestMethod]
        public void TestMethod26()
        {
            string oper = " 1 !* 1";
            Assert.AreEqual(0, SDNF.ResultOperation(oper));
        }
    }
}
