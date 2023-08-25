using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    public class DatabaseTools
    {
        private SqlConnection connection;

        public DatabaseTools()
        {
            connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gaby\OneDrive\Dokumente\Pro-Natur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string tableName)
        {
            string query = "SELECT * From " + tableName;

            connection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            connection.Close();

            return dataSet;
        }

        public void SaveData(int id, string tableName, string[] dataToSave, float productPrice)
        {
            if (tableName == "products")
            {
                string query = string.Format("insert into {3} values('{0}', '{1}', '{2}', @productPrice)", dataToSave[0], dataToSave[1], dataToSave[2], tableName);
                ExecuteQuery(query, productPrice);
            }
        }

        public void UpdateData(int id, string tableName, string[] updateData, float productPrice)
        {
            if (tableName == "products")
            {
                string query = string.Format("update {4} set Name='{0}', Brand='{1}', Category='{2}', Price=@productPrice where Id={3}"
                    , updateData[0], updateData[1], updateData[2], id, tableName);
                ExecuteQuery(query, productPrice);
            }
        }

        public void DeleteData(int id, string tableName) {

            string query = string.Format("delete from {0} where Id ='{1}'",tableName, id);

            ExecuteQuery(query, 0);
        }

        private void ExecuteQuery(string query, float productPrice)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            if (productPrice != 0)
                sqlCommand.Parameters.AddWithValue("@productPrice", productPrice);

            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
