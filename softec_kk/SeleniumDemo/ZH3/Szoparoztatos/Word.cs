using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoparoztatos
{
    internal class Word : Button
    {        
        public bool IsCorrectAnswer { get; set; } = false;

        public Word()
        {
            Width = 200;
            Height = 40;

            Click += Word_Click;
        }

        private void Word_Click(object? sender, EventArgs e)
        {
            if (IsCorrectAnswer)
            {
                BackColor = Color.Green;
            }
            else
            {
                BackColor = Color.Red;
            }
        }
    }
}
