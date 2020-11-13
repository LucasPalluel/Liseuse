namespace PPE
{
    partial class FRM_SaveConfirm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SaveConfirm));
            this.PL_Contenu = new System.Windows.Forms.Panel();
            this.PB_Imoticone = new System.Windows.Forms.PictureBox();
            this.BT_Valider = new System.Windows.Forms.Button();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.PL_Contenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).BeginInit();
            this.SuspendLayout();
            // 
            // PL_Contenu
            // 
            this.PL_Contenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PL_Contenu.Controls.Add(this.PB_Imoticone);
            this.PL_Contenu.Controls.Add(this.BT_Valider);
            this.PL_Contenu.Controls.Add(this.LBL_Message);
            this.PL_Contenu.Location = new System.Drawing.Point(1, 1);
            this.PL_Contenu.Name = "PL_Contenu";
            this.PL_Contenu.Size = new System.Drawing.Size(362, 122);
            this.PL_Contenu.TabIndex = 0;
            // 
            // PB_Imoticone
            // 
            this.PB_Imoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Imoticone.Image")));
            this.PB_Imoticone.Location = new System.Drawing.Point(15, 17);
            this.PB_Imoticone.Name = "PB_Imoticone";
            this.PB_Imoticone.Size = new System.Drawing.Size(69, 81);
            this.PB_Imoticone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_Imoticone.TabIndex = 5;
            this.PB_Imoticone.TabStop = false;
            // 
            // BT_Valider
            // 
            this.BT_Valider.Location = new System.Drawing.Point(169, 85);
            this.BT_Valider.Name = "BT_Valider";
            this.BT_Valider.Size = new System.Drawing.Size(75, 23);
            this.BT_Valider.TabIndex = 4;
            this.BT_Valider.Text = "OK";
            this.BT_Valider.UseVisualStyleBackColor = true;
            this.BT_Valider.Click += new System.EventHandler(this.BT_Valider_Click);
            // 
            // LBL_Message
            // 
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.Location = new System.Drawing.Point(90, 52);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(259, 16);
            this.LBL_Message.TabIndex = 3;
            this.LBL_Message.Text = "L\'enregistrement a bien été effectué.";
            // 
            // FRM_SaveConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 124);
            this.Controls.Add(this.PL_Contenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FRM_SaveConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.PL_Contenu.ResumeLayout(false);
            this.PL_Contenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PL_Contenu;
        private System.Windows.Forms.PictureBox PB_Imoticone;
        private System.Windows.Forms.Button BT_Valider;
        private System.Windows.Forms.Label LBL_Message;
    }
}

