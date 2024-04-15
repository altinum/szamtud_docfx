//using CsvHelper;
using CsvHelper;
using System.ComponentModel;
using System.Diagnostics.PerformanceData;
using System.Globalization;


namespace hajos_binding
{
    public partial class Form1 : Form
    {

        BindingList<VizsgaKérdés> kérdések = new();
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
        var tömb = csv.GetRecords<VizsgaKérdés>();

        foreach (var item in tömb)
        {
            kérdések.Add(item);
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
    dataGridView1.DataSource = kérdések;
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
        csv.WriteRecords(kérdések);
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
    if (vizsgaKérdésBindingSource.Current == null) return;

    if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        vizsgaKérdésBindingSource.RemoveCurrent();
    }

}

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new FormAddNew();

            if (formAddNew.ShowDialog() == DialogResult.OK)
            {
                kérdések.Add(formAddNew.ÚjVizsgaKérdés);

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (vizsgaKérdésBindingSource.Current is VizsgaKérdés)
            {
                FormEdit formEdit = new FormEdit();
                formEdit.ÚjVizsgaKérdés = (VizsgaKérdés)vizsgaKérdésBindingSource.Current;
                formEdit.Show();
            }



        }
    }
}
