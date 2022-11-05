
namespace UnitTests
{
    [TestClass]
    public class GetSimplifiedForm
    {
        [TestMethod]
        public void TestMethod()
        {
            string expression = " !x1 * !x2 * !x3 * !x4 + !x1 * !x2 * !x3 * x4 + !x1 * !x2 * x3 * !x4 + !x1 * x2 * x3 * !x4 + x1 * x2 * x3 * !x4 + x1 * x2 * x3 * x4 ";
            List<string> disjuncts = SLE.GetDisjuncts(expression);
            List<string> expected = new List<string>();

            expected.Add("!x1 * !x2 * !x3 ");
            expected.Add("!x1 * !x2 * !x4 ");
            expected.Add("!x1 * x3 * !x4 ");
            expected.Add("x2 * x3 * !x4 ");
            expected.Add("x1 * x2 * x3 ");

            disjuncts = SLE.GetSimplifiedForm(disjuncts);

            Assert.AreEqual(5, disjuncts.Count);

            for(int i=0;i<disjuncts.Count;++i)
            {
                Assert.AreEqual(expected[i], disjuncts[i]);
            }
        }
    }
}
