namespace Trivia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("trivia.csv", true);
            int i = 0;
            int spacing = 50;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (line == null) continue;

                string[] s = line.Split(";");

                if (s.Length != 2) continue;

                Label label = new Label();
                label.Text = s[0];
                label.AutoSize = true;

                SmartTextbox smartTextbox = new SmartTextbox();
                smartTextbox.CorrectAnswer = int.Parse(s[1]);

                HintButton hintButton = new HintButton();
                hintButton.Hint = s[1];

                label.Top = i * spacing+10;
                smartTextbox.Top = i * spacing+10;
                hintButton.Top= i * spacing + 10;
                smartTextbox.Left = 600;
                hintButton.Left = 720;

                i++;

                Controls.Add(label);
                Controls.Add(smartTextbox); 
                Controls.Add(hintButton);
            }

            sr.Close();
        }
    }
}