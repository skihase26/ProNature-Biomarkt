using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    public interface IDatabaseService
    {
        DataSet GetDataSet(string query);
        void SaveData(string tablename, string[] dataToSave, float productPrice=0);
        void UpdateData(int id, string tableName, string[] updateData, float productPrice = 0);
        void DeleteData(int id, string tableName);
    }
}
