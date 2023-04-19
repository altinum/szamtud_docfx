using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace koch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Teki béla = new Teki(this.CreateGraphics(), 50, this.Height/2);
            koch(béla, 120);



        }

        private void koch(Teki teknos, double hossz)
        {

            if (hossz < 5)
            {
                          
                teknos.elore(hossz);
                teknos.balra(60);
                teknos.elore(hossz);
                teknos.jobbra(120);
                teknos.elore(hossz);
                teknos.balra(60);
                teknos.elore(hossz);
                
            }
            else
            {
                koch(teknos, hossz / 3);
                teknos.balra(60);
                koch(teknos, hossz / 3);
                teknos.jobbra(120);
                koch(teknos, hossz / 3);
                teknos.balra(60);
                koch(teknos, hossz / 3);
            }
            
        }

    }
}
