using System.Text;
using System.Text.RegularExpressions;

namespace MetodKvaina
{
    public enum Operations
    {
        or,
        and,
        equal,
        xequal,
        implict,
        xor,
        xand
    }

    public static class ExOper
    {
        public static string ToString(this Operations operation)
        {
            string oper = "";
            switch (operation)
            {
                case Operations.or:
                    oper = "+";
                    break;
                case Operations.and:
                    oper = "*";
                    break;
                case Operations.equal:
                    oper = "==";
                    break;
                case Operations.xequal:
                    oper = "!=";
                    break;
                case Operations.implict:
                    oper = "->";
                    break;
                case Operations.xor:
                    oper = "!+";
                    break;
                case Operations.xand:
                    oper = "!*";
                    break;
            }

            return oper;
        }
    }
    public static class SDNF
    {
        public static bool Operation(bool x, bool y, Operations operation)
        {
            bool answ = false;
            switch (operation)
            {
                case Operations.or:
                    answ = x || y;
                    break;
                case Operations.and:
                    answ = x && y;
                    break;
                case Operations.equal:
                    answ = x == y;
                    break;
                case Operations.xequal:
                    answ = x != y;
                    break;
                case Operations.implict:
                    answ = !x || y;
                    break;
                case Operations.xor:
                    answ = !(x || y);
                    break;
                case Operations.xand:
                    answ = !(x && y);
                    break;
            }

            return answ;
        }
        public static bool GetResult(List<string> names, List<string> boolNames, in string expression)
        {
            string hehe = new string(expression);
            List<int> bools = new List<int>();
            Regex regExpSh1 = new Regex("[!]*[(]{1}[^()]*[)]{1}");

            foreach (string bName in boolNames)
            {
                if (bName.Contains('!'))
                    bools.Add(0);
                else
                    bools.Add(1);
            }

            ReplaceToInt(ref hehe, bools, names);

            MatchEvaluator matchEvaluator = x => ResultExp(x.ToString()).ToString();

            while (hehe.ToString().Contains('('))
            {
                hehe = regExpSh1.Replace(hehe, matchEvaluator);
            }

            return ResultExp(hehe)==1 ? true : false;
        }
        public static int ResultExp(string medExp)
        {
            int res = 0;
            Regex regExpSh1 = new Regex(@"[01]{1}[\s]*[*]{1}[\s]*[01]{1}");
            Regex regExpSh2 = new Regex(@"[01]{1}[\s]*[+]{1}[\s]*[01]{1}");
            Regex regExpSh3 = new Regex(@"[01]{1}[\s]*(!=)[\s]*[01]{1}");
            Regex regExpSh4 = new Regex(@"[01]{1}[\s]*(->)[\s]*[01]{1}");
            Regex regExpSh5 = new Regex(@"[01]{1}[\s]*(==)[\s]*[01]{1}");
            Regex regExpSh6 = new Regex(@"[01]{1}[\s]*(![*]){1}[\s]*[01]{1}");
            Regex regExpSh7 = new Regex(@"[01]{1}[\s]*(![+]){1}[\s]*[01]{1}");

            MatchEvaluator matchEvaluator = x => ResultOperation(x.ToString()).ToString();
            MatchEvaluator matchEvaluator2 = x => RasBraces(x.ToString());

            while (regExpSh6.IsMatch(medExp))
            {
                medExp = regExpSh6.Replace(medExp, matchEvaluator2);
            }
            while (regExpSh7.IsMatch(medExp))
            {
                medExp = regExpSh7.Replace(medExp, matchEvaluator2);
            }
            while (regExpSh1.IsMatch(medExp))
            {
                medExp = regExpSh1.Replace(medExp, matchEvaluator);
            }
            while (regExpSh2.IsMatch(medExp))
            {
                medExp = regExpSh2.Replace(medExp, matchEvaluator);
            }
            while (regExpSh3.IsMatch(medExp))
            {
                medExp = regExpSh3.Replace(medExp, matchEvaluator);
            }
            while (regExpSh4.IsMatch(medExp))
            {
                medExp = regExpSh4.Replace(medExp, matchEvaluator);
            }
            while (regExpSh5.IsMatch(medExp))
            {
                medExp = regExpSh5.Replace(medExp, matchEvaluator);
            }

            if (medExp.Contains('1'))
                res = 1;
            else
                res = 0;
            return res;
        }
        public static int ResultOperation(string smallExp)
        {
            int res = 0;
            bool x = false, y = false;
            Operations operation = Operations.or;

            if (Regex.IsMatch(smallExp, "[^!][*]"))
            {
                operation = Operations.and;
            }
            else if (Regex.IsMatch(smallExp, "[^!][+]"))
            {
                operation = Operations.or;
            }
            else if (smallExp.Contains("=="))
            {
                operation = Operations.equal;
            }
            else if (smallExp.Contains("!="))
            {
                operation = Operations.xequal;
            }
            else if (smallExp.Contains("->"))
            {
                operation = Operations.implict;
            }
            else if (smallExp.Contains("!+"))
            {
                operation = Operations.xor;
            }
            else if (smallExp.Contains("!*"))
            {
                operation = Operations.xand;
            }

            if (Regex.IsMatch(smallExp, "[0].*[0]"))
            {
                x=false;
                y=false;
            }
            else if (Regex.IsMatch(smallExp, "[0].*[1]"))
            {
                x=false;
                y=true;
            }
            else if (Regex.IsMatch(smallExp, "[1].*[0]"))
            {
                x=true;
                y=false;
            }
            else if (Regex.IsMatch(smallExp, "[1].*[1]"))
            {
                x=true;
                y=true;
            }
            res = Operation(x, y, operation) ? 1 : 0;
            return res;
        }
        public static string RasBraces(string match)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            for (int i = 0; i<match.Length; ++i)
            {
                if (match[i]=='0')
                {
                    stringBuilder.Append('1');
                }
                else if (match[i]=='1')
                {
                    stringBuilder.Append('0');
                }
                else if (match[i]=='*')
                {
                    stringBuilder.Append('+');
                }
                else if (match[i]=='+')
                {
                    stringBuilder.Append('*');
                }
                else if (match[i]!='!')
                {
                    stringBuilder.Append(match[i]);
                }
            }
            return stringBuilder.ToString();
        }
        public static void ReplaceToInt(ref string expression, List<int> bools, List<string> names)
        {
            for (int i = 0; i<names.Count; ++i)
            {
                expression = Regex.Replace(expression, $"[!]({names[i]})", $"{(bools[i]==1 ? 0 : 1)}");
                expression = Regex.Replace(expression, $@"[^!\s()]*({names[i]})", $"{bools[i]}");
            }
        }
        public static string GetSDNF(string expression)
        {
            string sdnf = "";
            List<string> names = GetNamesSDNF(expression);
            List<List<string>> allcomb = SLE.GetAllCombinations(names);
            List<List<string>> sdnfCombs = GetCombs(names, allcomb, expression);
            return sdnf;
        }
        public static void CleanNames(List<string> names)
        {
            for (int i = 0; i<names.Count; ++i)
            {
                if (names[i].Contains('!'))
                    names[i] = names[i].Remove(0, 1);
            }
        }
        public static List<List<string>> GetCombs(List<string> names, List<List<string>> allcomb, string expression)
        {
            List<List<string>> needCombs = new List<List<string>>();

            foreach (List<string> comb in allcomb)
            {
                if (GetResult(names, comb,in expression))
                    needCombs.Add(comb);
            }
            return needCombs;
        }
        public static List<string> GetNamesSDNF(string expression)
        {
            List<string> names = new List<string>();
            Regex regex = new Regex(@"[a-zA-Z0-9]+");
            List<Match> matches = Regex.Matches(expression, @"[a-zA-Z0-9]+").ToList();
            foreach(Match match in matches)
            {
                if (!names.Contains(match.ToString()))
                    names.Add(match.ToString());
            }
            return names;
        }
    }
}
