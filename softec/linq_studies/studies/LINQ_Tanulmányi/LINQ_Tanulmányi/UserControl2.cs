using LINQ_Tanulmányi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Tanulmányi
{
    public partial class UserControl2 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl2()
        {
            InitializeComponent();

            FillDataSource();
            listBox1.DisplayMember = "Name";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Course course = listBox1.SelectedItem as Course;

            dataGridView1.DataSource = (from l in context.Lessons
                                        where l.CourseFk == course.CourseSk
                                        select new
                                        {
                                            Nap = l.DayFkNavigation.Name,
                                            Sáv = l.TimeFkNavigation.Name,
                                            Oktató = l.InstructorFkNavigation.Name
                                        }).ToList();
        }

        private void FillDataSource()
        {
            listBox1.DataSource = (from c in context.Courses
                                   where c.Name.Contains(textBox1.Text)
                                   select c).ToList();
        }
    }
}
