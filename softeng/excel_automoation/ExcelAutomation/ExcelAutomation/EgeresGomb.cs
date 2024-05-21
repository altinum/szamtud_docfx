using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAutomation
{
    internal class EgeresGomb : Button
    {
        public EgeresGomb()
        {
            Width = 40;
            Height = 40;
            Text = ":)";

            MouseEnter += EgeresGomb_MouseEnter;
            MouseLeave += EgeresGomb_MouseLeave;    
        }


        public EgeresGomb(int méret)
        {
            Width = méret;
            Height = méret;
            Text = ":)";

            MouseEnter += EgeresGomb_MouseEnter;
            MouseLeave += EgeresGomb_MouseLeave;
        }

        private void EgeresGomb_MouseLeave(object? sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void EgeresGomb_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.Red;
        }

        public void MenjArrébb(int mennyit)
        {
            Left += mennyit;
        }        

        public int Titok { get; set; }
    }
}
