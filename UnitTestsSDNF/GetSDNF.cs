
using System.Text.RegularExpressions;

namespace UnitTestsSDNF
{
    [TestClass]
    public class GetSDNF
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = "( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )";
            string actSDNF = SDNF.GetSDNF(expression);
            bool res = Regex.IsMatch(actSDNF, ".*(!x [*] !y [*] z).*(!x [*] y [*] !z).*(!x [*] y [*] z).*(x [*] !y [*] !z).*(x [*] !y [*] z).*(x [*] y [*] !z).*");
            Assert.IsTrue(res);
        }
    }
}
