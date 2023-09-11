using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    internal class Categories
    {
        private readonly CategoryScreen _CategoryScreen;
        private readonly IDatabaseService _IDatabaseService;
        private DataSet dataSet;
        private string tableName;

        public Categories (CategoryScreen categoryScreen, IDatabaseService iDatabaseService)
        {
            this._CategoryScreen = categoryScreen;
            this._IDatabaseService = iDatabaseService;
            this.dataSet = new DataSet();
            this.tableName = "Categories";
        }

        /// <summary>
        /// fill the gridview with actual datas from table products
        /// </summary>
        public void UpdateGridView()
        {

            //get all datas from the products table and fill the datagridview
            dataSet = _IDatabaseService.GetDataSet(new CreateQueries(tableName).Query);
            _CategoryScreen.dgvBinding.DataSource = dataSet.Tables[0];

        }

        public void SaveNewCategory(string[] dataTextControls)
        {
            _IDatabaseService.SaveData(new CreateQueries(dataTextControls, 0, tableName).Query);
        }

        public void UpdateCategory(int id, string[] dataTextControls)
        {
            _IDatabaseService.UpdateData(new CreateQueries(id, dataTextControls, 0, tableName).Query);
        }
    }
}
