using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public class Products
    {
        private readonly ProductsScreen _ProductsScreen;
        private readonly IDatabaseService _IDatabaseService;
        private DataSet dataSet;

        public Products() { }

        public Products(ProductsScreen productsScreen, IDatabaseService iDatabaseService) { 
            this._ProductsScreen = productsScreen;
            this._IDatabaseService = iDatabaseService;
            dataSet = new DataSet();
        }

        /// <summary>
        /// fill the gridview with actual datas from table products
        /// </summary>
        public void UpdateGridView()
        {
            
            //get all datas from the products table and fill the datagridview
            dataSet = _IDatabaseService.GetDataSet(new CreateQueries("Products").Query);
            _ProductsScreen.dgvBinding.DataSource = dataSet.Tables[0];
            
        }
    }
}
