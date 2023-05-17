using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    internal class HintButton : Button
    {
        public string Hint { get; set; }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public HintButton()
        {
            timer.Interval= 1000;
            Click += HintButton_Click;
            timer.Tick += Timer_Tick;

            Height = 30;
            Text = "?";
                
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Text = "";
            timer.Enabled = false;
        }

        private void HintButton_Click(object? sender, EventArgs e)
        {
            Text = Hint;
            timer.Enabled = true;
        }
    }
}
