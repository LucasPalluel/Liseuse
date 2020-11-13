using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using VersOne.Epub;
using System.IO.Compression;

namespace PPE
{
    public partial class FRM_Editer : Form
    {
        public int i=0, j=0;
        public string fichier;
        EpubBook epubBook; // In
        public string nom, nchemin; 
        Livres ch;
        public Bibliotheque biblio;
        public int charge;
        
        public FRM_Editer(Bibliotheque bibli,Livres chemin)
        {
            biblio = bibli;
            InitializeComponent();
            try
            {
                ch = chemin;
                Epub();
                Copie(1);
                FRM_NumeriBook.ActiveForm.Visible = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExeptionCatch(ex);
            }
        }

        private void Epub()
        {
            nom = Path.GetFileName(ch.full_chemin_livre); //Nom fichier epub
            string extention = System.IO.Path.GetFileNameWithoutExtension(nom) + ".zip";
            string pathString = biblio.CurrentPath + @"\copies\";
            nchemin = pathString + extention;
            if (File.Exists(pathString + nom))
            {
                //FRM_OriginalModifier Popup = new FRM_OriginalModifier();
                //Popup.ShowDialog();
                //charge = Popup.Choix();
                if (charge == 1)
                {
                    epubBook = EpubReader.ReadBook(ch.full_chemin_livre);
                }
                else
                {
                    epubBook = EpubReader.ReadBook(pathString + nom);
                }
            }
        }
        private void Copie(int i)
        {
            nom = Path.GetFileName(ch.full_chemin_livre) ; //Nom fichier epub
            string extention = System.IO.Path.GetFileNameWithoutExtension(nom) + ".zip";
            string pathString = biblio.CurrentPath + @"\copies\";
            nchemin = pathString + extention;
            string var;
            try
            {
                if (!Directory.Exists(biblio.CurrentPath + @"\copies\edit"))
                {
                    Directory.CreateDirectory(biblio.CurrentPath + @"\copies\edit");
                }
                if (!File.Exists(pathString + nom))
                {
                    var = ch.full_chemin_livre;
                }
                else
                {
                    var = pathString + nom;
                }
                    if (i == 1)
                    {
                        File.Copy(var, nchemin, true);
                        ZipFile.ExtractToDirectory(nchemin, pathString + "edit");
                        File.Delete(nchemin);
                    }
                    if (i == 2)
                    {
                        ZipFile.CreateFromDirectory(pathString + "edit", nchemin);
                        if (File.Exists(pathString + nom))
                        {
                            File.Delete(pathString + nom);
                        }
                        File.Copy(nchemin, pathString + nom, true);
                        File.Delete(nchemin);
                        Directory.Delete(pathString + @"edit", true);
                    }
            }
            catch(Exception exc)
            {
                ExceptionHandler.ExeptionCatch(exc);
            }
        }

        private void FRM_Editer_Load(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, EpubByteContentFile> img = epubBook.Content.Images;
                Dictionary<string, EpubContentFile> allFiles = epubBook.Content.AllFiles;
                foreach(KeyValuePair<string, EpubByteContentFile> item in img)
                {
                    allFiles.Remove(item.Key);
                }
                foreach (KeyValuePair<string, EpubContentFile> item in allFiles)
                {
                    LB_Fichiers.Items.Add(item.Key);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExeptionCatch(ex);
            }
        }

        private void LB_Fichiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string html;
            i = 0;
            fichier = LB_Fichiers.SelectedItem.ToString();

            Dictionary<string, EpubContentFile> allFiles = epubBook.Content.AllFiles;
            try
            {
                foreach (EpubTextContentFile htmlFile in allFiles.Values)
                {
                    if (htmlFile.FileName == fichier)
                    {
                        i = -3;
                        html = htmlFile.Content;
                        RTXT_Editeur.Text = html;
                    }
                    if (i != -3)
                    {
                        j = j + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                ExceptionHandler.ExeptionCatch(ex);
            }
        }

        private void B_Reduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            Fermeture();
        }

        private void B_Copier_Click(object sender, EventArgs e)
        {
            if (RTXT_Editeur.SelectionLength > 0)
                RTXT_Editeur.Copy();
        }

        private void B_Couper_Click(object sender, EventArgs e)
        {
            if (RTXT_Editeur.SelectedText != "")
                RTXT_Editeur.Cut();
        }

        private void B_Coller_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (RTXT_Editeur.SelectionLength > 0)
                {
                    if (MessageBox.Show("Voulez vous copier par dessus votre selection?", "Ecraser la sélection?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        RTXT_Editeur.SelectionStart = RTXT_Editeur.SelectionStart + RTXT_Editeur.SelectionLength;
                    }
                }
                RTXT_Editeur.Paste();
            }
        }

        private void B_Undo_Click(object sender, EventArgs e)
        {
            if (RTXT_Editeur.CanUndo == true)
            {
                RTXT_Editeur.Undo();
            }
        }

        private void B_Redo_Click(object sender, EventArgs e)
        {
            if (RTXT_Editeur.CanRedo==true)
            {
                RTXT_Editeur.Redo();
            }
        }

        private void SaveAll()
        {

            string s = "", str = LB_Fichiers.SelectedItem.ToString();
            string sPath = biblio.CurrentPath + @"\copies\edit";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            foreach (string sFileName in System.IO.Directory.GetFiles(sPath, LB_Fichiers.SelectedItem.ToString(), SearchOption.AllDirectories))
            {
                if (Path.GetFileName(sFileName) == LB_Fichiers.SelectedItem.ToString())
                {
                    s = Path.GetFullPath(sFileName);
                    File.Delete(s);
                    StreamWriter file = new StreamWriter(s);
                    file.Write(RTXT_Editeur.Text);
                    file.Close();
                }
            }
        }

        private void Fermeture()
        {
            Copie(2);
            /*      FRM_NumeriBook fRM_NumeriBook = new FRM_NumeriBook();
                  PPE.Active active = new Active(true, fRM_NumeriBook); */
            FRM_NumeriBook.ActiveForm.Visible = true;
            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode== Keys.F4)
            {
                e.SuppressKeyPress=true;
                Fermeture();
            }
            base.OnKeyDown(e);
        }

        private void RTXT_Editeur_TextChanged(object sender, EventArgs e)
        {
            WB_Rendu.DocumentText = RTXT_Editeur.Text;
            try
            {
                SaveAll();
                WB_Rendu.DocumentText = RTXT_Editeur.Text;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExeptionCatch(ex);
            }

        }
    }
}
