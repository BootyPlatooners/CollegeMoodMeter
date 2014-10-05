using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeMoodMeter
{
    public partial class Form1 : Form
    {
        //Instantiate global dictionary:
        Dictionary<string, int> wordDictionary = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();

        }

        private void readFile(string fileName)
        {
            // Instantiate variables:
            string line;

            // Declare file to read from:
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            
            // Iterate over lines in text file (in format 'word frequency') and add to dictionary:
            while ((line = file.ReadLine()) != null)
            {
                int index = line.IndexOf(' ');
                string word = line.Substring(0, index);
                string countString = line.Substring(line.IndexOf(" ") + 1).Trim();
                int count = Convert.ToInt32(countString);

                wordDictionary.Add(word, count);
            }

            // Sort dictionary in descending order by value:
            wordDictionary = wordDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private string[] topWords()
        {
            // Define temporary dictionary:
            Dictionary<string, int> temp = new Dictionary<string, int>();

            // Grab top 5 words, place into temporary dictionary, and put into array:
            temp = wordDictionary.Take(5).ToDictionary(pair => pair.Key, pair => pair.Value);
            string[] topWords = temp.Keys.ToArray();

            return topWords;
        }

        private void scorer()
        {
            string[] happiness = { "<3", ":)", ":-)", ":]", ":D", ";)", ";]", "^^", "better", "easy", "ecstatic", "excited", "family", "friends", "fun", "funny", "glad", "good", "happiest", "happiness", "happy", "hilarious", "kind", "kindness", "laugh", "laughing", "lol", "love", "loving", "nice", "passed", "win", "winning", "xD", "yay", "yes" };
            string[] sadness = { ":(", ":-(", ":[", ";(", "bad", "crying", "D:", "depressed", "depressing", "depression", "disgust", "disgusting", "Dx", "enemies", "fat", "fml", "gross", "hard", "hate", "idiot", "impolite", "judgement", "lose", "miserable", "miss", "mistake", "rude", "sad", "saddening", "saddest", "sadness", "shitty", "sick", "sin", "stupid", "suck", "sucks", "useless", "worst", "worthless" };
            string[] stress = { "2am", "could've", "exam", "exams", "fail", "failed", "failure", "finals", "help", "homework", "job", "late", "midterm", "midterms", "money", "more", "procrastinate", "procrastination", "regret", "should've", "stress", "stressed", "stressed", "stressing", "studying", "wish" };
            string[] ratchetness = { "alcohol", "beer", "blacked", "blackout", "booty", "booze", "crunk", "drunk", "drunkatOSU", "laid", "partied", "party", "partying", "puke", "puked", "puking", "ratchet", "smashed", "tgif", "turnt", "turnttt", "turnup", "wasted", "yolo", "drunk" };

            int happinessScore = 0;
            int sadnessScore = 0;
            int stressScore = 0;
            int ratchetnessScore = 0;
        }




    }
}
