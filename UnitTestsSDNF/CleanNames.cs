

namespace UnitTestsSDNF
{
    [TestClass]
    public class CleanNames
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> listAct = new List<string>(new string[] {"!x","!y","!z" });
            List<string> listExp = new List<string>(new string[] { "x", "y", "z" });

            SDNF.CleanNames(listAct);

            for(int i=0;i<3;++i)
            {
                Assert.AreEqual(listAct[i], listExp[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> listAct = new List<string>(new string[] { "x", "y", "z" });
            List<string> listExp = new List<string>(new string[] { "x", "y", "z" });

            SDNF.CleanNames(listAct);

            for (int i = 0; i<3; ++i)
            {
                Assert.AreEqual(listAct[i], listExp[i]);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> listAct = new List<string>(new string[] { "x", "!y", "z" });
            List<string> listExp = new List<string>(new string[] { "x", "y", "z" });

            SDNF.CleanNames(listAct);

            for (int i = 0; i<3; ++i)
            {
                Assert.AreEqual(listAct[i], listExp[i]);
            }
        }
    }
}