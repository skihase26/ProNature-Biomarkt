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

        private int lastSelectedCustomerId;
        private DatabaseTools databaseTools;

        public CustomerScreen()
        {
            InitializeComponent();
            databaseTools = new DatabaseTools();
            lastSelectedCustomerId = -1;
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

        /// <summary>
        /// save or update the data in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            //proof the fields, when one field is empty, the method return without saving
            if (!ProofAllFieldsFilled()) { return; }

            string[]  dataToSave = GetDataFromTextfields();

            //if there isn't any data selected, the data will be saved as new
            //else the data is updated in the database
            if (lastSelectedCustomerId < 0)
            {
                databaseTools.SaveData("Customer", dataToSave);

            } else
            {
                databaseTools.UpdateData(lastSelectedCustomerId, "customer", dataToSave);
            }

            ClearAllFields();
            DisableFields();
            UpdateGridView();
        }

        /// <summary>
        /// clear and enable the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
        }

        /// <summary>
        /// enable the fields, when a data is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeCustomer_Click(object sender, EventArgs e)
        {
            if(lastSelectedCustomerId > 0)
                EnableFields();
        }

        /// <summary>
        /// delete the selected data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            databaseTools.DeleteData(lastSelectedCustomerId, "Customer");
            ClearAllFields();
            DisableFields();
            UpdateGridView();
        }

        /// <summary>
        /// enable all fields
        /// </summary>
        private void EnableFields()
        {
            tboCustomerName.Enabled = true;
            tboFirstName.Enabled = true;
            tboAddress.Enabled = true;
            tboEmail.Enabled = true;
        }

        /// <summary>
        /// disable all fields
        /// </summary>
        private void DisableFields()
        {
            tboCustomerName.Enabled = false;
            tboFirstName.Enabled = false;
            tboAddress.Enabled = false;
            tboEmail.Enabled = false;
        }

        /// <summary>
        /// clear all fields
        /// </summary>
        private void ClearAllFields()
        {
            tboCustomerName.Text = string.Empty;
            tboFirstName.Text = string.Empty;
            tboAddress.Text = string.Empty;
            tboEmail.Text = string.Empty;
            lastSelectedCustomerId = -1;
        }

        /// <summary>
        /// get the datas from the textfields and put it into a string array
        /// </summary>
        /// <returns>textboxValues</returns>
        private string[] GetDataFromTextfields()
        {

            string[] textboxValues = new string[4];
            textboxValues[0] = tboCustomerName.Text;
            textboxValues[1] = tboFirstName.Text;
            textboxValues[2] = tboAddress.Text;
            textboxValues[3] = tboEmail.Text;

            return textboxValues;
        }

        /// <summary>
        /// proof the fields, that aren't allowed to be empty
        /// </summary>
        /// <returns></returns>
        private bool ProofAllFieldsFilled()
        {
            if (tboCustomerName.Text == "" || tboFirstName.Text == "" || tboAddress.Text == "" || tboEmail.Text == "")
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// fill the fields with the selected data and set the last selected Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tboCustomerName.Text = dgvCustomers.SelectedRows[0].Cells[1].Value.ToString();
            tboFirstName.Text = dgvCustomers.SelectedRows[0].Cells[2].Value.ToString();
            tboAddress.Text = dgvCustomers.SelectedRows[0].Cells[3].Value.ToString();
            tboEmail.Text = dgvCustomers.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedCustomerId = (int)dgvCustomers.SelectedRows[0].Cells[0].Value;
        }
    }
}
