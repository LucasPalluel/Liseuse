namespace PPE
{
    partial class FRM_DialogueLivreLiseuse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DialogueLivreLiseuse));
            this.PBX_Logo = new System.Windows.Forms.PictureBox();
            this.LB_Livres = new System.Windows.Forms.ListBox();
            this.LBL_Explication = new System.Windows.Forms.Label();
            this.B_DialogSome = new System.Windows.Forms.Button();
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
            // LBL_Explication
            // 
            this.LBL_Explication.AutoSize = true;
            this.LBL_Explication.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Explication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Explication.Location = new System.Drawing.Point(108, 53);
            this.LBL_Explication.Name = "LBL_Explication";
            this.LBL_Explication.Size = new System.Drawing.Size(205, 18);
            this.LBL_Explication.TabIndex = 6;
            this.LBL_Explication.Text = "Livres contenu dans la liseuse";
            // 
            // B_DialogSome
            // 
            this.B_DialogSome.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_DialogSome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_DialogSome.Image = ((System.Drawing.Image)(resources.GetObject("B_DialogSome.Image")));
            this.B_DialogSome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DialogSome.Location = new System.Drawing.Point(367, 364);
            this.B_DialogSome.Name = "B_DialogSome";
            this.B_DialogSome.Size = new System.Drawing.Size(149, 47);
            this.B_DialogSome.TabIndex = 4;
            this.B_DialogSome.Text = "OK";
            this.B_DialogSome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DialogSome.UseVisualStyleBackColor = true;
            // 
            // FRM_DialogueLivreLiseuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 450);
            this.ControlBox = false;
            this.Controls.Add(this.LBL_Explication);
            this.Controls.Add(this.B_DialogSome);
            this.Controls.Add(this.LB_Livres);
            this.Controls.Add(this.PBX_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_DialogueLivreLiseuse";
            this.Text = "FRM_DialogueTransfert";
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PBX_Logo;
        public System.Windows.Forms.ListBox LB_Livres;
        private System.Windows.Forms.Label LBL_Explication;
        private System.Windows.Forms.Button B_DialogSome;
    }
}