using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public class DatabaseServices : IDatabaseService
    {
        private readonly SqlConnection connection;

        public DatabaseServices()
        {
            connection = new ConnectToDb().Connection;
        }

        /// <summary>
        /// get the dataset of the table and return it
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string query)
        {
            //query = "SELECT * From " + tableName;

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
        public void SaveData(string query)
        {
            ExecuteQuery(query, "gespeichert");
        }

        /// <summary>
        /// update a data with id in the table
        /// </summary>
        /// <param name="id">the id of data</param>
        /// <param name="tableName">where will update the data</param>
        /// <param name="updateData">data array (name, brand, category) for updating</param>
        /// <param name="productPrice"></param>
        public void UpdateData(string query)
        {
            ExecuteQuery(query, "gespeichert");
        }

        /// <summary>
        /// delete the data in the named table with the id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public void DeleteData(string query)
        {
            ExecuteQuery(query, "gelöscht");
        }

       

        private void ExecuteQuery(string query, string messagetext)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                connection.Open();
                int data = sqlCommand.ExecuteNonQuery();
                if (data > 0)
                    MessageBox.Show($"Die Daten wurden {messagetext}.", "Information");
                else
                    MessageBox.Show($"Die Daten wurden nicht {messagetext}.", "Information");
            }catch (SqlException  eSql)
            {
                if (eSql.ErrorCode == -2146232060)
                    MessageBox.Show("Die Kategorie ist schon vorhanden!", "Fehler");
                else
                    MessageBox.Show(eSql.Message, "Fehler");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Die Daten konnten nicht in die Datenbank eingetragen werden. Bitte versuchen sie es noch einmal!", "Fehler");
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            
        }
    }
}
