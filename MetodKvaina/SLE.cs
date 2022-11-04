using System.Text.RegularExpressions;
using System.Text;

namespace MetodKvaina
{
    public static class SLE
    {
        public static string GetMinimumForm(string SDNF)
        {
            string minForm = SDNF;
            return minForm;
        }
        public static string GetSDNF(string logicalExpression)
        {
            string SDNF = logicalExpression;
            return SDNF;
        }
        public static List<string> GetDisjuncts(string Expression)
        {
            List<string> disjuncts = Expression.Split('+').ToList();
            return disjuncts;
        }
        public static List<string> GetSimplifiedForm(string expression,List<string> disjuncts)
        {
            List<string> sokrExpression = new List<string>();
            return sokrExpression;
        }
        public static List<string> GetNamesFromExpression(string expression)
        {
            List<string> names = new List<string>();
            StringBuilder name = new StringBuilder();
            for(int i=0;i<expression.Length;++i)
            {
                name.Append(expression[i]);
                if(Regex.IsMatch(name.ToString(), @"[\W_,.;:.!?-]"))
                {
                    if(name.Length>1)
                    {
                        name.Remove(name.Length-1, 1);
                        if(!Regex.IsMatch(name.ToString(), @"^\d+$"))
                            names.Add(name.ToString());
                    }
                    name.Clear();
                }
            }
            return names;
        }
    }
}