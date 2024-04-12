using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hajos_binding
{
    public partial class FormAddNew : Form
    {
        public VizsgaKérdés ÚjVizsgaKérdés = new();
        public FormAddNew()
        {
            InitializeComponent();
        }

        private void FormAddNew_Load(object sender, EventArgs e)
        {
            vizsgaKérdésBindingSource.DataSource = ÚjVizsgaKérdés;
        }
    }
}
