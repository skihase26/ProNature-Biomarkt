using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{
    public partial class CategoryScreen : Form
    {
        DatabaseServices databaseService;

        public CategoryScreen()
        {
            InitializeComponent();
            databaseService = new DatabaseServices();
        }

        /// <summary>
        /// save the new categorie only when it not already exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string[] saveData = new string[1];
            saveData[0] = tboCategoryName.Text;
            databaseService.SaveData("Categories");
        }
    }
}
