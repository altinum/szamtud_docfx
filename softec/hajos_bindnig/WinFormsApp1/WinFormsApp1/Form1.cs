namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchMatrix(1, 2);
        }

        async void SwitchMatrix(int input, int output)
        {

            string destination = "http://192.168.191.114/cgi-bin/instr";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    
                    string requestBody = "{\"comhead\":\"video switch\",\"language\":0,\"source\":[1,2]}";
                    HttpContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(destination, content);

                    label1.Text = response.StatusCode.ToString();

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

    }
}
