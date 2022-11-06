using System.Text.RegularExpressions;
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
    public struct Coverage
    {
        public static int countOfDisjuncts;
        public List<string> implicants;
        public List<int> coveregDisjuncts;
        public Coverage()
        {
            implicants = new List<string>();
            coveregDisjuncts = new List<int>();
        }
        static Coverage()
        {
            countOfDisjuncts = 0;
        }
        public bool isCover()
        {
            bool isCov = true;
            for(int i=0;i<countOfDisjuncts && isCov;++i)
            {
                if (!coveregDisjuncts.Contains(i))
                    isCov = false;
            }
            return isCov;
        }
    }
    public class Coveric
    {
        public string implicant;
        public List<int> covered;
        public Coveric()
        {
            implicant = "";
            covered = new List<int>();
        }
    }

    public static class SLE// !x2 - good x2! - bad x!2 - bad
    {
        public static string GetMinimumForm(string SDNF)
        {

            List<string> disjuncts = GetDisjuncts(SDNF);

            List<string> implicants = GetSimplifiedForm(disjuncts);

            Coverage.countOfDisjuncts = disjuncts.Count;

            Coverage minCov = new Coverage();

            int countOfCover = implicants.Count;

            bool isCovered = true;

            while(isCovered && countOfCover>1)
            {
                --countOfCover;
                isCovered = false;

                List<Coverage> coverages = GetCoverage(disjuncts, implicants, countOfCover);

                for(int i=0;i<coverages.Count && !isCovered;++i)
                {
                    if (coverages[i].isCover())
                    {
                        isCovered = true;
                        minCov = coverages[i];
                    }
                }
                
            }

            StringBuilder minform = new StringBuilder("");

            foreach(string imp in minCov.implicants)
            {
                minform.Append($" {imp}+");
            }

            minform = minform.Remove(minform.Length-1, 1);

            return minform.ToString();
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
        public static List<string> GetSimplifiedForm(List<string> disjuncts)
        {
            List<List<string>> implicants;
            OperationOfGluing(out implicants, disjuncts);
            implicants = UniqueSoches(implicants);
            return GetImplicants(in implicants);
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
        public static List<List<T>> GetAllSoch<T>(List<T> names)
        {
            List<List<T>> sochetania = new List<List<T>>();
            for(int i=names.Count-1;i>=0;--i)
            {
                List<T> sochetanie = new List<T>();
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
        public static void OperationOfGluing(out List<List<string>> implicants, List<string> disjuncts)
        {
            implicants = new List<List<string>>();

            for(int i=0;i<disjuncts.Count-1;++i)
            {
                List<string> names = GetNamesFromExpression(disjuncts[i]);
                List<List<string>> sochet = GetAllSoch(names);
                List<Glued> sochl = GLuedSoch(names, sochet);
                int whatsoch = -1;

                for (int j=i+1;j<disjuncts.Count;++j)
                {
                    if (CanIGluedThey(disjuncts[j],sochl,out whatsoch))
                    {
                        implicants.Add(sochl[whatsoch].soch);
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
        public static List<List<T>> UniqueSoches<T>(List<List<T>> soches)
        {
            List<List<T>> uniqueSoches = new List<List<T>>();

            foreach(List<T>  list in soches)
            {
                bool isUnique = true;
                for(int i=0;i<uniqueSoches.Count && isUnique;++i)
                {
                    bool isUniqueElem = false;
                    for(int j=0;j<uniqueSoches[i].Count && !isUniqueElem;++j)
                    {
                        if (!uniqueSoches[i].Contains(list[j]))
                            isUniqueElem = true;
                    }
                    isUnique = isUniqueElem;
                }

                if(isUnique)
                    uniqueSoches.Add(list);
            }
            return uniqueSoches;
        }
        public static List<string> UniqueDisjuncts(List<string> disjuncts)
        {
            List<string> unDisjuncts = new List<string>();
            for(int i=0;i<disjuncts.Count;++i)
            {
                bool isUnique = true;
                for(int j=0;j<unDisjuncts.Count && isUnique;++j)
                {
                    bool isUniqueElem = false;
                    List<string> names1 = GetNamesFromExpression(unDisjuncts[j]);
                    List<string> names2 = GetNamesFromExpression(disjuncts[i]);
                    if(names1.Count==names2.Count)
                    {
                        for (int g = 0; g<names2.Count; ++g)
                        {
                            if (!names1.Contains(names2[g]))
                                isUniqueElem = true;
                        }
                    }
                    else
                    {
                        isUniqueElem = true;
                    }
                   
                    isUnique = isUniqueElem;
                }

                if (isUnique)
                    unDisjuncts.Add(disjuncts[i]);
            }
            return unDisjuncts;
        }
        public static void OperationOfMerge(in List<List<string>> soches,ref List<string> disjuncts)
        {
            for(int i = 0;i<disjuncts.Count;++i)
            {
                int countOfNames = GetNamesFromExpression(disjuncts[i]).Count;
                bool isRemoved = false;
                for (int j=0;j<soches.Count && countOfNames>soches[j].Count && !isRemoved; ++j)
                {
                    string regExp = GetSh1RegularExp(soches[j]);

                    if (Regex.IsMatch(disjuncts[i],regExp) )
                    {
                        disjuncts.Remove(disjuncts[i]);
                        isRemoved = true;
                        --i;
                    }
                }
            }
        }
        public static List<string> GetImplicants(in List<List<string>> implicants)
        {
            List<string> imp = new List<string>();
            foreach (var implicant in implicants)
            {   
                StringBuilder impl = new StringBuilder($"{implicant[0]} ");

                for(int i=1;i<implicant.Count;++i)
                {
                    impl.Append($"* {implicant[i]} ");
                }

                imp.Add(impl.ToString());
            }
            return imp;
        }
        public static List<Coverage> GetCoverage(in List<string> disjuncts, in List<string> implis,int countOfCover)
        {
            List<Coverage> coverages = new List<Coverage>();

            List<Coveric> coverics = new List<Coveric>();

            foreach(var impl in implis)
            {
                Coveric coveric = new Coveric();

                coveric.implicant = impl;

                for(int i=0;i<disjuncts.Count;++i)
                {
                    string RegExp = GetSh1RegularExp(GetNamesFromExpression(impl));
                    if (Regex.IsMatch(disjuncts[i],RegExp))
                    {
                        coveric.covered.Add(i);
                    }
                }
                coverics.Add(coveric);
            }

            List<List<Coveric>> sochCov = GetAllSoch(coverics);

            for(int i=1;i<implis.Count - countOfCover;++i)
            {
                List<List<Coveric>> newSochCov = new List<List<Coveric>>();

                for(int j=0;j<sochCov.Count;++j)
                {
                    List<List<Coveric>> hohoho = GetAllSoch(sochCov[j]);

                    foreach(List<Coveric> elem in hohoho)
                    {
                        newSochCov.Add(elem);
                    }
                }

                newSochCov = UniqueSoches(newSochCov);

                sochCov = newSochCov;
            }

            foreach(List<Coveric> coverics1 in sochCov)
            {
                Coverage coverage = new Coverage();
                foreach(Coveric coveric2 in coverics1)
                {
                    coverage.implicants.Add(coveric2.implicant);
                    coverage.coveregDisjuncts.AddRange(coveric2.covered);
                }
                coverages.Add(coverage);
            }
           
            return coverages;
        }
        public static List<string> GetMinImp(string SDNF,List<string> sokrImplicants)
        {
            List<string> minimum = new List<string>();

            return minimum;
        }
    }
}