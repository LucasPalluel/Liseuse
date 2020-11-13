using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace PPE
{
    class ClassAjout
    {
        private static string destination = "";
        public ClassAjout()
        {
        }

        public static void AjoutFolderUnique(Bibliotheque biblio)
        {
            // Affiche la fenetre popup et l'explorateur de dossier
            popupnomdos pop = new popupnomdos();
            pop.ShowDialog();

            FolderBrowserDialog dos = new FolderBrowserDialog();
            dos.ShowDialog();
            if (pop.DialogResult == DialogResult.OK)
            {
                //recupérqtion du chemain du fichier
                string dirpath = dos.SelectedPath.ToString();
                destination = biblio.CurrentPath;
                if (Directory.Exists(dirpath))
                {
                    //création du dossier vers la destination
                    string z = pop.TXT_ndos.Text;
                    Directory.CreateDirectory(destination + z);
                    string[] files = Directory.GetFiles(dirpath);
                    //récupération des fichier contenue dans le dossier
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string ext = Path.GetExtension(s);
                        string destFile = System.IO.Path.Combine(destination + z, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        if (ext == ".epub")
                            AjoutEpub(s, fileName, biblio);
                    }
                }
            }
        }
        public static void AjoutFolder2(Bibliotheque biblio)
        {
            FolderBrowserDialog dos = new FolderBrowserDialog();
            dos.ShowDialog();

            // Récupération du chemin des fichier epub et ceux des sous dossiers etc..
            string path = dos.SelectedPath.ToString();
            string[] filepaths = Directory.GetFiles(path, "*.epub", SearchOption.AllDirectories);

            //Boucle qui récupère chaque fichier epub trouvé 
            foreach (string filepath in filepaths)
            {
                string FileName = Path.GetFileName(filepath);
                AjoutEpub(filepath, FileName, biblio);
            }
        }

        public static void Ajoutsimple(Bibliotheque biblio)
        {
            PATHandNAME tmp = QuelFichier();
            if (tmp != null)
                AjoutEpub(tmp, biblio);
        }
        public static PATHandNAME QuelFichier()
        {
            OpenFileDialog smd = new OpenFileDialog();
            PATHandNAME pn;
            smd.Title = "Choisissez un fichier EPUB";
            smd.Filter = "EPUB files|*.epub";
            smd.InitialDirectory = @"C:\";

            if (smd.ShowDialog() == DialogResult.OK)
                pn = new PATHandNAME(smd.FileName, smd.SafeFileName);
            else
                pn = null;
            return pn;
        }

        public static void AjoutEpub(PATHandNAME PATHNAME, Bibliotheque biblio)
        {
            AjoutEpub(PATHNAME.PATH, PATHNAME.NAME, biblio);
        }
        public static void AjoutEpub(string PATH, string FileName, Bibliotheque biblio)
        {
            string chemin = "\\" + FileName, id_livre = "", id_auteur = "", id_collect = "", id_editeur = "";
            Random rng = new Random();
            SQLiteDataReader sqldr;

            try
            {
                ClassEpubRead epubRead = new ClassEpubRead(PATH);

                string hash = Hachage.FileToHashMD5(PATH);
                sqldr = biblio.Database.Extraction("SELECT id_livre FROM LIVRE WHERE hash LIKE '" + hash + "'");

                sqldr.Read();
                if (!sqldr.IsDBNull(0))
                {
                    //MessageBox.Show("Erreur le livre existe déjà dans la base " + sqldr[0].ToString(), "Erreur Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_livre = MakeID(rng, "L"+hash.Substring(0,10));


                    //Détermination de l'id
                    //Détermination des auteurs
                    //MessageBox.Show(epubRead.auteur_prenom);
                    sqldr = biblio.Database.Extraction("SELECT id_auteur FROM auteur WHERE nom_auteur LIKE '" + epubRead.auteur + "'");
                    sqldr.Read();
                    if (!sqldr.IsDBNull(0))
                    {
                        id_auteur = (string)sqldr[0];
                    }
                    else
                    {
                        id_auteur = MakeID(rng, "A" + hash.Substring(0, 10));
                        biblio.Database.Requete("INSERT INTO AUTEUR (id_auteur, nom_auteur, prenom_auteur) VALUES ('" + id_auteur + "', '" + epubRead.auteur + "', ' ')");
                    }
                    //Determine si le livre existe déjà

                    // determine la collection
                    sqldr = biblio.Database.Extraction("SELECT id_collect, nom_collect FROM COLLECT WHERE nom_collect LIKE '" + epubRead.titre.Replace('\'', ' ') + "'");
                    sqldr.Read();
                    if (!sqldr.IsDBNull(0))
                        id_collect = (string)sqldr[0];
                    else
                    {
                        id_collect = MakeID(rng, "C" + hash.Substring(0, 10));
                        biblio.Database.Requete("INSERT INTO COLLECT (id_collect, nom_collect) VALUES ('" + id_collect + "', '" + epubRead.titre.Replace('\'', ' ') + "')");
                    }

                    //Determination de l'editeur
                    sqldr = biblio.Database.Extraction("SELECT id_editeur FROM EDITEUR WHERE nom_editeur LIKE '" + epubRead.editeur.Replace('\'', ' ') + "'");
                    sqldr.Read();
                    if (!sqldr.IsDBNull(0))
                        id_editeur = (string)sqldr[0];
                    else
                    {
                        id_editeur = MakeID(rng, "E" + hash.Substring(0, 10));
                        biblio.Database.Requete("INSERT INTO EDITEUR (id_editeur, nom_editeur) VALUES ('" + id_editeur + "', '" + epubRead.editeur.Replace('\'', ' ') + "')");

                    }

                    if (epubRead.date == null)
                    {
                        if (epubRead.descri == null)
                        {
                            biblio.Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0, 11111, '" + chemin + "', 'Pas de descri', 0, 'fr', '" + hash + "', 0, null, null )");
                        }
                        else
                        {
                            biblio.Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0, 11111, '" + chemin + "', '" + epubRead.descri.Replace('\'', ' ') + "', 0, 'fr', '" + hash + "', 0, null, null )");
                        }
                    }
                    else
                    {
                        if (epubRead.descri == null)
                        {
                            biblio.Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0,'" + epubRead.date.Replace('\'', ' ') + "', '" + chemin + "', 'Pas de descri', 0, 'fr', '" + hash + "', 0, null, null )");
                        }
                        else
                        {
                            biblio.Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0,'" + epubRead.date.Replace('\'', ' ') + "', '" + chemin + "', '" + epubRead.descri.Replace("'", "''") + "', 0, 'fr', '" + hash + "', 0, null, null )");
                        }
                    }

                    //MessageBox.Show(epubRead.date);
                    //MessageBox.Show("DESC " + epubRead.descri);

                    //Détermination des genres
                    //ExceptionHandler.Message("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0, '" + epubRead.date.Replace('\'', ' ') + "', '" + chemin + "', '" + epubRead.descri.Replace('\'', ' ') + "', 0, 'fr', '" + hash + "', 0, null, null )");
                    // revoir la requete

                    //Ajout dans la base
                    //biblio.Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', '" + epubRead.titre.Replace('\'', ' ') + "', 100, 0, '" + epubRead.date.Replace('\'', ' ') + "', '" + chemin + "', @'" + epubRead.descri.Replace('\'', ' ') + "', 0, 'fr', '" + hash + "', 0, null, null )");

                    biblio.Database.Requete("INSERT INTO EDITER_LIVRE (id_editeur, id_livre, id_collect, ISBN, pays) VALUES ('" + id_editeur + "', '" + id_livre + "', '" + id_collect + "', '" + epubRead.isbn + "', 'France')");
                    biblio.Database.Requete("INSERT INTO A_ECRIT (id_livre, id_auteur) VALUES ('" + id_livre + "', '" + id_auteur + "')");
                    File.Copy(PATH, biblio.CurrentPath + "\\" + FileName);
                }
            }
            catch (Exception exc)
            {
                ExceptionHandler.ExeptionCatch(exc);
                ExceptionHandler.Message(id_editeur + ", '" + id_livre + "', '" + id_collect + "', '" + id_auteur);
            }
        }

        public static string MakeID()
        {
            return MakeID(new Random());
        }
        public static string MakeID(Random rng, string Supp = "")
        {
            string tmp = Supp;
            tmp += DateTime.Now.ToString("yyyyMMddHHmmssf");
            tmp += rng.Next().ToString();
            return tmp;
        }
        public class PATHandNAME
        {
            public PATHandNAME(string pATH, string nAME)
            {
                PATH = pATH;
                NAME = nAME;
            }

            public string PATH { get; set; }
            public string NAME { get; set; }
        }

        public static void AjoutMultipEpub(Bibliotheque biblio)
        {
            //On vas récupérer les fichier avec des conditions
            OpenFileDialog smd = new OpenFileDialog();
            smd.Title = "Choisissez un fichier EPUB";
            smd.Filter = "EPUB files|*.epub";
            smd.Multiselect = true;
            //Validation des fichiers selectionné
            if (smd.ShowDialog() == DialogResult.OK)
            {
                //Ajout des fichier dans la base et bibliothèque
                foreach (string file in smd.FileNames)
                {
                    string filepath = smd.FileName;
                    string FileName = Path.GetFileName(file);
                    AjoutEpub(filepath, FileName, biblio);
                }
            }
        }
    }
}