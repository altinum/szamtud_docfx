namespace Többablakos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormA fc = new FormA();
            fc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormB fb =  new FormB();
            fb.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormC fb = new FormC();
            fb.ShowDialog();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserControlA uca = new UserControlA();
            panel1.Controls.Clear();
            panel1.Controls.Add(uca);
            uca.Dock = DockStyle.Fill;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserControlB ucb = new UserControlB();
            panel1.Controls.Clear();
            panel1.Controls.Add(ucb);
            ucb.Dock = DockStyle.Fill;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserControlC ucc = new UserControlC();
            panel1.Controls.Clear();
            panel1.Controls.Add(ucc);
            ucc.Dock = DockStyle.Fill;
        }

        private void kilépésToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}