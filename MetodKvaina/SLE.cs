﻿using System.Text.RegularExpressions;
using System.Text;

namespace MetodKvaina
{
    public struct Glued
    {
        public List<string> soch;
        public string lastName;
        public Glued()
        {
            soch = new List<string>();
            lastName = "";
        }
        public string ToExp()
        {
            StringBuilder builder = new StringBuilder($"{soch[0]} ");
            for(int i = 1; i < soch.Count; i++)
            {
                builder.Append($"* {soch[i]} ");
            }
            return builder.ToString();
        }
    }
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
            List<List<string>> sochetan;
            OperationOfGluing(out sochetan, ref disjuncts);

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
        public static List<List<string>> GetAllSoch(List<string> names)
        {
            List<List<string>> sochetania = new List<List<string>>();
            for(int i=names.Count-1;i>=0;--i)
            {
                List<string> sochetanie = new List<string>();
                for(int j=0;j<names.Count;++j)
                {
                    if (j!=i)
                        sochetanie.Add(names[j]);
                }
                sochetania.Add(sochetanie);
            }
            return sochetania;
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
                List<string> combination = new List<string>(namesCopy.Count);

                for (int j=0;j<namesCopy.Count;++j)
                {
                    combination.Add(WhatsName(namesCopy[j], namesCopy.Count-1-j, i));
                }

                allCombinations.Add(combination);
            }
            return allCombinations;
        }
        public static string WhatsName(string name,int currentposName,int globalPos)
        {
            int cycle = (int)Math.Pow(2, currentposName);
            if((globalPos/cycle) % 2==0)
            {
                name = '!' + name;
            }
            return name;
        }
        public static string OppositeName(string name)
        {
            if(name.Contains('!'))
            {
                name = name.Remove(0, 1);
            }
            else
            {
                name = '!'+name;
            }
            return name;
        }
        public static List<Glued> GLuedSoch(List<string> names,List<List<string>> soch)
        {
            List<Glued> nSoch = new List<Glued>();
            foreach(List<string> list in soch)
            {
                Glued glued = new Glued();
                glued.soch = list;
                glued.lastName = names.Find(x=>!list.Contains(x));
                nSoch.Add(glued);
            }
            return nSoch;
        }
        public static void OperationOfGluing(out List<List<string>> sochetania, ref List<string> disjuncts)
        {
            sochetania = new List<List<string>>();

            for(int i=0;i<disjuncts.Count-1;++i)
            {
                List<string> names = GetNamesFromExpression(disjuncts[i]);
                List<List<string>> sochet = GetAllSoch(names);
                List<Glued> sochl = GLuedSoch(names, sochet);
                int whatsoch = -1;

                for (int j=i+1;j<disjuncts.Count && whatsoch ==-1;++j)
                {
                    if (CanIGluedThey(disjuncts[j],sochl,out whatsoch))
                    {
                        disjuncts[i] = sochl[whatsoch].ToExp();
                        sochetania.Add(sochl[whatsoch].soch);
                        disjuncts.Remove(disjuncts[j]);
                    }
                }
            }
        }
        static public bool CanIGluedThey(string expression,List<Glued> glueds,out int whatSoch)
        {
            bool isGludable = false;
            whatSoch = -1;
            expression = ' ' + expression;
            for(int i=0;i<glueds.Count && !isGludable;++i)
            {
                string RegEx = GetSh1RegularExp(glueds[i].soch);

                if(Regex.IsMatch(expression,RegEx) && expression.Contains(OppositeName(glueds[i].lastName)))
                {
                    isGludable = true;
                    whatSoch = i;
                }
            }
            expression = expression.Remove(0, 1);
            return isGludable;
        }
        public static string GetSh1RegularExp(List<string> names)
        {
            StringBuilder Fullexp = new StringBuilder();
            StringBuilder exp = new StringBuilder(".*[^!]");
            StringBuilder partOfExpression = new StringBuilder($"({names[0]}");

            for(int i=1;i<names.Count;++i)
            {
                partOfExpression.Append($"|{names[i]}");
            }

            partOfExpression.Append(')');
            exp.Append(partOfExpression);

            for(int i=0;i<names.Count;++i)
            {
                Fullexp.Append(exp);
            }
            return Fullexp.ToString();
        }
    }
}