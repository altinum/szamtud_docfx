namespace Quiz
{
    public partial class Form1 : Form
    {
        List<Question> questions = new List<Question>();
        List<Question> answeredQuestions = new List<Question>();
        int currentQuestion = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("multichoice.csv");

            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(";");
                if (s.Length != 6) continue;
                
                Question question = new Question();

                question.QuestionText= s[0];
                question.Answer1 = s[1];
                question.Answer2 = s[2];
                question.Answer3 = s[3];
                question.Answer4 = s[4];
                question.CorrectAnswerId = int.Parse(s[5]);

                questions.Add(question);
            }

            sr.Close();
        }

        void DisplayQuestion()
        {
            label1.Text = questions[currentQuestion].QuestionText;
            button1.Text = questions[currentQuestion].Answer1;
            button2.Text = questions[currentQuestion].Answer2;
            button3.Text = questions[currentQuestion].Answer3;
            button4.Text = questions[currentQuestion].Answer4;
        }

        void NextQuestion()
        {
            currentQuestion++;
            if (currentQuestion >= questions.Count) currentQuestion = 0;
            DisplayQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NextQuestion();
        }
    }
}