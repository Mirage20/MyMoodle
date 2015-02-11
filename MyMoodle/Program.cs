using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMoodle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("HtmlAgilityPack.dll"))
            {
                MessageBox.Show("HtmlAgilityPack.dll not found.", "My Moodle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists("FeedbackProvider.dll"))
            {
                MessageBox.Show("FeedbackProvider.dll not found.", "My Moodle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

        }
    }
}
