
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
            sohesExp.Add(new List<string>(new string[] { "x1", "!x2" }));

            List<string> disjuncts = SLE.GetDisjuncts(exp);
            List<string> disjunctsExp = new List<string>();

            disjunctsExp.Add("x2 * x3 ");
            disjunctsExp.Add("x1 * !x2 ");

            SLE.OperationOfGluing(out sohes, ref disjuncts);

            Assert.AreEqual(2, sohes.Count);

            for (int i = 0; i < sohesExp.Count; ++i)
            {
                for(int j = 0; j<sohesExp[i].Count;++j)
                {
                    sohesExp[i][j]=sohes[i][j];
                }
            }

            Assert.AreEqual(2, disjuncts.Count);

            for(int i=0;i<disjuncts.Count;++i)
            {
                
            }
        }
    }
}
