
using System.Text.RegularExpressions;

namespace UnitTests
{
    [TestClass]
    public class GetMinimumForm
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = " !x1 * !x2 * !x3 * !x4 + !x1 * !x2 * !x3 * x4 + !x1 * !x2 * x3 * !x4 + !x1 * x2 * x3 * !x4 + x1 * x2 * x3 * !x4 + x1 * x2 * x3 * x4 ";
            string MinForm = SLE.GetMinimumForm(expression);
            bool isMatch = Regex.IsMatch(MinForm, ".*(!x1|!x2|!x3).*(!x1|!x2|!x3).*(!x1|!x2|!x3).*(!x1|x3|!x4).*(!x1|x3|!x4).*(!x1|x3|!x4).*(x1|x2|x3).*(x1|x2|x3).*(x1|x2|x3)");
            Assert.AreEqual(true, isMatch);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string expression = " x * y * z +  x * y * !z +  x * !y * !z + !x * !y * !z +  !x * y * z +  !x * !y * z ";
            string MinForm = SLE.GetMinimumForm(expression);
            bool isMatch = Regex.IsMatch(MinForm, ".*(x|y).*(x|y).*(!y|!z).*(!y|!z).*(!x|z).*(!x|z)");
            if(!isMatch)
                isMatch = Regex.IsMatch(MinForm, ".*(y|z).*(y|z).*(x|!z).*(x|!z).*(!x|!y).*(!x|!y)");
            Assert.AreEqual(true, isMatch);
        }
    }
}
