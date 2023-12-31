﻿using System;
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

        public ProductService(IDatabaseService iDatabaseService) {
    
            this._IDatabaseService = iDatabaseService;
        }

        public void DeleteData(string query)
        {
            _IDatabaseService.DeleteData(query);
        }

        public DataSet GetDataSet(string query)
        {   
            var dataSet = _IDatabaseService.GetDataSet(query);
            return dataSet;
        }

        public void SaveData(string query)
        {
            _IDatabaseService.SaveData(query);
        }

        public void UpdateData(string query)
        {
            _IDatabaseService.UpdateData(query);
        }
    }
}
