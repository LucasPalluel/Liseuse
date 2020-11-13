namespace PPE
{
    partial class FRM_Editer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Editer));
            this.LB_Fichiers = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PN_Bordure = new System.Windows.Forms.Panel();
            this.B_Exit = new System.Windows.Forms.Button();
            this.B_Reduire = new System.Windows.Forms.Button();
            this.PN_Bas = new System.Windows.Forms.Panel();
            this.PN_Gauche = new System.Windows.Forms.Panel();
            this.PN_Droite = new System.Windows.Forms.Panel();
            this.RTXT_Editeur = new System.Windows.Forms.RichTextBox();
            this.B_Copier = new System.Windows.Forms.Button();
            this.B_Coller = new System.Windows.Forms.Button();
            this.B_Couper = new System.Windows.Forms.Button();
            this.B_Redo = new System.Windows.Forms.Button();
            this.B_Undo = new System.Windows.Forms.Button();
            this.GB_Controle = new System.Windows.Forms.GroupBox();
            this.WB_Rendu = new System.Windows.Forms.WebBrowser();
            this.OFD_Chemin = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.PN_Bordure.SuspendLayout();
            this.GB_Controle.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_Fichiers
            // 
            this.LB_Fichiers.FormattingEnabled = true;
            this.LB_Fichiers.Location = new System.Drawing.Point(12, 25);
            this.LB_Fichiers.Name = "LB_Fichiers";
            this.LB_Fichiers.Size = new System.Drawing.Size(134, 407);
            this.LB_Fichiers.TabIndex = 0;
            this.LB_Fichiers.SelectedIndexChanged += new System.EventHandler(this.LB_Fichiers_SelectedIndexChanged);
            // 
            // PN_Bordure
            // 
            this.PN_Bordure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PN_Bordure.Controls.Add(this.B_Exit);
            this.PN_Bordure.Controls.Add(this.B_Reduire);
            this.PN_Bordure.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Bordure.Location = new System.Drawing.Point(0, 0);
            this.PN_Bordure.Name = "PN_Bordure";
            this.PN_Bordure.Size = new System.Drawing.Size(909, 19);
            this.PN_Bordure.TabIndex = 2;
            // 
            // B_Exit
            // 
            this.B_Exit.BackColor = System.Drawing.Color.Firebrick;
            this.B_Exit.FlatAppearance.BorderSize = 0;
            this.B_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Exit.Location = new System.Drawing.Point(889, 0);
            this.B_Exit.Name = "B_Exit";
            this.B_Exit.Size = new System.Drawing.Size(20, 19);
            this.B_Exit.TabIndex = 9;
            this.B_Exit.Text = "X";
            this.B_Exit.UseVisualStyleBackColor = false;
            this.B_Exit.Click += new System.EventHandler(this.B_Exit_Click);
            // 
            // B_Reduire
            // 
            this.B_Reduire.BackColor = System.Drawing.Color.Gray;
            this.B_Reduire.FlatAppearance.BorderSize = 0;
            this.B_Reduire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Reduire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.B_Reduire.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.B_Reduire.Location = new System.Drawing.Point(860, 0);
            this.B_Reduire.Name = "B_Reduire";
            this.B_Reduire.Size = new System.Drawing.Size(23, 19);
            this.B_Reduire.TabIndex = 8;
            this.B_Reduire.Text = "-";
            this.B_Reduire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Reduire.UseVisualStyleBackColor = false;
            this.B_Reduire.Click += new System.EventHandler(this.B_Reduire_Click);
            // 
            // PN_Bas
            // 
            this.PN_Bas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PN_Bas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PN_Bas.Location = new System.Drawing.Point(0, 445);
            this.PN_Bas.Name = "PN_Bas";
            this.PN_Bas.Size = new System.Drawing.Size(909, 5);
            this.PN_Bas.TabIndex = 3;
            // 
            // PN_Gauche
            // 
            this.PN_Gauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PN_Gauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.PN_Gauche.Location = new System.Drawing.Point(0, 19);
            this.PN_Gauche.Name = "PN_Gauche";
            this.PN_Gauche.Size = new System.Drawing.Size(5, 426);
            this.PN_Gauche.TabIndex = 4;
            // 
            // PN_Droite
            // 
            this.PN_Droite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PN_Droite.Dock = System.Windows.Forms.DockStyle.Right;
            this.PN_Droite.Location = new System.Drawing.Point(904, 19);
            this.PN_Droite.Name = "PN_Droite";
            this.PN_Droite.Size = new System.Drawing.Size(5, 426);
            this.PN_Droite.TabIndex = 4;
            // 
            // RTXT_Editeur
            // 
            this.RTXT_Editeur.Location = new System.Drawing.Point(152, 83);
            this.RTXT_Editeur.Name = "RTXT_Editeur";
            this.RTXT_Editeur.Size = new System.Drawing.Size(406, 349);
            this.RTXT_Editeur.TabIndex = 6;
            this.RTXT_Editeur.Text = "";
            this.RTXT_Editeur.TextChanged += new System.EventHandler(this.RTXT_Editeur_TextChanged);
            // 
            // B_Copier
            // 
            this.B_Copier.Image = ((System.Drawing.Image)(resources.GetObject("B_Copier.Image")));
            this.B_Copier.Location = new System.Drawing.Point(13, 6);
            this.B_Copier.Name = "B_Copier";
            this.B_Copier.Size = new System.Drawing.Size(32, 26);
            this.B_Copier.TabIndex = 1;
            this.B_Copier.UseVisualStyleBackColor = true;
            this.B_Copier.Click += new System.EventHandler(this.B_Copier_Click);
            // 
            // B_Coller
            // 
            this.B_Coller.Image = ((System.Drawing.Image)(resources.GetObject("B_Coller.Image")));
            this.B_Coller.Location = new System.Drawing.Point(89, 6);
            this.B_Coller.Name = "B_Coller";
            this.B_Coller.Size = new System.Drawing.Size(32, 26);
            this.B_Coller.TabIndex = 3;
            this.B_Coller.UseVisualStyleBackColor = true;
            this.B_Coller.Click += new System.EventHandler(this.B_Coller_Click);
            // 
            // B_Couper
            // 
            this.B_Couper.Image = ((System.Drawing.Image)(resources.GetObject("B_Couper.Image")));
            this.B_Couper.Location = new System.Drawing.Point(51, 6);
            this.B_Couper.Name = "B_Couper";
            this.B_Couper.Size = new System.Drawing.Size(32, 26);
            this.B_Couper.TabIndex = 2;
            this.B_Couper.UseVisualStyleBackColor = true;
            this.B_Couper.Click += new System.EventHandler(this.B_Couper_Click);
            // 
            // B_Redo
            // 
            this.B_Redo.Image = ((System.Drawing.Image)(resources.GetObject("B_Redo.Image")));
            this.B_Redo.Location = new System.Drawing.Point(184, 6);
            this.B_Redo.Name = "B_Redo";
            this.B_Redo.Size = new System.Drawing.Size(32, 26);
            this.B_Redo.TabIndex = 5;
            this.B_Redo.UseVisualStyleBackColor = true;
            this.B_Redo.Click += new System.EventHandler(this.B_Redo_Click);
            // 
            // B_Undo
            // 
            this.B_Undo.Image = ((System.Drawing.Image)(resources.GetObject("B_Undo.Image")));
            this.B_Undo.Location = new System.Drawing.Point(146, 6);
            this.B_Undo.Name = "B_Undo";
            this.B_Undo.Size = new System.Drawing.Size(32, 26);
            this.B_Undo.TabIndex = 4;
            this.B_Undo.UseVisualStyleBackColor = true;
            this.B_Undo.Click += new System.EventHandler(this.B_Undo_Click);
            // 
            // GB_Controle
            // 
            this.GB_Controle.Controls.Add(this.B_Undo);
            this.GB_Controle.Controls.Add(this.B_Redo);
            this.GB_Controle.Controls.Add(this.B_Couper);
            this.GB_Controle.Controls.Add(this.B_Coller);
            this.GB_Controle.Controls.Add(this.B_Copier);
            this.GB_Controle.Location = new System.Drawing.Point(153, 35);
            this.GB_Controle.Name = "GB_Controle";
            this.GB_Controle.Size = new System.Drawing.Size(405, 31);
            this.GB_Controle.TabIndex = 10;
            this.GB_Controle.TabStop = false;
            // 
            // WB_Rendu
            // 
            this.WB_Rendu.Location = new System.Drawing.Point(564, 25);
            this.WB_Rendu.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB_Rendu.Name = "WB_Rendu";
            this.WB_Rendu.Size = new System.Drawing.Size(319, 407);
            this.WB_Rendu.TabIndex = 7;
            // 
            // OFD_Chemin
            // 
            this.OFD_Chemin.FileName = "openFileDialog1";
            // 
            // FRM_Editer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 450);
            this.Controls.Add(this.WB_Rendu);
            this.Controls.Add(this.GB_Controle);
            this.Controls.Add(this.RTXT_Editeur);
            this.Controls.Add(this.PN_Gauche);
            this.Controls.Add(this.PN_Droite);
            this.Controls.Add(this.PN_Bas);
            this.Controls.Add(this.PN_Bordure);
            this.Controls.Add(this.LB_Fichiers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FRM_Editer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editer le Livre";
            this.Load += new System.EventHandler(this.FRM_Editer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.PN_Bordure.ResumeLayout(false);
            this.GB_Controle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Fichiers;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel PN_Bordure;
        private System.Windows.Forms.Button B_Reduire;
        private System.Windows.Forms.Panel PN_Bas;
        private System.Windows.Forms.Panel PN_Gauche;
        private System.Windows.Forms.Panel PN_Droite;
        private System.Windows.Forms.RichTextBox RTXT_Editeur;
        private System.Windows.Forms.Button B_Exit;
        private System.Windows.Forms.Button B_Copier;
        private System.Windows.Forms.Button B_Coller;
        private System.Windows.Forms.Button B_Couper;
        private System.Windows.Forms.Button B_Redo;
        private System.Windows.Forms.Button B_Undo;
        private System.Windows.Forms.GroupBox GB_Controle;
        private System.Windows.Forms.WebBrowser WB_Rendu;
        private System.Windows.Forms.OpenFileDialog OFD_Chemin;
    }
}

