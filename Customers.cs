using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    internal class Customers
    {
        private CustomerScreen _CustomerScreen;
        private IDatabaseService _IDatabaseService;
        private DataSet dataSet;
        private string tableName;

        public Customers(CustomerScreen customerScreen, IDatabaseService databaseServices) 
        {
            this._CustomerScreen = customerScreen;
            this._IDatabaseService = databaseServices;
            dataSet = new DataSet();
            tableName = "Customer";
        }

        /// <summary>
        /// fill the gridview with actual datas from table products
        /// </summary>
        public void UpdateGridView()
        {

            //get all datas from the products table and fill the datagridview
            dataSet = _IDatabaseService.GetDataSet(new CreateQueries(tableName).Query);
            _CustomerScreen.dgvBinding.DataSource = dataSet.Tables[0];

        }

        public void DeleteCustomer(int id)
        {
            _IDatabaseService.DeleteData(new CreateQueries(id, tableName).Query);
        }

        public void SaveNewCustomer(string[] dataTextControls)
        {
            _IDatabaseService.SaveData(new CreateQueries(dataTextControls, 0, tableName).Query);
        }

        public void UpdateCustomer(int id, string[] dataTextControls)
        {
            _IDatabaseService.UpdateData(new CreateQueries(id, dataTextControls, 0, tableName).Query);
        }
    }
}
