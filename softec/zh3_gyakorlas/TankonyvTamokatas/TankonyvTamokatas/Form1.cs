using TankonyvTamokatas.Models;

namespace TankonyvTamokatas
{
    public partial class Form1 : Form
    {
        TextbookSupportContext context = new TextbookSupportContext();
        public Form1()
        {
            InitializeComponent();
        }

private void Form1_Load(object sender, EventArgs e)
{
    var students = context.Students.ToList();
    var textbooks = context.Textbooks.ToList();

    listBox1.DataSource = students;
    listBox1.DisplayMember = "Name";
    listBox1.ValueMember = "StudentId";

    listBox3.DataSource = textbooks;
    listBox3.DisplayMember = "Title";
    listBox3.ValueMember = "TextbookId";
}

private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
{
    LoadOrders();
}

private void LoadOrders()
{
    Student student = (Student)listBox1.SelectedItem;
    var ol = from x in context.Orders
                where x.StudentFk == student.StudentId
                select new
                {
                    x.OrderSk,
                    x.StudentFk,
                    x.TextbookFkNavigation.Title
                };
    listBox2.DataSource = ol.ToList();
    listBox2.DisplayMember = "Title";
    listBox2.ValueMember = "OrderSk";
}

private void button1_Click(object sender, EventArgs e)
{
    int oID = Convert.ToInt32(listBox2.SelectedValue);
    var od = from x in context.Orders
                where x.OrderSk == oID
                select x;
    context.Orders.Remove(od.FirstOrDefault());
    context.SaveChanges();
    LoadOrders();
}

private void button2_Click(object sender, EventArgs e)
{
    Student student = (Student)listBox1.SelectedItem;
    Textbook textbook = (Textbook)listBox3.SelectedItem;

    Order o = new Order();
    o.StudentFk = student.StudentId;
    o.TextbookFk = textbook.TextbookId;
    context.Orders.Local.Add(o);
    try
    {
        context.SaveChanges();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    LoadOrders();
}
    }
}
