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
        List<WeekStatistics> WeekListSp13 { get; set; }
        List<WeekStatistics> WeekListAu13 { get; set; }
        List<WeekStatistics> WeekListSp14 { get; set; }
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
                    convertAndOutput(responseSp13);
                }

                // Grab JSON strings from URL for Au13:
                if (checkBoxAu13.Checked == true)
                {
                    var jsonURLAu13 = await client.GetAsync(new Uri("URL"));
                    string responseAu13 = await jsonURLAu13.Content.ReadAsStringAsync();
                    convertAndOutput(responseAu13);
                }

                // Grab JSON strings from URL for Sp14:
                if (checkBoxSp14.Checked == true)
                {
                    var jsonURLSp14 = await client.GetAsync(new Uri("URL"));
                    string responseSp14 = await jsonURLSp14.Content.ReadAsStringAsync();
                    convertAndOutput(responseSp14);
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

        public void convertAndOutput(string jsonResult)
        {
            // Deserialize objects:
            WeekListSp13 = JsonConvert.DeserializeObject<List<WeekStatistics>>(jsonResult);
            WeekStatistics week1Sp13 = WeekListSp13[0];
            WeekStatistics week2Sp13 = WeekListSp13[1];
            WeekStatistics week3Sp13 = WeekListSp13[2];
            WeekStatistics week4Sp13 = WeekListSp13[3];
            WeekStatistics week5Sp13 = WeekListSp13[4];
            WeekStatistics week6Sp13 = WeekListSp13[5];
            WeekStatistics week7Sp13 = WeekListSp13[6];
            WeekStatistics week8Sp13 = WeekListSp13[7];
            WeekStatistics week9Sp13 = WeekListSp13[8];
            WeekStatistics week10Sp13 = WeekListSp13[9];
            WeekStatistics week11Sp13 = WeekListSp13[10];
            WeekStatistics week12Sp13 = WeekListSp13[11];
            WeekStatistics week13Sp13 = WeekListSp13[12];
            WeekStatistics week14Sp13 = WeekListSp13[13];
            WeekStatistics week15Sp13 = WeekListSp13[14];
            WeekStatistics week16Sp13 = WeekListSp13[15];


        }

    }
}
