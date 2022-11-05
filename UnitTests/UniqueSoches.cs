
namespace UnitTests
{
    [TestClass]
    public class UniqueSoches
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<List<string>> soches = new List<List<string>>();
            soches.Add(new List<string>(new string[] { "x2", "x3" }));
            soches.Add(new List<string>(new string[] { "x1", "!x2" }));
            soches.Add(new List<string>(new string[] { "x3", "x2" }));
            soches.Add(new List<string>(new string[] { "!x2", "x1" }));

            soches = SLE.UniqueSoches(soches);

            List<List<string>> sohesExp = new List<List<string>>();
            sohesExp.Add(new List<string>(new string[] { "x2", "x3" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2" }));

            Assert.AreEqual(2, soches.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for (int j = 0; j<sohesExp[i].Count; ++j)
                {
                    sohesExp[i][j]=soches[i][j];
                }
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<List<string>> soches = new List<List<string>>();
            soches.Add(new List<string>(new string[] { "x2", "x3" }));
            soches.Add(new List<string>(new string[] { "x1", "!x2" }));
            soches.Add(new List<string>(new string[] { "x2", "x3" }));
            soches.Add(new List<string>(new string[] { "x1", "!x2" }));
            soches.Add(new List<string>(new string[] { "x3", "x2" }));
            soches.Add(new List<string>(new string[] { "!x2", "x1" }));

            soches = SLE.UniqueSoches(soches);

            List<List<string>> sohesExp = new List<List<string>>();
            sohesExp.Add(new List<string>(new string[] { "x2", "x3" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2" }));

            Assert.AreEqual(2, soches.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for (int j = 0; j<sohesExp[i].Count; ++j)
                {
                    sohesExp[i][j]=soches[i][j];
                }
            }
        }
    }
}
