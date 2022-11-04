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
            List<List<string>> allCombinationsOfNames = new List<List<string>>();

            return sokrExpression;
        }
        public static List<string> GetNamesFromExpression(string expression)
        {
            List<string> names = new List<string>();
            StringBuilder name = new StringBuilder();
            expression += ' ';
            for(int i=0;i<expression.Length;++i)
            {
                name.Append(expression[i]);
                if(Regex.IsMatch(name.ToString(), @"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Lm}!]"))
                {
                    if (name.Length>1)
                    {
                        name.Remove(name.Length-1, 1);
                        if (!Regex.IsMatch(name.ToString(), @"^\d+$"))
                            names.Add(name.ToString());
                    }
                    name.Clear();
                }
            }
            expression = expression.Remove(expression.Length-1, 1);
            return names;
        }
        public static List<List<string>> GetAllCombinations(List<string> names)
        {
            List<List<string>> allCombinations = new List<List<string>>((int)Math.Pow(2, names.Count));
            List<string> namesCopy = new List<string>(names);
            for(int i=0;i<names.Count;++i)
            {
                if (namesCopy[i].Contains('!'))
                    namesCopy[i]=namesCopy[i].Remove(0, 1);
            }

            for(int i=0;i<(int)Math.Pow(2,names.Count);++i)
            {
                List<string> combination = new List<string>(names.Count);
            }
            return allCombinations;
        }
    }
}