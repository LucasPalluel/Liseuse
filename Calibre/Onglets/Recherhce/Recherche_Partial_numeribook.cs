using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PPE
{
    partial class FRM_NumeriBook
    {

        public void AfficheLesEnregistrementsEpub(string WHERE = "")
        {
            if (biblio.Database != null)
            {
                LV_Livre.Items.Clear();
                cheminLivre.Clear();
                SQLiteDataReader sQ = biblio.Database.Extraction("SELECT A.nom_auteur, A.prenom_auteur, L.titre, L.datepubli, L.nbpages, E.nom_editeur, G.type_genre, L.chemin_livre, L.id_livre FROM Livre AS L, A_Ecrit AS AE, Auteur AS A, Editeur AS E, Editer_Livre AS EL, Collect AS C, Genre AS G WHERE AE.id_auteur = A.id_auteur AND AE.id_livre = L.id_livre AND EL.id_editeur = E.id_editeur AND EL.id_collect = C.id_collect AND EL.id_livre = L.id_livre AND G.id_genre = L.id_genre " + WHERE + ";");
                ListViewItem items = new ListViewItem();
                if (sQ != null)
                {
                    while (sQ.Read())
                    {
                        items = new ListViewItem(new[] { cheminLivre.Count.ToString(), sQ[0].ToString() + " " + sQ[1].ToString(), sQ[2].ToString(), sQ[3].ToString(), sQ[4].ToString(), sQ[5].ToString(), sQ[6].ToString() });
                        //cheminLivre.Add(sQ[7].ToString());
                        items.Tag = new Livres((string)sQ[8], (string)sQ[2], 0, 0, "", (string)sQ[7], "", 0, "", "", biblio.CurrentPath);
                        LV_Livre.Items.Add(items);
                    }
                }
            }
            else
            {
                biblio.OpenMenu();
            }
        }

        private string ResultatRecherche(FRM_Recherhce Recherche)
        {
            string WHERE = "";

            if (Recherche.TXT_Titre.Text.Length != 0)
            {
                string titreRecherche = Recherche.TXT_Titre.Text;
                WHERE = WHERE + "AND L.titre Like '%" + titreRecherche + "%' ";
            }

            if(Recherche.CBX_Auteur.Text != "")
            {
                string Auteur = Recherche.ListAuteur[Recherche.CBX_Auteur.SelectedIndex];
                //MessageBox.Show(Auteur + " | " + Auteur.Length);
                WHERE = WHERE + "AND A.id_auteur = '" + Auteur + "' ";
            }

            if (Recherche.CBX_Genre.Text != "")
            {
                string Genre = Recherche.ListGenre[Recherche.CBX_Genre.SelectedIndex];
                WHERE = WHERE + "AND G.id_genre = " + Genre + " ";
            }

            if (Recherche.CBX_Serie.Text != "")
            {
                string Serie = Recherche.ListSerie[Recherche.CBX_Serie.SelectedIndex];
                WHERE = WHERE + " AND S.id_serie = " + Serie + " ";
            }

            return WHERE;
        }

        private void B_ObtenirLivre_Click(object sender, EventArgs e)
        {
            Active active = new Active(false, this);
            FRM_Recherhce recherche = new FRM_Recherhce(biblio.Database);
            recherche.ShowDialog();
            active.visibleForm(true);

            if (recherche.DialogResult == DialogResult.OK)
            {
                AfficheLesEnregistrementsEpub(ResultatRecherche(recherche));
            }
        }

        private void TXT_Recherche_TextChanged(object sender, EventArgs e)
        {

            string WHERE = "AND (A.nom_auteur LIKE '%" + TXT_Recherche.Text + "%' OR A.prenom_auteur LIKE '%" + TXT_Recherche.Text + "%' OR L.titre LIKE '%" + TXT_Recherche.Text + "%' OR E.nom_editeur LIKE '%" + TXT_Recherche.Text + "%' OR G.type_genre LIKE '%" + TXT_Recherche.Text + "%')";

            AfficheLesEnregistrementsEpub(WHERE);
        }

        private void BTN_RAZ_Click(object sender, EventArgs e)
        {
            string WHERE = "";
            TXT_Recherche.Text = "";
            AfficheLesEnregistrementsEpub(WHERE);
        }

        private void B_TriA_Click(object sender, EventArgs e)
        {
            string lettre = "a";
            BTN_Lettre(lettre);
        }

        private void B_TriB_Click(object sender, EventArgs e)
        {
            string lettre = "b";
            BTN_Lettre(lettre);
        }

        private void B_TruC_Click(object sender, EventArgs e)
        {
            string lettre = "c";
            BTN_Lettre(lettre);
        }

        private void B_TriD_Click(object sender, EventArgs e)
        {
            string lettre = "d";
            BTN_Lettre(lettre);
        }

        private void B_TriE_Click(object sender, EventArgs e)
        {
            string lettre = "e";
            BTN_Lettre(lettre);
        }

        private void B_TriF_Click(object sender, EventArgs e)
        {
            string lettre = "f";
            BTN_Lettre(lettre);
        }

        private void B_TriG_Click(object sender, EventArgs e)
        {
            string lettre = "g";
            BTN_Lettre(lettre);
        }

        private void B_TriH_Click(object sender, EventArgs e)
        {
            string lettre = "h";
            BTN_Lettre(lettre);
        }

        private void B_TriI_Click(object sender, EventArgs e)
        {
            string lettre = "i";
            BTN_Lettre(lettre);
        }

        private void B_TriJ_Click(object sender, EventArgs e)
        {
            string lettre = "j";
            BTN_Lettre(lettre);
        }

        private void B_TriK_Click(object sender, EventArgs e)
        {
            string lettre = "k";
            BTN_Lettre(lettre);
        }

        private void B_TriL_Click(object sender, EventArgs e)
        {
            string lettre = "l";
            BTN_Lettre(lettre);
        }

        private void B_TriM_Click(object sender, EventArgs e)
        {
            string lettre = "m";
            BTN_Lettre(lettre);
        }

        private void B_TriN_Click(object sender, EventArgs e)
        {
            string lettre = "n";
            BTN_Lettre(lettre);
        }

        private void B_TriO_Click(object sender, EventArgs e)
        {
            string lettre = "o";
            BTN_Lettre(lettre);
        }

        private void B_TriP_Click(object sender, EventArgs e)
        {
            string lettre = "p";
            BTN_Lettre(lettre);
        }

        private void B_TriQ_Click(object sender, EventArgs e)
        {
            string lettre = "q";
            BTN_Lettre(lettre);
        }

        private void B_TriR_Click(object sender, EventArgs e)
        {
            string lettre = "r";
            BTN_Lettre(lettre);
        }

        private void B_TriS_Click(object sender, EventArgs e)
        {
            string lettre = "s";
            BTN_Lettre(lettre);
        }

        private void B_TriT_Click(object sender, EventArgs e)
        {
            string lettre = "t";
            BTN_Lettre(lettre);
        }

        private void B_TriU_Click(object sender, EventArgs e)
        {
            string lettre = "u";
            BTN_Lettre(lettre);
        }

        private void B_TriV_Click(object sender, EventArgs e)
        {
            string lettre = "v";
            BTN_Lettre(lettre);
        }

        private void B_TriW_Click(object sender, EventArgs e)
        {
            string lettre = "w";
            BTN_Lettre(lettre);
        }

        private void B_TriX_Click(object sender, EventArgs e)
        {
            string lettre = "x";
            BTN_Lettre(lettre);
        }

        private void B_TriY_Click(object sender, EventArgs e)
        {
            string lettre = "y";
            BTN_Lettre(lettre);
        }

        private void B_TriZ_Click(object sender, EventArgs e)
        {
            string lettre = "z";
            BTN_Lettre(lettre);
        }


        public void BTN_Lettre(string lettreBTN)
        {
            string WHERE;
            if (RAB_Auteur.Checked == true)
            {
                LV_Livre.Items.Clear();
                WHERE = " AND ( A.nom_auteur LIKE '" + lettreBTN + "%' OR A.prenom_auteur LIKE '" + lettreBTN + "%' ) ORDER BY A.Nom_Auteur, A.Prenom_Auteur";
                AfficheLesEnregistrementsEpub(WHERE);
            }
            else
            {
                LV_Livre.Items.Clear();
                WHERE = " AND L.titre LIKE '" + lettreBTN + "%' ORDER BY L.titre";
                AfficheLesEnregistrementsEpub(WHERE);
            }
        }

        public Livres[] GetAllSelectedLivres()
        {
            List<Livres> tmp = new List<Livres>();
            if(LV_Livre.SelectedItems.Count > 0 )
            {
                foreach(ListViewItem lvi in LV_Livre.SelectedItems)
                {
                    tmp.Add((Livres)lvi.Tag);
                }
            }

            return tmp.ToArray();
        }

        public string[] GetAllSelectedID()
        {
            List<string> tmp = new List<string>();
            if (LV_Livre.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in LV_Livre.SelectedItems)
                {
                    tmp.Add(((Livres)lvi.Tag).id_livre);
                }
            }

            return tmp.ToArray();
        }

        public string[] GetAllSelectedPath(bool full = false)
        {
            List<string> tmp = new List<string>();
            if (LV_Livre.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in LV_Livre.SelectedItems)
                {
                    if (full)
                    {
                        tmp.Add(((Livres)lvi.Tag).full_chemin_livre);
                    }
                    else
                    {
                        tmp.Add(((Livres)lvi.Tag).chemin_livre);
                    }
                }
            }

            return tmp.ToArray();
        }


    }
}
