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
        private readonly Categories categories;
        public BindingSource dgvBinding;
        private int lastSelectedCategoryKey;

        public CategoryScreen()
        {
            InitializeComponent();
            lastSelectedCategoryKey = -1;
            databaseService = new DatabaseServices();
            categories = new Categories(this, databaseService);
        }

        /// <summary>
        /// save the new categorie only when it not already exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string[] saveData = new string[1];
            if (tboCategoryName.Text != "")
            {
                saveData[0] = tboCategoryName.Text;
                if (lastSelectedCategoryKey < 0)
                    categories.SaveNewCategory(saveData);
                else
                    categories.UpdateCategory(lastSelectedCategoryKey, saveData);

                tboCategoryName.Text = "";
                tboCategoryName.Enabled = false;
                categories.UpdateGridView();
                dgvCategory.Columns[0].Visible = false;
            }
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            tboCategoryName.Text = "";
            tboCategoryName.Enabled = true;
        }

        private void btnChangeKategorie_Click(object sender, EventArgs e)
        {
            tboCategoryName.Enabled = true;
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tboCategoryName.Text = dgvCategory.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void CategoryScreen_Load(object sender, EventArgs e)
        {
            dgvBinding = new BindingSource();
            dgvCategory.DataSource = dgvBinding;
            categories.UpdateGridView();
            dgvCategory.Columns[0].Visible = false;
        }
    }
}
