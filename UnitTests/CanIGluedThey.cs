
namespace UnitTests
{
    [TestClass]
    public class CanIGluedThey
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expres1 = " x1 * x2 *x3 * !x4";
            string expres2 = " x1 * x2 *x3 * x4";
            List<string> names = SLE.GetNamesFromExpression(expres2);
            List<List<string>> sohes = SLE.GetAllSoch(names);
            List<Glued> glueds = SLE.GLuedSoch(names,sohes);
            int whatcode = -1;
            Assert.AreEqual(true, SLE.CanIGluedThey(expres1,glueds,out whatcode));
            Assert.AreEqual(0, whatcode);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string expres1 = " x1 * x2 *x3 * x4";
            string expres2 = " x1 * x2 *x3 * x4";
            List<string> names = SLE.GetNamesFromExpression(expres2);
            List<List<string>> sohes = SLE.GetAllSoch(names);
            List<Glued> glueds = SLE.GLuedSoch(names, sohes);
            int whatcode = -1;
            Assert.AreEqual(false, SLE.CanIGluedThey(expres1, glueds, out whatcode));
            Assert.AreEqual(-1, whatcode);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string expres1 = " x1 * x2 *x3 * x4";
            string expres2 = " x2 * x3 *x1 * !x4";
            List<string> names = SLE.GetNamesFromExpression(expres2);
            List<List<string>> sohes = SLE.GetAllSoch(names);
            List<Glued> glueds = SLE.GLuedSoch(names, sohes);
            int whatcode = -1;
            Assert.AreEqual(true, SLE.CanIGluedThey(expres1, glueds, out whatcode));
            Assert.AreEqual(0, whatcode);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string expres1 =  " !x4 * x2 * x3 *x1";
            string expres2 = " x1 * x2 *x3 * x4";
            List<string> names = SLE.GetNamesFromExpression(expres2);
            List<List<string>> sohes = SLE.GetAllSoch(names);
            List<Glued> glueds = SLE.GLuedSoch(names, sohes);
            int whatcode = -1;
            Assert.AreEqual(true, SLE.CanIGluedThey(expres1, glueds, out whatcode));
            Assert.AreEqual(0, whatcode);
        }
    }
}
