using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fraktal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Törlés();
        }

        const double nagyitás = 40;

        private void button1_Click(object sender, EventArgs e)
        {
            Rajzolas();
        }

        Bitmap bmp = new Bitmap(1500, 1500);

        private void Rajzolas()
        {
            Graphics g = panel1.CreateGraphics();
            panel1.Height = bmp.Height;
            panel1.Width = bmp.Width;

            double[,] matrix = new double[4, 6]
           {
               {0.00,0.00,0.16,0.00,0.00,0.00},
               {0.85,0.04,-0.04,0.85,0.00,1.60},
               {0.20,-0.26,0.23,0.22,0.00,1.60},
               {-0.15,0.28,0.26,0.24,0.00,0.44},
           };

            double x = 0;
            double y = 0;
            Random rnd=new Random();

            for (int i = 0; i < 15000; i++)
            {
                int v = rnd.Next(100);
                int sor = 0;
                if (v<=1) sor = 0;
                if (v>1 && v<=86)  sor = 1;
                if (v>86 && v<=93) sor = 2;
                if (v>93) sor = 3;

                double a = matrix[sor, 0];
                double b = matrix[sor, 1];
                double c = matrix[sor, 2];
                double d = matrix[sor, 3];
                double e = matrix[sor, 4];
                double f = matrix[sor, 5];

                double nx = a * x + b * y + e;
                double ny = c * x + d * y + f;

                x = nx;
                y = ny;

                g.DrawLine(new Pen(Color.Red), (int)(x * nagyitás), (int)(y * nagyitás), (int)(x * nagyitás) + 1, (int)(y * nagyitás));

                if ((int)((x * nagyitás) + 150 )> bmp.Width-2 || (int)((y * nagyitás) + 50) > bmp.Height-2 || (int)(x*nagyitás + 150) < 0 || (int)(y*nagyitás + 50) < 0) continue;

              
                Color szín = bmp.GetPixel((int)(x * nagyitás) + 150, (int)(y * nagyitás) + 50);

                int zöld = szín.G;
                if (zöld < 244) zöld += 10;
                bmp.SetPixel((int)(x * nagyitás) + 150, (int)(y * nagyitás) + 50, Color.FromArgb(0, zöld, 0));            
            }
            //g.DrawImage(bmp, 1, 1);            
        }

        private void Törlés()
        {
            Graphics gbmp = Graphics.FromImage(bmp);
            gbmp.FillRectangle(new SolidBrush(Color.Black), 0, 0, bmp.Height, bmp.Width);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Törlés();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawImage(bmp, 1, 1);    
        }
    }
}
