namespace FRM_TropDeFichier
{
    partial class FRM_TropDeFichier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_TropDeFichier));
            this.P_Error = new System.Windows.Forms.Panel();
            this.LBL_Titre = new System.Windows.Forms.Label();
            this.PB_Emoticone = new System.Windows.Forms.PictureBox();
            this.B_OkError = new System.Windows.Forms.Button();
            this.LBL_Message2 = new System.Windows.Forms.Label();
            this.P_Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Emoticone)).BeginInit();
            this.SuspendLayout();
            // 
            // P_Error
            // 
            this.P_Error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P_Error.Controls.Add(this.LBL_Titre);
            this.P_Error.Controls.Add(this.PB_Emoticone);
            this.P_Error.Controls.Add(this.B_OkError);
            this.P_Error.Controls.Add(this.LBL_Message2);
            this.P_Error.Location = new System.Drawing.Point(0, 1);
            this.P_Error.Name = "P_Error";
            this.P_Error.Size = new System.Drawing.Size(362, 121);
            this.P_Error.TabIndex = 13;
            // 
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(7, 6);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(101, 15);
            this.LBL_Titre.TabIndex = 15;
            this.LBL_Titre.Text = "Trop de fichier";
            // 
            // PB_Emoticone
            // 
            this.PB_Emoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Emoticone.Image")));
            this.PB_Emoticone.Location = new System.Drawing.Point(10, 24);
            this.PB_Emoticone.Name = "PB_Emoticone";
            this.PB_Emoticone.Size = new System.Drawing.Size(79, 85);
            this.PB_Emoticone.TabIndex = 14;
            this.PB_Emoticone.TabStop = false;
            // 
            // B_OkError
            // 
            this.B_OkError.Location = new System.Drawing.Point(184, 77);
            this.B_OkError.Name = "B_OkError";
            this.B_OkError.Size = new System.Drawing.Size(75, 29);
            this.B_OkError.TabIndex = 13;
            this.B_OkError.Text = "OK";
            this.B_OkError.UseVisualStyleBackColor = true;
            this.B_OkError.Click += new System.EventHandler(this.B_OkError_Click);
            // 
            // LBL_Message2
            // 
            this.LBL_Message2.AutoSize = true;
            this.LBL_Message2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message2.Location = new System.Drawing.Point(120, 44);
            this.LBL_Message2.Name = "LBL_Message2";
            this.LBL_Message2.Size = new System.Drawing.Size(224, 18);
            this.LBL_Message2.TabIndex = 12;
            this.LBL_Message2.Text = "Trop  de fichier selectionné";
            // 
            // FRM_TropDeFichier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 124);
            this.Controls.Add(this.P_Error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_TropDeFichier";
            this.Text = "Erreur";
            this.P_Error.ResumeLayout(false);
            this.P_Error.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Emoticone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_Error;
        private System.Windows.Forms.Label LBL_Titre;
        private System.Windows.Forms.PictureBox PB_Emoticone;
        private System.Windows.Forms.Button B_OkError;
        private System.Windows.Forms.Label LBL_Message2;
    }
}

