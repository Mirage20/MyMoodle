using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net.Cache;
using System.Runtime.InteropServices;
namespace MyMoodle
{
    class Moodle
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetCheckConnection(string lpszUrl, int dwFlags, int dwReserved);

        CookieContainer cookies;
        string lastRequestHeader = "";
        string lastResponseHeader = "";
        HttpRequestCachePolicy cachePolicy;
        IWebProxy proxySettings;

        string pageData = "";
        public string LastResponseHeader
        {
            get { return lastResponseHeader; }
        }

        public string LastRequestHeader
        {
            get { return lastRequestHeader; }
        }

        

        public Moodle()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain,SslPolicyErrors errors)
            {
                return (true);
            };

            cookies = new CookieContainer();
            cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache);

            proxySettings = null;
            
        }

        public bool checkInternetConnection()
        {           
              return InternetCheckConnection ("http://online.mrt.ac.lk",1,0);                                    
        }

        public bool validateURL(string url)
        {
            
           Uri tmp;

            if(Uri.TryCreate(url,UriKind.Absolute,out tmp))
            {
                return true;
            }
            else
                return false;

        }
        public bool Login(string username,string password)
        {
            string url = "https://online.mrt.ac.lk/login/index.php"; 
            HttpWebRequest request = WebRequest.CreateHttp(url);

            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.CookieContainer = cookies;
            request.CachePolicy = cachePolicy;
            request.Proxy = proxySettings;

            byte[] bytes = Encoding.ASCII.GetBytes("username=" + username + "&password=" + password);
            request.ContentLength = bytes.Length;

            Stream requestBuffer = request.GetRequestStream();
            requestBuffer.Write(bytes, 0, bytes.Length);
            requestBuffer.Close();
            
            WebResponse response = request.GetResponse();
            
            lastRequestHeader =request.Headers.ToString();
            lastResponseHeader = response.Headers.ToString();
            //System.Diagnostics.Debug.WriteLine("Loggin is cache="+response.IsFromCache);
            //bool t = response.IsFromCache;

            return isSuccess(response);
        }

        public void Logout()
        {
            cookies = new CookieContainer();
        }

        public string requestMoodlePage(string moodleCourseURL)
        {          
            string courseUrl = moodleCourseURL;

            HttpWebRequest request = WebRequest.CreateHttp(courseUrl);
            
            request.CookieContainer=cookies;
            request.Proxy = proxySettings;
            request.CachePolicy = cachePolicy;
            
            WebResponse getResponse = request.GetResponse();
            
            StreamReader readBuffer = new StreamReader(getResponse.GetResponseStream());
            
            pageData = readBuffer.ReadToEnd();
            readBuffer.Close();
            //System.Diagnostics.Debug.WriteLine("moodle page is cache=" + getResponse.IsFromCache);
            return pageData;
        }

        private bool isSuccess(WebResponse response)
        {
            if (response.Headers["Expires"].Equals(""))
                return false;
            else
                return true;
        }

        public bool isAlive()
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(this.requestMoodlePage("http://online.mrt.ac.lk/my/"));
            if (this.getHtmlNodesByClass(htmlDoc.DocumentNode, "logininfo", "div")[0].InnerText.Equals("You are not logged in."))
                return false;

            return true;
        }

      


        private HtmlNode[] getHtmlNodesByClass(HtmlNode rootNode,string className,string tag)
        {
            var nodesWithMatchingClasses = rootNode.Descendants(tag).Where(tmp => tmp.Attributes.Contains("class") && tmp.Attributes["class"].Value.Equals(className));
            
            HtmlNode[] nodeArray = nodesWithMatchingClasses.ToArray<HtmlNode>();

            return nodeArray;
        }





        public void getUpdates(string moodleCourseURL,out string courseTitle,out HtmlNode[] activities,out HtmlNode[] events)
        {
            HtmlNode[] recentActivities=new HtmlNode[0];
            HtmlNode[] upcomingEvents = new HtmlNode[0];

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(this.requestMoodlePage(moodleCourseURL));
            try
            {
                courseTitle= htmlDoc.DocumentNode.Descendants("title").ToArray<HtmlNode>()[0].InnerText;
                HtmlNode recentBlock = getHtmlNodesByClass(htmlDoc.DocumentNode, "block_recent_activity  block","div")[0];
                HtmlNode recentContent = getHtmlNodesByClass(recentBlock, "content","div")[0];
                recentActivities = getHtmlNodesByClass(recentContent, "activity", "p");  //activity class p tag

                HtmlNode upcomingBlock = getHtmlNodesByClass(htmlDoc.DocumentNode, "block_calendar_upcoming  block","div")[0];
                HtmlNode upcomingContent = getHtmlNodesByClass(upcomingBlock, "content","div")[0];
                upcomingEvents = getHtmlNodesByClass(upcomingContent, "event", "div");  //event class
            }
            catch (Exception)
            {
                courseTitle = "";
            }

            activities = recentActivities;
            events = upcomingEvents;
            
        }
        
    }
}
