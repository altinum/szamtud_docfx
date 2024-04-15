//using CsvHelper;
using CsvHelper;
using System.ComponentModel;
using System.Diagnostics.PerformanceData;
using System.Globalization;


namespace hajos_binding
{
    public partial class Form1 : Form
    {

        BindingList<VizsgaK�rd�s> k�rd�sek = new();
        public Form1()
        {
            InitializeComponent();
        }

private void buttonOpen_Click(object sender, EventArgs e)
{
    try
    {
        StreamReader sr = new StreamReader("hajozasi_szabalyzat_coma.txt");
        var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
        var t�mb = csv.GetRecords<VizsgaK�rd�s>();

        foreach (var item in t�mb)
        {
            k�rd�sek.Add(item);
        }


        sr.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}

private void Form1_Load(object sender, EventArgs e)
{
    dataGridView1.DataSource = k�rd�sek;
}

        private void buttonSave_Click(object sender, EventArgs e)
        {
try
{
    SaveFileDialog saveFileDialog = new SaveFileDialog();

    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
        var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
        csv.WriteRecords(k�rd�sek);
        sw.Close();
    }
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message);
}
        }

private void buttonDelete_Click(object sender, EventArgs e)
{
    if (vizsgaK�rd�sBindingSource.Current == null) return;

    if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        vizsgaK�rd�sBindingSource.RemoveCurrent();
    }

}

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new FormAddNew();

            if (formAddNew.ShowDialog() == DialogResult.OK)
            {
                k�rd�sek.Add(formAddNew.�jVizsgaK�rd�s);

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (vizsgaK�rd�sBindingSource.Current is VizsgaK�rd�s)
            {
                FormEdit formEdit = new FormEdit();
                formEdit.�jVizsgaK�rd�s = (VizsgaK�rd�s)vizsgaK�rd�sBindingSource.Current;
                formEdit.Show();
            }



        }
    }
}
