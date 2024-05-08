# Akasztófa játék

> [!NOTE]
>
> Az alábbi kódrészlet nincs kidolgozva, csak elindulni segíthet a problémamegoldásban.

```csharp
internal class Word
{
    string wordToGuess;

    public string WordMask { get; private set; }

    public Word(string wordToGuess)
    {
        this.wordToGuess = wordToGuess.ToUpper();
        this.WordMask = new string('_', wordToGuess.Length);
    }

    public bool Guess(char letter)
    {
        bool found = false;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == char.ToUpper(letter))
            {
                char[] tempWordMask = WordMask.ToCharArray();
                tempWordMask[i] = letter;
                WordMask = new string(tempWordMask);
                found = true;
            }
        }
        return found;
    }
}
```

A `Form1` kódja:

```c#
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
```

