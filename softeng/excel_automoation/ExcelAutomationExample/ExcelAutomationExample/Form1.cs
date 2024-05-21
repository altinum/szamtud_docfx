using ClosedXML.Excel;

namespace ExcelAutomationExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sample Sheet");



            worksheet.Cell("A1").Value = "Hello World!";
            worksheet.Cell("A2").FormulaA1 = "A1";

            worksheet.Cells("A3:A4").Style.Fill.BackgroundColor = XLColor.Red;
            worksheet.Cell(3,3).Value = "This is red";

            var range = worksheet.Range("B2:C5");
            range.Cell(1, 1).Value = "HEllo";
            range.Style.Fill.BackgroundColor = XLColor.Blue;

            for (int i = 1; i <= 100; i++)
            {
                
                if (i > 2)
                {
                    int �rt�k1=worksheet.Cell(i-1, 1).GetValue<int>();
                    int �rt�k2 = worksheet.Cell(i - 2, 1).GetValue<int>();
                    worksheet.Cell(i, 1).Value = �rt�k1 + �rt�k2;
                }
                else
                {
                    worksheet.Cell(i, 1).Value = 1;
                }



            }

            workbook.SaveAs("c:/temp/HelloWorld.xlsx");
        }
    }
}
