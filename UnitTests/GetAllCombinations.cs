
namespace UnitTests
{
    [TestClass]
    public class GetAllCombinations
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> names = new List<string>();
            names.Add("x1");
            names.Add("x2");
            names.Add("x3");
            List<List<string>> comb = SLE.GetAllCombinations(names);
            List<List<string>> combExpected = new List<List<string>>();
            combExpected.Add(new List<string>(new string[] {"!x1","!x2","!x3"}));
            combExpected.Add(new List<string>(new string[] { "!x1", "!x2", "x3" }));
            combExpected.Add(new List<string>(new string[] { "!x1", "x2", "!x3" }));
            combExpected.Add(new List<string>(new string[] { "!x1", "x2", "x3" }));
            combExpected.Add(new List<string>(new string[] { "x1", "!x2", "!x3" }));
            combExpected.Add(new List<string>(new string[] { "x1", "!x2", "x3" }));
            combExpected.Add(new List<string>(new string[] { "x1", "x2", "!x3" }));
            combExpected.Add(new List<string>(new string[] { "x1", "x2", "x3" }));
            Assert.AreEqual(8, comb.Count);
            Assert.AreEqual(3, comb[0].Count);
            for(int i=0;i<combExpected.Count;++i)
            {
                for(int j = 0; j<combExpected[i].Count;++j)
                {
                    Assert.AreEqual(combExpected[i][j], comb[i][j]);
                }
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> names = new List<string>();
            names.Add("x1");
            names.Add("x2");
            List<List<string>> comb = SLE.GetAllCombinations(names);
            List<List<string>> combExpected = new List<List<string>>();
            combExpected.Add(new List<string>(new string[] { "!x1", "!x2" }));
            combExpected.Add(new List<string>(new string[] { "!x1", "x2" }));
            combExpected.Add(new List<string>(new string[] { "x1", "!x2" }));
            combExpected.Add(new List<string>(new string[] { "x1", "x2" }));
            Assert.AreEqual(4, comb.Count);
            Assert.AreEqual(2, comb[0].Count);
            for (int i = 0; i<combExpected.Count; ++i)
            {
                for (int j = 0; j<combExpected[i].Count; ++j)
                {
                    Assert.AreEqual(combExpected[i][j], comb[i][j]);
                }
            }
        }
    }
}
