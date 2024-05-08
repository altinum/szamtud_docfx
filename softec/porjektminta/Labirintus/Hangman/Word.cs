using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
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
}
