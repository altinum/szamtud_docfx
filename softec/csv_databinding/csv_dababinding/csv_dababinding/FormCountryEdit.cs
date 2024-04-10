using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_dababinding
{
public partial class FormCountryEdit : Form
{
    public CountryData CountryData;
    public CountryData originalCountryData;
    public FormCountryEdit()
    {
        InitializeComponent();
    }

    private void FormCountryEdit_Load(object sender, EventArgs e)
    {
        originalCountryData = new();
        originalCountryData.Name = CountryData.Name;
        originalCountryData.Population = CountryData.Population;
        originalCountryData.AreaInSquareKmx = CountryData.AreaInSquareKmx;

        bindingSource1.DataSource = CountryData;

    }

        private void button2_Click(object sender, EventArgs e)
        {
            CountryData.Name = originalCountryData.Name;         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
        }
    }
}
