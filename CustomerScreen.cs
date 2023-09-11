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
        private readonly IDatabaseService databaseService;
        private readonly Customers customers;
        public BindingSource dgvBinding;

        public CustomerScreen()
        {
            InitializeComponent();
            lastSelectedCustomerId = -1;
            databaseService = new DatabaseServices();
            customers = new Customers(this, databaseService);
            
            
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
                customers.SaveNewCustomer(dataToSave);

            } else
            {
                customers.UpdateCustomer(lastSelectedCustomerId, dataToSave);
            }

            ClearAllFields();
            DisableFields();
            customers.UpdateGridView();
            dgvCustomers.Columns[0].Visible = false;
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
            customers.DeleteCustomer(lastSelectedCustomerId);
            ClearAllFields();
            DisableFields();
            customers.UpdateGridView();
            dgvCustomers.Columns[0].Visible = false;
        }

        /// <summary>
        /// enable all fields
        /// </summary>
        private void EnableFields()
        {
            tboCustomerName.Enabled = true;
            tboFirstName.Enabled = true;
            tboStreet.Enabled = true;
            tboHouseNumber.Enabled = true;
            tboPlz.Enabled = true;
            tboCity.Enabled = true;
            tboEmail.Enabled = true;
        }

        /// <summary>
        /// disable all fields
        /// </summary>
        private void DisableFields()
        {
            tboCustomerName.Enabled = false;
            tboFirstName.Enabled = false;
            tboStreet.Enabled = false;
            tboHouseNumber.Enabled = false; 
            tboPlz.Enabled = false;
            tboCity.Enabled = false;
            tboEmail.Enabled = false;
        }

        /// <summary>
        /// clear all fields
        /// </summary>
        private void ClearAllFields()
        {
            tboCustomerName.Text = string.Empty;
            tboFirstName.Text = string.Empty;
            tboStreet.Text = string.Empty;
            tboHouseNumber.Text = string.Empty;
            tboPlz.Text = string.Empty;
            tboCity.Text = string.Empty;
            tboEmail.Text = string.Empty;
            lastSelectedCustomerId = -1;
        }

        /// <summary>
        /// get the datas from the textfields and put it into a string array
        /// </summary>
        /// <returns>textboxValues</returns>
        private string[] GetDataFromTextfields()
        {

            string[] textboxValues = new string[7];
            textboxValues[0] = tboCustomerName.Text;
            textboxValues[1] = tboFirstName.Text;
            textboxValues[2] = tboStreet.Text;
            textboxValues[3] = tboHouseNumber.Text;
            textboxValues[4] = tboPlz.Text;
            textboxValues[5] = tboCity.Text;
            textboxValues[6] = tboEmail.Text;

            return textboxValues;
        }

        /// <summary>
        /// proof the fields, that aren't allowed to be empty
        /// </summary>
        /// <returns></returns>
        private bool ProofAllFieldsFilled()
        {
            if (tboCustomerName.Text == "" || tboFirstName.Text == "" 
                || tboPlz.Text == "" || tboEmail.Text == ""
                || tboCity.Text == "" || tboStreet.Text == "" || tboHouseNumber.Text == "")
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
            tboStreet.Text = dgvCustomers.Rows[0].Cells[3].Value.ToString();
            tboHouseNumber.Text = dgvCustomers.SelectedRows[0].Cells[4].Value.ToString();
            tboPlz.Text = dgvCustomers.SelectedRows[0].Cells[5].Value.ToString();
            tboCity.Text = dgvCustomers.SelectedRows[0].Cells[6].Value.ToString();
            tboEmail.Text = dgvCustomers.SelectedRows[0].Cells[7].Value.ToString();

            lastSelectedCustomerId = (int)dgvCustomers.SelectedRows[0].Cells[0].Value;
        }

        private void CustomerScreen_Load(object sender, EventArgs e)
        {
            dgvBinding = new BindingSource();
            dgvCustomers.DataSource = dgvBinding;
            customers.UpdateGridView();
            dgvCustomers.Columns[0].Visible = false;
        }
    }
}
