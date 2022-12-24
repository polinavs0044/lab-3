using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace laba1
{
    class ResearchTeam: Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        protected string topic;
        protected TimeFrame info;
        List<Person> members;
        List<Paper> papersList;

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public TimeFrame Info
        {
            get { return info; }
            set { info = value; }
        }

        public List<Paper> PapersList
        {
            get { return papersList; }
            set { papersList = value; }
        }

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public ResearchTeam(string topic, string org, int regNum, TimeFrame info)
        {
            Topic = topic;
            this.OrgName = org;
            RegNum = regNum;
            Info = info;
            papersList = new List<Paper>();
            members = new List<Person>();
        }

        public ResearchTeam()
        {
            Topic = "Topic";
            OrgName = "NameOrg";
            RegNum = 1;
            Info = 0;
            papersList = new List<Paper>();
            members = new List<Person>();
        }

        public Paper LastPaper
        {
            get
            {
                return papersList.LastOrDefault();
            }
        }

        public bool this[TimeFrame timeFr]
        {
            get
            {
                if (timeFr == info) return true;
                else return false;
            }
        }

        public void AddPapers(params Paper[] p)
        {
            for (int i = 0, max = p.Length; i < max; i++)
                papersList.Add(p[i]);
        }

        public void AddMembers(params Person[] p)
        {
            for (int i = 0, max = p.Length; i < max; i++)
                members.Add(p[i]);
        }

        public Team ToBaseTeam
        {
            get
            {
                return new Team(orgName, regNum);
            }
            set
            {
                this.regNum = value.RegNum;
                this.orgName = value.OrgName;
            }
        }

        public override string ToString()
        {
            string s = "Topic: " +  topic + "; Organization: " + OrgName + "; Registration Number: " + RegNum + "; Information: " + info + "\n" + "     Papers:\n";
            for (int i = 0; i < papersList.Count; i++)
            {
                s += papersList[i].ToString();
                s += "\n";
            }
            s+= "  all   Members:\n";
            for (int i = 0; i < members.Count; i++)
            {
                s += members[i].ToString();
                s += "\n";
            }
            return s;
        }

        public virtual string ToShortString()
        {
            string s = topic + " " + OrgName + " " + RegNum + " " + info;
            return s;
        }

        public override object DeepCopy()
        {
            ResearchTeam temp = new ResearchTeam(this.topic, this.OrgName, this.RegNum, this.info);
            for (int i = 0, max = members.Count; i < max; i++)
            {
                Person p = new Person((members[i] as Person).Name, (members[i] as Person).LastName, (members[i] as Person).Birth);
                temp.AddMembers(p);
            }
            for (int i = 0, max = papersList.Count; i < max; i++)
            {
                Paper p = new Paper((papersList[i] as Paper).Title, (papersList[i] as Paper).Author, (papersList[i] as Paper).Date);
                temp.AddPapers(p);
            }
            return temp;           
        }

        public IEnumerable GetMemsNoPaps()
        {
            List<Person> temp = new List<Person>();
            bool flag = false;
            for (int i = 0, max = members.Count; i < max; i++)
            {
                for (int k = 0, max1 = papersList.Count; k < max1; k++)
                    if (papersList[k].Author.ToString() == members[i].ToString())
                    {
                        flag = true;
                        break;
                    }
                if (!flag) temp.Add(members[i]);
            }
            for (int i = 0, max = temp.Count; i < max; i++)
                yield return temp[i];
        }

        public IEnumerable GetMemsMuchPaps()
        {
            List<Person> temp = new List<Person>();
            int flag;
            for (int i = 0, max = members.Count; i < max; i++)
            {
                flag = 0;
                for (int k = 0, max1 = papersList.Count; k < max1; k++)
                    if (papersList[k].Author.ToString() == members[i].ToString())
                        flag ++;
                if (flag > 1) temp.Add(members[i]);
            }
            for (int i = 0, max = temp.Count; i < max; i++)
                yield return temp[i];
        }

        public IEnumerable GetLastPaps()
        {
            List<Paper> temp = new List<Paper>();
            for (int i = 0, max = papersList.Count; i < max; i++)
                if (papersList[i].Date > new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day))
                    temp.Add(papersList[i]);
            for (int i = 0, max = temp.Count; i < max; i++)
                yield return temp[i];
        }

        public IEnumerable GetPapForYears(int n)
        {
            DateTime dat = new DateTime(DateTime.Now.Year - n, DateTime.Now.Month, DateTime.Now.Day);
            List<Paper> temp = new List<Paper>();
            for (int k = 0, max1 = papersList.Count; k < max1; k++)
                if (papersList[k].Date > dat)
                    temp.Add(papersList[k]);
            for (int i = 0, max = temp.Count; i < max; i++)
                yield return temp[i];
        }

        public IEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(members, papersList);
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return System.String.Compare(x.Topic, y.Topic);
        }
    }
}
