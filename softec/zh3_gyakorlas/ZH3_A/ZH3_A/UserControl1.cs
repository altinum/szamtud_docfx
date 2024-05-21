using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZH3_A.Models;

namespace ZH3_A
{
    public partial class UserControl1 : UserControl
    {
        SeCocktailsContext seCocktailsContext = new SeCocktailsContext();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in seCocktailsContext.Recipes
                                       select new
                                       {
                                           Material = x.MaterialFkNavigation.Name,
                                           Cocktail = x.CocktailFkNavigation.Name,
                                           x.Quantity
                                       }).ToList();


        }
    }
}
