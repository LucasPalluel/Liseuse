namespace PPE {
    partial class FRM_DialogueTransfert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DialogueTransfert));
            this.PBX_Logo = new System.Windows.Forms.PictureBox();
            this.LB_Livres = new System.Windows.Forms.ListBox();
            this.B_DialogAll = new System.Windows.Forms.Button();
            this.B_DialogSome = new System.Windows.Forms.Button();
            this.B_DialogAbort = new System.Windows.Forms.Button();
            this.LBL_Explication = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // PBX_Logo
            // 
            this.PBX_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PBX_Logo.Image")));
            this.PBX_Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("PBX_Logo.InitialImage")));
            this.PBX_Logo.Location = new System.Drawing.Point(34, 35);
            this.PBX_Logo.Name = "PBX_Logo";
            this.PBX_Logo.Size = new System.Drawing.Size(50, 50);
            this.PBX_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBX_Logo.TabIndex = 1;
            this.PBX_Logo.TabStop = false;
            // 
            // LB_Livres
            // 
            this.LB_Livres.FormattingEnabled = true;
            this.LB_Livres.Location = new System.Drawing.Point(34, 116);
            this.LB_Livres.Name = "LB_Livres";
            this.LB_Livres.ScrollAlwaysVisible = true;
            this.LB_Livres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LB_Livres.Size = new System.Drawing.Size(482, 199);
            this.LB_Livres.TabIndex = 2;
            // 
            // B_DialogAll
            // 
            this.B_DialogAll.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.B_DialogAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogAll.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogAll.Image")));
            this.B_DialogAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogAll.Location = new System.Drawing.Point(34, 364);
            this.B_DialogAll.Name = "B_DialogAll";
            this.B_DialogAll.Size = new System.Drawing.Size(171, 47);
            this.B_DialogAll.TabIndex = 3;
            this.B_DialogAll.Text = "Importer tout les livres";
            this.B_DialogAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogAll.UseVisualStyleBackColor = true;
            // 
            // B_DialogSome
            // 
            this.B_DialogSome.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_DialogSome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogSome.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogSome.Image")));
            this.B_DialogSome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogSome.Location = new System.Drawing.Point(211, 364);
            this.B_DialogSome.Name = "B_DialogSome";
            this.B_DialogSome.Size = new System.Drawing.Size(149, 47);
            this.B_DialogSome.TabIndex = 4;
            this.B_DialogSome.Text = "Importer les livres selectionnés";
            this.B_DialogSome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogSome.UseVisualStyleBackColor = true;
            // 
            // B_DialogAbort
            // 
            this.B_DialogAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_DialogAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogAbort.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogAbort.Image")));
            this.B_DialogAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogAbort.Location = new System.Drawing.Point(366, 364);
            this.B_DialogAbort.Name = "B_DialogAbort";
            this.B_DialogAbort.Size = new System.Drawing.Size(136, 47);
            this.B_DialogAbort.TabIndex = 5;
            this.B_DialogAbort.Text = "Ne pas importer";
            this.B_DialogAbort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogAbort.UseVisualStyleBackColor = true;
            // 
            // LBL_Explication
            // 
            this.LBL_Explication.AutoSize = true;
            this.LBL_Explication.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Explication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Explication.Location = new System.Drawing.Point(108, 53);
            this.LBL_Explication.Name = "LBL_Explication";
            this.LBL_Explication.Size = new System.Drawing.Size(360, 18);
            this.LBL_Explication.TabIndex = 6;
            this.LBL_Explication.Text = "Voulez-vous importer ces livres dans la bibliotheque ?\r\n";
            // 
            // FRM_DialogueTransfert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 450);
            this.ControlBox = false;
            this.Controls.Add(this.LBL_Explication);
            this.Controls.Add(this.B_DialogAbort);
            this.Controls.Add(this.B_DialogSome);
            this.Controls.Add(this.B_DialogAll);
            this.Controls.Add(this.LB_Livres);
            this.Controls.Add(this.PBX_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_DialogueTransfert";
            this.Text = "FRM_DialogueTransfert";
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PBX_Logo;
        public System.Windows.Forms.ListBox LB_Livres;
        private System.Windows.Forms.Button B_DialogAll;
        private System.Windows.Forms.Button B_DialogSome;
        private System.Windows.Forms.Button B_DialogAbort;
        private System.Windows.Forms.Label LBL_Explication;
    }
}