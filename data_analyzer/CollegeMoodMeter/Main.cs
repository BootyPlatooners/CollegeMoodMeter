//-------------------------------------------------------------------------------------------//
// This program takes data files provided by the Python application, analyzes it,
// and outputs it to a static HTML webpage.
//
// Author: Kevin Payravi (http://www.kevinpayravi.com/)
//-------------------------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CollegeMoodMeter
{
    public partial class Main : Form
    {
        string path = "C:\\Users\\Kayvan\\Desktop\\index.html";

        public Main()
        {
            InitializeComponent();
         
            // Output HTML header:
            outputHeader();

            // Instantiate links to data files outputted to GitHub by Python program:
            string wordFileOSU = "C:\\Users\\Kayvan\\Desktop\\Osu.txt";
            string wordFileUM = "C:\\Users\\Kayvan\\Desktop\\Mich.txt";

            // Instantiate constant keywords for mood categories; customized school spirit keywords are below.
            string[] happiness = { "<3", ":)", ":-)", ":]", ":D", ";)", ";]", "^^", "better", "easy", "ecstatic", "excited", "family", "friends", "fun", "funny", "glad", "good", "happiest", "happiness", "happy", "hilarious", "kind", "kindness", "laugh", "laughing", "lol", "love", "loving", "nice", "passed", "win", "winning", "xD", "yay", "yes" };
            string[] sadness = { ":(", ":-(", ":[", ";(", "bad", "crying", "D:", "depressed", "depressing", "depression", "disgust", "disgusting", "Dx", "enemies", "fat", "fml", "gross", "hard", "hate", "idiot", "impolite", "judgement", "lose", "miserable", "miss", "mistake", "rude", "sad", "saddening", "saddest", "sadness", "shitty", "sick", "sin", "stupid", "suck", "sucks", "useless", "worst", "worthless" };
            string[] stress = { "2am", "could've", "exam", "exams", "fail", "failed", "failure", "finals", "help", "homework", "job", "late", "midterm", "midterms", "money", "more", "procrastinate", "procrastination", "regret", "should've", "stress", "stressed", "stressed", "stressing", "studying", "wish" };

            //-------------------------------------------------------------------------------------------//
            // ADDING/CHANGING SCHOOLS? The only code that needs to be edited is below.
            //-------------------------------------------------------------------------------------------//

            // Process Ohio State data:
            Dictionary<string, int> wordDictionaryOSU = new Dictionary<string, int>();
            wordDictionaryOSU = readFile(wordFileOSU, wordDictionaryOSU);
            string[] topWordsOSU = topWords(wordDictionaryOSU);
            int[] topWordsCountsOSU = topWordsCounts(wordDictionaryOSU);
            string[] spiritOSU = { "bestcollege", "coolestcollege", "football", "gameday", "gored", "undefeated", "brutus", "buckeye", "buckeyes", "buckeyebrutus", "gobucks", "goosu", "iloveosu", "loveosu", "osufootball", "scarletandgray", "scarletandgrey" };
            int[] scoresOSU = scorer("OSU", wordDictionaryOSU, happiness, sadness, stress, spiritOSU);
            int totalScoreOSU = scoresOSU[0] - scoresOSU[1] - scoresOSU[2] + scoresOSU[3];
            outputSchoolStats("Ohio State University", scoresOSU[0], scoresOSU[1], scoresOSU[2], scoresOSU[3], totalScoreOSU, topWordsOSU, topWordsCountsOSU);

            // Process Michigan data:
            Dictionary<string, int> wordDictionaryUM = new Dictionary<string, int>();
            wordDictionaryUM = readFile(wordFileUM, wordDictionaryUM);
            string[] topWordsUM = topWords(wordDictionaryUM);
            int[] topWordsCountsUM = topWordsCounts(wordDictionaryUM);
            string[] spiritUM = { "bestcollege", "coolestcollege", "football", "gameday", "gored", "undefeated", "biff", "chadtough", "gobigblue", "goblue", "gomichigan", "wolverine", "wolverines" };
            int[] scoresUM = scorer("UM", wordDictionaryUM, happiness, sadness, stress, spiritUM);
            int totalScoreUM = scoresUM[0] - scoresUM[1] - scoresUM[2] + scoresUM[3];
            outputSchoolStats("University of Michigan", scoresUM[0], scoresUM[1], scoresUM[2], scoresUM[3], totalScoreUM, topWordsUM, topWordsCountsUM);

            //-------------------------------------------------------------------------------------------//
            // ADDING/CHANGING SCHOOLS? The only code that needs to be edited is above.
            //-------------------------------------------------------------------------------------------//

            // Output HTML footer:
            outputFooter();

        }

        //-------------------------------------------------------------------------------------------//
        // readFile: Take 
        //-------------------------------------------------------------------------------------------//
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

                if (word.Length > 2 && !word.Equals("the") && !word.Equals("they") && !word.Equals("not") && !word.Equals("some") && !word.Equals("did") && !word.Equals("his") && !word.Equals("her") && !word.Equals("has") && !word.Equals("but") && !word.Equals("how") && !word.Equals("who") && !word.Equals("too") && !word.Equals("w/") && !word.Equals("you") && !word.Equals("him") && !word.Equals("her") && !word.Equals("these") && !word.Equals("those") && !word.Equals("that") && !word.Equals("and") && !word.Equals("for") && !word.Equals("this") && !word.Equals("with") && !word.Equals("when") && !word.Equals("your") && !word.Equals("you're") && !word.Equals("what") && !word.Equals("just") && !word.Equals("youre") && !word.Equals("are") && !word.Equals("your") && !word.Equals("from") && !word.Equals("all") && !word.Equals("get") && !word.Equals("one") && !word.Equals("can") && !word.Equals("have") && !word.Equals("was") && !word.Equals("its") && !word.Equals("out"))
                {
                    wordDictionary.Add(word, count);
                }
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
            temp = wordDictionary.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            string[] topWords = temp.Keys.ToArray();

            return topWords;
        }

        private int[] topWordsCounts(Dictionary<String, int> wordDictionary)
        {
            // Define temporary dictionary:
            Dictionary<string, int> temp = new Dictionary<string, int>();

            // Grab top 10 words, place into temporary dictionary, and put into array:
            temp = wordDictionary.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            int[] topWords = temp.Values.ToArray();

            return topWords;
        }

        private int[] scorer(string school, Dictionary<String, int> wordDictionary, string[] happiness, string[] sadness, string[] stress, string[] spirit)
        {
            double happinessScore = 0.0;
            for (int i = 0; i < happiness.Length; i++)
            {
                if (wordDictionary.ContainsKey(happiness[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(happiness[i], out val);
                    happinessScore += val;
                }
            }

            double sadnessScore = 0.0;
            for (int i = 0; i < sadness.Length; i++)
            {
                if (wordDictionary.ContainsKey(sadness[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(sadness[i], out val);
                    sadnessScore += val;
                }
            }

            double stressScore = 0.0;
            for (int i = 0; i < stress.Length; i++)
            {
                if (wordDictionary.ContainsKey(stress[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(stress[i], out val);
                    stressScore += val;
                }
            }

            double spiritScore = 0.0;
            for (int i = 0; i < spirit.Length; i++)
            {
                if (wordDictionary.ContainsKey(spirit[i]))
                {
                    int val = 0;
                    wordDictionary.TryGetValue(spirit[i], out val);
                    spiritScore += (double)val;
                }
            }

            int numWords = wordDictionary.Count();
            int happinessScoreFinal = (int)Math.Truncate((happinessScore / numWords) * 1000);
            int sadnessScoreFinal = (int)Math.Truncate((sadnessScore / numWords) * 1000);
            int stressScoreFinal = (int)Math.Truncate((stressScore / numWords) * 1000);
            int spiritScoreFinal = (int)Math.Truncate((spiritScore / numWords) * 1000);

            int[] scores = { happinessScoreFinal, sadnessScoreFinal, stressScoreFinal, spiritScoreFinal };

            return scores;
        }

        private void outputHeader()
        {
            string urlStyle = "https://rawgit.com/OHIOhackathon2014/CollegeMoodMeter/master/css/style.css";
            string urlOSU = "https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/images/osu.gif";
            string urlLogo = "https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/images/logo.png";
            string urlMich = "https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/images/mich.gif";
            string urlRepo = "https://github.com/OHIOhackathon2014/CollegeMoodMeter";
            string urlOHIO = "https://www.ohiohackathon.org/";

            string[] outputCodeHeader = { "<!DOCTYPE html>",
                                       "<html lang=\"en\">",
                                       "<head>",
                                       "<link rel=\"stylesheet\" type=\"text/css\" href=\"" + urlStyle + "\">",
                                       "</head>",
                                       "<body>",
                                       "<div id = \"side\"> ",
                                       "<div class = \"description\">",
                                       "Welcome to the College Mood Meter - a Twitter analysis program that identifies students from particular colleges and determines the schools' overall mood levels.<br><br>Analysis is done through Twitter searches via the Twitter API. First, a list of students from each college is compiled by finding recent mentions of particular keywords and account mentions used most exclusively by current students from that particular college. The last 200 tweets for each of these users is then compiled. The most commonly occuring words are recorded, along with performing a search for specific keywords that indicate each of the four moods. Then, the number of occurences of these keywords are recorded. Using the extracted data, mood levels are assigned to each of the colleges based on the keyword occurrence counts.<br><br>The current program is built to analyze Ohio State and University of Michigan students, which can easily be expanded to other schools (or other user sets).",
                                       "</div>",
                                       "<br>",
                                       "<a href = \"" + urlRepo + "\"><div class = \"links\">GitHub Repo</div></a>",
                                       "<a href = \"" + urlOHIO + "\"><div class = \"links\">Made with <3 at OHI/O</div></a>",
                                       "</div>",
                                       "<div id = \"main\">",
                                       "<img src=\"" + urlOSU + "\" width=\"200px\">",
                                       "<img src=\"" + urlLogo + "\" width=\"360px\">",
                                       "<img src=\"" + urlMich + "\" width=\"200px\">",
                                       };

            File.WriteAllLines(path, outputCodeHeader, Encoding.UTF8);
            
        }

        private void outputSchoolStats(string school, int happinessScore, int sadnessScore, int stressScore, int spiritScore, int totalScore, string[] topWords, int[] topWordsCounts)
        {
            string[] outputCodeStats = { "<br><br><br>",
                                       "<div class = \"title\">"};
            
            string urlSchoolLogo = "";
            if(school.Equals("Ohio State University")){
                urlSchoolLogo = "https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/images/osulogoclose.png";
            }else if(school.Equals("University of Michigan")){
                urlSchoolLogo = "https://raw.githubusercontent.com/OHIOhackathon2014/CollegeMoodMeter/master/images/michlogoclose.png";
            }
            
            string[] outputCodeStats2 = { "<img src=\"" + urlSchoolLogo + "\" width=\"400px\"></div>",
                                       "<font style=\"font-size: 20px;\">Scores</font>",
                                       "<br>",
                                       "Happiness - <font color=\"green\">" + happinessScore + "</font><br>",
                                       "Sadness - <font color=\"red\">" + sadnessScore + "</font><br>",
                                       "Stress - <font color=\"red\">" + stressScore + "</font><br>",
                                       "School Spirit - <font color=\"green\">" + spiritScore + "</font><br>",
                                       "<br>",
                                       "<font style=\"font-size: 20px;\">Total Score</font>",
                                       "<br>",
                                       "<font style=\"font-size: 20px;\">" + totalScore + "</font>",
                                       "<br><br>",
                                       "<font style=\"font-size: 20px;\">Top Keywords</font>",
                                       "<br>",
                                       topWords[0] + " <font size=\"2\">(" + topWordsCounts[0] + ")</font> • " +  topWords[1] + " <font size=\"2\">(" + topWordsCounts[1] + ")</font> • " +  topWords[2] + " <font size=\"2\">(" + topWordsCounts[2] + ")</font> • " +  topWords[3] + " <font size=\"2\">(" + topWordsCounts[3] + ")</font><br>" +  topWords[4] + " <font size=\"2\">(" + topWordsCounts[4] + ")</font> • " +  topWords[5] + " <font size=\"2\">(" + topWordsCounts[5] + ")</font> • " +  topWords[6] + " <font size=\"2\">(" + topWordsCounts[6] + ")</font> • " +  topWords[7] + " <font size=\"2\">(" + topWordsCounts[7] + ")</font> • " +  topWords[8] + " <font size=\"2\">(" + topWordsCounts[8] + ")</font> • " +  topWords[9] + " <font size=\"2\">(" + topWordsCounts[9] + ")</font>"};

            File.AppendAllLines(path, outputCodeStats, Encoding.UTF8);
            File.AppendAllLines(path, outputCodeStats2, Encoding.UTF8);
        }

        private void outputFooter()
        {
            string[] outputCodeFooter = { "</div>",
                                       "</body>",
                                       "</html>"};

            File.AppendAllLines(path, outputCodeFooter, Encoding.UTF8);
        }
    }
}
