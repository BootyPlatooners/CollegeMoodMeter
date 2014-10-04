// Default Libraries:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Additional Libraries:
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace RatchetMeter
{
    public partial class Form1 : Form
    {
        List<WeekStatistics> WeekList { get; set; }
        List<WeekStatistics> Statistics { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------- //
        // Object to hold Week Statistics objects
        // ---------------------------------------------------------------------------------------------------- //

        public class WeekStatistics
        {
            public string weekNumberCount { get; set; }
            public string ratchetLevelWeek { get; set; }
            public string turnupCount { get; set; }
            public string turntCount { get; set; }
            public string turntttCount { get; set; }
            public string ratchetCount { get; set; }
            public string drunkCount { get; set; }
            public string crunkCount { get; set; }
            public string wastedCount { get; set; }
            public string blackout_drunkCount { get; set; }
            public string blacked_outCount { get; set; }
            public string alcoholCount { get; set; }
            public string boozeCount { get; set; }
            public string beerCount { get; set; }
            public string smashedCount { get; set; }
            public string drunkatOSUCount { get; set; }
            public string partyCount { get; set; }
            public string partyingCount { get; set; }
            public string partiedCount { get; set; }
            public string tgifCount { get; set; }
            public string pukeCount { get; set; }
            public string pukedCount { get; set; }
            public string pukingCount { get; set; }
            public string drunk_textCount { get; set; }
            public string drunk_textingCount { get; set; }
            public string laidCount { get; set; }
            public string yoloCount { get; set; }
        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            ReadDataFromWeb();
        }

        async public void ReadDataFromWeb()
        {
            // Check for an internet connection:
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Create an HttpClient:
                var client = new HttpClient();

                // Grab JSON strings from URL for Sp13:
                if (checkBoxSp13.Checked == true)
                {
                    var jsonURLSp13 = await client.GetAsync(new Uri("URL"));
                    string responseSp13 = await jsonURLSp13.Content.ReadAsStringAsync();
                    convertAndOutput("Spring 2013", responseSp13);
                }

                // Grab JSON strings from URL for Au13:
                if (checkBoxAu13.Checked == true)
                {
                    var jsonURLAu13 = await client.GetAsync(new Uri("URL"));
                    string responseAu13 = await jsonURLAu13.Content.ReadAsStringAsync();
                    convertAndOutput("Autumn 2013", responseAu13);
                }

                // Grab JSON strings from URL for Sp14:
                if (checkBoxSp14.Checked == true)
                {
                    var jsonURLSp14 = await client.GetAsync(new Uri("URL"));
                    string responseSp14 = await jsonURLSp14.Content.ReadAsStringAsync();
                    convertAndOutput("Spring 2014", responseSp14);
                }

                // Grab JSON strings from URL for total statistics:
                var jsonURLTotal = await client.GetAsync(new Uri("URL"));
                string responseTotal = await jsonURLTotal.Content.ReadAsStringAsync();
            }
            else
            {
                // If no internet connection, return error to button:
                buttonGenerateCode.Text = "No internet connection!";
            }
        }

        public void convertAndOutput(string semester, string jsonResult)
        {
            // Deserialize objects:
            WeekList = JsonConvert.DeserializeObject<List<WeekStatistics>>(jsonResult);
            WeekStatistics week1 = WeekList[0];
            WeekStatistics week2 = WeekList[1];
            WeekStatistics week3 = WeekList[2];
            WeekStatistics week4 = WeekList[3];
            WeekStatistics week5 = WeekList[4];
            WeekStatistics week6 = WeekList[5];
            WeekStatistics week7 = WeekList[6];
            WeekStatistics week8 = WeekList[7];
            WeekStatistics week9 = WeekList[8];
            WeekStatistics week10 = WeekList[9];
            WeekStatistics week11 = WeekList[10];
            WeekStatistics week12 = WeekList[11];
            WeekStatistics week13 = WeekList[12];
            WeekStatistics week14 = WeekList[13];
            WeekStatistics week15 = WeekList[14];
            WeekStatistics week16 = WeekList[15];

            string[] outputCode = {"<!DOCTYPE html>\r\n",
                                  "<html lang=\"en\">",
                                  "<head>",
                                  "<link rel=\"stylesheet\" type=\"text/css\" href=\"https://raw.githubusercontent.com/OHIOhackathon2014/OSURatchetMeter/master/css/style.css?token=7636606__eyJzY29wZSI6IlJhd0Jsb2I6T0hJT2hhY2thdGhvbjIwMTQvT1NVUmF0Y2hldE1ldGVyL21hc3Rlci9jc3Mvc3R5bGUuY3NzIiwiZXhwaXJlcyI6MTQxMzAyNDczOX0%3D--3fee47675b5dc317f2927cc15ae34d4dd449bf1f\">",
                                  "</head>",
                                  "<body>",
                                  "<div id = \"side\">",
                                  "<div class = \"title\">",
                                  semester,
                                  "</div>",
                                  "<div class = \"description\">",
                                  "Welcome to Ohio State's Ratchet Meter - a Twitter program that analyzes tweets by Ohio State students over a period of time to determine the most fun, rowdy, and debaucherous weekends.",
                                  "</div>",
                                  "<br>"};

                                  "<a href=\"" + "C:\\Users\\Kayvan\\Desktop" + "\"><div class =\"links\">Facebook</div></a>",

                                  
                                  
                                  
                                  };



            System.IO.File.AppendAllLines(@"C:\Users\Kayvan\Desktop\Output.html", "string");
        }
    }
}
