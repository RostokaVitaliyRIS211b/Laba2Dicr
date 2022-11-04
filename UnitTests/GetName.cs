
namespace UnitTests
{
    [TestClass]
    public class GetNames
    {
        [TestMethod]
        public void TestMethod1()
        {
            string exp = "x1 * x2 * x3 * x4";
            List<string> list = new List<string>();
            list.Add("x1");
            list.Add("x2");
            list.Add("x3");
            list.Add("x4");
            List<string> names = SLE.GetNamesFromExpression(exp);
            Assert.AreEqual(4, names.Count);
            for(int i = 0; i < names.Count; ++i)
            {
                Assert.AreEqual(list[i], names[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string exp = "x_1 * x2_ * x3_3 * x12_4";
            List<string> list = new List<string>();
            list.Add("x");
            list.Add("x2");
            list.Add("x3");
            list.Add("x12");
            List<string> names = SLE.GetNamesFromExpression(exp);
            Assert.AreEqual(4, names.Count);
            for (int i = 0; i < names.Count; ++i)
            {
                Assert.AreEqual(list[i], names[i]);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            string exp = "123 * x2_ * x3_3 * x12_4";
            List<string> list = new List<string>();
            list.Add("x2");
            list.Add("x3");
            list.Add("x12");
            List<string> names = SLE.GetNamesFromExpression(exp);
            Assert.AreEqual(3, names.Count);
            for (int i = 0; i < names.Count; ++i)
            {
                Assert.AreEqual(list[i], names[i]);
            }
        }
    }
}