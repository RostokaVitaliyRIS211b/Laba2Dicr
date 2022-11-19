
namespace UnitTests
{
    [TestClass]
    public class OperationOfMerge
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = " x1 * x2  + !x2 * x3  + x1 * !x2 * x3 + x1 * x2 * !x3";
            List<string> disjuncts = SLE.GetDisjuncts(expression);
            List<string> disjunctsExp = new List<string>();

            disjunctsExp.Add("  x1 * x2  ");
            disjunctsExp.Add("  !x2 * x3  ");

            List<List<string>> soches = new List<List<string>>();
            soches.Add(new List<string>(new string[] { "x1", "x2" }));
            soches.Add(new List<string>(new string[] { "!x2", "x3" }));

            SLE.OperationOfMerge(in soches, ref disjuncts);

            Assert.AreEqual(2, disjuncts.Count);

            for(int i=0;i<disjuncts.Count;++i)
            {
                Assert.AreEqual(disjunctsExp[i], disjuncts[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string expression = " x1 * x2 * x4  + !x2 * x3 * x4  + x1 * !x2 * x3 * x4 + x1 * x2 * !x3 * x4";
            List<string> disjuncts = SLE.GetDisjuncts(expression);
            List<string> disjunctsExp = new List<string>();

            disjunctsExp.Add("  x1 * x2 * x4  ");
            disjunctsExp.Add("  !x2 * x3 * x4  ");

            List<List<string>> soches = new List<List<string>>();
            soches.Add(new List<string>(new string[] { "x1", "x2","x4" }));
            soches.Add(new List<string>(new string[] { "!x2", "x3","x4" }));

            SLE.OperationOfMerge(in soches, ref disjuncts);

            Assert.AreEqual(2, disjuncts.Count);

            for (int i = 0; i<disjuncts.Count; ++i)
            {
                Assert.AreEqual(disjunctsExp[i], disjuncts[i]);
            }
        }
    }
}
