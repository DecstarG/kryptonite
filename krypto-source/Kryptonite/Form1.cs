using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;

namespace Kryptonite
{
    public partial class Form1 : Form
    {
        public string currentCode;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "https://www.duckduckgo.com";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Checks for Enter/Return key press while inside TextBox1
            {
                using (WebClient client = new WebClient()) { //Sets up WebClient for request
                    currentCode = client.DownloadString(textBox1.Text);
                    if (currentCode.Contains("contact")&& (currentCode.Contains("microsoft")|| currentCode.Contains("ms"))&& (currentCode.Contains("13 20 58")==false|| currentCode.Contains("13-20-58") == false || currentCode.Contains("132058") == false)) //Filter algorithm *Currently only filters out Microsoft Tech Support Scams*
                    {
                        //Likely Tech-Support Scammer
                        richTextBox1.Text = "Likely tech support scam. This code may be malicious or attempt to decieve users. (Results by Kryptonite(c) ScamBlock";
                    }
                    else {
                        richTextBox1.Text = currentCode;
                    }
                    
                }
            }
        }
    }
}
