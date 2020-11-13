namespace PPE
{
    partial class FRM_Biblio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            this.BTN_BrowseFolder = new System.Windows.Forms.Button();
            this.BTN_Confirm = new System.Windows.Forms.Button();
            this.PL_Top = new System.Windows.Forms.Panel();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.RD_Option1 = new System.Windows.Forms.RadioButton();
            this.RD_Option2 = new System.Windows.Forms.RadioButton();
            this.RD_Option3 = new System.Windows.Forms.RadioButton();
            this.PL_Bottom = new System.Windows.Forms.Panel();
            this.LBL_Name = new System.Windows.Forms.Label();
            this.CB_Name = new System.Windows.Forms.ComboBox();
            this.TXT_Path = new System.Windows.Forms.TextBox();
            this.PL_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_BrowseFolder
            // 
            this.BTN_BrowseFolder.FlatAppearance.BorderSize = 0;
            this.BTN_BrowseFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_BrowseFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BTN_BrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_BrowseFolder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_BrowseFolder.Location = new System.Drawing.Point(576, 40);
            this.BTN_BrowseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_BrowseFolder.Name = "BTN_BrowseFolder";
            this.BTN_BrowseFolder.Size = new System.Drawing.Size(142, 30);
            this.BTN_BrowseFolder.TabIndex = 1;
            this.BTN_BrowseFolder.Text = "Parcourir";
            this.BTN_BrowseFolder.UseVisualStyleBackColor = true;
            // 
            // BTN_Confirm
            // 
            this.BTN_Confirm.FlatAppearance.BorderSize = 0;
            this.BTN_Confirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.BTN_Confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.BTN_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Confirm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Confirm.Location = new System.Drawing.Point(576, 195);
            this.BTN_Confirm.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Confirm.Name = "BTN_Confirm";
            this.BTN_Confirm.Size = new System.Drawing.Size(142, 32);
            this.BTN_Confirm.TabIndex = 6;
            this.BTN_Confirm.Text = "Confirmer";
            this.BTN_Confirm.UseVisualStyleBackColor = true;
            // 
            // PL_Top
            // 
            this.PL_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PL_Top.Controls.Add(this.BTN_Exit);
            this.PL_Top.Controls.Add(this.LBL_Title);
            this.PL_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PL_Top.Location = new System.Drawing.Point(0, 0);
            this.PL_Top.Name = "PL_Top";
            this.PL_Top.Size = new System.Drawing.Size(731, 22);
            this.PL_Top.TabIndex = 5;
            this.PL_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseDown);
            this.PL_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseMove);
            this.PL_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseUp);
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTN_Exit.FlatAppearance.BorderSize = 0;
            this.BTN_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Exit.ForeColor = System.Drawing.Color.White;
            this.BTN_Exit.Location = new System.Drawing.Point(693, 0);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(38, 22);
            this.BTN_Exit.TabIndex = 8;
            this.BTN_Exit.Text = "X";
            this.BTN_Exit.UseVisualStyleBackColor = true;
            this.BTN_Exit.Click += new System.EventHandler(this.BTN_Exit_Click);
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.ForeColor = System.Drawing.Color.White;
            this.LBL_Title.Location = new System.Drawing.Point(12, 3);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(167, 17);
            this.LBL_Title.TabIndex = 8;
            this.LBL_Title.Text = "Gestion Bibliothèques";
            // 
            // RD_Option1
            // 
            this.RD_Option1.AutoSize = true;
            this.RD_Option1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RD_Option1.Location = new System.Drawing.Point(18, 179);
            this.RD_Option1.Name = "RD_Option1";
            this.RD_Option1.Size = new System.Drawing.Size(238, 21);
            this.RD_Option1.TabIndex = 2;
            this.RD_Option1.Text = "Basculer vers la bibliothèque";
            this.RD_Option1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RD_Option1.UseVisualStyleBackColor = true;
            // 
            // RD_Option2
            // 
            this.RD_Option2.AutoSize = true;
            this.RD_Option2.Checked = true;
            this.RD_Option2.Location = new System.Drawing.Point(18, 152);
            this.RD_Option2.Name = "RD_Option2";
            this.RD_Option2.Size = new System.Drawing.Size(258, 21);
            this.RD_Option2.TabIndex = 3;
            this.RD_Option2.TabStop = true;
            this.RD_Option2.Text = "Créer une nouvelle bibliothèque";
            this.RD_Option2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RD_Option2.UseVisualStyleBackColor = true;
            // 
            // RD_Option3
            // 
            this.RD_Option3.AutoSize = true;
            this.RD_Option3.Location = new System.Drawing.Point(18, 206);
            this.RD_Option3.Name = "RD_Option3";
            this.RD_Option3.Size = new System.Drawing.Size(411, 21);
            this.RD_Option3.TabIndex = 4;
            this.RD_Option3.Text = "Déplacer la bibliothèque actuelle vers l\'emplacement";
            this.RD_Option3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RD_Option3.UseVisualStyleBackColor = true;
            // 
            // PL_Bottom
            // 
            this.PL_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PL_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PL_Bottom.Location = new System.Drawing.Point(0, 249);
            this.PL_Bottom.Name = "PL_Bottom";
            this.PL_Bottom.Size = new System.Drawing.Size(731, 15);
            this.PL_Bottom.TabIndex = 6;
            // 
            // LBL_Name
            // 
            this.LBL_Name.AutoSize = true;
            this.LBL_Name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Name.Location = new System.Drawing.Point(12, 89);
            this.LBL_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Name.Name = "LBL_Name";
            this.LBL_Name.Size = new System.Drawing.Size(197, 18);
            this.LBL_Name.TabIndex = 9;
            this.LBL_Name.Text = "Nom de la bibliothèque :";
            // 
            // CB_Name
            // 
            this.CB_Name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.CB_Name.FormattingEnabled = true;
            this.CB_Name.Location = new System.Drawing.Point(216, 87);
            this.CB_Name.Name = "CB_Name";
            this.CB_Name.Size = new System.Drawing.Size(336, 26);
            this.CB_Name.TabIndex = 10;
            // 
            // TXT_Path
            // 
            this.TXT_Path.Enabled = false;
            this.TXT_Path.Location = new System.Drawing.Point(15, 43);
            this.TXT_Path.Name = "TXT_Path";
            this.TXT_Path.Size = new System.Drawing.Size(554, 25);
            this.TXT_Path.TabIndex = 11;
            // 
            // FRM_Biblio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(731, 264);
            this.Controls.Add(this.TXT_Path);
            this.Controls.Add(this.CB_Name);
            this.Controls.Add(this.LBL_Name);
            this.Controls.Add(this.PL_Bottom);
            this.Controls.Add(this.RD_Option3);
            this.Controls.Add(this.RD_Option2);
            this.Controls.Add(this.RD_Option1);
            this.Controls.Add(this.PL_Top);
            this.Controls.Add(this.BTN_Confirm);
            this.Controls.Add(this.BTN_BrowseFolder);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM_Biblio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Biblio";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_Biblio_KeyDown);
            this.PL_Top.ResumeLayout(false);
            this.PL_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button BTN_BrowseFolder;
        public System.Windows.Forms.Button BTN_Confirm;
        public System.Windows.Forms.Panel PL_Top;
        public System.Windows.Forms.RadioButton RD_Option1;
        public System.Windows.Forms.RadioButton RD_Option2;
        public System.Windows.Forms.RadioButton RD_Option3;
        public System.Windows.Forms.Panel PL_Bottom;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Button BTN_Exit;
        public System.Windows.Forms.Label LBL_Name;
        public System.Windows.Forms.ComboBox CB_Name;
        public System.Windows.Forms.TextBox TXT_Path;
    }
}