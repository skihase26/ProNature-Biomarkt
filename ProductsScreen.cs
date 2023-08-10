using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public partial class ProductsScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gaby\OneDrive\Dokumente\Pro-Natur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");

        public ProductsScreen()
        {
            InitializeComponent();

            databaseConnection.Open();
            databaseConnection.Close();
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnClearTextbox_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
