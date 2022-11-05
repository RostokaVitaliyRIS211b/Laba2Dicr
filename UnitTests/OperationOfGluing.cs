
namespace UnitTests
{
    [TestClass]
    public class OperationOfGluing
    {
        [TestMethod]
        public void TestMethod1()
        {
            string exp = "x1 *x2 *x3 + !x1 * x2 * x3 + !x3 * x1 * !x2 + x1 * !x2 * x3";

            List<List<string>> sohes;
            List<List<string>> sohesExp = new List<List<string>>();

            sohesExp.Add(new List<string>(new string[] {"x2","x3"}));
            sohesExp.Add(new List<string>(new string[] { "x1", "x3" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2" }));

            List<string> disjuncts = SLE.GetDisjuncts(exp);

            SLE.OperationOfGluing(out sohes, disjuncts);

            Assert.AreEqual(3, sohes.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for(int j = 0; j<sohesExp[i].Count;++j)
                {
                    sohesExp[i][j]=sohes[i][j];
                }
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string exp = "x1 *x2 *x3 * x4 + x1 * x2 * x3 *!x4 + !x3 * x1 * !x2 *x4 + x1 * !x2 * x3 * x4";

            List<List<string>> sohes;
            List<List<string>> sohesExp = new List<List<string>>();

            sohesExp.Add(new List<string>(new string[] { "x1","x2", "x3" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "x3", "x4" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2","x4" }));

            List<string> disjuncts = SLE.GetDisjuncts(exp);

            SLE.OperationOfGluing(out sohes, disjuncts);

            Assert.AreEqual(3, sohes.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for (int j = 0; j<sohesExp[i].Count; ++j)
                {
                    sohesExp[i][j]=sohes[i][j];
                }
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            string exp = "x1 *x2 *x3 * x4 + x1 * x2 * x3 *!x4 + !x3 * x1 * !x2 *x4 + x1 * !x2 * x3 * x4 + !x1 * !x2 * !x3 * !x4";

            List<List<string>> sohes;
            List<List<string>> sohesExp = new List<List<string>>();

            sohesExp.Add(new List<string>(new string[] { "x1", "x2", "x3" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "x3", "x4" }));
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2", "x4" }));

            List<string> disjuncts = SLE.GetDisjuncts(exp);

            SLE.OperationOfGluing(out sohes, disjuncts);

            Assert.AreEqual(3, sohes.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for (int j = 0; j<sohesExp[i].Count; ++j)
                {
                    sohesExp[i][j]=sohes[i][j];
                }
            }
        }
    }
}
