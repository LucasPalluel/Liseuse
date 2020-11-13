using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.OleDb;

namespace PPE
{
    public partial class FRM_Recherhce : Form
    {
       readonly private ConnectSQLite Database;
#pragma warning disable CS0169 // Le champ 'FRM_Recherhce.biblio' n'est jamais utilisé
        private Bibliotheque biblio;
#pragma warning restore CS0169 // Le champ 'FRM_Recherhce.biblio' n'est jamais utilisé
        public List<string> ListAuteur = new List<string>();
        public List<string> ListSerie = new List<string>();
        public List<string> ListGenre = new List<string>();
        public FRM_Recherhce(ConnectSQLite _db)
        {
            Database = _db;
            InitializeComponent();
            RemplissageCBX();
            GBX_Sauvegarde.Visible = false;
            GBX_Restaurer.Visible = false;
        }

        
        private void RAZControl()
        {
            TXT_NomSauvegarde.Clear();
            TXT_Titre.Clear();
            CBX_Genre.Text = "";
            CBX_Serie.Text = "";
            CBX_Auteur.Text = "";

        }

        private void BTN_Fermer_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // La variable 'a' est assignée, mais sa valeur n'est jamais utilisée
            bool a = true;
#pragma warning restore CS0219 // La variable 'a' est assignée, mais sa valeur n'est jamais utilisée
            this.Close();
            RAZControl();
        }

        private void BTN_Cacher_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RemplissageCBX()
        {
            SQLiteDataReader sQEtiquettes = Database.Extraction("SELECT id_genre, type_genre FROM Genre ;");
            if (sQEtiquettes != null)
            {
                while (sQEtiquettes.Read())
                {
                    ListGenre.Add(sQEtiquettes[0].ToString());
                    CBX_Genre.Items.Add(sQEtiquettes[1].ToString());
                }
            }

            SQLiteDataReader sQAuteur = Database.Extraction("SELECT id_auteur, nom_auteur, prenom_auteur FROM Auteur ;");
            if (sQAuteur != null)
            {
                while (sQAuteur.Read())
                {
                    ListAuteur.Add(sQAuteur[0].ToString());
                    CBX_Auteur.Items.Add(sQAuteur[1].ToString() + " " + sQAuteur[2].ToString());
                }
            }

            SQLiteDataReader sQSerie = Database.Extraction("SELECT id_serie, nom_serie FROM Serie ;");
            if (sQSerie != null)
            {
                while (sQSerie.Read())
                {
                    ListSerie.Add(sQSerie[0].ToString());
                    CBX_Serie.Items.Add(sQSerie[1].ToString());
                }
            }
        }

        private void CBX_Auteur_KeyPress(object sender, KeyPressEventArgs e)
        {
            interdireEcriture(sender, e);
        }

        private void CBX_Serie_KeyPress(object sender, KeyPressEventArgs e)
        {
            interdireEcriture(sender, e);
        }

        private void CBX_Etiquettes_KeyPress(object sender, KeyPressEventArgs e)
        {
            interdireEcriture(sender, e);
        }

        private void interdireEcriture(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch) || (!Char.IsDigit(ch)))            //Bloque toutes saisies de tout caractère dans le comboBox
            {
                e.Handled = true;
            }
        }

        private void BTN_Rechercher_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // La variable 'a' est assignée, mais sa valeur n'est jamais utilisée
            bool a = true;
