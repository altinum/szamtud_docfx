using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace koch
{
    class Teki
    {
        double x, y, szog;
        Graphics rajzlap;


        public Teki(Graphics rajzlap)
        {
            this.rajzlap = rajzlap;

        }

        public Teki(Graphics rajzlap, double x, double y)
        {
            this.rajzlap = rajzlap;
            this.x = x;
            this.y = y;

        }



        public void elore(double tavolsag)
        {
            double uj_x = this.x + tavolsag * Math.Cos(szog * Math.PI / 180);
            double uj_y = this.y + tavolsag * Math.Sin(szog * Math.PI / 180);

            rajzlap.DrawLine(new Pen(Color.Black),(int)x, (int)y,(int)uj_x,(int)uj_y);

            this.x = uj_x;
            this.y = uj_y;
        }

        public void jobbra(double szog)
        {
            this.szog += szog;

        }

        public void balra(double szog)
        {

            this.szog -= szog;
        }


    }
}
