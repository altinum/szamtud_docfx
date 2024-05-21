using ClosedXML.Excel;
using System.Threading.Tasks.Sources;

namespace ExcelAutomation
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

            worksheet.Cell(1,1).Value = "Hello World!";

            worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Blue;

            workbook.SaveAs("c:/tmp/HelloWorld.xlsx");




        }
    }
   
}
