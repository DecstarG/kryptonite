using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using VirusTotalNET.Objects;
using VirusTotalNET.ResponseCodes;
using VirusTotalNET.Results;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;

namespace Kryptonite
{
    public partial class Form1Main : Form
    {
        public string currentCode; //Preps a variable used later
        public Control HTMLobject;

        public Form1Main()
        {
            InitializeComponent(); //Initiliazation
            textBox1.Text = "https://www.duckduckgo.com"; //Pre-sets URL to DuckDuckGo
            using (WebClient client = new WebClient())
            {
                currentCode = client.DownloadString(textBox1.Text);
                richTextBox1.Text = currentCode;
                var htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(currentCode);
                var title = htmldoc.DocumentNode.SelectSingleNode("//head/title");
                string titled = title.InnerText;
                if (titled == null)
                {
                    Text = textBox1.Text + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                }
                else
                {
                    Text = titled + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                }
                //Automatically sets page to DuckDuckGo
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Checks for Enter/Return key press while inside TextBox1
            {
                using (WebClient client = new WebClient()) { //Sets up WebClient for request
                    string term = textBox1.Text;
                    if (term.Contains("http")) //Checks if it is a correctly formatted URl (http:// or https://)
                    {
                        currentCode = client.DownloadString(textBox1.Text); //Gets HTML
                        if (((currentCode.Contains("contact") && (currentCode.Contains("microsoft") || currentCode.Contains("ms")) && currentCode.Contains("support")) && (currentCode.Contains("13 20 58") == false || currentCode.Contains("13-20-58") == false || currentCode.Contains("132058") == false))||((currentCode.Contains("apple")|| currentCode.Contains("mac"))&&currentCode.Contains("contact")&&(currentCode.Contains("1300 321 456")==false|| currentCode.Contains("1300-321-456") == false || currentCode.Contains("1300321456") == false))) //"ScamBlock" Filter algorithm *Currently only filters out Microsoft (AND Apple as of Build 4) Tech Support Scams*
                        {
                            //Likely Tech-Support Scammer (got any wiruses siwr? becoz ve are from mikerosoft tek supowt.)
                            richTextBox1.Text = "Likely tech support scam. This code may be malicious or attempt to decieve users. (Results by Kryptonite(c) ScamBlock)";
                            var htmldoc = new HtmlAgilityPack.HtmlDocument();
                            htmldoc.LoadHtml(currentCode);
                            var title = htmldoc.DocumentNode.SelectSingleNode("//head/title");
                            string titled = title.InnerText;
                            if (titled == null)
                            {
                                Text = textBox1.Text + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                            else
                            {
                                Text = titled + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                        }
                        else
                        {
                            //All good, most likely not a scam (IMPORTANT: MAY BE VIRUS)
                            richTextBox1.Text = currentCode; //Displays HTML markup
                            var htmldoc = new HtmlAgilityPack.HtmlDocument();
                            htmldoc.LoadHtml(currentCode);
                            var title = htmldoc.DocumentNode.SelectSingleNode("//head/title");
                            string titled = title.InnerText;
                            if (titled == null)
                            {
                                Text = textBox1.Text + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                            else {
                                Text = titled + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                           
                        }
                    }
                    else
                    {
                        if (term.Contains(".")&&term.Contains(" ")==false) //Checks if it is actually a url without http or https
                        {
                            currentCode = client.DownloadString("https://" + textBox1.Text); //Formats URL as https
                            textBox1.Text = "https://" + textBox1.Text;
                            richTextBox1.Text = currentCode;
                            var htmldoc = new HtmlAgilityPack.HtmlDocument();
                            htmldoc.LoadHtml(currentCode);
                            var title = htmldoc.DocumentNode.SelectSingleNode("//head/title");
                            string titled = title.InnerText;
                            if (titled == null)
                            {
                                Text = textBox1.Text + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                            else
                            {
                                Text = titled + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                        } else
                        {
                            currentCode = client.DownloadString("https://www.duckduckgo.com/?q=" + textBox1.Text); //Sends DuckDuckGo request
                            textBox1.Text = "https://www.duckduckgo.com/?q=" + textBox1.Text;
                            richTextBox1.Text = currentCode;
                            var htmldoc = new HtmlAgilityPack.HtmlDocument();
                            htmldoc.LoadHtml(currentCode);
                            var title = htmldoc.DocumentNode.SelectSingleNode("//head/title");
                            string titled = title.InnerText;
                            if (titled == null)
                            {
                                Text = textBox1.Text + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                            else
                            {
                                Text = titled + " - Kryptonite (Alpha) - The DuckDuckGo Integrated Browser";
                            }
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text!=null&&textBox1.Focused==false) {
                //Here is where the textbox bar will be updated with any new URL
                //Low Priority to finish
            }
        }

            }
        }