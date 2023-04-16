using System.ComponentModel;

namespace InMemory
{
    public partial class Form1 : Form
    {
        BindingList<Models.Student> students = new BindingList<Models.Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Models.Student student = new Models.Student();

            student.Name = "X Y";
            student.Neptun = "ABC123";
            student.IsActive = true;

            students.Add(student);

            studentBindingSource.DataSource = students;
        }
    }
}