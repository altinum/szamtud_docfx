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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Teki béla = new Teki(this.CreateGraphics(), 50, this.Height / 2);
            //koch(béla, 120);

            //Hatszög(béla);
            //Ötszög(béla);
            //Spirál(béla);
            Napocska(béla);
        }

        void Hatszög(Teki teknos)
        {
            for (int i = 0; i < 6; i++)
            {
                teknos.MenjElőre(100);
                teknos.ForduljJobbra(60);
            }
        }

        void Ötszög(Teki teknos)
        {
            for (int i = 0; i < 5; i++)
            {
                teknos.MenjElőre(200);
                teknos.ForduljJobbra(144);
            }
        }

        void Spirál(Teki teknos)
        {
            for (int i = 0; i < 20; i++)
            {
                teknos.MenjElőre(i * 10);
                teknos.ForduljJobbra(60);
            }
        }

        void Napocska(Teki teknos)
        {
            for (int i = 0; i < 36; i++)
            {
                teknos.MenjElőre(250);
                teknos.ForduljJobbra(170);
            }
        }

        private void koch(Teki teknos, double hossz)
        {
            if (hossz < 5)
            {

                teknos.MenjElőre(hossz);
                teknos.balra(60);
                teknos.MenjElőre(hossz);
                teknos.ForduljJobbra(120);
                teknos.MenjElőre(hossz);
                teknos.balra(60);
                teknos.MenjElőre(hossz);
            }
            else
            {
                koch(teknos, hossz / 3);
                teknos.balra(60);
                koch(teknos, hossz / 3);
                teknos.ForduljJobbra(120);
                koch(teknos, hossz / 3);
                teknos.balra(60);
                koch(teknos, hossz / 3);
            }
        }

    }
}
