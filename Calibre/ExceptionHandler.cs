using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PPE
{
    public class ExceptionHandler
    {
        const string PATH_LOG = "";

        //Methode d'écriture dans le fichier
        /// <summary>
        /// Ecrit dans le fichier log.txt une ligne comprenant l'erreur
        /// </summary>
        /// <param name="e">L'erreur</param>
        /// <param name="afficher">Si vrai afficher un MessageBox avec l'erreur inscrite</param>
        public static void ExeptionCatch(Exception e, bool afficher = false)
        {
            StreamWriter file = GetLog();
            string line = startLine() + e.Source + " : " + e.Message;

            file.WriteLine(line);
            
            if(afficher) MessageBox.Show(line);

            file.Close();
        }

        /// <summary>
        /// Ecrit dans le fichier log.txt une message
        /// </summary>
        /// <param name="message">Message écrit dans le fichier</param>
        public static void Message(string message)
        {
            StreamWriter file = GetLog();
            string line = startLine() + message;

            file.WriteLine(line);
            file.Close();
        }

        //Sous-méthode privé

        private static StreamWriter GetLog()
        {
            string PATH = Application.StartupPath + "/log.txt";
            StreamWriter file;
            if (!File.Exists(PATH))
            {
                file = new StreamWriter(PATH);
                file.WriteLine("======================================\n=         fichier de log             =\n======================================\n\nCréer le : " + DateTime.Now.ToString("G"));
                file.Close();
            }
            file = new StreamWriter(PATH, true);
            return file;
        }

        private static string startLine()
        {
            return "[" + DateTime.Now.ToString("G") + "] ";
        }
    }
}
