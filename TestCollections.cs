using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class TestCollections
    {
        private List<Team> teams;
        private List<string> strs;
        private Dictionary<Team, ResearchTeam> dic1;
        private Dictionary<string, ResearchTeam> dic2;

        public TestCollections(int n)
        {
            teams = new List<Team>();
            strs = new List<string>();
            dic1 = new Dictionary<Team, ResearchTeam>();
            dic2 = new Dictionary<string, ResearchTeam>();
            for (int i = 1; i <= n; i++)
            {
                ResearchTeam rt = LinkResT(i);
                teams.Add(rt.ToBaseTeam);
                strs.Add(rt.ToShortString());
                dic1.Add(rt.ToBaseTeam, rt);
                dic2.Add(rt.ToShortString(), rt);
            }
        }

        public static ResearchTeam LinkResT(int res)
        {
            return new ResearchTeam(res.ToString(), res.ToString(), res, TimeFrame.Year);
        }


        public void SearchTime(int size)
        {
            int time0;
            int time1;
            Console.WriteLine();
            Console.WriteLine("  ПОИСК ПЕРВОГО ЭЛЕМЕНТА");
            time0 = Environment.TickCount;
            if (teams.Contains(teams[0]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<Team>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (strs.Contains(strs[0]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<string>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsKey(teams[0]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsValue(LinkResT(1)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по значению): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic2.ContainsKey(strs[0]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            if (dic2.ContainsValue(LinkResT(1)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по значению): " + (time1 - time0));
            }

            Console.WriteLine();
            Console.WriteLine("  ПОИСК СРЕДНЕГО ЭЛЕМЕНТА");
            time0 = Environment.TickCount;
            if (teams.Contains(teams[size/2]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<Team>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (strs.Contains(strs[size / 2]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<string>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsKey(teams[size / 2]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsValue(LinkResT(size / 2)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по значению): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic2.ContainsKey(strs[size / 2]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            if (dic2.ContainsValue(LinkResT(size / 2)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по значению): " + (time1 - time0));
            }

            Console.WriteLine();
            Console.WriteLine("  ПОИСК ПОСЛЕДНЕГО ЭЛЕМЕНТА");
            time0 = Environment.TickCount;
            if (teams.Contains(teams[size - 1]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<Team>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (strs.Contains(strs[size - 1]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<string>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsKey(teams[size - 1]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic1.ContainsValue(LinkResT(size)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по значению): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (dic2.ContainsKey(strs[size - 1]))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            if (dic2.ContainsValue(LinkResT(size)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по значению): " + (time1 - time0));
            }

            Console.WriteLine();
            Console.WriteLine("  ПОИСК ОТСУТСТВУЮЩЕГО ЭЛЕМЕНТА");
            time0 = Environment.TickCount;
            if (!teams.Contains(LinkResT(size + 1).ToBaseTeam))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<Team>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (!strs.Contains(LinkResT(size + 1).ToShortString()))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("List<string>: " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (!dic1.ContainsKey(LinkResT(size + 1).ToBaseTeam))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (!dic1.ContainsValue(LinkResT(size + 1)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> (по значению): " + (time1 - time0));
            }
            time0 = Environment.TickCount;
            if (!dic2.ContainsKey(LinkResT(size + 1).ToShortString()))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по ключу): " + (time1 - time0));
            }
            if (!dic2.ContainsValue(LinkResT(size + 1)))
            {
                time1 = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> (по значению): " + (time1 - time0));
            }
        }
    }
}
