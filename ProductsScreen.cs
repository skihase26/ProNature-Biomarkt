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
            CboItemsLaden();
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

            float productPrice = float.Parse(tboProductPrice.Text);
            string[] updateInfos = GetDataFromTextfields();

            

            //If the lastSelectedProductKey is -1, then this is a new product
            //else the product data has changed
            if (lastSelectedProductKey < 0)
            {
                //save the datas in the products table
                databaseTools.SaveData("products", updateInfos, productPrice);
            } else
            {
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

        /// <summary>
        /// leave only the price field when there is a float
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboProductPrice_Leave(object sender, EventArgs e)
        {
            float productPrice;

            //try to parse the input of the pricefield to a float and write it to the variable,
            //if the text can't parse to float a message will show on the screen
            if (!float.TryParse(tboProductPrice.Text, out productPrice))
            {
                tboProductPrice.Select();
                return;
            }
        }

        /// <summary>
        /// call the category screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CategoryScreen().ShowDialog();
            this.Show();
            CboItemsLaden();

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
        /// enable all fields
        /// </summary>
        private void EnableFields()
        {
            tboProductName.Enabled = true;
            tboProductBrand.Enabled = true;
            tboProductPrice.Enabled = true;
            cboProductCategory.Enabled = true;
        }

        /// <summary>
        /// disable all fields
        /// </summary>
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

        /// <summary>
        /// proof the fields, that aren't allowed to be empty
        /// </summary>
        /// <returns></returns>
        private bool proofAllFieldsFilled()
        {
            if (tboProductName.Text == "" || tboProductBrand.Text == "" || tboProductPrice.Text == "" || cboProductCategory.Text == "")
            {
                MessageBox.Show("Bitte alle Felder ausfüllen und der Preis darf nicht 0 sein!");
                return false;
            }
            else { return true; }
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
        /// load the categories from database in the combobox
        /// 
        /// </summary>
        private void CboItemsLaden()
        {
            DataSet dataSet = databaseTools.GetDataSet("categories");

            cboProductCategory.DataSource = null;
            cboProductCategory.Items.Clear();

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                cboProductCategory.DataSource = dataSet.Tables[0];
                cboProductCategory.DisplayMember = "CategoryName";
                cboProductCategory.ValueMember = "Id";
            }
        }

        
    }
}
