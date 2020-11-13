using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Threading;

namespace PPE
{
    public partial class FRM_NumeriBook : Form
    {
        public int i;
        public string pathBook;
        public ConnectSQLite Database
        {
            get
            {
                return biblio.Database;
            }
        }

        private int mov, movX, movY;
        private readonly Bibliotheque biblio;
        private readonly Panel[] PlOption;
        private readonly List<string> cheminLivre = new List<string>();
        private readonly List<string> idLivre = new List<string>();
        private readonly Active active;
        public FRM_NumeriBook()
        {
            InitializeComponent();
            bgw_comparaison = new BackgroundWorker();
            bgw_comparaison.DoWork += new DoWorkEventHandler(this.comparaisonDoWork);
            bgw_comparaison.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.comparaisonComplete);
            active = new Active(true, this);
            biblio = new Bibliotheque(this);
            PlOption = new Panel[] { P_Ajouter, P_Supprimer, P_EnvoiePeriph, P_Peripherique, P_Enregistrer };
            ClearPanel();
            AfficheLesEnregistrementsEpub();
            RAB_Auteur.Checked = true;
            //AfficheLesFichierEpub();
        }
        private void BT_Close_Click(object sender, EventArgs e)
        {
            FRM_Sortie Sortie = new FRM_Sortie(biblio.Database);
            Sortie.ShowDialog();
        }
        private void BT_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void PL_BorderMove_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void PL_BorderMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }
        private void PL_BorderMove_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void LV_Livre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count > 0)
            {
                string selected = GetAllSelectedPath(true)[0];
                PB_Couverture.BackgroundImage = null;
                ClassEpubRead classEpub = new ClassEpubRead(selected);
                PB_Couverture.Image = classEpub.picture;
                LBL_Auteur.Text = "Auteur : " + classEpub.auteur;
                LBL_Etiquette.Text = "Etiquette : " + classEpub.genre;
                LBL_Chemin.Text = "Chemin : " + selected;
                LBL_Format.Text = "Format : " + selected.Substring(selected.Length - 4, 4).ToUpper();
            }
        }
        private void BT_Enregistrer_Click(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP _SelecSVP = new FRM_SelecSVP();
                _SelecSVP.ShowDialog();
            }
            else
            {
                try
                {
                    // Demande du chemin d'accès à l'utilisateur
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //Récupére dans une collection toute les index selectionnés
                        ListView.SelectedIndexCollection indexes = LV_Livre.SelectedIndices;

                        foreach (Livres index in GetAllSelectedLivres())
                        {
                            // On vien récupéré l'ID du livre selectionné dans la ListView et son chemin_livre
                            string selected = cheminLivre[LV_Livre.SelectedIndices[0]];
                            //PPE.Chemin ch = new Chemin(selected);

                            //ch.Serialize();

                            // Récupére le chemin d'accès dans une variable string
                            string chemin = fbd.SelectedPath;

                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                            // Récupére le nom de l'auteur du livre pour nommer le dossier principale
                            string MainFolderName = "A faire";

                            //Fusionne le chemin d'accès au dossier principale dans une variable MainFolder 
                            string MainFolder = @"" + chemin + "\\" + MainFolderName;

                            //Récupére le nom du livre pour nommer le sous-dossier
                            string SubFolderName = index.titre;

                            //Fusionne le MainFolder avec le sous-dossier
                            string pathString = System.IO.Path.Combine(MainFolder, SubFolderName);
                            System.IO.Directory.CreateDirectory(pathString);


                            //Utilise toutes les variables précédemment créer pour creer les dossiers, sous dossier et les fichiers.epub
                            string path = @"" + chemin + "\\" + MainFolderName + "\\" + SubFolderName + "\\" + index.FileName + "";

                            if (File.Exists(path))
                            {
                                FRM_LivreExisteDeja _LivreExisteDeja = new FRM_LivreExisteDeja();
                                _LivreExisteDeja.ShowDialog();
                            }
                            else
                            {
                                // Copie du fichier source et de son contenu dans le nouveau chemin
                                string sourcefile = index.full_chemin_livre;
                                string destinationfile = @"" + path + "";
                                File.Copy(sourcefile, destinationfile);

                                // Confirmation de l'enregistrement
                                PPE.FRM_SaveConfirm saveconfirm = new PPE.FRM_SaveConfirm();
                                saveconfirm.ShowDialog();
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    FRM_Erreur _Erreur = new FRM_Erreur();
                    _Erreur.ShowDialog();
                    ExceptionHandler.ExeptionCatch(ex);
                }
            }
        }
        private void BT_Bibliotheque_Click(object sender, EventArgs e)
        {
            active.visibleForm(false);
            biblio.OpenMenu();
            active.visibleForm(true);
        }

        private void BT_Convertir_Click(object sender, EventArgs e)
        {
            active.visibleForm(false);
            FRM_ConvertirGuide _ConvertirGuide = new FRM_ConvertirGuide(GetAllSelectedLivres()[0]);
            _ConvertirGuide.ShowDialog();
            active.visibleForm(true);
        }

        private void BT_EditerMetadonnees_Click(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else
            {
                active.visibleForm(false);
                FRM_EditerMetadonnees _EditerMetadonnees = new FRM_EditerMetadonnees(biblio.Database, GetAllSelectedLivres()[0]);
                //FRM_EditerMetadonnees _EditerMetadonnees = new FRM_EditerMetadonnees(biblio.Database, 0);
                _EditerMetadonnees.ShowDialog();
            }

            active.visibleForm(true);
        }

        private void BT_Visualiser_Click(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else
            {
                active.visibleForm(false);
                FRM_Visualiser _Visualiser = new FRM_Visualiser(GetAllSelectedLivres()[0]);
                _Visualiser.ShowDialog();
            }
            active.visibleForm(true);
        }

        private void BT_Editer_Click(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else if (LV_Livre.SelectedItems.Count >= 2)
            {
                FRM_TropDeFichier.FRM_TropDeFichier tr = new FRM_TropDeFichier.FRM_TropDeFichier();
                tr.ShowDialog();
            }
            else
            {
                FRM_Editer _Editer = new FRM_Editer(biblio, GetAllSelectedLivres()[0]);
                _Editer.ShowDialog();
                active.visibleForm(true);
            }
        }

        private void ClearPanel()
        {
            foreach (Panel pnl in PlOption)
                pnl.Visible = false;
        }
        private void ClearPanel(int _exeption)
        {
            for (int i = 0; i < PlOption.Length; i++)
                if (_exeption != i)
                    PlOption[i].Visible = false;
        }
        private void AfficherPanel(int index)
        {
            ClearPanel(index);
            PlOption[index].Visible = !PlOption[index].Visible;
        }
        private void PL_Button_Click(object sender, EventArgs e)
        {
            ClearPanel();
        }
        private void B_FlecheAjouter_MouseHover(object sender, EventArgs e)
        {
            AfficherPanel(0);
        }
        private void B_FlecheSupprimer_MouseHover(object sender, EventArgs e)
        {
            AfficherPanel(1);
        }
        private void B_FlecheEnregistrer_MouseHover(object sender, EventArgs e)
        {
            AfficherPanel(4);
        }
        private void BT_Devices_MouseHover(object sender, EventArgs e)
        {
            AfficherPanel(3);
        }
        private void B_FlecheEnvoiePeriph_MouseHover(object sender, EventArgs e)
        {
            AfficherPanel(2);
        }
        private void B_AjouterLivres_Click(object sender, EventArgs e)
        {
            P_Ajouter.Visible = false;
            ClassAjout.AjoutFolderUnique(biblio);
            AfficheLesEnregistrementsEpub();
        }

        private void FRM_NumeriBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.F1)
                B_FlecheAjouter_MouseHover(null, null);
            if (e.KeyCode == Keys.F2)
                BT_Editer_Click(null, null);
            if (e.KeyCode == Keys.F3)
                B_FlecheSupprimer_MouseHover(null, null);
            if (e.KeyCode == Keys.F4)
                B_FlecheEnregistrer_MouseHover(null, null);
        }

        private void B_AjouterLivre_Click(object sender, EventArgs e)
        {
            P_Ajouter.Visible = false;
            ClassAjout.Ajoutsimple(biblio);
            AfficheLesEnregistrementsEpub();
        }

        private void B_AjouterPlusieursLivres_Click(object sender, EventArgs e)
        {
            P_Ajouter.Visible = false;
            ClassAjout.AjoutFolder2(biblio);
            AfficheLesEnregistrementsEpub();
        }

        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
        public void SupprChoisi()
        {
            i = 0;
            try
            {
                string file, sourceDir, fileSQL;
                ListView.SelectedIndexCollection indexes = LV_Livre.SelectedIndices;
                file = cheminLivre[LV_Livre.SelectedIndices[0]];
                sourceDir = biblio.CurrentPath + "\\" + file;
                foreach (int index in indexes)
                    File.Delete(sourceDir);
                fileSQL = idLivre[LV_Livre.SelectedIndices[0]];
                biblio.Database.Requete("DELETE FROM LIVRE WHERE id_livre='" + fileSQL + "';");
                LV_Livre.Items.Clear();
                AfficheLesEnregistrementsEpub();
            }
            catch (Exception e)
            {
                FRM_Erreur continu = new FRM_Erreur();
                continu.ShowDialog();
                ExceptionHandler.ExeptionCatch(e);
            }
        }

        public void SupprTout()
        {
            i = 0;
            try
            {
                string path = biblio.CurrentPath;
                Directory.Delete(path, true);
                biblio.Database.Requete("DELETE FROM LIVRE;");
                LV_Livre.Items.Clear();
                AfficheLesEnregistrementsEpub();
            }
            catch (Exception e)
            {
                FRM_Erreur continu = new FRM_Erreur();
                continu.ShowDialog();
                ExceptionHandler.ExeptionCatch(e);
            }
        }
        public void SupprChoisiBase()
        {
            i = 0;
            try
            {
                string fileSQL = idLivre[LV_Livre.SelectedIndices[0]];
                biblio.Database.Requete("DELETE FROM LIVRE WHERE id_livre='" + fileSQL + "';");
                LV_Livre.Items.Clear();
                AfficheLesEnregistrementsEpub();
            }
            catch (Exception e)
            {
                FRM_Erreur continu = new FRM_Erreur();
                continu.ShowDialog();
                ExceptionHandler.ExeptionCatch(e);
            }
        }
        public void SupprToutBase()
        {
            i = 0;
            try
            {
                biblio.Database.Requete("DELETE FROM LIVRE;");
                LV_Livre.Items.Clear();
                AfficheLesEnregistrementsEpub();
            }
            catch (Exception e)
            {
                FRM_Erreur continu = new FRM_Erreur();
                continu.ShowDialog();
                ExceptionHandler.ExeptionCatch(e);
            }
        }
        private void B_SupprimerLivresBase_Click(object sender, EventArgs e)
        {
            P_Supprimer.Hide();
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else
            {
                i = 2;
                ConfirmationContinuation continu = new ConfirmationContinuation(this);
                continu.ShowDialog();
            }
        }

        private void B_SupprimerTouteBibliothèqueBase_Click(object sender, EventArgs e)
        {
            P_Supprimer.Hide();
            i = 3;
            ConfirmationSupprBiblio cont = new ConfirmationSupprBiblio(this);
            cont.ShowDialog();
        }

        private void B_SupprimerLivresLocal_Click(object sender, EventArgs e)
        {
            P_Supprimer.Hide();
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else
            {
                i = 1;
                ConfirmationContinuation continu = new ConfirmationContinuation(this);
                continu.ShowDialog();
            }
        }

        private void B_Ajouterdatabase_Click(object sender, EventArgs e)
        {
            P_Ajouter.Visible = false;
            ClassAjout.AjoutMultipEpub(biblio);
            AfficheLesEnregistrementsEpub();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            TXT_Mouse.Text = "X: " + e.X.ToString() + " \\ " + "Y: " + e.Y.ToString();
        }
        private void B_FlecheEnregistrer_MouseHover_1(object sender, EventArgs e)
        {
            AfficherPanel(4);
        }

        private void B_EnregistrerDossierUnique_Click(object sender, EventArgs e)
        {
            try
            {
                // L'utilisateur selectionne le chemin d'enregistrement
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                // On vérifie si le chemin choisi est bien valide
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Pour chaque item dans la listview
                    foreach (ListViewItem item in LV_Livre.Items)
                    {
                        // Chaque objet va être considerer comme selectionné
                        item.Selected = true;
                        // On récupére dans une collection indexes chaque indice de chaque item ayant été selectionné
                        ListView.SelectedIndexCollection indexes = LV_Livre.SelectedIndices;
                        // Pour chaque indice présent dans la collection indexes
                        foreach (Livres index in GetAllSelectedLivres())
                        {
                            // On vien récupéré l'ID du livre selectionné dans la ListView et son chemin_livre
                            string selected = cheminLivre[LV_Livre.SelectedIndices[0]];
                            //PPE.Chemin ch = new Chemin(selected);

                            //ch.Serialize();

                            // Récupére le chemin d'accès dans une variable string
                            string chemin = fbd.SelectedPath;

                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                            // Récupére le nom de l'auteur du livre pour nommer le dossier principale
                            string MainFolderName = "A faire";

                            //Fusionne le chemin d'accès au dossier principale dans une variable MainFolder 
                            string MainFolder = @"" + chemin + "\\" + MainFolderName;

                            //Récupére le nom du livre pour nommer le sous-dossier
                            string SubFolderName = index.titre;

                            //Fusionne le MainFolder avec le sous-dossier
                            string pathString = System.IO.Path.Combine(MainFolder, SubFolderName);
                            System.IO.Directory.CreateDirectory(pathString);

                            //Utilise toutes les variables précédemment créer pour creer les dossiers, sous dossier et les fichiers.epub
                            string path = @"" + chemin + "\\" + MainFolderName + "\\" + SubFolderName + "\\" + index.FileName + "";

                            // Si le livre existe déjà dans le chemin d'enregistrement, on affiche un message
                            if (File.Exists(path))
                            {
                                FRM_LivreExisteDeja _LivreExisteDeja = new FRM_LivreExisteDeja();
                                _LivreExisteDeja.ShowDialog();
                            }
                            else
                            {
                                // Copie du fichier source et de son contenu dans le nouveau chemin
                                string sourcefile = index.full_chemin_livre;
                                string destinationfile = @"" + path + "";
                                File.Copy(sourcefile, destinationfile);

                                // Confirmation de l'enregistrement
                                PPE.FRM_SaveConfirm saveconfirm = new PPE.FRM_SaveConfirm();
                                saveconfirm.ShowDialog();
                            }
                        }
                    }
                }
            }

            catch (Exception er)
            {
                FRM_Erreur _Erreur = new FRM_Erreur();
                _Erreur.ShowDialog();
                ExceptionHandler.ExeptionCatch(er);
            }
        }

        private void B_EnregistrerSous_Click(object sender, EventArgs e)
        {
            BT_Enregistrer_Click(null, null);
        }


        private void B_SupprimerTouteBibliothèqueLocal_Click(object sender, EventArgs e)
        {
            P_Supprimer.Hide();
            i = 4;
            ConfirmationSupprBiblio cont = new ConfirmationSupprBiblio(this);
            cont.ShowDialog();
        }
        private void BT_Supprimer_Click(object sender, EventArgs e)
        {
            if (LV_Livre.SelectedItems.Count == 0)
            {
                FRM_SelecSVP se = new FRM_SelecSVP();
                se.ShowDialog();
            }
            else
            {
                if (i != 0)
                {
                    ConfirmationContinuation continu = new ConfirmationContinuation();
                    continu.ShowDialog();
                }
            }
        }
    }
}