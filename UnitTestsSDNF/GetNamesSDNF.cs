
namespace UnitTestsSDNF
{
    [TestClass]
    public class GetNamesSDNF
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            List<string> actNames = SDNF.GetNamesSDNF(expression);
            List<string> expectedNames = new List<string>(new string[] {"x","y","z"});
            for(int i = 0; i < actNames.Count; ++i)
            {
                Assert.AreEqual(expectedNames[i], actNames[i]);
            }
        }
    }
}
