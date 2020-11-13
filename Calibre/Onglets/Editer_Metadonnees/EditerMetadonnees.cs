using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Epub
using VersOne.Epub;
using VersOne.Epub.Schema;
using eBdb.EpubReader;
//File
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Data.SQLite;
using System.Threading;

namespace PPE
{
    public partial class FRM_EditerMetadonnees : Form
    {
        readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        readonly private ConnectSQLite Database; // Base de donnée SQLite
        private string cheminLivre;
        readonly private Livres livre;
        int mov, movX, movY;

        /// <summary>
        /// Fonction qui retourne un Tableau de TextBox
        /// </summary>
        /// <returns>texte</returns>
        public TextBox[] Texts()
        {
            TextBox[] texte = new TextBox[] { TXT_Auteurs, TXT_Titre, TXT_Séries, TXT_IBSN, TXT_LanguesBook, TXT_Pages, TXT_Progess, TXT_PublieBook, TXT_DateBook, TXT_EditeurBook };
            return texte;
        }

        public FRM_EditerMetadonnees(ConnectSQLite _db, Livres _livre)
        {
            Database = _db;
            livre = _livre;
            InitializeComponent();
            LivreAndFileMod(livre.full_chemin_livre);
            ExtractionMetadataSql(livre.id_livre);
        }

