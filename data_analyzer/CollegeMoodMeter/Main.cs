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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            outputHeader();

            string wordFileOSU = "?";
            string wordFileUM = "?";

            Dictionary<string, int> wordDictionaryOSU = new Dictionary<string, int>();
            wordDictionaryOSU = readFile(wordFileOSU, wordDictionaryOSU);
            string[] topWordsOSU = topWords(wordDictionaryOSU);
            int[] scoresOSU = scorer("OSU", wordDictionaryOSU);
            outputSchoolStats("Ohio State University", scoresOSU[0], scoresOSU[1], scoresOSU[2], scoresOSU[3], topWordsOSU);

            Dictionary<string, int> wordDictionaryUM = new Dictionary<string, int>();
            wordDictionaryUM = readFile(wordFileUM, wordDictionaryUM);
            string[] topWordsUM = topWords(wordDictionaryUM);
            int[] scoresUM = scorer("OSU", wordDictionaryUM);
            outputSchoolStats("University of Michigan", scoresOSU[0], scoresOSU[1], scoresOSU[2], scoresOSU[3], topWordsUM);

            outputFooter();

        }

        private Dictionary<String, int> readFile(string fileName, Dictionary<String, int> wordDictionary)
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

            return wordDictionary;
        }

        private string[] topWords(Dictionary<String, int> wordDictionary)
        {
            // Define temporary dictionary:
            Dictionary<string, int> temp = new Dictionary<string, int>();

            // Grab top 5 words, place into temporary dictionary, and put into array:
            temp = wordDictionary.Take(5).ToDictionary(pair => pair.Key, pair => pair.Value);
            string[] topWords = temp.Keys.ToArray();

            return topWords;
        }

        private int[] scorer(string school, Dictionary<String, int> wordDictionary)
        {
            string[] happiness = { "<3", ":)", ":-)", ":]", ":D", ";)", ";]", "^^", "better", "easy", "ecstatic", "excited", "family", "friends", "fun", "funny", "glad", "good", "happiest", "happiness", "happy", "hilarious", "kind", "kindness", "laugh", "laughing", "lol", "love", "loving", "nice", "passed", "win", "winning", "xD", "yay", "yes" };
            string[] sadness = { ":(", ":-(", ":[", ";(", "bad", "crying", "D:", "depressed", "depressing", "depression", "disgust", "disgusting", "Dx", "enemies", "fat", "fml", "gross", "hard", "hate", "idiot", "impolite", "judgement", "lose", "miserable", "miss", "mistake", "rude", "sad", "saddening", "saddest", "sadness", "shitty", "sick", "sin", "stupid", "suck", "sucks", "useless", "worst", "worthless" };
            string[] stress = { "2am", "could've", "exam", "exams", "fail", "failed", "failure", "finals", "help", "homework", "job", "late", "midterm", "midterms", "money", "more", "procrastinate", "procrastination", "regret", "should've", "stress", "stressed", "stressed", "stressing", "studying", "wish" };
            string[] spiritOSU = { "bestcollege", "coolestcollege", "football", "gameday", "gored", "undefeated", "brutus", "buckeye", "buckeyes", "buckeyebrutus", "gobucks", "goosu", "iloveosu", "loveosu", "osufootball", "scarletandgray", "scarletandgrey" };
            string[] spiritUM = { "bestcollege", "coolestcollege", "football", "gameday", "gored", "undefeated", "biff", "chadtough", "gobigblue", "goblue", "gomichigan", "wolverine", "wolverines" };

            int happinessScore = 0;
            for (int i = 0; i < happiness.Length; i++)
            {
                if (wordDictionary.ContainsKey(happiness[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(happiness[i], out val);
                    happinessScore += val;
                }
            }

            int sadnessScore = 0;
            for (int i = 0; i < sadness.Length; i++)
            {
                if (wordDictionary.ContainsKey(sadness[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(sadness[i], out val);
                    sadnessScore += val;
                }
            }

            int stressScore = 0;
            for (int i = 0; i < stress.Length; i++)
            {
                if (wordDictionary.ContainsKey(stress[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(stress[i], out val);
                    stressScore += val;
                }
            }

            int spiritScore = 0;

            if(school.Equals("OSU")){
                for (int i = 0; i < spiritOSU.Length; i++)
                {
                    if (wordDictionary.ContainsKey(spiritOSU[i]))
                    {
                        int val = 0;
                        wordDictionary.TryGetValue(spiritOSU[i], out val);
                        spiritScore += val;
                    }
                }
            }
            if(school.Equals("UM")){
                for (int i = 0; i < spiritUM.Length; i++)
                {
                    if (wordDictionary.ContainsKey(spiritUM[i]))
                    {
                        int val = 0;
                        wordDictionary.TryGetValue(spiritUM[i], out val);
                        spiritScore += val;
                    }
                }
            }

            int[] scores = { happinessScore, sadnessScore, stressScore, spiritScore };
            return scores;
        }

        private void outputHeader()
        {
            string[] outputCodeHeader = { "<!DOCTYPE html>",
                                       "<html lang=\"en\">",
                                       "<head>",
                                       "<link rel=\"stylesheet\" type=\"text/css\" href=\"https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/css/style.css?token=7636606__eyJzY29wZSI6IlJhd0Jsb2I6T0hJT2hhY2thdGhvbjIwMTQvQ29sbGVnZU1vb2RNZXRlci9tYXN0ZXIvY3NzL3N0eWxlLmNzcyIsImV4cGlyZXMiOjE0MTMwNzk5Nzd9--5712ddcefd81e818b13d1fd6ace9249a2365b881\">",
                                       "</head>",
                                       "<body>",
                                       "<div id = \"side\"> ",
                                       "<div class = \"title\">College Mood Meter</div>",
                                       "<div class = \"description\">",
                                       "Welcome to the College Mood Meter - a Twitter analysis program that identifies students from particular colleges and determines the schools' overall mood levels.",
                                       "</div>",
                                       "<br>",
                                       "<a href = \"URL\"><div class = \"links\">GitHub Repo</div></a>",
                                       "</div>",
                                       "<div id = \"main\">"};
            
        }

        private void outputSchoolStats(string school, int happinessScore, int sadnessScore, int stressScore, int spiritScore, string[] topWords)
        {
            string[] outputCodeStats = { "<div class = \"title\">" + school + "</div>",
                                       "<br>",
                                       "<font style=\"font-size: 20px;\">Scores</font>",
                                       "<br>",
                                       "Happiness - " + happinessScore + "<br>",
                                       "Sadness - " + sadnessScore + "<br>",
                                       "Stress - " + stressScore + "<br>",
                                       "School Spirit - " + spiritScore + "<br>",
                                       "<br>",
                                       "<font style=\"font-size: 20px;\">Top Keywords</font>",
                                       "<br>",
                                       topWords[0] + " - " + topWords[1] + " - " + topWords[2] + " - " + topWords[3] + " - " + topWords[4] + " - " + topWords[5]};
        }

        private void outputFooter()
        {
            string[] outputCodeFooter = { "</div>",
                                       "</body>",
                                       "</html>"};

        }


    }
}
