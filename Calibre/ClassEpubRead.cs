using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersOne.Epub;
using VersOne.Epub.Schema;
using eBdb.EpubReader;
using System.IO;

namespace PPE
{
    class ClassEpubRead
    {
        public string chemin { get; set; }
        public string auteur { get; set; }
        public string auteurs { get; set; }
        public string titre { get; set; }
        public string isbn { get; set; }
        public string langage { get; set; }
        public string editeur { get; set; }
        public string genre { get; set; }
        public string descri { get; set; }
        public string date { get; set; }
        public string droits { get; set; }
        public Image picture { get; set; }
        public string auteur_nom
        {
            get
            {
                return auteur.Substring(0, auteur.Length / 2);
                

            }
        }
        public string auteur_prenom
        {
            get
            {
                return auteur.Substring(auteur.Length / 2);
            }
        }
        public ClassEpubRead(string _chemin)
        {
            chemin = _chemin;

            LireLesInfo();
        }

        public ClassEpubRead() : this("Aucun chemin") { }

        public void LireLesInfo()
        {
            EpubBook epubBook = EpubReader.ReadBook(chemin); // Lis les informations de base d'un fichier EPUB
            auteur = epubBook.Author;
            titre = epubBook.Title;
            if (epubBook.AuthorList.Count() != 0)
            {
                auteurs = epubBook.AuthorList[0];
            }
            else
            {
                auteurs = "Pas de plusieurs auteurs.";
            }

            byte[] coverImageContent = epubBook.CoverImage;
            if (coverImageContent != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(coverImageContent))
                {
                    picture = Image.FromStream(memoryStream);
                }
            }

            EpubPackage epubPackage = epubBook.Schema.Package;

            if (epubPackage.Metadata.Dates.Count() != 0)
            {
                date = epubPackage.Metadata.Dates[0].Date;
            }

            if (epubPackage.Metadata.Languages.Count() != 0)
            {
                langage = epubPackage.Metadata.Languages[0];
            }

            if (epubPackage.Metadata.Identifiers.Count() != 0)
            {
                isbn = epubPackage.Metadata.Identifiers[0].Identifier;
                //isbn = epubPackage.Metadata.Identifiers[0].Id;
            }

            if (epubPackage.Metadata.Subjects.Count() != 0)
            {
                genre = epubPackage.Metadata.Subjects[0];
            }

            if (epubPackage.Metadata.Publishers.Count() != 0)
            {
                editeur = epubPackage.Metadata.Publishers[0];
            }
            if (epubPackage.Metadata.Rights.Count() != 0)
            {
                droits = epubPackage.Metadata.Rights[0];
            }

            descri = epubPackage.Metadata.Description;
        }
    }
}
