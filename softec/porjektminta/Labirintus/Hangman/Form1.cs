namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Word word;
        private void Form1_Load(object sender, EventArgs e)
        {
            word = new Word("Megszentségteleníthetetlenségeskedéseitekért");
            KeyPress += Form1_KeyPress;

        }

        private void Form1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (word.Guess(e.KeyChar))
            {
                label1.Text = word.WordMask;
            }
            else
            {
                //hiba++
            }
        }
    }
}
