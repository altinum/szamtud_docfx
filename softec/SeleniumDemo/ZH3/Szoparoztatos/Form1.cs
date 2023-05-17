using System.Diagnostics;

namespace Szoparoztatos
{
    public partial class Form1 : Form
    {
        List<WordPair> wordPairs = new List<WordPair>();        

        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("words.csv", true);

            int i = 0;
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(";");
                WordPair wordPair = new WordPair();
                wordPair.Latin = s[0];
                wordPair.Hungarian = s[1];

                wordPairs.Add(wordPair);          
            }


            sr.Close();

            DisplayWord();
        }


        void DisplayWord()
        {
            flowLayoutPanel1.Controls.Clear();

            int wordId = rnd.Next(wordPairs.Count);
            label1.Text = wordPairs[wordId].Latin;

            List<Word> answers = new List<Word>();

            //A helyes válasz
            Word word = new Word();
            word.Text = wordPairs[wordId].Hungarian;
            word.IsCorrectAnswer = true;

            answers.Add(word);

            //A fals válaszok
            for (int i = 0; i < 14; i++)
            {
                int id = rnd.Next(wordPairs.Count);
                Word w = new Word();
                w.Text = wordPairs[id].Hungarian;
                answers.Add(w);
            }

            //keverés
            for (int i = 0; i < 15; i++)
            {
int melyiket = rnd.Next(answers.Count);
flowLayoutPanel1.Controls.Add(answers[melyiket]);
answers.RemoveAt(melyiket);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayWord();
        }
    }
}