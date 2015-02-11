using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodle
{

    class Course
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public HtmlAgilityPack.HtmlNode[] RecentActivityData { get; set; }

        public HtmlAgilityPack.HtmlNode[] UpcomingEvents { get; set; }

        public Course(string url)
        {
            this.Url = url;
            this.Title = "";
            this.RecentActivityData = new HtmlAgilityPack.HtmlNode[0];
            this.UpcomingEvents = new HtmlAgilityPack.HtmlNode[0];
        }
    }
}
