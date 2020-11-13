namespace PPE {
    partial class FRM_DialogueAutorise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DialogueAutorise));
            this.PBX_Logo = new System.Windows.Forms.PictureBox();
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
            this.PBX_Logo.Location = new System.Drawing.Point(51, 54);
            this.PBX_Logo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PBX_Logo.Name = "PBX_Logo";
            this.PBX_Logo.Size = new System.Drawing.Size(50, 50);
            this.PBX_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBX_Logo.TabIndex = 1;
            this.PBX_Logo.TabStop = false;
            // 
            // B_DialogSome
            // 
            this.B_DialogSome.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_DialogSome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogSome.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogSome.Image")));
            this.B_DialogSome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogSome.Location = new System.Drawing.Point(316, 189);
            this.B_DialogSome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_DialogSome.Name = "B_DialogSome";
            this.B_DialogSome.Size = new System.Drawing.Size(224, 72);
            this.B_DialogSome.TabIndex = 4;
            this.B_DialogSome.Text = "Oui";
            this.B_DialogSome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogSome.UseVisualStyleBackColor = true;
            // 
            // B_DialogAbort
            // 
            this.B_DialogAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_DialogAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogAbort.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogAbort.Image")));
            this.B_DialogAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogAbort.Location = new System.Drawing.Point(549, 189);
            this.B_DialogAbort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_DialogAbort.Name = "B_DialogAbort";
            this.B_DialogAbort.Size = new System.Drawing.Size(204, 72);
            this.B_DialogAbort.TabIndex = 5;
            this.B_DialogAbort.Text = "Non";
            this.B_DialogAbort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogAbort.UseVisualStyleBackColor = true;
            // 
            // LBL_Explication
            // 
            this.LBL_Explication.AutoSize = true;
            this.LBL_Explication.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Explication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Explication.Location = new System.Drawing.Point(162, 82);
            this.LBL_Explication.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Explication.Name = "LBL_Explication";
            this.LBL_Explication.Size = new System.Drawing.Size(588, 29);
            this.LBL_Explication.TabIndex = 6;
            this.LBL_Explication.Text = "Voulez-vous importer ces livres dans la bibliotheque ?\r\n";
            // 
            // FRM_DialogueAutorise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 316);
            this.ControlBox = false;
            this.Controls.Add(this.LBL_Explication);
            this.Controls.Add(this.B_DialogAbort);
            this.Controls.Add(this.B_DialogSome);
            this.Controls.Add(this.PBX_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_DialogueAutorise";
            this.Text = "FRM_DialogueTransfert";
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PBX_Logo;
        private System.Windows.Forms.Button B_DialogSome;
        private System.Windows.Forms.Button B_DialogAbort;
        private System.Windows.Forms.Label LBL_Explication;
    }
}