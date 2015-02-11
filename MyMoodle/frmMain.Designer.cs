namespace MyMoodle
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.notifyIconInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feddbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.happyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.listViewCourse = new System.Windows.Forms.ListView();
            this.columnHeaderCName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnDeleteURL = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartSync = new System.Windows.Forms.Button();
            this.btnStopSync = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewUpcoming = new System.Windows.Forms.ListView();
            this.columnHeaderEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewRecent = new System.Windows.Forms.ListView();
            this.columnHeaderActivity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(325, 494);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(255, 45);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 481);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(292, 58);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            // 
            // notifyIconInfo
            // 
            this.notifyIconInfo.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIconInfo.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconInfo.Icon")));
            this.notifyIconInfo.Visible = true;
            this.notifyIconInfo.BalloonTipClicked += new System.EventHandler(this.notifyIconInfo_BalloonTipClicked);
            this.notifyIconInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconInfo_MouseDoubleClick);
            this.notifyIconInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIconInfo_MouseMove);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.feddbackToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(125, 120);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // feddbackToolStripMenuItem
            // 
            this.feddbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.happyToolStripMenuItem,
            this.sadToolStripMenuItem});
            this.feddbackToolStripMenuItem.Name = "feddbackToolStripMenuItem";
            this.feddbackToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.feddbackToolStripMenuItem.Text = "&Feedback";
            // 
            // happyToolStripMenuItem
            // 
            this.happyToolStripMenuItem.Name = "happyToolStripMenuItem";
            this.happyToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.happyToolStripMenuItem.Text = "&Happy";
            this.happyToolStripMenuItem.Click += new System.EventHandler(this.happyToolStripMenuItem_Click);
            // 
            // sadToolStripMenuItem
            // 
            this.sadToolStripMenuItem.Name = "sadToolStripMenuItem";
            this.sadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.sadToolStripMenuItem.Text = "&Sad";
            this.sadToolStripMenuItem.Click += new System.EventHandler(this.sadToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(535, 465);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timerSync
            // 
            this.timerSync.Interval = 60000;
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // listViewCourse
            // 
            this.listViewCourse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCName,
            this.columnHeaderCUrl});
            this.listViewCourse.FullRowSelect = true;
            this.listViewCourse.Location = new System.Drawing.Point(12, 12);
            this.listViewCourse.MultiSelect = false;
            this.listViewCourse.Name = "listViewCourse";
            this.listViewCourse.Size = new System.Drawing.Size(628, 135);
            this.listViewCourse.TabIndex = 9;
            this.listViewCourse.UseCompatibleStateImageBehavior = false;
            this.listViewCourse.View = System.Windows.Forms.View.Details;
            this.listViewCourse.SelectedIndexChanged += new System.EventHandler(this.listViewCourse_SelectedIndexChanged);
            this.listViewCourse.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCourse_MouseDoubleClick);
            // 
            // columnHeaderCName
            // 
            this.columnHeaderCName.Text = "Course Name";
            this.columnHeaderCName.Width = 340;
            // 
            // columnHeaderCUrl
            // 
            this.columnHeaderCUrl.Text = "Course URL";
            this.columnHeaderCUrl.Width = 260;
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.Location = new System.Drawing.Point(484, 151);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(75, 23);
            this.btnAddUrl.TabIndex = 2;
            this.btnAddUrl.Text = "&Add URL";
            this.btnAddUrl.UseVisualStyleBackColor = true;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(12, 153);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(466, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnDeleteURL
            // 
            this.btnDeleteURL.Location = new System.Drawing.Point(565, 151);
            this.btnDeleteURL.Name = "btnDeleteURL";
            this.btnDeleteURL.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteURL.TabIndex = 3;
            this.btnDeleteURL.Text = "&Delete URL";
            this.btnDeleteURL.UseVisualStyleBackColor = true;
            this.btnDeleteURL.Click += new System.EventHandler(this.btnDeleteURL_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 206);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(106, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(73, 179);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(106, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // btnStartSync
            // 
            this.btnStartSync.Location = new System.Drawing.Point(185, 178);
            this.btnStartSync.Name = "btnStartSync";
            this.btnStartSync.Size = new System.Drawing.Size(75, 23);
            this.btnStartSync.TabIndex = 6;
            this.btnStartSync.Text = "&Start";
            this.btnStartSync.UseVisualStyleBackColor = true;
            this.btnStartSync.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // btnStopSync
            // 
            this.btnStopSync.Enabled = false;
            this.btnStopSync.Location = new System.Drawing.Point(185, 204);
            this.btnStopSync.Name = "btnStopSync";
            this.btnStopSync.Size = new System.Drawing.Size(75, 23);
            this.btnStopSync.TabIndex = 7;
            this.btnStopSync.Text = "Sto&p";
            this.btnStopSync.UseVisualStyleBackColor = true;
            this.btnStopSync.Click += new System.EventHandler(this.btnStopSync_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(484, 183);
            this.trackBar1.Maximum = 720;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(156, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickFrequency = 15;
            this.trackBar1.Value = 120;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Update interval           :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Estimated data usage :";
            // 
            // listViewUpcoming
            // 
            this.listViewUpcoming.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEvent,
            this.columnHeaderDate});
            this.listViewUpcoming.FullRowSelect = true;
            this.listViewUpcoming.Location = new System.Drawing.Point(12, 232);
            this.listViewUpcoming.MultiSelect = false;
            this.listViewUpcoming.Name = "listViewUpcoming";
            this.listViewUpcoming.Size = new System.Drawing.Size(628, 100);
            this.listViewUpcoming.TabIndex = 10;
            this.listViewUpcoming.UseCompatibleStateImageBehavior = false;
            this.listViewUpcoming.View = System.Windows.Forms.View.Details;
            this.listViewUpcoming.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewUpcoming_MouseDoubleClick);
            // 
            // columnHeaderEvent
            // 
            this.columnHeaderEvent.Text = "Upcoming Events";
            this.columnHeaderEvent.Width = 322;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 291;
            // 
            // listViewRecent
            // 
            this.listViewRecent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderActivity,
            this.columnHeaderDetails,
            this.columnHeaderUrl});
            this.listViewRecent.FullRowSelect = true;
            this.listViewRecent.Location = new System.Drawing.Point(12, 338);
            this.listViewRecent.MultiSelect = false;
            this.listViewRecent.Name = "listViewRecent";
            this.listViewRecent.Size = new System.Drawing.Size(628, 100);
            this.listViewRecent.TabIndex = 11;
            this.listViewRecent.UseCompatibleStateImageBehavior = false;
            this.listViewRecent.View = System.Windows.Forms.View.Details;
            this.listViewRecent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewRecent_MouseDoubleClick);
            // 
            // columnHeaderActivity
            // 
            this.columnHeaderActivity.Text = "Recent Updates";
            this.columnHeaderActivity.Width = 325;
            // 
            // columnHeaderDetails
            // 
            this.columnHeaderDetails.Text = "Details";
            this.columnHeaderDetails.Width = 289;
            // 
            // columnHeaderUrl
            // 
            this.columnHeaderUrl.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 451);
            this.Controls.Add(this.listViewRecent);
            this.Controls.Add(this.listViewUpcoming);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnStopSync);
            this.Controls.Add(this.btnStartSync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnDeleteURL);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnAddUrl);
            this.Controls.Add(this.listViewCourse);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Moodle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuStripNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.NotifyIcon notifyIconInfo;
        private System.Windows.Forms.ListView listViewCourse;
        private System.Windows.Forms.ColumnHeader columnHeaderCName;
        private System.Windows.Forms.ColumnHeader columnHeaderCUrl;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnDeleteURL;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartSync;
        private System.Windows.Forms.Button btnStopSync;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewUpcoming;
        private System.Windows.Forms.ColumnHeader columnHeaderEvent;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ListView listViewRecent;
        private System.Windows.Forms.ColumnHeader columnHeaderActivity;
        private System.Windows.Forms.ColumnHeader columnHeaderDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader columnHeaderUrl;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feddbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem happyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sadToolStripMenuItem;
    }
}

