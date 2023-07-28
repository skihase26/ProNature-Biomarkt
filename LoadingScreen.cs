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
    public partial class LoadingScreen : Form
    {
        private int loadingProgressValue;

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timLoadingBar.Start();
        }
        private void timLoadingBar_Tick(object sender, EventArgs e)
        {
            loadingProgressValue += 1;
            prbLoading.Value = loadingProgressValue;
            lblLoading.Text = loadingProgressValue.ToString();

            if (loadingProgressValue >= prbLoading.Maximum ) { 
                
                timLoadingBar.Stop(); 
            }
        }

        
    }
}
