namespace PPE
{
    partial class FRM_Sortie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Sortie));
            this.PB_Emoticone = new System.Windows.Forms.PictureBox();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.B_Non = new System.Windows.Forms.Button();
            this.B_Oui = new System.Windows.Forms.Button();
            this.PL_Contenu = new System.Windows.Forms.Panel();
            this.LBL_Titre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Emoticone)).BeginInit();
            this.PL_Contenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_Emoticone
            // 
            this.PB_Emoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Emoticone.Image")));
            this.PB_Emoticone.Location = new System.Drawing.Point(2, 28);
            this.PB_Emoticone.Name = "PB_Emoticone";
            this.PB_Emoticone.Size = new System.Drawing.Size(79, 85);
            this.PB_Emoticone.TabIndex = 0;
            this.PB_Emoticone.TabStop = false;
            // 
            // LBL_Message
            // 
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.Location = new System.Drawing.Point(93, 47);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(248, 18);
            this.LBL_Message.TabIndex = 1;
            this.LBL_Message.Text = "Voulez-vous vraiment quitter ?";
            // 
            // B_Non
            // 
            this.B_Non.Location = new System.Drawing.Point(126, 84);
            this.B_Non.Name = "B_Non";
            this.B_Non.Size = new System.Drawing.Size(75, 29);
            this.B_Non.TabIndex = 2;
            this.B_Non.Text = "Non";
            this.B_Non.UseVisualStyleBackColor = true;
            this.B_Non.Click += new System.EventHandler(this.B_Non_Click);
            // 
            // B_Oui
            // 
            this.B_Oui.Location = new System.Drawing.Point(207, 84);
            this.B_Oui.Name = "B_Oui";
            this.B_Oui.Size = new System.Drawing.Size(75, 29);
            this.B_Oui.TabIndex = 3;
            this.B_Oui.Text = "Oui";
            this.B_Oui.UseVisualStyleBackColor = true;
            this.B_Oui.Click += new System.EventHandler(this.B_Oui_Click);
            // 
            // PL_Contenu
            // 
            this.PL_Contenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PL_Contenu.Controls.Add(this.LBL_Titre);
            this.PL_Contenu.Controls.Add(this.LBL_Message);
            this.PL_Contenu.Controls.Add(this.B_Non);
            this.PL_Contenu.Controls.Add(this.B_Oui);
            this.PL_Contenu.Controls.Add(this.PB_Emoticone);
            this.PL_Contenu.Location = new System.Drawing.Point(1, 1);
            this.PL_Contenu.Name = "PL_Contenu";
            this.PL_Contenu.Size = new System.Drawing.Size(364, 124);
            this.PL_Contenu.TabIndex = 4;
            // 
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(10, 7);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(92, 15);
            this.LBL_Titre.TabIndex = 4;
            this.LBL_Titre.Text = "Confirmation";
            // 
            // FRM_Sortie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 126);
            this.Controls.Add(this.PL_Contenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Sortie";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_Sortie_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Emoticone)).EndInit();
            this.PL_Contenu.ResumeLayout(false);
            this.PL_Contenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Emoticone;
        private System.Windows.Forms.Label LBL_Message;
        private System.Windows.Forms.Button B_Non;
        private System.Windows.Forms.Button B_Oui;
        private System.Windows.Forms.Panel PL_Contenu;
        private System.Windows.Forms.Label LBL_Titre;
    }
}