        /// <summary>
        /// Récupère les information du livre dans la base de données.
        /// </summary>
        /// <param name="idL"></param>
        public void ExtractionMetadataSql(string idL)
        {
            SQLiteDataReader sQ = Database.Extraction("SELECT L.titre, L.chemin_livre, L.nbpages, G.type_genre, L.avancement, L.description, L.datepubli FROM LIVRE AS L, GENRE AS G WHERE id_livre = '" + idL + "' AND G.id_genre = L.id_genre;");
            while (sQ.Read())
            {
                TXT_Titre.Text = sQ[0].ToString();
                cheminLivre = sQ[1].ToString();
                TXT_Pages.Text = sQ[2].ToString();
                CB_Genre.Text = sQ[3].ToString();
                TXT_Progess.Text = sQ[4].ToString();
                RTB_Text.Text = sQ[5].ToString();
                WB_text.DocumentText = "<html><body><p>" + sQ[5].ToString() + "</p></body></html>";
                TXT_DateBook.Text = sQ[6].ToString();
            }
            SQLiteDataReader reader = Database.Extraction("SELECT type_genre FROM GENRE");
            while (reader.Read())
            {
                CB_Genre.Items.Add(reader[0]);
            }
        }
        /// <summary>
        /// fonction qui converti les Octets en Mo
        /// </summary>
        /// <param name="octet"></param>
        /// <returns>SizeMo</returns>
        public double ConvertisseurOct(string octet)
        {
            double SizeKo;
            double SizeMo;
            SizeKo = double.Parse(octet);
            SizeKo = SizeKo / 1024;
            SizeMo = SizeKo / 1024;
            return SizeMo;
        }
        /// <summary>
        /// ListView affiche une image du format EPUB et sur la taille fichier
        /// </summary>
        /// <param name="chemintext"></param>
        public void FileInfo(string chemintext)
        {
            LV_InfoLivreMo.SmallImageList = null;
            LV_InfoLivreMo.Items.Clear();
            LV_InfoLivreMo.Columns.Clear();

            //FileInfo fileInfo = new FileInfo(openFileDialog.FileName); // Info fichier
            FileInfo fileInfo = new FileInfo(chemintext);
            string size = fileInfo.Length.ToString();

            LV_InfoLivreMo.View = View.Details;
            LV_InfoLivreMo.Columns.Add("Taille fichier");
            LV_InfoLivreMo.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(50, 50); // dimension de l'image

            String[] paths = { };
            paths = Directory.GetFiles(Application.StartupPath + "/Resources"); // dossier de l'image du format EPUB

            try
            {
                foreach (String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ExceptionHandler.ExeptionCatch(ex);
            }

            LV_InfoLivreMo.SmallImageList = imgs;
            LV_InfoLivreMo.Items.Add("   " + ConvertisseurOct(size).ToString("0.000") + " Mo", 0);
        }
        /// <summary>
        /// Sélectionner un livre hors de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_AjoutBook_Click(object sender, EventArgs e)
        {
            TXT_Pages.Text = "";
            PICB_Couverture.Image = null;
            PICB_Couverture.BackgroundImage = null;
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "EPUB files (*.epub)";
            openFileDialog.ShowDialog();
            MessageBox.Show(openFileDialog.FileName);
            ClassEpubRead classEpubRead = new ClassEpubRead(openFileDialog.FileName);

            TXT_Auteurs.Text = classEpubRead.auteur;
            TXT_Titre.Text = classEpubRead.titre;
            PICB_Couverture.Image = classEpubRead.picture;
            CB_Genre.Text = classEpubRead.genre;
            TXT_IBSN.Text = classEpubRead.isbn;
            TXT_LanguesBook.Text = classEpubRead.langage;
            TXT_EditeurBook.Text = classEpubRead.editeur;
            TXT_DateBook.Text = classEpubRead.date;
            WB_text.DocumentText = "<html><body>" + classEpubRead.descri + "</body></html>";
            RTB_Text.Text = classEpubRead.descri;
            TXT_PublieBook.Text = classEpubRead.droits;

            FileInfo(openFileDialog.FileName);
        }
        /// <summary>
        /// fonction qui vérifie si un fichier de modification est existant
        /// </summary>
        /// <param name="chemin"></param>
        public void LivreAndFileMod(string chemin)
        {
            string cheminMod = chemin.Substring(0, chemin.Length - 4) + "opf";

            if (File.Exists(cheminMod) == true)
            {
                ReadModification(cheminMod, chemin);
            }
            else
            {
                SelectionLivre(chemin);
            }
        }
        /// <summary>
        /// lis les informations du livre qui a été sélectionné
        /// </summary>
        /// <param name="chemin"></param>
        public void SelectionLivre(string chemin)
        {
            PICB_Couverture.BackgroundImage = null;
            PICB_Couverture.Image = null;
            ClassEpubRead classEpubRead = new ClassEpubRead(chemin);

            TXT_Auteurs.Text = classEpubRead.auteur;
            //TXT_Titre.Text = classEpubRead.titre;
            PICB_Couverture.BackgroundImage = classEpubRead.picture;
            CB_Genre.Text = classEpubRead.genre;
            TXT_IBSN.Text = classEpubRead.isbn;
            TXT_LanguesBook.Text = classEpubRead.langage;
            TXT_EditeurBook.Text = classEpubRead.editeur;
            TXT_DateBook.Text = classEpubRead.date;
            //WB_text.DocumentText = "<html><body>" + classEpubRead.descri + "</body></html>";
            TXT_PublieBook.Text = classEpubRead.droits;
            //RTB_Text.Text = WB_text.DocumentText;
            FileInfo(chemin);
        }
        /// <summary>
        /// fonction qui lit le fichier binaire pour afficher les métadonnées modifier
        /// </summary>
        /// <param name="cheminMod"></param>
        /// <param name="chemin"></param>
        public void ReadModification(string cheminMod, string chemin)
        {
            int rbitsLength;
            PICB_Couverture.BackgroundImage = null;
            ClassEpubRead classEpubRead = new ClassEpubRead(chemin);
            FileStream fileStream = new FileStream(cheminMod, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            try
            {
                for (int i = 0; i < Texts().Length; i++)
                {
                    Texts()[i].Text = binaryReader.ReadString();
                }
                CB_NoteBook.Text = binaryReader.ReadString();
                WB_text.DocumentText = binaryReader.ReadString();
                rbitsLength = binaryReader.ReadInt32(); // Taille du tableau du memoryStream.GetBuffer
                if (rbitsLength == 0)
                {
                    PICB_Couverture.BackgroundImage = classEpubRead.picture;
                }
                else
                {
                    byte[] rbits = binaryReader.ReadBytes(rbitsLength); // Récupère le nombre d'octets du flux de l'image
                    MemoryStream memoryStream = new MemoryStream(rbits);
                    PICB_Couverture.Image = Image.FromStream(memoryStream); // Créer une images à partir du flux d'octets
                    memoryStream.Close();
                }
                RTB_Text.Text = WB_text.DocumentText;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Erreur" + e);
                ExceptionHandler.Message("Erreur récupération opf : " + e);
            }
            finally
            {
                fileStream.Close();
            }
        }
        void ClearTextBox(int i)
        {
            TextBox[] textBoxes = { TXT_Auteurs, TXT_Titre };
            textBoxes[i].Clear();
        }

        private void BT_ClearTitre_Click(object sender, EventArgs e)
        {
            ClearTextBox(1);
        }
        /// <summary>
        /// Supprimer le fichier EPUB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_SuppBook_Click(object sender, EventArgs e)
        {
            //File.Delete(openFileDialog.FileName);
            Database.Requete("DELETE FROM LIVRE WHERE id_livre='" + livre.id_livre + "';");
            Database.Requete("DELETE FROM EDITER_LIVRE WHERE id_livre='" + livre.id_livre + "';");
            Database.Requete("DELETE FROM A_ECRIT WHERE id_livre='" + livre.id_livre + "';");
        }

        private void LV_InfoLivreMo_MouseClick(object sender, MouseEventArgs e)
        {
            String selected = LV_InfoLivreMo.SelectedItems[0].SubItems[0].Text; // Sélection d'un item affiche texte.
            MessageBox.Show(selected);
        }
        /// <summary>
        /// Efface les textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Reset_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxesBook = new TextBox[] { TXT_Auteurs, TXT_Progess, TXT_Titre, TXT_DateBook, TXT_EditeurBook, TXT_LanguesBook, TXT_Séries };
            for (int i = 0; i < textBoxesBook.Length; i++)
            {
                textBoxesBook[i].Clear();
            }
            WB_text.DocumentText = "";
            RTB_Text.Text = "";
        }
        /// <summary>
        /// Recherhce sur internet l'auteur du livre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Auteurs_Click(object sender, EventArgs e) // recherhce de l'auteur sur internet.
        {
            string motclef;
            motclef = TXT_Auteurs.Text;
            System.Diagnostics.Process.Start("http://www.google.com.au/search?q=" + motclef + " livres");
        }
        /// <summary>
        /// Close Windows Forms et clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Close_Click(object sender, EventArgs e) // Close
        {
            for (int i = 0; i < Texts().Length; i++)
            {
                Texts()[i].Clear();
            }
            CB_Genre.Text = "";
            CB_Genre.Items.Clear();
            CB_NoteBook.Text = "";
            RTB_Text.Clear();

            this.Close();
        }
        private void PL_Border_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void PL_Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void PL_Border_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        /// <summary>
        /// fonction qui va sauvegarder les métadonnées modifier dans un fichier binaire
        /// </summary>
        public void BookModification()
        {
            string chemin = livre.full_chemin_livre.Substring(0, livre.full_chemin_livre.Length - 4) + "opf"; // Extension du fichier .opf
            FileStream fileStream = new FileStream(chemin, FileMode.Create, FileAccess.Write);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            try
            {

                for (int i = 0; i < Texts().Length; i++)
                {
                    binaryWriter.Write(Texts()[i].Text);
                }
                binaryWriter.Write(CB_NoteBook.Text);
                binaryWriter.Write(WB_text.DocumentText);
                if (PICB_Couverture.Image != null)
                {
                    PICB_Couverture.Image.Save(memoryStream, PICB_Couverture.Image.RawFormat);
                    byte[] bits = memoryStream.GetBuffer(); // Création d'un flux d'octets
                    int bitsLenght = bits.Length; // Taille du tableau du byte[] bits
                    binaryWriter.Write(bitsLenght);
                    binaryWriter.Write(bits);
                    memoryStream.Close();
                }
                else
                {
                    int bitsLenght = 0;
                    binaryWriter.Write(bitsLenght);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Erreur" + e);
                ExceptionHandler.Message("Erreur modification : " + e);
            }
            finally
            {
                fileStream.Close();
            }
        }
        /// <summary>
        /// Sérialisation et Envoie la requête UPDATE de modification des métadonnées du livre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Edit_Click(object sender, EventArgs e) // editer
        {
            int idGenre = 0, idNewGenre = 0, evaluation;
            BookModification(); // Fichier Binaire Sauvegarde

            SQLiteDataReader sQ = Database.Extraction("SELECT * FROM GENRE");
            while (sQ.Read())
            {
                if (CB_Genre.Text == sQ[1].ToString())
                {
                    idGenre = int.Parse(sQ[0].ToString());
                }
                else
                {
                    if (idNewGenre == int.Parse(sQ[0].ToString()))
                    {
                        idNewGenre = int.Parse(sQ[0].ToString()) + 1;
                        Database.Requete("INSERT INTO GENRE (id_genre, type_genre) VALUES (" + idNewGenre + ", '" + CB_Genre.Text + "')");
                    }
                }
            }
            evaluation = CB_NoteBook.Text.Length;
            Database.Requete("UPDATE LIVRE SET titre = '" + TXT_Titre.Text + "', nbpages = '" + TXT_Pages.Text + "', evaluation = " + evaluation + ", datepubli = '" + TXT_DateBook.Text + "', description = '" + RTB_Text.Text + "', avancement = '" + TXT_Progess.Text + "', langue = '" + TXT_LanguesBook.Text + "', id_genre = " + idGenre + "  WHERE id_livre = '" + livre.id_livre + "';");
            MessageBox.Show("Modifications apportées avec succès.");
        }

        private void RTB_Text_TextChanged(object sender, EventArgs e)
        {
            WB_text.DocumentText = "<html><body>" + RTB_Text.Text + "</body></html>";
        }

        private void BT_U_Click(object sender, EventArgs e)
        {
            RichtextboxBaliseHtml("<u>", "</u>");
        }

        private void BT_EditBook_Click(object sender, EventArgs e)
        {
            BT_Edit_Click(null, null);
        }

        private void BT_B_Click(object sender, EventArgs e)
        {
            RichtextboxBaliseHtml("<b>", "</b>");
        }

        private void BT_I_Click(object sender, EventArgs e)
        {
            RichtextboxBaliseHtml("<i>", "</i>");
        }
        private void BT_justifier_Click(object sender, EventArgs e)
        {
            RichtextboxBaliseHtml(" <p align='justify'>", "</p>");
        }

        private void FRM_EditerMetadonnees_Load(object sender, EventArgs e)
        {
            Bulle.SetToolTip(BT_AjoutBook, "Ajout livre");
            Bulle.SetToolTip(BT_SuppBook, "Supprimer livre");
            Bulle.SetToolTip(BT_EditBook, "Modifier les métadonnées");
        }

        private void BT_DelCover_Click(object sender, EventArgs e)
        {
            PICB_Couverture.Image = null;
            PICB_Couverture.BackgroundImage = null;
        }

        /// <summary>
        /// Choisir une image de couverture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_CoverChange_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "*.png|*.jpg";
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PICB_Couverture.BackgroundImage = null;
                PICB_Couverture.Image = Bitmap.FromFile(openFileDialog.FileName);
            }
        }
        /// <summary>
        /// Fonction qui ajout des balise html pour editer le text
        /// </summary>
        /// <param name="baliseStart"></param>
        /// <param name="baliseEnd"></param>
        private void RichtextboxBaliseHtml(string baliseStart, string baliseEnd)
        {
            int SelectStart = RTB_Text.SelectionStart; int SelectEnd = SelectStart + RTB_Text.SelectionLength;

            RTB_Text.Text = RTB_Text.Text.Insert(SelectStart, baliseStart);

            SelectEnd += baliseStart.Length;

            RTB_Text.Text = RTB_Text.Text.Insert(SelectEnd, baliseStart);
        }
    }
}