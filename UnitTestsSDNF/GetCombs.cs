
namespace UnitTestsSDNF
{
    [TestClass]
    public class GetCombs
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> list2 = new List<string>(new string[] { "x", "y", "z" });
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            List<List<string>> allcombs = SLE.GetAllCombinations(list2);
            List<List<string>> expectedCombs = new List<List<string>>();
            expectedCombs.Add(new List<string>(new string[] {"!x","!y","z"}));
            expectedCombs.Add(new List<string>(new string[] { "!x", "y", "!z" }));
            expectedCombs.Add(new List<string>(new string[] { "!x", "y", "z" }));
            expectedCombs.Add(new List<string>(new string[] { "x", "!y", "!z" }));
            expectedCombs.Add(new List<string>(new string[] { "x", "!y", "z" }));
            expectedCombs.Add(new List<string>(new string[] { "x", "y", "!z" }));
            List<List<string>> actCombs = SDNF.GetCombs(SDNF.GetNamesSDNF(expression),allcombs,expression);
            for(int i=0;i<expectedCombs.Count;++i)
            {
                for(int j=0;j<expectedCombs[i].Count;++j)
                {
                    Assert.AreEqual(expectedCombs[i][j], actCombs[i][j]);
                }
            }
        }
    }
}
