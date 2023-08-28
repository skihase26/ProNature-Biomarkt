﻿using System;
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
        DatabaseTools databaseTools;

        public CategoryScreen()
        {
            InitializeComponent();
            databaseTools = new DatabaseTools();
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string[] saveData = new string[1];
            saveData[0] = tboCategoryName.Text;
            databaseTools.SaveData("Categories", saveData);
        }
    }
}