namespace PPE
{
    partial class FRM_Erreur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Erreur));
            this.P_Error = new System.Windows.Forms.Panel();
            this.LBL_Message2 = new System.Windows.Forms.Label();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.B_OkError = new System.Windows.Forms.Button();
            this.PB_Emoticone = new System.Windows.Forms.PictureBox();
            this.LBL_Titre = new System.Windows.Forms.Label();
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
            this.P_Error.Controls.Add(this.LBL_Message);
            this.P_Error.Location = new System.Drawing.Point(1, 1);
            this.P_Error.Name = "P_Error";
            this.P_Error.Size = new System.Drawing.Size(362, 121);
            this.P_Error.TabIndex = 12;
            // 
            // LBL_Message2
            // 
            this.LBL_Message2.AutoSize = true;
            this.LBL_Message2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message2.Location = new System.Drawing.Point(127, 44);
            this.LBL_Message2.Name = "LBL_Message2";
            this.LBL_Message2.Size = new System.Drawing.Size(203, 18);
            this.LBL_Message2.TabIndex = 12;
            this.LBL_Message2.Text = "Une erreur est survenue";
            // 
            // LBL_Message
            // 
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.Location = new System.Drawing.Point(185, 19);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(69, 18);
            this.LBL_Message.TabIndex = 11;
            this.LBL_Message.Text = "Oops ...";
            // 
            // B_OkError
            // 
            this.B_OkError.Location = new System.Drawing.Point(180, 80);
            this.B_OkError.Name = "B_OkError";
            this.B_OkError.Size = new System.Drawing.Size(75, 29);
            this.B_OkError.TabIndex = 13;
            this.B_OkError.Text = "OK";
            this.B_OkError.UseVisualStyleBackColor = true;
            this.B_OkError.Click += new System.EventHandler(this.B_OkError_Click);
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
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(10, 6);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(50, 15);
            this.LBL_Titre.TabIndex = 15;
            this.LBL_Titre.Text = "Erreur";
            // 
            // FRM_Erreur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 123);
            this.Controls.Add(this.P_Error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Erreur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Erreur";
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
        private System.Windows.Forms.Label LBL_Message;
    }
}