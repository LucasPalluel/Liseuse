namespace PPE
{
    partial class FRM_ConvertirGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ConvertirGuide));
            this.GB_bouton = new System.Windows.Forms.GroupBox();
            this.B_annuler = new System.Windows.Forms.Button();
            this.B_convertir = new System.Windows.Forms.Button();
            this.B_details = new System.Windows.Forms.Button();
            this.B_meta = new System.Windows.Forms.Button();
            this.GB_details = new System.Windows.Forms.GroupBox();
            this.WB_Description = new System.Windows.Forms.WebBrowser();
            this.PN_details = new System.Windows.Forms.Panel();
            this.CB_formatconvertion = new System.Windows.Forms.ComboBox();
            this.LBL_taille = new System.Windows.Forms.Label();
            this.LV_format = new System.Windows.Forms.ListView();
            this.LBL_formatconvertion = new System.Windows.Forms.Label();
            this.TXT_titredetails = new System.Windows.Forms.TextBox();
            this.LBL_titredetails = new System.Windows.Forms.Label();
            this.GB_meta = new System.Windows.Forms.GroupBox();
            this.WB_Description2 = new System.Windows.Forms.WebBrowser();
            this.PAN_meta = new System.Windows.Forms.Panel();
            this.TXT_titre = new System.Windows.Forms.TextBox();
            this.CB_editeur = new System.Windows.Forms.ComboBox();
            this.CB_Auteurs = new System.Windows.Forms.ComboBox();
            this.LBL_auteur_meta = new System.Windows.Forms.Label();
            this.LBL_titre_meta = new System.Windows.Forms.Label();
            this.LBL_editeur_meta = new System.Windows.Forms.Label();
            this.PAN_picture_meta = new System.Windows.Forms.Panel();
            this.PB_meta = new System.Windows.Forms.PictureBox();
            this.B_Minimize = new System.Windows.Forms.Button();
            this.B_Fermeture = new System.Windows.Forms.Button();
            this.PNL_Header = new System.Windows.Forms.Panel();
            this.PNL_Footer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_Rediriger = new System.Windows.Forms.Button();
            this.GB_bouton.SuspendLayout();
            this.GB_details.SuspendLayout();
            this.PN_details.SuspendLayout();
            this.GB_meta.SuspendLayout();
            this.PAN_meta.SuspendLayout();
            this.PAN_picture_meta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_meta)).BeginInit();
            this.PNL_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_bouton
            // 
            this.GB_bouton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GB_bouton.Controls.Add(this.BT_Rediriger);
            this.GB_bouton.Controls.Add(this.B_annuler);
            this.GB_bouton.Controls.Add(this.B_convertir);
            this.GB_bouton.Controls.Add(this.B_details);
            this.GB_bouton.Controls.Add(this.B_meta);
            this.GB_bouton.Location = new System.Drawing.Point(13, 31);
            this.GB_bouton.Name = "GB_bouton";
            this.GB_bouton.Size = new System.Drawing.Size(220, 564);
            this.GB_bouton.TabIndex = 0;
            this.GB_bouton.TabStop = false;
            // 
            // B_annuler
            // 
            this.B_annuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.B_annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_annuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_annuler.ForeColor = System.Drawing.Color.White;
            this.B_annuler.Location = new System.Drawing.Point(0, 341);
            this.B_annuler.Name = "B_annuler";
            this.B_annuler.Size = new System.Drawing.Size(220, 79);
            this.B_annuler.TabIndex = 4;
            this.B_annuler.Text = "Annuler";
            this.B_annuler.UseVisualStyleBackColor = false;
            this.B_annuler.Click += new System.EventHandler(this.B_annuler_Click);
            // 
            // B_convertir
            // 
            this.B_convertir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.B_convertir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_convertir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_convertir.ForeColor = System.Drawing.Color.White;
            this.B_convertir.Location = new System.Drawing.Point(0, 256);
            this.B_convertir.Name = "B_convertir";
            this.B_convertir.Size = new System.Drawing.Size(220, 79);
            this.B_convertir.TabIndex = 2;
            this.B_convertir.Text = "Convertir";
            this.B_convertir.UseVisualStyleBackColor = false;
            this.B_convertir.Click += new System.EventHandler(this.B_convertir_Click);
            // 
            // B_details
            // 
            this.B_details.BackColor = System.Drawing.Color.Gray;
            this.B_details.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_details.ForeColor = System.Drawing.Color.White;
            this.B_details.Location = new System.Drawing.Point(0, 86);
            this.B_details.Name = "B_details";
            this.B_details.Size = new System.Drawing.Size(220, 79);
            this.B_details.TabIndex = 1;
            this.B_details.Text = "Détails de convertion";
            this.B_details.UseVisualStyleBackColor = false;
            this.B_details.Click += new System.EventHandler(this.B_recherche_Click);
            // 
            // B_meta
            // 
            this.B_meta.BackColor = System.Drawing.Color.Gray;
            this.B_meta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_meta.ForeColor = System.Drawing.Color.White;
            this.B_meta.Location = new System.Drawing.Point(0, 0);
            this.B_meta.Name = "B_meta";
            this.B_meta.Size = new System.Drawing.Size(220, 79);
            this.B_meta.TabIndex = 0;
            this.B_meta.Text = "Metadonnées";
            this.B_meta.UseVisualStyleBackColor = false;
            this.B_meta.Click += new System.EventHandler(this.B_meta_Click);
            // 
            // GB_details
            // 
            this.GB_details.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GB_details.Controls.Add(this.WB_Description);
            this.GB_details.Controls.Add(this.PN_details);
            this.GB_details.Location = new System.Drawing.Point(621, 30);
            this.GB_details.Name = "GB_details";
            this.GB_details.Size = new System.Drawing.Size(575, 563);
            this.GB_details.TabIndex = 3;
            this.GB_details.TabStop = false;
            this.GB_details.Visible = false;
            // 
            // WB_Description
            // 
            this.WB_Description.Location = new System.Drawing.Point(11, 229);
            this.WB_Description.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB_Description.Name = "WB_Description";
            this.WB_Description.Size = new System.Drawing.Size(547, 328);
            this.WB_Description.TabIndex = 9;
            // 
            // PN_details
            // 
            this.PN_details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PN_details.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PN_details.Controls.Add(this.CB_formatconvertion);
            this.PN_details.Controls.Add(this.LBL_taille);
            this.PN_details.Controls.Add(this.LV_format);
            this.PN_details.Controls.Add(this.LBL_formatconvertion);
            this.PN_details.Controls.Add(this.TXT_titredetails);
            this.PN_details.Controls.Add(this.LBL_titredetails);
            this.PN_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PN_details.Location = new System.Drawing.Point(11, 19);
            this.PN_details.Name = "PN_details";
            this.PN_details.Size = new System.Drawing.Size(547, 204);
            this.PN_details.TabIndex = 8;
            // 
            // CB_formatconvertion
            // 
            this.CB_formatconvertion.Enabled = false;
            this.CB_formatconvertion.FormattingEnabled = true;
            this.CB_formatconvertion.Items.AddRange(new object[] {
            "PDF",
            "Aucun"});
            this.CB_formatconvertion.Location = new System.Drawing.Point(176, 160);
            this.CB_formatconvertion.Name = "CB_formatconvertion";
            this.CB_formatconvertion.Size = new System.Drawing.Size(350, 28);
            this.CB_formatconvertion.TabIndex = 21;
            // 
            // LBL_taille
            // 
            this.LBL_taille.AutoSize = true;
            this.LBL_taille.Location = new System.Drawing.Point(25, 39);
            this.LBL_taille.Name = "LBL_taille";
            this.LBL_taille.Size = new System.Drawing.Size(125, 20);
            this.LBL_taille.TabIndex = 20;
            this.LBL_taille.Text = "Taille du format :";
            // 
            // LV_format
            // 
            this.LV_format.Enabled = false;
            this.LV_format.HideSelection = false;
            this.LV_format.Location = new System.Drawing.Point(176, 3);
            this.LV_format.Name = "LV_format";
            this.LV_format.Size = new System.Drawing.Size(344, 97);
            this.LV_format.TabIndex = 19;
            this.LV_format.UseCompatibleStateImageBehavior = false;
            this.LV_format.SelectedIndexChanged += new System.EventHandler(this.LV_format_SelectedIndexChanged);
            // 
            // LBL_formatconvertion
            // 
            this.LBL_formatconvertion.AutoSize = true;
            this.LBL_formatconvertion.Location = new System.Drawing.Point(0, 168);
            this.LBL_formatconvertion.Name = "LBL_formatconvertion";
            this.LBL_formatconvertion.Size = new System.Drawing.Size(167, 20);
            this.LBL_formatconvertion.TabIndex = 17;
            this.LBL_formatconvertion.Text = "Format de convertion :";
            // 
            // TXT_titredetails
            // 
            this.TXT_titredetails.Enabled = false;
            this.TXT_titredetails.Location = new System.Drawing.Point(176, 122);
            this.TXT_titredetails.Name = "TXT_titredetails";
            this.TXT_titredetails.Size = new System.Drawing.Size(350, 26);
            this.TXT_titredetails.TabIndex = 14;
            // 
            // LBL_titredetails
            // 
            this.LBL_titredetails.AutoSize = true;
            this.LBL_titredetails.Location = new System.Drawing.Point(56, 128);
            this.LBL_titredetails.Name = "LBL_titredetails";
            this.LBL_titredetails.Size = new System.Drawing.Size(48, 20);
            this.LBL_titredetails.TabIndex = 13;
            this.LBL_titredetails.Text = "Titre :";
            // 
            // GB_meta
            // 
            this.GB_meta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GB_meta.Controls.Add(this.WB_Description2);
            this.GB_meta.Controls.Add(this.PAN_meta);
            this.GB_meta.Location = new System.Drawing.Point(621, 32);
            this.GB_meta.Name = "GB_meta";
            this.GB_meta.Size = new System.Drawing.Size(577, 563);
            this.GB_meta.TabIndex = 2;
            this.GB_meta.TabStop = false;
            this.GB_meta.Visible = false;
            // 
            // WB_Description2
            // 
            this.WB_Description2.Location = new System.Drawing.Point(17, 210);
            this.WB_Description2.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB_Description2.Name = "WB_Description2";
            this.WB_Description2.Size = new System.Drawing.Size(547, 347);
            this.WB_Description2.TabIndex = 10;
            // 
            // PAN_meta
            // 
            this.PAN_meta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PAN_meta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PAN_meta.Controls.Add(this.TXT_titre);
            this.PAN_meta.Controls.Add(this.CB_editeur);
            this.PAN_meta.Controls.Add(this.CB_Auteurs);
            this.PAN_meta.Controls.Add(this.LBL_auteur_meta);
            this.PAN_meta.Controls.Add(this.LBL_titre_meta);
            this.PAN_meta.Controls.Add(this.LBL_editeur_meta);
            this.PAN_meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAN_meta.Location = new System.Drawing.Point(17, 19);
            this.PAN_meta.Name = "PAN_meta";
            this.PAN_meta.Size = new System.Drawing.Size(547, 185);
            this.PAN_meta.TabIndex = 7;
            // 
            // TXT_titre
            // 
            this.TXT_titre.Enabled = false;
            this.TXT_titre.Location = new System.Drawing.Point(120, 22);
            this.TXT_titre.Name = "TXT_titre";
            this.TXT_titre.Size = new System.Drawing.Size(408, 26);
            this.TXT_titre.TabIndex = 12;
            // 
            // CB_editeur
            // 
            this.CB_editeur.Enabled = false;
            this.CB_editeur.FormattingEnabled = true;
            this.CB_editeur.Location = new System.Drawing.Point(121, 115);
            this.CB_editeur.Name = "CB_editeur";
            this.CB_editeur.Size = new System.Drawing.Size(407, 28);
            this.CB_editeur.TabIndex = 8;
            // 
            // CB_Auteurs
            // 
            this.CB_Auteurs.Enabled = false;
            this.CB_Auteurs.FormattingEnabled = true;
            this.CB_Auteurs.Location = new System.Drawing.Point(121, 66);
            this.CB_Auteurs.Name = "CB_Auteurs";
            this.CB_Auteurs.Size = new System.Drawing.Size(407, 28);
            this.CB_Auteurs.TabIndex = 7;
            // 
            // LBL_auteur_meta
            // 
            this.LBL_auteur_meta.AutoSize = true;
            this.LBL_auteur_meta.Location = new System.Drawing.Point(23, 69);
            this.LBL_auteur_meta.Name = "LBL_auteur_meta";
            this.LBL_auteur_meta.Size = new System.Drawing.Size(83, 20);
            this.LBL_auteur_meta.TabIndex = 2;
            this.LBL_auteur_meta.Text = "Auteur(s) :";
            // 
            // LBL_titre_meta
            // 
            this.LBL_titre_meta.AutoSize = true;
            this.LBL_titre_meta.Location = new System.Drawing.Point(23, 23);
            this.LBL_titre_meta.Name = "LBL_titre_meta";
            this.LBL_titre_meta.Size = new System.Drawing.Size(48, 20);
            this.LBL_titre_meta.TabIndex = 1;
            this.LBL_titre_meta.Text = "Titre :";
            // 
            // LBL_editeur_meta
            // 
            this.LBL_editeur_meta.AutoSize = true;
            this.LBL_editeur_meta.Location = new System.Drawing.Point(23, 121);
            this.LBL_editeur_meta.Name = "LBL_editeur_meta";
            this.LBL_editeur_meta.Size = new System.Drawing.Size(68, 20);
            this.LBL_editeur_meta.TabIndex = 3;
            this.LBL_editeur_meta.Text = "Editeur :";
            // 
            // PAN_picture_meta
            // 
            this.PAN_picture_meta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PAN_picture_meta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PAN_picture_meta.Controls.Add(this.PB_meta);
            this.PAN_picture_meta.Location = new System.Drawing.Point(238, 30);
            this.PAN_picture_meta.Name = "PAN_picture_meta";
            this.PAN_picture_meta.Size = new System.Drawing.Size(377, 563);
            this.PAN_picture_meta.TabIndex = 0;
            // 
            // PB_meta
            // 
            this.PB_meta.BackColor = System.Drawing.Color.White;
            this.PB_meta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PB_meta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PB_meta.Location = new System.Drawing.Point(23, 17);
            this.PB_meta.Name = "PB_meta";
            this.PB_meta.Size = new System.Drawing.Size(323, 521);
            this.PB_meta.TabIndex = 0;
            this.PB_meta.TabStop = false;
            // 
            // B_Minimize
            // 
            this.B_Minimize.BackColor = System.Drawing.Color.Silver;
            this.B_Minimize.FlatAppearance.BorderSize = 0;
            this.B_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.B_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.B_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Minimize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.B_Minimize.Location = new System.Drawing.Point(1144, -1);
            this.B_Minimize.Name = "B_Minimize";
            this.B_Minimize.Size = new System.Drawing.Size(25, 25);
            this.B_Minimize.TabIndex = 49;
            this.B_Minimize.Text = "_";
            this.B_Minimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Minimize.UseVisualStyleBackColor = false;
            this.B_Minimize.Click += new System.EventHandler(this.B_Minimize_Click);
            // 
            // B_Fermeture
            // 
            this.B_Fermeture.BackColor = System.Drawing.Color.Firebrick;
            this.B_Fermeture.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Fermeture.FlatAppearance.BorderSize = 0;
            this.B_Fermeture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.B_Fermeture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.B_Fermeture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Fermeture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Fermeture.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.B_Fermeture.Location = new System.Drawing.Point(1170, 0);
            this.B_Fermeture.Name = "B_Fermeture";
            this.B_Fermeture.Size = new System.Drawing.Size(36, 23);
            this.B_Fermeture.TabIndex = 48;
            this.B_Fermeture.Text = "X";
            this.B_Fermeture.UseVisualStyleBackColor = false;
            this.B_Fermeture.Click += new System.EventHandler(this.B_Fermeture_Click);
            // 
            // PNL_Header
            // 
            this.PNL_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PNL_Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_Header.Controls.Add(this.B_Fermeture);
            this.PNL_Header.Controls.Add(this.B_Minimize);
            this.PNL_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_Header.Location = new System.Drawing.Point(0, 0);
            this.PNL_Header.Name = "PNL_Header";
            this.PNL_Header.Size = new System.Drawing.Size(1208, 25);
            this.PNL_Header.TabIndex = 50;
            this.PNL_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseDown);
            this.PNL_Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseMove);
            this.PNL_Header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PL_Top_MouseUp);
            // 
            // PNL_Footer
            // 
            this.PNL_Footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.PNL_Footer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PNL_Footer.Location = new System.Drawing.Point(0, 596);
            this.PNL_Footer.Name = "PNL_Footer";
            this.PNL_Footer.Size = new System.Drawing.Size(1208, 20);
            this.PNL_Footer.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1204, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 571);
            this.panel1.TabIndex = 52;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 571);
            this.panel2.TabIndex = 53;
            // 
            // BT_Rediriger
            // 
            this.BT_Rediriger.BackColor = System.Drawing.Color.Gray;
            this.BT_Rediriger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Rediriger.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_Rediriger.ForeColor = System.Drawing.Color.White;
            this.BT_Rediriger.Location = new System.Drawing.Point(0, 171);
            this.BT_Rediriger.Name = "BT_Rediriger";
            this.BT_Rediriger.Size = new System.Drawing.Size(220, 79);
            this.BT_Rediriger.TabIndex = 5;
            this.BT_Rediriger.Text = "Redirection vers Converteur";
            this.BT_Rediriger.UseVisualStyleBackColor = false;
            this.BT_Rediriger.Click += new System.EventHandler(this.BT_Rediriger_Click);
            // 
            // FRM_ConvertirGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 616);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GB_details);
            this.Controls.Add(this.PNL_Footer);
            this.Controls.Add(this.PNL_Header);
            this.Controls.Add(this.GB_meta);
            this.Controls.Add(this.PAN_picture_meta);
            this.Controls.Add(this.GB_bouton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_ConvertirGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convertir Livre";
            this.GB_bouton.ResumeLayout(false);
            this.GB_details.ResumeLayout(false);
            this.PN_details.ResumeLayout(false);
            this.PN_details.PerformLayout();
            this.GB_meta.ResumeLayout(false);
            this.PAN_meta.ResumeLayout(false);
            this.PAN_meta.PerformLayout();
            this.PAN_picture_meta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_meta)).EndInit();
            this.PNL_Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_bouton;
        private System.Windows.Forms.GroupBox GB_meta;
        private System.Windows.Forms.Button B_meta;
        private System.Windows.Forms.Button B_convertir;
        private System.Windows.Forms.Button B_details;
        private System.Windows.Forms.Panel PAN_picture_meta;
        private System.Windows.Forms.PictureBox PB_meta;
        private System.Windows.Forms.Panel PAN_meta;
        private System.Windows.Forms.Label LBL_auteur_meta;
        private System.Windows.Forms.Label LBL_titre_meta;
        private System.Windows.Forms.Label LBL_editeur_meta;
        private System.Windows.Forms.TextBox TXT_titre;
        private System.Windows.Forms.ComboBox CB_editeur;
        private System.Windows.Forms.ComboBox CB_Auteurs;
        private System.Windows.Forms.GroupBox GB_details;
        private System.Windows.Forms.Button B_annuler;
        private System.Windows.Forms.Panel PN_details;
        private System.Windows.Forms.Label LBL_taille;
        private System.Windows.Forms.ListView LV_format;
        private System.Windows.Forms.Label LBL_formatconvertion;
        private System.Windows.Forms.TextBox TXT_titredetails;
        private System.Windows.Forms.Label LBL_titredetails;
        private System.Windows.Forms.ComboBox CB_formatconvertion;
        private System.Windows.Forms.Button B_Minimize;
        private System.Windows.Forms.Button B_Fermeture;
        private System.Windows.Forms.Panel PNL_Header;
        private System.Windows.Forms.Panel PNL_Footer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser WB_Description;
        private System.Windows.Forms.WebBrowser WB_Description2;
        private System.Windows.Forms.Button BT_Rediriger;
    }
}