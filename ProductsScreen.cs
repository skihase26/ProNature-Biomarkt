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
            UpdateGridView();
            
        }

        private void UpdateGridView()
        {
            databaseConnection.Open();

            string query = "select * from Products";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dgvProducts.DataSource = dataSet.Tables[0];

            dgvProducts.Columns[0].Visible = false;


            databaseConnection.Close();
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            string productName = tboProductName.Text;
            string productBrand = tboProductBrand.Text;
            string productCategory = cboProductCategory.Text;
            float productPrice = float.Parse(tboProductPrice.Text);

            string query = string.Format("insert into products values('{0}', '{1}', '{2}', @productPrice)", productName, productBrand, productCategory);
                        
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
           
            sqlCommand.Parameters.AddWithValue("@productPrice", productPrice);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
            ClearAllFields();
            UpdateGridView();
        }

        private void btnChangeProduct_Click(object sender, EventArgs e)
        {

            UpdateGridView();
        }

        private void btnClearTextbox_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            UpdateGridView();
        }

        private void ClearAllFields()
        {
            tboProductName.Text = "";
            tboProductBrand.Text = "";
            tboProductPrice.Text = "";
            cboProductCategory.SelectedItem = null;
            cboProductCategory.Text = "";
        }
    }
}
