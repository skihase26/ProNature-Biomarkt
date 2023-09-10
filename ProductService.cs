using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    public class ProductService : IDatabaseService
    {
       
        private readonly IDatabaseService _IDatabaseService;
        private readonly string tableName;

        public ProductService(IDatabaseService iDatabaseService) {
    
            this._IDatabaseService = iDatabaseService;
            tableName = "Products";
        }

        public void DeleteData(int id, string tableName)
        {
            _IDatabaseService.DeleteData(id, tableName);
        }

        public DataSet GetDataSet(string query)
        {   
            var dataSet = _IDatabaseService.GetDataSet(query);
            return dataSet;
        }

        public void SaveData(string tablename, string[] dataToSave, float productPrice = 0)
        {
            _IDatabaseService.SaveData(tablename, dataToSave, productPrice);
        }

        public void UpdateData(int id, string tableName, string[] updateData, float productPrice = 0)
        {
            _IDatabaseService.UpdateData(id, tableName, updateData, productPrice);
        }
    }
}
