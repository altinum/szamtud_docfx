namespace LINQ_Tanulmányi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl1 uc = new UserControl1();   
            panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
