using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMoodle.Properties;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;
namespace MyMoodle
{
    public partial class frmMain : Form
    {


        MoodleHandler myMoodleHandler;
        int lastSelection = 0;
        DateTime lastSyncTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
        public frmMain()
        {
            InitializeComponent();
            BinarySerializeProvider.FilePath = "user.dat";
            NetworkChange.NetworkAvailabilityChanged += NetworkChanged;
            SystemEvents.PowerModeChanged+=OSStatusChanged;
       
           
        }

        
       
        #region FormEvents

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists("user.dat"))
            {
                //if (MessageBox.Show(this, "PLEASE READ BEFORE YOU START.\r\n You need to enable the \"Upcoming events\" and \"Recent activity\" for the courses.\r\nDo you want to do it now?", "My Moodle", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                //    Process.Start("http://online.mrt.ac.lk");
                //else
                //    MessageBox.Show(this, "Application may not work correctly.", "My Moodle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MoodleSettings settings = BinarySerializeProvider.load();
            txtUserName.Text = settings.UserName;
            txtPassword.Text = Security.Decrypt(settings.Password);
            trackBar1.Value = settings.SyncInterval;

            for (int i = 0; i < settings.CourseDetails.Length; i++)
            {
                ListViewItem newItem = new ListViewItem(settings.CourseDetails[i].CourseName);
                newItem.SubItems.Add(settings.CourseDetails[i].CourseUrl);
                listViewCourse.Items.Add(newItem);
            }
            updateTrackbar();
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                balloonShow(true, "My Moodle is still running", ToolTipIcon.Info, 5);
            }

            timerSync.Enabled = false;

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MoodleSettings newSettings = new MoodleSettings();
            newSettings.UserName = txtUserName.Text;
            newSettings.Password = Security.Encrypt(txtPassword.Text);
            newSettings.SyncInterval = trackBar1.Value;

            newSettings.CourseDetails = new MoodleSettings.CourseData[listViewCourse.Items.Count];

            for (int i = 0; i < listViewCourse.Items.Count; i++)
            {
                newSettings.CourseDetails[i] = new MoodleSettings.CourseData(listViewCourse.Items[i].SubItems[0].Text, listViewCourse.Items[i].SubItems[1].Text);

            }

