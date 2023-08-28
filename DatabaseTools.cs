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
        public void SaveData(string tableName, string[] dataToSave, float productPrice=0)
        {
            string query = "";
            tableName = tableName.ToLower();

            switch (tableName)
            {
                case "products": query = $"insert into {tableName} values('{dataToSave[0]}', '{dataToSave[1]}', '{dataToSave[2]}', {productPrice.ToString(CultureInfo.InvariantCulture)})";
                    break;

                case "customer": query = $"insert into {tableName} values('{dataToSave[0]}', '{dataToSave[1]}', '{dataToSave[2]}', '{dataToSave[3]}')";
                    break;

                case "categories": query = $"insert into {tableName} values('{dataToSave[0]}')";
                    break;

                default: MessageBox.Show("Die Datenbanktabelle ist unbekannt. Daten konnten nicht gespeichert werden!");
                    return;
                
            }

            ExecuteQuery(query);
        }

        /// <summary>
        /// update a data with id in the table
        /// </summary>
        /// <param name="id">the id of data</param>
        /// <param name="tableName">where will update the data</param>
        /// <param name="updateData">data array (name, brand, category) for updating</param>
        /// <param name="productPrice"></param>
        public void UpdateData(int id, string tableName, string[] updateData, float productPrice=0)
        {
            string query = "";
            switch (tableName)
            {
                case "products": query = $"update {tableName} set Name='{updateData[0]}', Brand='{updateData[1]}', Category='{updateData[2]}', Price={productPrice.ToString(CultureInfo.InvariantCulture)} where Id={id}";
                    break;
                case "customer": query = $"update {tableName} set CostumerName='{updateData[0]}', CustomerFirstName='{updateData[1]}', Address='{updateData[2]}', Email='{updateData[3]}'";
                    break;
                default: MessageBox.Show("Die Datenbanktabelle ist unbekannt. Daten konnten nicht gespeichert werden!");
                    return;

            }
            ExecuteQuery(query);
        }

        /// <summary>
        /// delete the data in the named table with the id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public void DeleteData(int id, string tableName)
        {
            string query = "";

            tableName = tableName.ToLower();

            switch (tableName) {
                case "products": query = $"delete from {tableName} where Id ='{id}'";
                    break;
                case "customer": query = $"delete from {tableName} where CustomerId ='{id}'";
                    break;
            }
            ExecuteQuery(query);
        }

       

        private void ExecuteQuery(string query)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Die Daten wurden gespeichert.");

            }catch (Exception ex)
            {
                MessageBox.Show("Die Daten konnten nicht in die Datenbank eingetragen werden. Bitte versuchen sie es noch einmal!");
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            
        }
    }
}
