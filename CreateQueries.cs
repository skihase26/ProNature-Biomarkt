﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    internal class CreateQueries
    {
        private string tableName;
        private int id;
        private string[] controlDatas;
        private float price;

        public string Query { get; set; }

        public CreateQueries(string tablename) {
            this.tableName = tablename;
            CreateSelectQuery();
        }

        public CreateQueries(int id, string tablename) {
            this.tableName = tablename;
            this.id = id;
            CreateDeleteQuery();
        }

        public CreateQueries(string[] dataOfControls, float price, string tablename) 
        {
            this.controlDatas = dataOfControls;
            this.price = price;
            this.tableName = tablename;
            CreateSaveQuery();

        }

        public CreateQueries(int id, string[] dataOfControls, float price, string tablename)
        {
            this.id = id;
            this.controlDatas = dataOfControls;
            this.price = price;
            this.tableName = tablename;
            UpdateQuery();
        }

        private void CreateSelectQuery()
        {
            Query = $"SELECT * FROM {tableName}";
        }

        private void CreateDeleteQuery()
        {
            Query = $"DELETE FROM {tableName} WHERE Id ='{id}'";
        }

        private void CreateSaveQuery()
        {
            switch (tableName) {
                case "Products":  Query = $"insert into {tableName} values('{controlDatas[0]}', '{controlDatas[1]}', '{controlDatas[2]}', {price.ToString(CultureInfo.InvariantCulture)})";
                    break;
                case "Customer": Query = $"insert into {tableName} values('{controlDatas[0]}', '{controlDatas[1]}', '{controlDatas[2]}', '{controlDatas[3]}','{controlDatas[4]}', '{controlDatas[5]}', '{controlDatas[6]}')";
                    break;
                case "Categories": Query = $"insert into {tableName} values('{controlDatas[0]}')";
                    break;
                default: MessageBox.Show("Ungültige Tabelle!", "Information");
                    return;
            }
        }

        private void UpdateQuery()
        {
            switch (tableName) {
                case "Products":  Query = $"update {tableName} set Name='{controlDatas[0]}', Brand='{controlDatas[1]}', Category='{controlDatas[2]}', Price={price.ToString(CultureInfo.InvariantCulture)} where Id={id}";
                    break;
                case "Customer": Query = $"update {tableName} set CustomerName='{controlDatas[0]}', CustomerFirstName='{controlDatas[1]}', Street='{controlDatas[2]}', HouseNo='{controlDatas[3]}', plz='{controlDatas[4]}', City='{controlDatas[5]}', Email='{controlDatas[6]}' WHERE CustomerId ={id}";
                    break;
                case "Caregories": Query = $"update {tableName} set CategoryName='{controlDatas[0]}' where Id={id}";
                    break;
                default: MessageBox.Show("Ungültige Tabelle!", "Information");
                    return;
            }
        }
    }
}
