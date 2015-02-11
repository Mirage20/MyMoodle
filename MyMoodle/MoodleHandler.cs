using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace MyMoodle
{
    
    class MoodleHandler
    {

        private volatile bool isFirstLogin;
        private volatile Moodle myMoodle = null;
        private string userName = "";
        private string password = "";
        private volatile Course[] courses;       
        private Action<bool, string, ToolTipIcon, int> balloonShow;
        private Action<int, string> updateList;
        private Action<string, string, string> updateRecentList;
        private Action updateSyncTime;

        public Action UpdateSyncTime
        {
            
            set { updateSyncTime = value; }
        }

        public Action<string, string, string> UpdateRecentList
        {
            
            set { updateRecentList = value; }
        }

        public Action<int, string> UpdateList
        {           
            set { updateList = value; }
        }

        internal Course[] Courses
        {
            get { return courses; }
        }

        int changesCount = 0;

        public int ChangesCount
        {
            get
            {
                return changesCount;
            }
            set
            {
                if (value == 0)
                    changesCount = value;
            }
            
        }

        public MoodleHandler(Action <bool, string, ToolTipIcon, int> notify, string userName, string password)
        {
            this.myMoodle = new Moodle();
            
            this.isFirstLogin = true;
            this.userName = userName;
            this.password = password;
            this.courses=new Course[0];
            balloonShow = notify;
            this.changesCount = 0;
            
        }

        public void setCourseUrls(string[] courseURLs)
        {
            courses=new Course[courseURLs.Length];
            for (int i = 0; i < courseURLs.Length; i++)
            {
                courses[i] =new Course(courseURLs[i]);
            }
           
        }
        public void startSync()
        {
            if(this.courses.Length>0)
                Task.Run(() => asyncConnect());
            else
                this.balloonShow(true, "Could not find any course.", ToolTipIcon.Error, 10);
        }

        private void asyncConnect()
        {
            //make new moooddle object
            this.balloonShow(this.isFirstLogin, "Connecting...", ToolTipIcon.Info, 10);
            if (!myMoodle.checkInternetConnection())
            {
                this.balloonShow(true, "Could not connect to the internet.", ToolTipIcon.Warning, 5);
                this.isFirstLogin = true;
                return;
            }
            else
            {
                this.balloonShow(this.isFirstLogin, "Establishing...", ToolTipIcon.Info, 5);

                if (!myMoodle.isAlive())
                {


                    Moodle tmp = new Moodle();
                    this.balloonShow(this.isFirstLogin, "Authenticating...", ToolTipIcon.Info, 5);

                    bool result = tmp.Login(this.userName, this.password);

                    if (result)
                        this.balloonShow(this.isFirstLogin, "Login Success.", ToolTipIcon.Info, 5);
                    else
                    {
                        this.balloonShow(this.isFirstLogin, "Login Failed.", ToolTipIcon.Warning, 5);
                        this.isFirstLogin = true;
                        return;
                    }
                    myMoodle = tmp;

                }
                
                if (myMoodle.isAlive())
                {
                    this.balloonShow(this.isFirstLogin, "Getting information...", ToolTipIcon.Info, 5);
                    for (int i = 0; i < courses.Length; i++)
                    {
                        string url = courses[i].Url;
                        if (myMoodle.validateURL(url))
                        {
                            string title = "";
                            HtmlNode[] activities;
                            HtmlNode[] events;

                            myMoodle.getUpdates(url,out title,out activities,out events);

                            courses[i].Title = title;
                            courses[i].RecentActivityData = activities;
                            courses[i].UpcomingEvents = events;
                            
                            if(updateList!=null && !title.Equals(""))
                                updateList(i, title);
                            //this.balloonShow(this.isFirstLogin, title, ToolTipIcon.Info, 5);
                        } 
                        else
                        {
                            this.balloonShow(true, "Invalid URL " +url, ToolTipIcon.Error, 20);
                        }
                    }
                    //this.balloonShow(this.isFirstLogin, "Come so far...", ToolTipIcon.Info, 5);
                    string data = "";
                    for (int i = 0; i < courses.Length; i++)
                    {
                        if (courses[i].RecentActivityData.Length>0)
                        {
                            data += courses[i].Title.Remove(0, 8) + "\r\n";
                            for (int j = 0; j < courses[i].RecentActivityData.Length; j++)
                            {
                                data += courses[i].RecentActivityData[j].InnerText + "\r\n";
                                string url="";
                                if (courses[i].RecentActivityData[j].ChildNodes[2].HasAttributes)
                                    url = courses[i].RecentActivityData[j].ChildNodes[2].Attributes[0].Value;
                                updateRecentList(courses[i].Title.Remove(0, 8), Courses[i].RecentActivityData[j].ChildNodes[2].InnerText, url);
                                changesCount++;
                            }
                            myMoodle.Logout();
                            //this.balloonShow(this.isFirstLogin, "log out??...", ToolTipIcon.Info, 5);

                        }

                    }
                    updateSyncTime();                   
                    this.isFirstLogin = false;
                    if(!data.Equals(""))
                        this.balloonShow(true, data, ToolTipIcon.Info, 20);
                    else
                        this.balloonShow(this.isFirstLogin, "No new updates.", ToolTipIcon.Info, 5);
                    
                }
                
                
            }
        }

        
    }
}
