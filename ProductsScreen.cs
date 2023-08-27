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
    /// <summary>
    /// form to handle the products of the products table, where you can create, update or delete a product
    /// and show you all products 
    /// </summary>
    public partial class ProductsScreen : Form
    {
  
        private int lastSelectedProductKey;
        private readonly DatabaseTools databaseTools;

        public ProductsScreen()
        {
            InitializeComponent();
            lastSelectedProductKey = -1;
            databaseTools = new DatabaseTools();
            UpdateGridView();
            
        }

        /// <summary>
        /// fill the gridview with actual datas from table products
        /// </summary>
        private void UpdateGridView()
        {
            //get all datas from the products table and fill the datagridview
            DataSet dataSet = databaseTools.GetDataSet("products");
            dgvProducts.DataSource = dataSet.Tables[0];

            //hide the id column
            dgvProducts.Columns[0].Visible = false;
        }

        /// <summary>
        /// save the datas from the textfields in the products table, 
        /// when all fields are filled with datas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            //proof the textfields, when one field is empty, the method return without saving
            if (!proofAllFieldsFilled()) {return;}

            //If the lastSelectedProductKey is -1, then this is a new product
            //else the product data has changed
            if (lastSelectedProductKey < 0)
            {
                string[] updateInfos = GetDataFromTextfields();
                float productPrice = float.Parse(tboProductPrice.Text);

                //save the datas in the products table
                databaseTools.SaveData("products", updateInfos, productPrice);
            } else
            {
                string[] updateInfos = GetDataFromTextfields();
                float productPrice = float.Parse(tboProductPrice.Text);

                databaseTools.UpdateData(lastSelectedProductKey, "products", updateInfos, productPrice);
            }
                      
            ClearAllFields();
            DisableFields();
            UpdateGridView();
        }

        /// <summary>
        /// Enable the fields, so that values can be changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeProduct_Click(object sender, EventArgs e)
        {
            EnableFields();
        }

        /// <summary>
        /// clear all fields and enable them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
        }

        /// <summary>
        /// delete the selected product, clear the fields and update the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            databaseTools.DeleteData(lastSelectedProductKey, "products");

            ClearAllFields();
            UpdateGridView();
        }

        private void EnableFields()
        {
            tboProductName.Enabled = true;
            tboProductBrand.Enabled = true;
            tboProductPrice.Enabled = true;
            cboProductCategory.Enabled = true;
        }

        private void DisableFields()
        {
            tboProductName.Enabled = false;
            tboProductBrand.Enabled = false;
            tboProductPrice.Enabled = false;
            cboProductCategory.Enabled = false;
        }

        /// <summary>
        /// clear the textfields and combobox
        /// </summary>
        private void ClearAllFields()
        {
            tboProductName.Text = "";
            tboProductBrand.Text = "";
            tboProductPrice.Text = "";
            cboProductCategory.SelectedItem = null;
            cboProductCategory.Text = "";
            lastSelectedProductKey = -1;
        }

        private bool proofAllFieldsFilled()
        {
            if (tboProductName.Text == "" || tboProductBrand.Text == "" || tboProductPrice.Text == "" || cboProductCategory.Text == "" || float.Parse(tboProductPrice.Text) == 0)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen und der Preis darf nicht 0 sein!");
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// fill the textfields with datas from the selected content of the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tboProductName.Text = dgvProducts.SelectedRows[0].Cells[1].Value.ToString();
            tboProductBrand.Text = dgvProducts.SelectedRows[0].Cells[2].Value.ToString();
            cboProductCategory.Text = dgvProducts.SelectedRows[0].Cells[3].Value.ToString();
            tboProductPrice.Text = dgvProducts.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedProductKey = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
            DisableFields();
            //Console.WriteLine(lastSelectedProductKey);
        }

        /// <summary>
        /// get the datas from the textfields and put it into a string array
        /// </summary>
        /// <returns>textboxValues</returns>
        private string[] GetDataFromTextfields()
        {
           
            string[] textboxValues = new string[3];
            textboxValues[0] = tboProductName.Text;
            textboxValues[1] = tboProductBrand.Text;
            textboxValues[2] = cboProductCategory.Text;

            return textboxValues;
        }


        /// <summary>
        /// if the form is closed, show the main menue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenueScreen mainMenueScreen = new MainMenueScreen();
            mainMenueScreen.Show();
        }

        
    }
}
