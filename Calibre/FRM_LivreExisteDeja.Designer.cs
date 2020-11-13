namespace PPE
{
    partial class FRM_LivreExisteDeja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_LivreExisteDeja));
            this.P_Error = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.P_Error.Controls.Add(this.label1);
            this.P_Error.Controls.Add(this.LBL_Titre);
            this.P_Error.Controls.Add(this.PB_Emoticone);
            this.P_Error.Controls.Add(this.B_OkError);
            this.P_Error.Controls.Add(this.LBL_Message2);
            this.P_Error.Location = new System.Drawing.Point(1, 1);
            this.P_Error.Name = "P_Error";
            this.P_Error.Size = new System.Drawing.Size(362, 121);
            this.P_Error.TabIndex = 13;
            this.P_Error.Paint += new System.Windows.Forms.PaintEventHandler(this.P_Error_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "dans la bibliothèque";
            // 
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(10, 5);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(60, 15);
            this.LBL_Titre.TabIndex = 15;
            this.LBL_Titre.Text = "Existant";
            // 
            // PB_Emoticone
            // 
            this.PB_Emoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Emoticone.Image")));
            this.PB_Emoticone.Location = new System.Drawing.Point(-1, 20);
            this.PB_Emoticone.Name = "PB_Emoticone";
            this.PB_Emoticone.Size = new System.Drawing.Size(95, 96);
            this.PB_Emoticone.TabIndex = 14;
            this.PB_Emoticone.TabStop = false;
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
            // LBL_Message2
            // 
            this.LBL_Message2.AutoSize = true;
            this.LBL_Message2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message2.Location = new System.Drawing.Point(137, 33);
            this.LBL_Message2.Name = "LBL_Message2";
            this.LBL_Message2.Size = new System.Drawing.Size(157, 18);
            this.LBL_Message2.TabIndex = 12;
            this.LBL_Message2.Text = "Ce livre existe déjà";
            // 
            // FRM_LivreExisteDeja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 123);
            this.Controls.Add(this.P_Error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_LivreExisteDeja";
            this.Text = "FRM_LivreExisteDeja";
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
        private System.Windows.Forms.Label label1;
    }
}