
namespace UnitTestsSDNF
{
    [TestClass]
    public class GetResult
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> list = new List<string>(new string[] {"!x","!y","z"});
            List<string> list2 = new List<string>(new string[] {"x","y","z"});
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2,list,expression));
        }
        [TestMethod]
        public void TestMethod8()
        {
            List<string> list = new List<string>(new string[] { "x", "y", "!z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod7()
        {
            List<string> list = new List<string>(new string[] { "x", "!y", "z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod6()
        {
            List<string> list = new List<string>(new string[] { "x", "!y", "!z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod5()
        {
            List<string> list = new List<string>(new string[] { "!x", "y", "z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod4()
        {
            List<string> list = new List<string>(new string[] { "!x", "y", "!z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(true, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> list = new List<string>(new string[] { "!x", "!y", "!z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(false, SDNF.GetResult(list2, list, expression));
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> list = new List<string>(new string[] { "x", "y", "z" });
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            Assert.AreEqual(false, SDNF.GetResult(list2, list, expression));
        }
    }
}
