using System.Data.SQLite;

namespace PPE
{
    public class Livres
    {
        public string id_livre { get; set; }
        public string titre { get; set; }
        public int nbpages { get; set; }
        public int evaluation { get; set; }
        public string datepubli { get; set; }
        public string chemin_livre { get; set; }

        public string full_chemin_livre
        {
            get
            {
                return pathBilio + "\\" + chemin_livre;
            }
        }

        public string description { get; set; }
        public int avancement { get; set; }
        public string langue { get; set; }
        public string hash { get; set; }

        public string FileName
        {
            get
            {
                string[] tmp = full_chemin_livre.Split('\\');
                return tmp[tmp.Length - 1];
            }
        }

        private string pathBilio;

        public Livres(string _id, string _titre, int _pages, int _eval, string _date, string _chemin, string _desc, int _avancement, string _langue, string _hash, string pathtodb) : this(_id, _titre, _pages, _eval, _date, _chemin, _desc, _avancement, _langue, _hash)
        {
            pathBilio = pathtodb;
        }

        public Livres(string _id, string _titre, int _pages, int _eval, string _date, string _chemin, string _desc, int _avancement, string _langue, string _hash)
        {
            this.id_livre = _id;
            this.titre = _titre;
            this.nbpages = _pages;
            this.evaluation = _eval;
            this.datepubli = _date;
            this.chemin_livre = _chemin;
            this.description = _desc;
            this.avancement = _avancement;
            this.langue = _langue;
            this.hash = _hash;
        }
        public Livres(): this("-1", null, 0, 0, null, null, null, 0, null, null) {}

        public override string ToString()
        {
            return titre;
        }

        public static Livres IDtoLivres(Bibliotheque biblio, string id)
        {
            Livres tmp = new Livres();
            if (biblio.Database != null)
            {
                SQLiteDataReader sQ = biblio.Database.Extraction("SELECT * FROM Livre WHERE id_livre LIKE '" + id + "'");
                if (sQ.HasRows)
                {
                    sQ.Read();
                    tmp = new Livres(sQ.GetString(0), sQ.GetString(1), sQ.GetInt32(2), sQ.GetInt32(3), sQ.GetString(4), sQ.GetString(5), sQ.GetString(6), sQ.GetInt32(7), sQ.GetString(8), sQ.GetString(9));
                }
            }
            return tmp;
        }
    }
}
