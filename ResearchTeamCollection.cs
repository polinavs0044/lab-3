using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba1
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> resT;

        public void AddDefaults()
        {
            resT = new List<ResearchTeam>();
        }

        public void AddResearchTeams(params ResearchTeam[] p)
        {
            for (int i = 0; i < p.Length; i++)
                resT.Add(p[i]);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < resT.Count; i++)
                s += resT[i].ToString() + "\n";
            return s;
        }

        public virtual string ToShortString()
        {
            string s = "";
            for (int i = 0; i < resT.Count; i++)
                s += resT[i].ToShortString() 
                    + " Публикаций: " 
                    + resT[i].PapersList.Count 
                    + " Участников: " 
                    + resT[i].Members.Count
                    + "\n";
            return s;
        }

        public void SortRegNum()
        {
            resT.Sort();
        }

        public void SortTopic()
        {
            resT.Sort(new ResearchTeam().Compare);
        }

        public void SortNumPapers()
        {
            resT.Sort(new ResTeamCompare().Compare);
        }

        public int MinRegNum
        {
            get
            {
                if (resT.Count != 0)
                {
                    return resT.Min(resTeam => resTeam.RegNum);
                }
                else return -1; 
            }
        }

        public IEnumerable<ResearchTeam> TwoYears
        {
            get
            {
                return resT.Where(resTeam => resTeam.Info == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> NGroup(int n)
        {
            var query = resT.GroupBy(x => x.PapersList.Count);
            foreach (var group in query)
                if (group.Key == n) return group.ToList();
            return new List<ResearchTeam>();
        }
    }
}
