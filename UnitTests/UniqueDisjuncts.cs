
namespace UnitTests
{
    [TestClass]
    public class UniqueDisjuncts
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = " x1 * x2  + !x2 * x3  + x1 * !x2 * x3 + x1 * x2 * !x3 + x1 * x2  + !x2 * x3";
            List<string> disjuncts = SLE.GetDisjuncts(expression);
            List<string> disjunctsExp = new List<string>();

            disjunctsExp.Add(" x1 * x2  ");
            disjunctsExp.Add(" !x2 * x3  ");
            disjunctsExp.Add(" x1 * !x2 * x3 ");
            disjunctsExp.Add(" x1 * x2 * !x3 ");

            disjuncts = SLE.UniqueDisjuncts(disjuncts);

            Assert.AreEqual(4, disjuncts.Count);
            for(int i=0;i<disjunctsExp.Count;++i)
            {
                Assert.AreEqual(disjunctsExp[i], disjuncts[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string expression = " x1 * !x2 * x3 + x1 * x2 * !x3 + x1 * x2  + !x2 * x3";
            List<string> disjuncts = SLE.GetDisjuncts(expression);
            List<string> disjunctsExp = new List<string>();

            
            disjunctsExp.Add(" x1 * !x2 * x3 ");
            disjunctsExp.Add(" x1 * x2 * !x3 ");
            disjunctsExp.Add(" x1 * x2  ");
            disjunctsExp.Add(" !x2 * x3");

            disjuncts = SLE.UniqueDisjuncts(disjuncts);

            Assert.AreEqual(4, disjuncts.Count);
            for (int i = 0; i<disjunctsExp.Count; ++i)
            {
                Assert.AreEqual(disjunctsExp[i], disjuncts[i]);
            }
        }
    }
}
