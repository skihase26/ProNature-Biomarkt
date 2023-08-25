using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public partial class MainMenueScreen : Form
    {
        public MainMenueScreen()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsScreen productsScreen = new ProductsScreen();
            productsScreen.Show();

            this.Hide();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerScreen customerScreen = new CustomerScreen();
            customerScreen.Show();

            this.Hide();
        }
    }
}
