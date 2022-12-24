using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class ResTeamCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            ResearchTeam x1 = x as ResearchTeam;
            ResearchTeam y1 = y as ResearchTeam;
            return x1.PapersList.Count.CompareTo(y1.PapersList.Count);
        }
    }
}
