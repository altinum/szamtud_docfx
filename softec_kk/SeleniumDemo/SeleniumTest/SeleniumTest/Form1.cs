namespace SeleniumTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            List<UniClass> classes = Scraper.ScrapeClasses(textBoxUser.Text, textBoxPassword.Text);
            dataGridView1.DataSource= classes;

            //Meghívjuk az excelizer példány Órarendkészítő metódusát, és odaadjuk a lekapart osztályokat
            Excelizer excelizer = new Excelizer(@"C:\temp");
            excelizer.CreateTimeTable(classes);

            MessageBox.Show("Órarend legenerálva!");
        }
    }
}