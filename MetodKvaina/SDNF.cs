using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string oper= "";
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
        public static bool Operation(bool x, bool y,Operations operation)
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
        public static bool GetResult(List<string> names,List<string> boolNames,string expression)
        {
            StringBuilder expCopy = new StringBuilder(expression);
            List<int> bools = new List<int>();
            Regex regExpSh1 = new Regex("[!]*[(]{1}[^()]*[)]{1}");
            
            foreach (string bName in boolNames)
            {
                if (bName.Contains('!'))
                    bools.Add(0);
                else
                    bools.Add(1);
            }

            ReplaceToInt(ref expression, bools, names);

            while(expCopy.ToString().Contains('('))
            {
                regExpSh1.Replace(expression,ResultExp(regExpSh1.Match(expression).ToString()).ToString());
            }

            return ResultExp(expression)==1 ? true : false;
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

            while(regExpSh1.IsMatch(medExp))
            {
                regExpSh1.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh2.IsMatch(medExp))
            {
                regExpSh2.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh3.IsMatch(medExp))
            {
                regExpSh3.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh4.IsMatch(medExp))
            {
                regExpSh4.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh5.IsMatch(medExp))
            {
                regExpSh5.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh6.IsMatch(medExp))
            {
                regExpSh6.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }
            while (regExpSh7.IsMatch(medExp))
            {
                regExpSh7.Replace(medExp, ResultOperation(regExpSh1.Match(medExp).ToString()).ToString());
            }

            return res;
        }
        public static int ResultOperation(string smallExp)
        {
            int res = 0;
            bool x=false, y=false;
            Operations operation = Operations.or;

            if(Regex.IsMatch(smallExp,"[^!][*]"))
            {
                operation = Operations.and;
            }
            else if(Regex.IsMatch(smallExp, "[^!][+]"))
            {
                operation = Operations.or;
            }
            else if(smallExp.Contains("=="))
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

            if(Regex.IsMatch(smallExp,"[0].*[0]"))
            {
                x=false;
                y=false;
            }
            else if (Regex.IsMatch(smallExp, "[0].*[1]"))
            {
                x=false;
                y=true;
            }
            else if(Regex.IsMatch(smallExp, "[1].*[0]"))
            {
                x=true;
                y=false;
            }
            else if (Regex.IsMatch(smallExp, "[1].*[1]"))
            {
                x=true;
                y=true;
            }
            res = Operation(x, y, operation)?1:0;
            return res;
        }
        public static void ReplaceToInt(ref string expression, List<int> bools, List<string> names)
        {
            for (int i = 0; i<names.Count; ++i)
            {
                expression = Regex.Replace(expression, $"[!]({names[i]})", $"{(bools[i]==1 ? 0 : 1)}");
                expression = Regex.Replace(expression, $@"[^!\s]*({names[i]})", $"{bools[i]}");
            }
        }
        public static string GetSDNF(string expression)
        {
            string sdnf="";
            List<string> names = SLE.GetNamesFromExpression(expression);
            CleanNames(names);
            List<List<string>> allcomb = SLE.GetAllCombinations(names);
            List<List<string>> sdnfCombs = GetCombs(names, allcomb, expression);
            return sdnf;
        }
        public static void CleanNames(List<string> names)
        {
            for(int i=0;i<names.Count;++i)
            {
                if (names[i].Contains('!'))
                    names[i] = names[i].Remove(0, 1);
            }
        }
        public static List<List<string>> GetCombs(List<string> names,List<List<string>> allcomb,string expression)
        {
            List<List<string>> needCombs = new List<List<string>>();

            foreach (List<string> comb in allcomb)
            {
                if (GetResult(names, comb, expression))
                    needCombs.Add(comb);
            }
            return needCombs;
        }
    }
}
