using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// you get the connection of database
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// get the dataset of the table and return it
        /// </summary>
        /// <param name="tableName"></param>
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

        /// <summary>
        /// insert the new dataset in the database
        /// </summary>
        /// <param name="tableName">table name of database</param>
        /// <param name="dataToSave">data array (name, brand, category) inserting in the table</param>
        /// <param name="productPrice"></param>
        public void SaveData(string tableName, string[] dataToSave, float productPrice)
        {
            if (tableName == "products")
            {
                string query = string.Format("insert into {3} values('{0}', '{1}', '{2}', @productPrice)", dataToSave[0], dataToSave[1], dataToSave[2], tableName);
                BuildSqlCommand(query, productPrice);
            }
        }

        /// <summary>
        /// update a data with id in the table
        /// </summary>
        /// <param name="id">the id of data</param>
        /// <param name="tableName">where will update the data</param>
        /// <param name="updateData">data array (name, brand, category) for updating</param>
        /// <param name="productPrice"></param>
        public void UpdateData(int id, string tableName, string[] updateData, float productPrice)
        {
            if (tableName == "products")
            {
                string query = string.Format("update {4} set Name='{0}', Brand='{1}', Category='{2}', Price=@productPrice where Id={3}"
                    , updateData[0], updateData[1], updateData[2], id, tableName);
                BuildSqlCommand(query, productPrice);
            }
        }

        /// <summary>
        /// delete the data in the named table with the id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public void DeleteData(int id, string tableName) {

            string query = string.Format("delete from {0} where Id ='{1}'",tableName, id);

            BuildSqlCommand(query);
        }

        private void  BuildSqlCommand(string query)
        {
            
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            ExecuteQuery(sqlCommand);
        }

        /// <summary>
        /// execute the query and get the data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="productPrice"></param>
        private void BuildSqlCommand(string query, float productPrice)
        {
           
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            // replace the placeholder with the float of productPrice in the query
            sqlCommand.Parameters.AddWithValue("@productPrice", productPrice);
            ExecuteQuery(sqlCommand);
        }

        private void ExecuteQuery(SqlCommand sqlCommand)
        {
            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }catch (Exception ex)
            {
                MessageBox.Show("Die Daten konnten nicht in die Datenbank eingetragen werden. Bitte versuchen sie es noch einmal!");
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            
        }
    }
}
