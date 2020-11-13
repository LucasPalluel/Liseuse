namespace PPE
{
    partial class popupnomdos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_ndos = new System.Windows.Forms.Label();
            this.TXT_ndos = new System.Windows.Forms.TextBox();
            this.BTN_annule = new System.Windows.Forms.Button();
            this.BTN_continu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LBL_ndos
            // 
            this.LBL_ndos.AutoSize = true;
            this.LBL_ndos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ndos.Location = new System.Drawing.Point(7, 37);
            this.LBL_ndos.Name = "LBL_ndos";
            this.LBL_ndos.Size = new System.Drawing.Size(140, 18);
            this.LBL_ndos.TabIndex = 0;
            this.LBL_ndos.Text = "Nom du dossier :";
            // 
            // TXT_ndos
            // 
            this.TXT_ndos.Location = new System.Drawing.Point(145, 38);
            this.TXT_ndos.Name = "TXT_ndos";
            this.TXT_ndos.Size = new System.Drawing.Size(183, 20);
            this.TXT_ndos.TabIndex = 1;
            // 
            // BTN_annule
            // 
            this.BTN_annule.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_annule.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_annule.Location = new System.Drawing.Point(12, 128);
            this.BTN_annule.Name = "BTN_annule";
            this.BTN_annule.Size = new System.Drawing.Size(92, 37);
            this.BTN_annule.TabIndex = 2;
            this.BTN_annule.Text = "Annuler";
            this.BTN_annule.UseVisualStyleBackColor = true;
            this.BTN_annule.Click += new System.EventHandler(this.BTN_annule_Click);
            // 
            // BTN_continu
            // 
            this.BTN_continu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_continu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_continu.Location = new System.Drawing.Point(236, 128);
            this.BTN_continu.Name = "BTN_continu";
            this.BTN_continu.Size = new System.Drawing.Size(92, 37);
            this.BTN_continu.TabIndex = 3;
            this.BTN_continu.Text = "Continuer";
            this.BTN_continu.UseVisualStyleBackColor = true;
            this.BTN_continu.Click += new System.EventHandler(this.BTN_continu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 33);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.panel2.Location = new System.Drawing.Point(-1, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 33);
            this.panel2.TabIndex = 5;
            // 
            // popupnomdos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 177);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_continu);
            this.Controls.Add(this.BTN_annule);
            this.Controls.Add(this.TXT_ndos);
            this.Controls.Add(this.LBL_ndos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popupnomdos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donner un nom au dossier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_ndos;
        private System.Windows.Forms.Button BTN_annule;
        private System.Windows.Forms.Button BTN_continu;
        public System.Windows.Forms.TextBox TXT_ndos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}