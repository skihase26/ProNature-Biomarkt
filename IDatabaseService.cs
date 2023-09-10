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
        void SaveData(string query);
        void UpdateData(string query);
        void DeleteData(string query);
    }
}
