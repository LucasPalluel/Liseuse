using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace PPE
{
    public class ConnectSQLite
    {
         readonly private string _dbPATH;
        private SQLiteConnection connexion;

        private string Connection_str()
        {
            return "Data Source=" + _dbPATH + ";Version=3;";
        }

        public ConnectSQLite(string PATH)
        {
            _dbPATH = PATH;
            Connection();

        }

        private void Connection()
        {
            try
            {
                if (File.Exists(_dbPATH))
                    connexion = new SQLiteConnection(Connection_str());
                else
                    throw new Exception("Fichier SQLite Innexistant");
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }
        }

        /// <summary>
        /// Permet d'ouvrir la connexion avec le base de données
        /// </summary>
        /// <param name="afficherErreur">si faux l'erreur n'est pas afficher</param>
        /// <returns>Retourne l'état de la connexion</returns>
        public bool OuvrirBDD(bool afficherErreur = true)
        {
            bool flag = false;
            try
            {
                connexion.Open();
                flag = true;
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e, afficherErreur);
            }
            return flag;
        }

        /// <summary>
        /// Ferme la connexion avec le base de données
        /// </summary>
        /// <param name="afficherErreur"></param>
        public void FermerBDD(bool afficherErreur = false)
        {
            try
            {
                connexion.Close();
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e, afficherErreur);
            }
        }

        /// <summary>
        /// Extraction avec la base de données (SELECT)
        /// </summary>
        /// <param name="Requete_SQL">Chaine comprenant la requete sql</param>
        /// <param name="afficherErreur">si faux l'erreur n'est pas affichée</param>
        /// <returns></returns>
        public SQLiteDataReader Extraction(string Requete_SQL, bool afficherErreur = false)
        {
            SQLiteDataReader SQLDr = null;
            SQLiteCommand SQLCmd = new SQLiteCommand(Requete_SQL, connexion)
            {
                CommandType = System.Data.CommandType.Text
            };
            try
            {
                SQLDr = SQLCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e, afficherErreur);
            }
            return SQLDr;
        }

        /// <summary>
        /// Execute une Requete SQL (INSERT, UDATE, DELETE)
        /// </summary>
        /// <param name="Requete_SQL">Chaine comprenant la requete sql</param>
        /// <param name="afficherErreur">si faux l'erreur n'est pas affichée</param>
        /// <returns>Le nombre de ligne affectué ou -1 en cas d'erreur</returns>
        public int Requete(string Requete_SQL, bool afficherErreur = false)
        {
            int n = -1;
            SQLiteCommand SQLCmd = new SQLiteCommand(Requete_SQL, connexion)
            {
                CommandType = System.Data.CommandType.Text
            };
            try
            {
                n = SQLCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e, afficherErreur);
            }
            return n;
        }

        //Fonction static
        /// <summary>
        /// Retourne le chemin relatif par rapport au logiciel (selement accendant);
        /// </summary>
        /// <param name="cheminrelatif"></param>
        /// <returns></returns>
        public static string TrouverLeChemin(string cheminrelatif)
        {
            return Application.StartupPath + "\\" + cheminrelatif.Replace('/', '\\');
        }
    }
}
