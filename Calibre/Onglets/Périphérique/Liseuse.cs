using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PPE
{
    public class Liseuse
    {
        private const string pathtodb = @":\.kobo\KoboReader.sqlite";
        public char Lecteur { get; private set; }
        public List<Livre> Biblioteque;
        private ConnectSQLite connexionLiseuse;
        private List<string> livreEnvoyes;
        public bool IsBusy
        {
            get
            {
                return _isbusy;
            }
        }

        private bool _isbusy = false;

        public Liseuse(char lecteur)
        {
            Lecteur = lecteur;
            try
            {
                if (!LiaisonAppLiseuse.IsAReadableKobo(lecteur)) throw new Exception("Le périphérique est soit absent ou ce n'est pas une kobo");
                connexionLiseuse = new ConnectSQLite(PATHTODB());
                Biblioteque = new List<Livre>();
                livreEnvoyes = new List<string>();
                GetLivres();
            }
            catch(Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }
        }

        /// <summary>
        /// Transforme les données livres de la base de données en données de la liseuse en objet livre dans la collection de Bibliothèque
        /// </summary>
        private void GetLivres()
        {
            Livre tmp;
            try
            {
                if (connexionLiseuse.OuvrirBDD())
                {
                    _isbusy = true;
                    //Declaration et initialisation
                    FRM_LoadingLiseuse loading = new FRM_LoadingLiseuse();
                    SQLiteDataReader SQLDrLivre;

                    //Affiche la fenetre de chargement
                    loading.Show();
                    //Obtient tout les livres de la liseuse
                    SQLiteDataReader SQLDr = connexionLiseuse.Extraction(
                        "SELECT BookTitle FROM content WHERE MimeType = 'application/epub+zip' AND BookTitle IS NOT NULL GROUP BY BookTitle");

                    //Obtient le nombre de livre dans la liseuse
                    SQLDrLivre = connexionLiseuse.Extraction("SELECT COUNT(*) FROM (SELECT BookTitle FROM content WHERE MimeType = 'application/epub+zip' AND BookTitle IS NOT NULL GROUP BY BookTitle) AS LIVRE");


                    //Modifie le maximum de la progress bar
                    if (SQLDrLivre.Read())
                    {
                        loading.PB_bar.Maximum = SQLDrLivre.GetInt32(0) + 1;
                    }

                    //Retourne une erreure si la donnée n'est pas lisible
                    else
                        throw new Exception("Erreur BDD nombre de livre");

                    SQLDrLivre.Close();


                    if (SQLDr != null)
                    {
                        //Boucle d'ajout des livres
                        while(SQLDr.Read())
                        {
                            loading.pas();
                            SQLDrLivre = connexionLiseuse.Extraction("SELECT ContentID FROM content WHERE BookTitle LIKE '" + Apostrophe((string)SQLDr[0]) + "'");

                            SQLDrLivre.Read();
                            try
                            {
                                tmp = new Livre((string)SQLDr["BookTitle"], PathLivreFromID((string)SQLDrLivre["ContentID"]), Lecteur);

                                //Ajout d'un livre dans la bibliothèque
                                Biblioteque.Add(tmp);
                            }
                            catch(Exception e)
                            {
                                ExceptionHandler.Message("Erreur sur le livre : " + (string)SQLDr[0]);
                                ExceptionHandler.ExeptionCatch(e);
                            }
                            SQLDrLivre.Close();

                        }
                        SQLDr.Close();
                        
                    }
                    loading.Close();
                    connexionLiseuse.FermerBDD();
                    _isbusy = false;
                }

            }
            catch(Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }

        }

        /// <summary>
        /// Permet de gerer les appostrophe des requetes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string Apostrophe(string str)
        {
            return str.Replace("'", "''");
        }

        /// <summary>
        /// Retourne une liste des livres de la liseuse
        /// </summary>
        /// <returns></returns>
        public string ListBook()
        {
            string tmp = Biblioteque.Count.ToString() + "\n\n";
            foreach(Livre livre in Biblioteque)
            {
                tmp += livre.PATH + " : " + livre.Titre + " || " + livre.Hash  + " || " + Apostrophe(livre.Hash)+ "\n";
            }
            return tmp;
        }

        public void ListBookLog()
        {
            string List = ListBook();
            ExceptionHandler.Message(List);
        }

        /// <summary>
        /// Retourne une liste des livre contenu dans la liseuse mais non dans la bibliothèque
        /// </summary>
        /// <param name="biblio"></param>
        /// <returns></returns>
        public List<Livre> CompareLiseuse(Bibliotheque biblio)
        {
            List<Livre> tmp = new List<Livre>();
            SQLiteDataReader SQLDr;
            try
            {
                if (biblio.Database != null)
                {
                    foreach (Livre livre in Biblioteque)
                    {
                        //ExceptionHandler.Message("SELECT id_livre FROM LIVRE WHERE hash LIKE '" + Apostrophe(livre.Hash) + "';");
                        SQLDr = biblio.Database.Extraction("SELECT id_livre FROM LIVRE WHERE hash LIKE '" + livre.Hash + "';");

                        if (!SQLDr.HasRows)
                        {
                            tmp.Add(livre);
                        }
                    }
                }
                else
                    throw new Exception("Connection à la base impossible");
            }
            catch(Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }
            return tmp;
        }


        private string PathLivreFromID(string str)
        {
            return str.Split('#')[0];
        }

        /// <summary>
        /// Retourne le chemin vers la DB de la liseuse
        /// </summary>
        /// <returns></returns>
        private string PATHTODB()
        {
            return Lecteur.ToString() + pathtodb;
        }

        /// <summary>
        /// PErmet d'inserez des livres dans la liseuse
        /// </summary>
        /// <param name="livres"></param>
        /// <returns>Renvoie les livres qui ne sont pas entré dans la liseuse</returns>
        public string[] ExportLivre(Livres[] livres)
        {
            FRM_LoadingLiseuse ll = new FRM_LoadingLiseuse(livres.Length);
            ll.Phrase = "Envoie des livres vers la liseuse";
            List<string> tmp = new List<string>();
            try
            {
                ll.Show();
                foreach (Livres livre in livres)
                {
                    _isbusy = true;
                    try
                    {   
                        File.Copy(livre.full_chemin_livre, Lecteur.ToString() + @":\" + livre.FileName);
                        MessageBox.Show("fait");
                    }
                    catch(Exception e)
                    {
                        tmp.Add(livre.titre);
                        ExceptionHandler.ExeptionCatch(e);
                    }
                    ll.pas();
                }
                ll.Close();
                _isbusy = false;
            }
            catch(Exception e)
            {
                _isbusy = false;
                ExceptionHandler.ExeptionCatch(e);
            }
            return tmp.ToArray();
        }


        //Classe Livre

        public class Livre
        {
            public Livre(string titre, string pATH, char lecteur)
            {
                Titre = titre;
                PATH = getTruePath(pATH, lecteur);
                Hash = Hachage.FileToHashMD5(PATH);
                //Hash = Hachage.StringToHashMD5(PATH);
            }

            public string Titre { get; set; }
            public string PATH { get; set; }
            public string FileName
            {
                get
                {
                    return PATH.Split('\\').Last();
                }
            }
            public string Hash { get; set; }

            public override string ToString()
            {
                return Titre;
            }

            public string ToString(int i)
            {
                switch (i)
                {
                    case 1: return Titre + "      //      " + PATH + "\n" + Hash;
                    default: return ToString();    

                }
            }

            private string getTruePath(string str, char lecteur)
            {
                //"file:///mnt/onboard/"
                str = str.Remove(0, 19);
                str = str.Replace('/', '\\');
                str = lecteur + ":" + str;

                return str;


            }
        }
    }
}
