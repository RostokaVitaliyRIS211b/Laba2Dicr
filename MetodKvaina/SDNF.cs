using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        xand,
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
            bool res = false;
            StringBuilder expCopy = new StringBuilder(expression);
            List<int> bools = new List<int>();
            foreach (string bName in boolNames)
            {
                if (bName.Contains(!))
                    bools.Add(0);
                else
                    bools.Add(1);
            }
            while(expCopy.Length>1)
            {

            }
            return res;
        }
        public static bool ResultOperation(string smallExp)
        {
            bool res = false;

            return res;
        }
        public static string GetSDNF(string expression)
        {
            string sdnf="";
            List<string> names = SLE.GetNamesFromExpression(expression);
            List<List<string>> allcomb = SLE.GetAllCombinations(names);
            List<List<string>> sdnfCombs = GetCombs(names, allcomb, expression);
            return sdnf;
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
