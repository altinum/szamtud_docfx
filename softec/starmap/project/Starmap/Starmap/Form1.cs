

using Starmap.Models;

namespace Starmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HajosContext context = new HajosContext();

            var stars = (from s in context.StarData select new {s.Hip, s.X, s.Y, s.Magnitude }).ToList();

            var stars2 = context.StarData.Select(s => new { s.Hip, s.X, s.Y, s.Magnitude }).ToList();

            double nagyitás = 500;

            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Color c = Color.Black;
            Pen toll = new Pen(c, 1);
            Brush brush = new SolidBrush(c);

            float cx = ClientRectangle.Width / 2;
            float cy = ClientRectangle.Height / 2;

           

            foreach (var s in stars)
            {
                if (Math.Sqrt(Math.Pow(s.X, 2) + Math.Pow(s.Y, 2)) > 1) continue;

                float x1 = (float)(nagyitás * s.X);
                float y1 = (float)(nagyitás * s.Y);

                double size = 20 * Math.Pow(10, (s.Magnitude) / -2.5);
                if (size < 1) size = 1;
                g.FillEllipse(brush, x1 + cx, y1 + cy, (float)size, (float)size);
            }

            var lines = context.ConstellationLines.ToList();

            foreach (var line in lines)
            {
                var star1 = (from s in stars where s.Hip == line.Star1 select s).FirstOrDefault();
                var star2 = (from s in stars where s.Hip == line.Star2 select s).FirstOrDefault();

                if (star1 == null || star2 == null) continue;              

                float x1 = (float)(nagyitás * star1.X);
                float y1 = (float)(nagyitás * star1.Y);
                float x2 = (float)(nagyitás * star2.X);
                float y2 = (float)(nagyitás * star2.Y);

                g.DrawLine(toll, x1 + cx, y1 + cy, x2 + cx, y2 + cy);
            }
            
        }
    }
}
