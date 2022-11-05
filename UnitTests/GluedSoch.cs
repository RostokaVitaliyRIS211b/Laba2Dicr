
namespace UnitTests
{
    [TestClass]
    public class GluedSoch
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> names = new List<string>();

            names.Add("x1");
            names.Add("x2");
            names.Add("x3");
            names.Add("x4");

            List<List<string>> list = SLE.GetAllSoch(names);
            List<Glued> glueds =SLE.GLuedSoch(names, list);

            Assert.AreEqual(4, glueds.Count);

            for(int i = 0; i < glueds.Count; ++i)
            {
                Assert.AreEqual(names.Find(x => !list[i].Contains(x)), glueds[i].lastName);
            }
        }
    }
}
