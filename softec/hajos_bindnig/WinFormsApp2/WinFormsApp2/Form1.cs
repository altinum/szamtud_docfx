using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        BindingList<Futok> futoks = new BindingList<Futok>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = futoks;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("futottakmeg.txt");
            var  csv = new CsvReader(sr,CultureInfo.InvariantCulture);
            var  t = csv.GetRecords<Futok>();

            foreach (var item in t)
            {
                futoks.Add(item);
            }






            sr.Close();

            double �sszeg = 0;
            foreach (var item in futoks)
            {
                �sszeg += item.EredmenyPerc;
            }

            double �tlag = �sszeg / futoks.Count();

            MessageBox.Show(�tlag.ToString());

        }
    }
}
