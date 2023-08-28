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
            //ProductsScreen productsScreen = new ProductsScreen();
            this.Hide();
            new ProductsScreen().ShowDialog();
            this.Show();
            
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new CustomerScreen().ShowDialog();
            this.Show();

            
        }

        private void MainMenueScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
