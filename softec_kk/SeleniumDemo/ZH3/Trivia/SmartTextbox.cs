using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    internal class SmartTextbox : TextBox
    {
        public int CorrectAnswer { get; set; }

        void ChechAnswer()
        {
            if (int.TryParse(Text, out int x))
            {
                if (x == CorrectAnswer)
                {
                    BackColor = Color.LightGreen;
                }
                else
                {
                    BackColor = Color.Coral;
                }
            }

        }

        void Reset()
        {
            BackColor = Color.White;
        }
    }
}
