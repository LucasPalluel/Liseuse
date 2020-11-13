namespace PPE
{
    partial class ConfirmationContinuation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationContinuation));
            this.LBL_Titre = new System.Windows.Forms.Label();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.B_Non = new System.Windows.Forms.Button();
            this.B_Oui = new System.Windows.Forms.Button();
            this.PB_Imoticone = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_NonLocal = new System.Windows.Forms.Button();
            this.B_OuiLocal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_Titre
            // 
            this.LBL_Titre.AutoSize = true;
            this.LBL_Titre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Titre.Location = new System.Drawing.Point(11, 8);
            this.LBL_Titre.Name = "LBL_Titre";
            this.LBL_Titre.Size = new System.Drawing.Size(92, 15);
            this.LBL_Titre.TabIndex = 9;
            this.LBL_Titre.Text = "Confirmation";
            // 
            // LBL_Message
            // 
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.Location = new System.Drawing.Point(91, 46);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(272, 18);
            this.LBL_Message.TabIndex = 6;
            this.LBL_Message.Text = "Voulez-vous vraiment continuer ?";
            // 
            // B_Non
            // 
            this.B_Non.Location = new System.Drawing.Point(127, 85);
            this.B_Non.Name = "B_Non";
            this.B_Non.Size = new System.Drawing.Size(75, 29);
            this.B_Non.TabIndex = 7;
            this.B_Non.Text = "Non";
            this.B_Non.UseVisualStyleBackColor = true;
            this.B_Non.Visible = false;
            this.B_Non.Click += new System.EventHandler(this.B_Non_Click);
            // 
            // B_Oui
            // 
            this.B_Oui.Location = new System.Drawing.Point(208, 85);
            this.B_Oui.Name = "B_Oui";
            this.B_Oui.Size = new System.Drawing.Size(75, 29);
            this.B_Oui.TabIndex = 8;
            this.B_Oui.Text = "Oui";
            this.B_Oui.UseVisualStyleBackColor = true;
            this.B_Oui.Visible = false;
            this.B_Oui.Click += new System.EventHandler(this.B_Oui_Click);
            // 
            // PB_Imoticone
            // 
            this.PB_Imoticone.BackColor = System.Drawing.Color.Transparent;
            this.PB_Imoticone.Image = ((System.Drawing.Image)(resources.GetObject("PB_Imoticone.Image")));
            this.PB_Imoticone.Location = new System.Drawing.Point(12, 21);
            this.PB_Imoticone.Name = "PB_Imoticone";
            this.PB_Imoticone.Size = new System.Drawing.Size(83, 94);
            this.PB_Imoticone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_Imoticone.TabIndex = 10;
            this.PB_Imoticone.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.B_NonLocal);
            this.panel1.Controls.Add(this.LBL_Message);
            this.panel1.Controls.Add(this.B_OuiLocal);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 124);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // B_NonLocal
            // 
            this.B_NonLocal.Location = new System.Drawing.Point(125, 82);
            this.B_NonLocal.Name = "B_NonLocal";
            this.B_NonLocal.Size = new System.Drawing.Size(75, 29);
            this.B_NonLocal.TabIndex = 12;
            this.B_NonLocal.Text = "Non";
            this.B_NonLocal.UseVisualStyleBackColor = true;
            this.B_NonLocal.Visible = false;
            this.B_NonLocal.Click += new System.EventHandler(this.B_NonLocal_Click);
            // 
            // B_OuiLocal
            // 
            this.B_OuiLocal.Location = new System.Drawing.Point(206, 82);
            this.B_OuiLocal.Name = "B_OuiLocal";
            this.B_OuiLocal.Size = new System.Drawing.Size(75, 29);
            this.B_OuiLocal.TabIndex = 13;
            this.B_OuiLocal.Text = "Oui";
            this.B_OuiLocal.UseVisualStyleBackColor = true;
            this.B_OuiLocal.Visible = false;
            this.B_OuiLocal.Click += new System.EventHandler(this.B_OuiLocal_Click);
            // 
            // ConfirmationContinuation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 126);
            this.Controls.Add(this.PB_Imoticone);
            this.Controls.Add(this.LBL_Titre);
            this.Controls.Add(this.B_Non);
            this.Controls.Add(this.B_Oui);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmationContinuation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmationContinuation";
            this.Load += new System.EventHandler(this.ConfirmationContinuation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Imoticone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Titre;
        private System.Windows.Forms.Label LBL_Message;
        private System.Windows.Forms.Button B_Non;
        private System.Windows.Forms.Button B_Oui;
        private System.Windows.Forms.PictureBox PB_Imoticone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_NonLocal;
        private System.Windows.Forms.Button B_OuiLocal;
    }
}