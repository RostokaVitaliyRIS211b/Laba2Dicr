
namespace UnitTestsSDNF
{
    [TestClass]
    public class ReplaceToInt
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> list = new List<int>(new int[] { 1,0,1 });
            List<string> names = new List<string>(new string[] { "x", "y", "z" });
            string expression = " x * y -> !z + (!x * !y) * z ";
            string expected = " 1 * 0 -> 0 + (0 * 1) * 1 ";
            SDNF.ReplaceToInt(ref expression, list, names);
            Assert.AreEqual(expected, expression);
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<int> list = new List<int>(new int[] { 0, 0, 0 });
            List<string> names = new List<string>(new string[] { "x", "y", "z" });
            string expression = " x * y -> !z + (!x * !y) * z ";
            string expected = " 0 * 0 -> 1 + (1 * 1) * 0 ";
            SDNF.ReplaceToInt(ref expression, list, names);
            Assert.AreEqual(expected, expression);
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<int> list = new List<int>(new int[] { 1, 1, 1 });
            List<string> names = new List<string>(new string[] { "x", "y", "z" });
            string expression = " x * y -> !z + (!x * !y) * z ";
            string expected = " 1 * 1 -> 0 + (0 * 0) * 1 ";
            SDNF.ReplaceToInt(ref expression, list, names);
            Assert.AreEqual(expected, expression);
        }
    }
}
