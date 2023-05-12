using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace UseCourseScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            // Megnyitjuk a neptunt
            driver.Navigate().GoToUrl("https://telex.hu");

            var x = driver.FindElements(By.ClassName("widget--rate--dn"));
            textBox1.Text= x[0].Text;
            

            driver.Close();
            driver.Quit();

        }
    }
}