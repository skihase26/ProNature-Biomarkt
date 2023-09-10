using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNaturGmbH
{
    internal class CreateQueries
    {
        private string tableName;

        public string Query { get; set; }

        public CreateQueries(string tablename) {
            this.tableName = tablename;
            CreateSelectQuery();
        }

        private void CreateSelectQuery()
        {
            Query = $"SELECT * FROM {tableName}";
        }
    }
}
