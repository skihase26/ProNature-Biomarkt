namespace ProNaturGmbH
{
    partial class LoadingScreen
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.prbLoading = new System.Windows.Forms.ProgressBar();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblProzentAngabe = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timLoadingBar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // prbLoading
            // 
            this.prbLoading.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.prbLoading.Location = new System.Drawing.Point(12, 283);
            this.prbLoading.Name = "prbLoading";
            this.prbLoading.Size = new System.Drawing.Size(660, 23);
            this.prbLoading.TabIndex = 0;
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(300, 267);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(41, 13);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "loading";
            // 
            // lblProzentAngabe
            // 
            this.lblProzentAngabe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProzentAngabe.AutoSize = true;
            this.lblProzentAngabe.Location = new System.Drawing.Point(347, 267);
            this.lblProzentAngabe.Name = "lblProzentAngabe";
            this.lblProzentAngabe.Size = new System.Drawing.Size(21, 13);
            this.lblProzentAngabe.TabIndex = 3;
            this.lblProzentAngabe.Text = "0%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(660, 243);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // timLoadingBar
            // 
            this.timLoadingBar.Tick += new System.EventHandler(this.timLoadingBar_Tick);
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(684, 318);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblProzentAngabe);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.prbLoading);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProNatur-Biomarkt  GmbH";
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbLoading;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblProzentAngabe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timLoadingBar;
    }
}