            BinarySerializeProvider.save(newSettings);
        }

        #endregion

        #region ButtonEvents

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            if (!txtURL.Text.Trim().Equals(""))
            {
                for (int i = 0; i < listViewCourse.Items.Count; i++)
                {
                    if (listViewCourse.Items[i].SubItems[1].Text.Equals(txtURL.Text.Trim()))
                    {
                        MessageBox.Show(this, "Course already exist.", "My Moodle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ListViewItem newItem = new ListViewItem("Pending...");
                newItem.SubItems.Add(txtURL.Text);
                listViewCourse.Items.Add(newItem);
                updateTrackbar(); 
            }
        }

        private void btnDeleteURL_Click(object sender, EventArgs e)
        {
            if (listViewCourse.SelectedItems.Count > 0 && MessageBox.Show(this,"Do you want to delete course \""+listViewCourse.SelectedItems[0].Text+"\" ?","My Moodle",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                listViewCourse.Items.RemoveAt(listViewCourse.SelectedItems[0].Index);

                updateTrackbar();

                if (myMoodleHandler != null)
                {
                    string[] urls = new string[listViewCourse.Items.Count];
                    for (int i = 0; i < listViewCourse.Items.Count; i++)
                    {
                        urls[i] = listViewCourse.Items[i].SubItems[1].Text;
                    }

                    myMoodleHandler.setCourseUrls(urls);
                    myMoodleHandler.startSync();
                    
                }
            }
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            myMoodleHandler = new MoodleHandler(balloonShow, txtUserName.Text, txtPassword.Text);

            string[] urls = new string[listViewCourse.Items.Count];
            for (int i = 0; i < listViewCourse.Items.Count; i++)
            {
                urls[i] = listViewCourse.Items[i].SubItems[1].Text;
            }

            myMoodleHandler.setCourseUrls(urls);
            myMoodleHandler.UpdateList = updateListCourseTitle;
            myMoodleHandler.UpdateRecentList = updateListRecent;
            myMoodleHandler.UpdateSyncTime = updateSyncTime;
            timerSync.Enabled = true;
            btnStopSync.Enabled = true;
            btnStartSync.Enabled = false;
            myMoodleHandler.startSync();
            
        }

        private void btnStopSync_Click(object sender, EventArgs e)
        {
            timerSync.Enabled = false;
            btnStopSync.Enabled = false;
            btnStartSync.Enabled = true;
        }


        #endregion

        #region ListViewEvents

        private void listViewCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCourse.SelectedItems.Count > 0)
            {
                listViewUpcoming.Items.Clear();
                int selection = listViewCourse.SelectedItems[0].Index;
                this.lastSelection = selection;
                if (myMoodleHandler != null && myMoodleHandler.Courses[selection].UpcomingEvents.Length > 0)
                {
                    for (int i = 0; i < myMoodleHandler.Courses[selection].UpcomingEvents.Length; i++)
                    {
                        ListViewItem newEvent = new ListViewItem(myMoodleHandler.Courses[selection].UpcomingEvents[i].ChildNodes[1].InnerText);
                        newEvent.SubItems.Add(myMoodleHandler.Courses[selection].UpcomingEvents[i].ChildNodes[2].InnerText);
                        listViewUpcoming.Items.Add(newEvent);
                    }
                }

                //listViewRecent.Items.Clear();

                //if (myMoodleHandler != null && myMoodleHandler.Courses[selection].RecentActivityData.Length > 0)
                //{
                //    for (int i = 0; i < myMoodleHandler.Courses[selection].RecentActivityData.Length; i++)
                //    {
                //        // ListViewItem newActivity = new ListViewItem(myMoodleHandler.Courses[selection].RecentActivityData[i].ChildNodes[0].InnerText);
                //        // newActivity.SubItems.Add(myMoodleHandler.Courses[selection].RecentActivityData[i].ChildNodes[2].InnerText);
                //        // listViewRecent.Items.Add(newActivity);
                //    }
                //}
            }

        }

        private void listViewCourse_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewCourse.SelectedItems.Count > 0)
            {
                Process.Start(listViewCourse.Items[listViewCourse.SelectedItems[0].Index].SubItems[1].Text);
            }
        }

        private void listViewRecent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewRecent.SelectedItems.Count > 0)
            {
                Process.Start(listViewRecent.Items[listViewRecent.SelectedItems[0].Index].SubItems[2].Text);
            }
        }

        private void listViewUpcoming_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewUpcoming.SelectedItems.Count > 0)
            {
                int selection = listViewUpcoming.SelectedItems[0].Index;
                if (myMoodleHandler.Courses[lastSelection].UpcomingEvents[selection].ChildNodes[1].HasAttributes)
                    Process.Start(myMoodleHandler.Courses[lastSelection].UpcomingEvents[selection].ChildNodes[1].Attributes[0].Value);
            }
        }

        #endregion


        #region OtherEvents

        private void timerSync_Tick(object sender, EventArgs e)
        {
            //this.Text = DateTime.Now.ToString() ;
            myMoodleHandler.startSync();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            updateTrackbar();
        }

        private void notifyIconInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if(DateTime.Now.Subtract(lastSyncTime).Days<(365 * 10))
                notifyIconInfo.Text ="Last check about " +ConvertHelper.timeDifferenceConvert(lastSyncTime, DateTime.Now) + " ago";           
        }

        private void notifyIconInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timerSync.Enabled)
            {
                this.btnStopSync_Click(sender, e);
                this.btnStartSync_Click(sender, e);
            }
            else
            {           
                this.btnStartSync_Click(sender, e);
                this.btnStopSync_Click(sender, e);
            }
        }

        private void happyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            FeedbackProvider.Feedback.SendSmileToMiRAGECreator(assembly.GetName().Name, Application.ExecutablePath, fvi.ProductName, fvi.ProductVersion, Environment.OSVersion.ToString(), Environment.Version.ToString());
        }

        private void sadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            FeedbackProvider.Feedback.SendSadToMiRAGECreator(assembly.GetName().Name, Application.ExecutablePath, fvi.ProductName, fvi.ProductVersion, Environment.OSVersion.ToString(), Environment.Version.ToString());

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIconInfo_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }

        private void NetworkChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            BeginInvoke(new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged), new object[] { sender, e });
        }
        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            //this.Text = "Network change " + e.IsAvailable.ToString();
            if (e.IsAvailable && !btnStartSync.Enabled)
            {
                timerSync.Enabled = false;
                myMoodleHandler.startSync();
                timerSync.Enabled = true;

            }
        
        }

        private void OSStatusChanged(object sender, PowerModeChangedEventArgs e)
        {
            BeginInvoke(new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged), new object[] { sender, e });
        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (!btnStartSync.Enabled && e.Mode == PowerModes.Suspend)
            {
                timerSync.Enabled = false;
                //this.Text = "OS suspend" ;
                
            }
            
            if (!btnStartSync.Enabled && e.Mode == PowerModes.Resume)
            {
                timerSync.Enabled = false;
                myMoodleHandler.startSync();
                timerSync.Enabled = true;
                //this.Text = "OS resume";
            }
        }

        #endregion


        #region Methods

        private delegate void UpdateSyncTime();
        
        
        private void updateSyncTime()
        {
            this.BeginInvoke(new UpdateSyncTime(changeSyncTime));           
        }

        private void changeSyncTime()
        {
                       
            lastSyncTime = DateTime.Now;
            listViewUpcoming.Items.Clear();
        }

        private void balloonShow(bool isFirst, string textData, ToolTipIcon icon, int time)
        {
            if (isFirst)            
                notifyIconInfo.ShowBalloonTip(time, "My Moodle", textData, icon);          
        }


        private delegate void UpdateList(int index, string title);
        private void updateListCourseTitle(int index, string title)
        {
            listViewCourse.BeginInvoke(new UpdateList(updateListTitle), new object[] { index, title });
        }
        private void updateListTitle(int index, string title)
        {
            listViewCourse.Items[index].SubItems[0].Text = title.Remove(0, 8);
        }



        private delegate void UpdateRecentList(string course, string data,string url);
        private void updateListRecent(string course, string data,string url)
        {
            listViewRecent.BeginInvoke(new UpdateRecentList(updateRecentListData), new object[] { course, data,url });
        }
        private void updateRecentListData(string course, string data,string url)
        {

             ListViewItem newActivity = new ListViewItem(course);
             newActivity.SubItems.Add(data);
             newActivity.SubItems.Add(url);
             listViewRecent.Items.Add(newActivity);
        }


        private void updateTrackbar()
        {
            long totalBytes = (150 * 1024) + (100 * 1024 * listViewCourse.Items.Count);
            long totalMinPerDay = 60 * 24;

            long numberOfSyncs = totalMinPerDay / trackBar1.Value;
            label3.Text = "Update interval           : " + ConvertHelper.minConvet(trackBar1.Value);
            label4.Text = "Estimated data usage : " + ConvertHelper.byteConvet(numberOfSyncs * totalBytes) + "/Day";
            timerSync.Interval = trackBar1.Value * 60 * 1000;
        }

        #endregion

        #region Junk

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = myMoodleHandler.Courses[0].UpcomingEvents[0].ChildNodes[1].InnerText;
            textBox2.Text = myMoodleHandler.Courses[0].UpcomingEvents[0].ChildNodes[2].InnerText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //timerSync.Enabled = true;
            listViewCourse.Items[0].SubItems[0].Text = "354";
        }


        private void test()
        {
            HtmlNode[] recentActivities = new HtmlNode[0];
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            string text = System.IO.File.ReadAllText(@"C:\Users\Mirage\Desktop\MyMoodle\k.html");

            htmlDoc.LoadHtml(text);
            HtmlNode recentBlock = getHtmlNodesByClass(htmlDoc.DocumentNode, "block_recent_activity  block", "div")[0];
            HtmlNode recentContent = getHtmlNodesByClass(recentBlock, "content", "div")[0];
            recentActivities = getHtmlNodesByClass(recentContent, "activity", "p");

            for (int i = 0; i < recentActivities.Length; i++)
            {
                ListViewItem newEvent = new ListViewItem(recentActivities[i].ChildNodes[0].InnerText);
                newEvent.SubItems.Add(recentActivities[i].ChildNodes[2].InnerText);
                listViewRecent.Items.Add(newEvent);
            }
            if (recentActivities[0].ChildNodes[2].HasAttributes)
                textBox1.Text = recentActivities[0].ChildNodes[2].Attributes[0].Value;
        }

        private HtmlNode[] getHtmlNodesByClass(HtmlNode rootNode, string className, string tag)
        {
            var nodesWithMatchingClasses = rootNode.Descendants().Where(tmp => tmp.Attributes.Contains("class") && tmp.Attributes["class"].Value.Equals(className));

            HtmlNode[] nodeArray = nodesWithMatchingClasses.ToArray<HtmlNode>();

            return nodeArray;
        }

        #endregion
        
       

        

        

        

        

        

        

        

       

        

        

        
    }
}
