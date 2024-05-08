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
    public partial class UserControl1 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            FillDataSource();
            listBox1.DisplayMember = "Name";
        }

        private void FillDataSource()
        {
            listBox1.DataSource = (from i in context.Instructors
                                   where i.Name.Contains(textBox1.Text)
                                   select i).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null) return;

            Instructor selectedInstructor = listBox1.SelectedItem as Instructor;

            var lessons = from l in context.Lessons
                          where l.InstructorFk == selectedInstructor.InstructorSk
                          select new
                          {
                              Kurzus = l.CourseFkNavigation.Name,
                              Nap = l.DayFkNavigation.Name,
                              Sáv = l.TimeFkNavigation.Name
                          };
            
            var lessons2 = context.Lessons.Where(l => l.InstructorFk == selectedInstructor.InstructorSk)
                .Select(l => new
                {
                    Kurzus = l.CourseFkNavigation.Name,
                    Nap = l.DayFkNavigation.Name,
                    Sáv = l.TimeFkNavigation.Name
                });

            dataGridView1.DataSource = lessons.ToList();
        }
    }
}
