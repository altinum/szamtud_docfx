namespace ZH3_A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(uc1);
        }
    }
}
