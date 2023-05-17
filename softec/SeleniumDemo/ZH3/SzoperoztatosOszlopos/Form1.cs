namespace SzoperoztatosOszlopos
{
    public partial class Form1 : Form
    {
        List<Word> words = new List<Word>();
        Word lastWord;
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
                Word latinWord = new Word();
                Word hungarianWord = new Word();
                latinWord.ID = i;
                hungarianWord.ID = i;

                latinWord.Text = s[0];
                hungarianWord.Text = s[1];         

                hungarianWord.BackColor= Color.White;

                words.Add(latinWord);
                words.Add(hungarianWord);

                i++;
            }

            
            for (int j = 0; j < i; j++)
            {
                int sor = j / 5;
                int oszlop = j % 5;

                words[j].Top = sor * words[j].Height;
                words[j].Left = oszlop * words[j].Width;

                Controls.Add(words[j]);

                words[j].Click += Form1_Click;
            }


            sr.Close();

            ShuffleWords();
        }

        private void Form1_Click(object? sender, EventArgs e)
        {
            Word currentWord = sender as Word;

            if (lastWord != null && currentWord != lastWord && currentWord.ID == lastWord.ID)
            {
                Controls.Remove(lastWord);
                Controls.Remove(currentWord);
            }

            lastWord = sender as Word;
        }

        void ShuffleWords()
        {

        }
    }
}