#pragma warning restore CS0219 // La variable 'a' est assignée, mais sa valeur n'est jamais utilisée
            this.Close();
        }

        private void BTN_Sauvegarder_Click_1(object sender, EventArgs e)
        {
            GBX_Restaurer.Visible = false;
            GBX_Sauvegarde.Visible = true;
            GBX_TitreAuteurSérieEtiquettes.Visible = false;
        }

        private void BTN_Annuler_Click(object sender, EventArgs e)
        {
            affichageTitreAuteurSerieEtiquette();
        }

        public string ResultatRecherche()
        {
            string WHERE = "";
            if (TXT_Titre.Text.Length != 0)
            {
                string titreRecherche = TXT_Titre.Text;
                WHERE = WHERE + "AND L.titre Like '%" + titreRecherche + "%' ";
            }
            if (CBX_Auteur.Text != "")
            {
                string Auteur = ListAuteur[CBX_Auteur.SelectedIndex];
                WHERE = WHERE + "AND A.id_auteur = " + Auteur + " ";
            }
            if (CBX_Genre.Text != "")
            {
                string Genre = ListGenre[CBX_Genre.SelectedIndex];
                WHERE = WHERE + "AND G.id_genre = " + Genre + " ";
            }
            if (CBX_Serie.Text != "")
            {
                string Serie = ListSerie[CBX_Serie.SelectedIndex];
                WHERE = WHERE + " AND S.id_serie = " + Serie + " ";
            }
            MessageBox.Show(WHERE);
            return WHERE;
        }

        private void BTN_SauvegarderFinal_Click(object sender, EventArgs e)
        {
            Encoding encoding = Encoding.ASCII;
            string _where = ResultatRecherche();
            string INSERT_INTO_VALUES = "'" + TXT_NomSauvegarde.Text + "'";
            string INSERT_INTO_COLUMN = "nomWhere";

            if (TXT_Titre.Text.Length != 0)
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", '" + TXT_Titre.Text + "'";
                INSERT_INTO_COLUMN = INSERT_INTO_COLUMN + ", titreWhere";
            }/*
            else
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", ";
            }*/

            if (CBX_Auteur.Text != "")
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", '" + ListAuteur[CBX_Auteur.SelectedIndex] + "'";
                INSERT_INTO_COLUMN = INSERT_INTO_COLUMN + ", idAuteurWhere";
                //MessageBox.Show("TestAuteurPlein");
            }/*
            else
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", ''";
                //MessageBox.Show("TestAuteurVide");
            }*/

            if (CBX_Genre.Text != "")
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", " + ListGenre[CBX_Genre.SelectedIndex];
                INSERT_INTO_COLUMN = INSERT_INTO_COLUMN + ", idGenreWhere";
                //MessageBox.Show("TestGenrePlein");
            }/*
            else
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", -1";
                //MessageBox.Show("TestGenreVide");
            }*/

            if (CBX_Serie.Text != "")
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", " + ListSerie[CBX_Serie.SelectedIndex];
                INSERT_INTO_COLUMN = INSERT_INTO_COLUMN + ", idSerieWhere";
                //MessageBox.Show("TestSeriePlein");
            }/*
            else
            {
                INSERT_INTO_VALUES = INSERT_INTO_VALUES + ", -1";
                //MessageBox.Show("TestSerieVide");
            }*/

            //MessageBox.Show("INSERT INTO SauvegardeRecherche ( " + INSERT_INTO_COL + " ) VALUES ( " + INSERT_INTO_VALUES + ")");
            Database.Requete("INSERT INTO SauvegardeRecherche ( " + INSERT_INTO_COLUMN + " ) VALUES ( " + INSERT_INTO_VALUES + ")");
            RAZControl();
            affichageTitreAuteurSerieEtiquette();
        }

        private void BTN_Restaurer_Click(object sender, EventArgs e)
        {
            string WHERE = "";
            GBX_Restaurer.Visible = true;
            AfficheLesRecherches(WHERE);
            GBX_Sauvegarde.Visible = false;
            GBX_TitreAuteurSérieEtiquettes.Visible = false;
        }

        public void AfficheLesRecherches(string WHERE = "")
        {
            LV_AncienWhere.Items.Clear();
            //SQLiteDataReader sQ = Database.Extraction("SELECT  L.titre, A.nom_auteur, A.prenom_auteur, S.nom_serie, G.type_genre FROM Livre AS L, Auteur AS A, Genre AS G, Serie AS S WHERE G.id_genre = L.id_genre AND S.id_serie = L.id_serie " + WHERE );
            string auteur = "";
            string serie = "";
            string genre = "";
            SQLiteDataReader sQ = Database.Extraction("SELECT S.idWhere, S.nomWhere, S.titreWhere, S.idAuteurWhere, S.idSerieWhere, S.idGenreWhere FROM SauvegardeRecherche AS S " + WHERE);
            ListViewItem items = new ListViewItem();
            if (sQ != null)
            {
                while (sQ.Read())
                {
#pragma warning disable CS0252 // Possibilité d'une comparaison de références involontaire ; pour obtenir une comparaison de valeurs, effectuez un cast de la partie gauche en type 'string'
                    if (sQ[3] != "")
#pragma warning restore CS0252 // Possibilité d'une comparaison de références involontaire ; pour obtenir une comparaison de valeurs, effectuez un cast de la partie gauche en type 'string'
                    {
                        SQLiteDataReader sQauteur = Database.Extraction("SELECT A.nom_auteur, A.prenom_auteur FROM Auteur AS A WHERE A.id_auteur = '" + sQ[3] + "'");
                        auteur = sQauteur[0].ToString() + " " + sQauteur[1].ToString();
                    }
                    if (!sQ.IsDBNull(4))
                    {
                        MessageBox.Show(sQ[4].ToString());
                        SQLiteDataReader sQserie = Database.Extraction("SELECT S.nom_serie FROM Serie AS S WHERE S.id_serie = " + sQ[4]);
                        serie = sQserie[0].ToString();
                    }
                    if (!sQ.IsDBNull(5))
                    {
                        SQLiteDataReader sQgenre = Database.Extraction("SELECT G.type_genre FROM Genre AS G WHERE G.id_genre = " + sQ[5]);
                        genre = sQgenre[0].ToString();
                    }
                    items = new ListViewItem(new[] { sQ[0].ToString(), sQ[1].ToString(), sQ[2].ToString(), auteur, serie, genre });
                    LV_AncienWhere.Items.Add(items);
                    auteur = "";
                    serie = "";
                    genre = "";
                }
            }
        }

        private void TXT_Recherche_TextChanged(object sender, EventArgs e)
        {
            string WHERE = "WHERE S.nomWhere LIKE '%" + TXT_Recherche.Text + "%'";

            AfficheLesRecherches(WHERE);
        }

        private void BTN_AnnulerRestaurer_Click(object sender, EventArgs e)
        {
            affichageTitreAuteurSerieEtiquette();
        }

        private void affichageTitreAuteurSerieEtiquette()
        {
            GBX_Restaurer.Visible = false;
            GBX_Sauvegarde.Visible = false;
            GBX_TitreAuteurSérieEtiquettes.Visible = true;
        }

        private void LV_AncienWhere_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RAZControl();
            string idWhere = LV_AncienWhere.SelectedItems[0].Text;
            SQLiteDataReader sQ = Database.Extraction("SELECT S.titreWhere, S.idAuteurWhere, S.idSerieWhere, S.idGenreWhere FROM SauvegardeRecherche AS S WHERE idWhere = " + idWhere );
            if (sQ != null)
            {
                TXT_Titre.Text = sQ[0].ToString();
#pragma warning disable CS0252 // Possibilité d'une comparaison de références involontaire ; pour obtenir une comparaison de valeurs, effectuez un cast de la partie gauche en type 'string'
                if (sQ[1] != "")
#pragma warning restore CS0252 // Possibilité d'une comparaison de références involontaire ; pour obtenir une comparaison de valeurs, effectuez un cast de la partie gauche en type 'string'
                {
                    string idAuteur = sQ[1].ToString();
                    int ComboAuteur = BalayageList("a", idAuteur);
                    CBX_Auteur.SelectedIndex = ComboAuteur;
                }
                if (!sQ.IsDBNull(2))
                {
                    MessageBox.Show(sQ[2].ToString());
                    string idSerie = sQ[2].ToString();
                    int ComboSerie = BalayageList("s", idSerie);
                    CBX_Serie.SelectedIndex = ComboSerie;
                }
                if (!sQ.IsDBNull(3))
                {
                    string idGenre = sQ[3].ToString();
                    int ComboGenre = BalayageList("g", idGenre);
                    CBX_Genre.SelectedIndex = ComboGenre;
                }
                affichageTitreAuteurSerieEtiquette();
            }
        }

        private int BalayageList(string List, string id)
        {
            int ComboId = 0;
            int iteration = 0; 

            switch (List)
            {
                case "a":
                    foreach(string i in ListAuteur)
                    {
                        if (id == i)
                        {
                            ComboId = iteration;
                            break;
                        }
                        else
                        {
                            iteration++;
                        }
                    }
                    break;

                case "g":
                    foreach (string i in ListGenre)
                    {
                        if (id == i)
                        {
                            ComboId = iteration;
                            break;
                        }
                        else
                        {
                            iteration++;
                        }
                    }
                    break;

                case "s":
                    foreach (string i in ListSerie)
                    {
                        if (id == i)
                        {
                            ComboId = iteration;
                            break;
                        }
                        else
                        {
                            iteration++;
                        }
                    }
                    break;
            }

            return ComboId;
        }

        private void BTN_RAZ_Click(object sender, EventArgs e)
        {
            RAZControl();
        }

        private void BTN_Suppr_Click(object sender, EventArgs e)
        {
            if (LV_AncienWhere.SelectedItems.ToString() != "-1")
            {
                string idWhere = LV_AncienWhere.SelectedItems[0].Text;
                SQLiteDataReader sQ = Database.Extraction("DELETE FROM SauvegardeRecherche WHERE idWhere = " + idWhere);
                AfficheLesRecherches();
            }
        }
    }
}
