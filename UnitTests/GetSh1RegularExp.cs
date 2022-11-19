
namespace UnitTests
{
    [TestClass]
    public class GetSh1RegularExp
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> names = new List<string>();

            names.Add("x1");
            names.Add("x2");
            names.Add("x3");

            string RegExp = ".*([^!]x1|[^!]x2|[^!]x3).*([^!]x1|[^!]x2|[^!]x3).*([^!]x1|[^!]x2|[^!]x3)";
            Assert.AreEqual(RegExp, SLE.GetSh1RegularExp(names));
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> names = new List<string>();

            names.Add("x1");
            names.Add("x2");

            string RegExp = ".*([^!]x1|[^!]x2).*([^!]x1|[^!]x2)";
            Assert.AreEqual(RegExp, SLE.GetSh1RegularExp(names));
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> names = new List<string>();

            names.Add("x1");
            names.Add("x2");
            names.Add("x3");
            names.Add("x4");

            string RegExp = ".*([^!]x1|[^!]x2|[^!]x3|[^!]x4).*([^!]x1|[^!]x2|[^!]x3|[^!]x4).*([^!]x1|[^!]x2|[^!]x3|[^!]x4).*([^!]x1|[^!]x2|[^!]x3|[^!]x4)";
            Assert.AreEqual(RegExp, SLE.GetSh1RegularExp(names));
        }
    }
}
