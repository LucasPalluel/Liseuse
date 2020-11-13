namespace PPE
{
    partial class FRM_SelecSVP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SelecSVP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBL_Titre = new System.Windows.Forms.Label();
            this.B_Ok = new System.Windows.Forms.Button();
            this.PB_Imoticone = new System.Windows.Forms.PictureBox();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LBL_Titre);
            this.panel1.Controls.Add(this.B_Ok);
            this.panel1.Controls.Add(this.PB_Imoticone);
            this.panel1.Controls.Add(this.LBL_Message);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 123);
            this.panel1.TabIndex = 13;
            // 
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(10, 7);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(69, 15);
            this.LBL_Titre.TabIndex = 14;
            this.LBL_Titre.Text = "Selection";
            // 
            // B_Ok
            // 
            this.B_Ok.Location = new System.Drawing.Point(178, 82);
            this.B_Ok.Name = "B_Ok";
            this.B_Ok.Size = new System.Drawing.Size(75, 29);
            this.B_Ok.TabIndex = 13;
            this.B_Ok.Text = "Ok";
            this.B_Ok.UseVisualStyleBackColor = true;
            this.B_Ok.Click += new System.EventHandler(this.B_Ok_Click);
            // 
            // PB_Imoticone
            // 
            this.PB_Imoticone.BackColor = System.Drawing.Color.Transparent;
            this.PB_Imoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Imoticone.Image")));
            this.PB_Imoticone.Location = new System.Drawing.Point(-1, 25);
            this.PB_Imoticone.Name = "PB_Imoticone";
            this.PB_Imoticone.Size = new System.Drawing.Size(83, 94);
            this.PB_Imoticone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_Imoticone.TabIndex = 11;
            this.PB_Imoticone.TabStop = false;
            // 
            // LBL_Message
            // 
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.Location = new System.Drawing.Point(108, 44);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(235, 18);
            this.LBL_Message.TabIndex = 6;
            this.LBL_Message.Text = "Veuillez sélectionner un livre";
            this.LBL_Message.Click += new System.EventHandler(this.LBL_Message_Click);
            // 
            // FRM_SelecSVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 125);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SelecSVP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_SelecSVP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBL_Titre;
        private System.Windows.Forms.Button B_Ok;
        private System.Windows.Forms.PictureBox PB_Imoticone;
        private System.Windows.Forms.Label LBL_Message;
    }
}