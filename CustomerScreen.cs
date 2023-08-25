using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public partial class CustomerScreen : Form
    {
        
        private int lastSelectedProductKey;
        private DatabaseTools databaseTools;

        public CustomerScreen()
        {
            InitializeComponent();
            databaseTools = new DatabaseTools();
            UpdateGridView();
        }

        /// <summary>
        /// fill the datagridview with datas
        /// </summary>
        private void UpdateGridView()
        {
            //get all datas from the customer table
            DataSet dataSet = databaseTools.GetDataSet("customer");
            dgvCustomers.DataSource = dataSet.Tables[0];

            //hide the CustomerId column
            dgvCustomers.Columns[0].Visible = false;
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {

        }

        private void CustomerScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainMenueScreen mainMenueScreen = new MainMenueScreen();
            mainMenueScreen.Show();
        }
    }
}
