using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.IO;

namespace PPE
{
    class Manuel
    {
        public ConnectSQLite Database;
        readonly string bookKobo = "Manuel utilisation Kobo.epub";
        readonly string bookNotice = "Notice utilisation Numeribook.epub";
        readonly string sourcePath = Application.StartupPath + "\\Manuel";

        public void CopyManuelEpub(ConnectSQLite _db, string targetPath)
        {
            Database = _db;
            try
            {
                BookKobo(targetPath);
                BookNotice(targetPath);
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }
        }

        public bool BookKobo(string targetPath)
        {
            bool flag = true;
            // Manuel Kobo
            string sourceFileKobo = Path.Combine(sourcePath, bookKobo), hash, id_livre, id_collect, id_editeur, id_auteur;
            FileInfo fileInfo = new FileInfo(sourceFileKobo);
            fileInfo.CopyTo(targetPath + "\\" + bookKobo);
            string destiFinal = targetPath + "\\" + bookKobo;
            hash = Hachage.FileToHashMD5(destiFinal);

            id_livre = ClassAjout.MakeID(new Random(), "L");
            id_collect = ClassAjout.MakeID(new Random(), "C");
            id_editeur = ClassAjout.MakeID(new Random(), "A");
            id_auteur = ClassAjout.MakeID(new Random(), "E");

            Database.Requete("INSERT INTO AUTEUR (id_auteur, nom_auteur, prenom_auteur) VALUES ('" + id_auteur + "', 'Rakuten Kobo', 'Rakuten Kobo')");
            Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', 'Manuel d''utilisation de Kobo Aura 2ème édition', 62, 0, '01/09/2019', '\\Manuel utilisation Kobo.epub', 'Manuel Kobo utilisateur', 0, 'fr', '" + hash + "', 44, null, null)");
            Database.Requete("INSERT INTO COLLECT (id_collect, nom_collect) VALUES ('" + id_collect + "', 'Manuel Kobo')");
            Database.Requete("INSERT INTO EDITEUR (id_editeur, nom_editeur) VALUES ('" + id_editeur + "', 'Rakuten Kobo Inc')");
            Database.Requete("INSERT INTO EDITER_LIVRE (id_editeur, id_livre, id_collect, ISBN, pays) VALUES ('" + id_editeur + "', '" + id_livre + "', '" + id_collect + "', '5215220101221', 'France')");
            Database.Requete("INSERT INTO A_ECRIT (id_livre, id_auteur) VALUES ('" + id_livre + "', '" + id_auteur + "')");

            return flag;
        }

        public void BookNotice(string targetPath)
        {
            // Notice NumeriBook
            string sourceFileNotice = Path.Combine(sourcePath, bookNotice), hash, id_livre, id_collect, id_editeur, id_auteur;
            FileInfo fileInfo = new FileInfo(sourceFileNotice);
            fileInfo.CopyTo(targetPath + "\\" + bookNotice);
            string destiFinal = targetPath + "\\" + bookNotice;
            hash = Hachage.FileToHashMD5(destiFinal);

            id_livre = ClassAjout.MakeID(new Random(), "L");
            id_collect = ClassAjout.MakeID(new Random(), "C");
            id_editeur = ClassAjout.MakeID(new Random(), "A");
            id_auteur = ClassAjout.MakeID(new Random(), "E");

            Database.Requete("INSERT INTO AUTEUR (id_auteur, nom_auteur, prenom_auteur) VALUES ('" + id_auteur + "', 'BTS SIO 2019', 'BTS SIO 2019')");
            Database.Requete("INSERT INTO LIVRE (id_livre, titre, nbpages, evaluation, datepubli, chemin_livre, description, avancement, langue, hash, id_genre, id_tomes, id_serie) VALUES ('" + id_livre + "', 'Notice d''utilisation NumeriBooK', 3, 0, '28/11/2019', '\\Notice utilisation Numeribook.epub', 'Quelle est la différence entre Windows Me et un virus  Le virus il fonctionne', 0, 'fr', '" + hash + "', 44, null, null)");
            Database.Requete("INSERT INTO COLLECT (id_collect, nom_collect) VALUES ('" + id_collect + "', 'Notice NumeriBook')");
            Database.Requete("INSERT INTO EDITEUR (id_editeur, nom_editeur) VALUES ('" + id_editeur + "', 'PPE NumeriBook')");
            Database.Requete("INSERT INTO EDITER_LIVRE (id_editeur, id_livre, id_collect, ISBN, pays) VALUES ('" + id_editeur + "', '" + id_livre + "', '" + id_collect + "', '67e0423a-de53-4903-b614-abc0b8ad97f9', 'France')");
            Database.Requete("INSERT INTO A_ECRIT (id_livre, id_auteur) VALUES ('" + id_livre + "', '" + id_auteur + "')");
            ExceptionHandler.Message("Les deux livres par défaut sont dans la base SQLite...");
        }
    }
}