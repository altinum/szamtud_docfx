using ClosedXML.Excel;

namespace WinFormsAppExcelDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
             XLWorkbook workbook = new XLWorkbook("c:/temp/Sample.xlsx");
            
             var worksheet = workbook.Worksheet(1);

             int sorokSzáma = worksheet.RowsUsed().Count();

            for (int i = 1; i <= sorokSzáma; i++)
            {
                if (worksheet.Cell(i, 1).TryGetValue<int>(out int x))
                {

                }
                else
                {
                    MessageBox.Show("Hibás adat");
                }


                int cellValue = worksheet.Cell(i, 1).GetValue<int>();
                if (cellValue>80)
                {
                    worksheet.Cell(i, 1).Style.Fill.SetBackgroundColor(XLColor.RedMunsell);
                }
                
            }

            workbook.SaveAs("c:/temp/Sample2.xlsx");

        }
    }
}
