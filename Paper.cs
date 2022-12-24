using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public enum TimeFrame { Year, TwoYears, Long };

    class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime Date { get; set; }

        public Paper(string title, Person author, DateTime date)
        {
            Title = title;
            Author = author;
            Date = date;
        }

        public Paper()
        {
            Title = "NoTitle";
            Author = new Person();
            Date = new DateTime(1900, 1, 1);
        }

        public override string ToString()
        {
            string s = "Title: " + Title + "; Author: " + Author.ToString() + "; Date: " + Date.ToLongDateString();
            return s;
        }
    }
}
