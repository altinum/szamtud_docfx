namespace Labirintus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox player = new PictureBox();

        List<PictureBox> bricks = new List<PictureBox>();

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("maze1.txt");
            int y = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                for (int x = 0; x < sor.Length; x++)
                {                    
                    if (sor[x] == '#')
                    {
                        PictureBox pb = new PictureBox();
                        pb.Location = new Point(x * 20, y * 20);
                        pb.Size = new Size(20, 20);
                        pb.BackColor = Color.Black;
                        this.Controls.Add(pb);
                        bricks.Add(pb);
                    }                                                        
                }
                y++;
            }

            player.Location = new Point(0, 0);
            player.Size = new Size(20, 20);
            player.BackColor = Color.Red;
            Controls.Add(player);    

            KeyDown += Form1_KeyDown; 
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            int x = player.Location.X;
            int y = player.Location.Y;

            if (e.KeyCode == Keys.Right)
            {
                x += 20;
            }

            if (e.KeyCode == Keys.Left)
            {
                x -= 20;
            }

            if (e.KeyCode == Keys.Up)
            {
                y -= 20;
            }

            if (e.KeyCode == Keys.Down)
            {
               y += 20;
            }

            var wall = bricks.FirstOrDefault(w => w.Location.X == x && w.Location.Y == y);
            if (wall == null)
            {
                player.Location = new Point(x, y);
            }   
        }
    }
}
