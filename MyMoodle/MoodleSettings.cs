using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodle
{
    [Serializable]
    class MoodleSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public CourseData[] CourseDetails { get; set; }


        public int SyncInterval { get; set; }
        public MoodleSettings()
        {
            UserName = "";
            Password = "";
            CourseDetails = new CourseData[0];
            SyncInterval = 60;
        }

        [Serializable]
        internal class CourseData
        {
            public string CourseName { get; set; }
            public string CourseUrl { get; set; }

            public CourseData(string courseName,string url)
            {
                CourseName = courseName;
                CourseUrl = url;
            }
        }
    }
}
