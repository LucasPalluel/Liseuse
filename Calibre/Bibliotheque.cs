using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace PPE
{
    public class Bibliotheque
    {
        public ConnectSQLite Database;
        public string CurrentPath;
        public string CurrentName;
        public List<Livres> Books = new List<Livres> { };
        private readonly XmlDocument doc = new XmlDocument();
        private FRM_Biblio Dialog;
        private FRM_NumeriBook FormBase;

        public Bibliotheque(FRM_NumeriBook _base)
        {
            LoadBiblio();
            FormBase = _base;
        }

        /// <summary>
        /// Charge les données de bibliothèque
        /// </summary>
        private void LoadBiblio()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Config.xml"))
            {
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");
                XmlNode CurrentPath = doc.SelectSingleNode("Bibliotheque/CurrentBib");
                SetCurrent(CurrentPath.InnerText, CurrentPath.Attributes["name"].Value);
            }
            else
            {
                string _path = AppDomain.CurrentDomain.BaseDirectory + "NumeriBook", _name = "NumeriBook";
                XmlDocument _doc = new XmlDocument();
                XmlNode rootNode = _doc.CreateElement("Bibliotheque");
                _doc.AppendChild(rootNode);

                XmlNode currentPath = _doc.CreateElement("CurrentBib");
                currentPath.InnerText = _path;
                XmlAttribute attr = _doc.CreateAttribute("name");
                attr.Value = _name;
                currentPath.Attributes.Append(attr);
                rootNode.AppendChild(currentPath);

                XmlNode allPaths = _doc.CreateElement("AllList");
                rootNode.AppendChild(allPaths);

                XmlNode element1 = _doc.CreateElement("Biblio");
                element1.InnerText = _path;
                element1.Attributes.Append(attr);
                allPaths.AppendChild(element1);

                _doc.Save(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");
                Directory.CreateDirectory(_path);
                Option_CreateNew(_path, _name, false);
                LoadBiblio();
            }
        }

        /// <summary>
        /// Ouvre le menu de gestion de bibliothèque
        /// </summary>
        public void OpenMenu()
        {
            Dialog = new FRM_Biblio(FormBase, this);

            Dialog.TXT_Path.Text = this.CurrentPath;
            Dialog.CB_Name.Text = this.CurrentName;

            Dialog.BTN_Confirm.Click += new EventHandler(ConfirmDialog);
            Dialog.BTN_BrowseFolder.Click += new EventHandler(OpenFolderBrowser);

            Dialog.CB_Name.Items.Clear();
            XML_CheckHistory();
            XML_LoadHistory();
            Dialog.ShowDialog();
        }

        /// <summary>
        /// Confirme l'action selectionnée dans le menu de gestion de bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmDialog(object sender, EventArgs e)
        {
            string selectedPath = Dialog.TXT_Path.Text, selectedName = Dialog.CB_Name.Text;
            if (Dialog.RD_Option1.Checked) //Basculer vers la bibliothèque
                Option_ChangeActual(selectedPath, selectedName);

            if (Dialog.RD_Option2.Checked) //Créer une nouvelle bibliothèque
                Option_CreateNew(selectedPath, selectedName, true);

            if (Dialog.RD_Option3.Checked) //Déplacer la bibliothèque actuelle
                Option_MoveActual(selectedPath, selectedName);
            UpdateDialog();
        }

        /// <summary>
        /// Change l'emplacement de la bibliothèque utilisée
        /// </summary>
        /// <param name="selectedPath">Chemin d'accès de la nouvelle bibliotheque</param>
        private void Option_ChangeActual(string _selectedPath, string _selectedName)
        {
            //Directory exists
            if ((Directory.Exists(_selectedPath)))
            {
                if (File.Exists(_selectedPath + "\\data.sqlite"))
                {
                    MessageBox.Show("Bibliothèque utilisée : " + _selectedPath, "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetCurrent(_selectedPath, Dialog.CB_Name.Text);
                    XML_AddToHistory(_selectedPath, _selectedName);
                }
                else
                    MessageBox.Show("Le fichier " + _selectedPath + "\\data.sqlite n'existe pas.", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Le dossier " + _selectedPath + " n'existe pas.", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Déplace l'ensemble des fichiers et sous dossiers de la bibliothèque actuelle
        /// </summary>
        /// <param name="selectedPath">Chemin de destination</param>
        private void Option_MoveActual(string _selectedPath, string _selectedName)
        {
            if ((Directory.Exists(CurrentPath)))
            {
                if (CurrentPath != _selectedPath)
                {
                    if ((Directory.Exists(_selectedPath)))
                    {
                        try
                        {
                            foreach (string dirPath in Directory.GetDirectories(CurrentPath, "*",
                            SearchOption.AllDirectories))
                                Directory.CreateDirectory(dirPath.Replace(CurrentPath, _selectedPath));
                            foreach (string newPath in Directory.GetFiles(CurrentPath, "*.*",
                                SearchOption.AllDirectories))
                                File.Copy(newPath, newPath.Replace(CurrentPath, _selectedPath), true);
                        }
                        catch (Exception e)
                        {
                            ExceptionHandler.ExeptionCatch(e);
                        }
                        SetCurrent(_selectedPath, _selectedName);
                    }
                    else
                        MessageBox.Show("Le dossier cible n'existe pas", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Cette bibliothèque est déjà active", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("La bibliothèque actuelle n'existe plus", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Créer une nouvelle bibliothèque
        /// </summary>
        /// <param name="selectedPath">Chemin de destination</param>
        private void Option_CreateNew(string _selectedPath, string _selectedName, bool _display)
        {
            Manuel manuel = new Manuel();
            if ((Directory.Exists(_selectedPath)))
            {
                if (!File.Exists(_selectedPath + "\\data.sqlite"))
                {
                    SQLiteConnection.CreateFile(_selectedPath + "\\data.sqlite");
                    Database = new ConnectSQLite(_selectedPath + "\\" + "data.sqlite");
                    Database.OuvrirBDD();
                    Database.Requete(File.ReadAllText("sqlite.sql"));
                    Database.FermerBDD();
                    if(_display)
                        MessageBox.Show("Bibliothèque créée", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetCurrent(_selectedPath, _selectedName);
                    manuel.CopyManuelEpub(Database, _selectedPath);
                }
                else
                    MessageBox.Show("Une bibliothèque existe déjà à cet emplacement", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Le dossier " + _selectedPath + " n'existe pas.", "Bibliothèque", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Met à jour le dialog de gestion de bibliothèque
        /// </summary>
        private void UpdateDialog()
        {
            Dialog.TXT_Path.Text = this.CurrentPath;
            Dialog.CB_Name.Text = this.CurrentName;
        }

        /// <summary>
        /// Redéfinie la base de donnée et l'emplacement actuel
        /// </summary>
        /// <param name="_path">Chemin de la bibliothèque</param>
        private void SetCurrent(string _path, string _name)
        {
            CurrentPath = _path;
            CurrentName = _name;
            XmlAttribute attr = doc.CreateAttribute("name");
            attr.Value = _name;
            doc.SelectSingleNode("Bibliotheque/CurrentBib").Attributes.Append(attr);
            doc.SelectSingleNode("Bibliotheque/CurrentBib").InnerText = _path;

            doc.Save("Config.xml");
            
            //Si le fichier base de donnée n'existe pas, database = null, sinon ouvre une connexion
            if (!File.Exists(_path + "\\data.sqlite"))
                Database = null;
            else
            {
                Database = new ConnectSQLite(_path + "\\data.sqlite");
                Database.OuvrirBDD();
                GetAllBooks();
            }
        }

        /// <summary>
        /// Action parcourir dans les fichiers Windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolderBrowser(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
                Dialog.TXT_Path.Text = folderDlg.SelectedPath;
        }

        /// <summary>
        /// Recharge la liste de tous les livres
        /// </summary>
        private void GetAllBooks()
        {
            SQLiteDataReader sQ = Database.Extraction("SELECT * FROM Livre");
            Livres tmp;
            Books.Clear();
            while (sQ.Read())
            {
                tmp = new Livres(sQ.GetString(0), sQ.GetString(1), sQ.GetInt32(2), sQ.GetInt32(3), sQ.GetString(4), sQ.GetString(5), sQ.GetString(6), sQ.GetInt32(7), sQ.GetString(8), sQ.GetString(9));
                Books.Add(tmp);
            }
        }

        /// <summary>
        /// Vérifie chaque chemin XML et le supprime si existe
        /// </summary>
        private void XML_CheckHistory()
        {
            XmlNodeList AllList = doc.GetElementsByTagName("Biblio");
            foreach (XmlNode node in AllList)
                if (!(Directory.Exists(node.InnerText)))
                    XML_RemoveFromHistory(node.Attributes["name"].Value);
        }

        /// <summary>
        /// Recharge la liste des bibliothèques déjà utilisées
        /// </summary>
        private void XML_LoadHistory()
        {
            XmlNodeList AllList = doc.GetElementsByTagName("Biblio");
            foreach (XmlNode node in AllList)
                Dialog.CB_Name.Items.Add(node.Attributes["name"].Value);
        }

        /// <summary>
        /// Ajoute un élément dans la liste des bibliothèques
        /// </summary>
        private void XML_AddToHistory(string _path, string _name)
        {
            bool flag = true;
            XmlNodeList AllList = doc.GetElementsByTagName("Biblio");
            foreach (XmlNode node in AllList)
                if (_path == node.InnerText)
                    flag = false;
            if (flag)
            {
                XmlNode list = doc.SelectSingleNode("Bibliotheque/AllList");
                XmlNode newNode = doc.CreateElement("Biblio");
                newNode.InnerText = _path;
                newNode.Attributes["name"].Value = _name;
                list.AppendChild(newNode);
                doc.Save("Config.xml");
            }
        }

        /// <summary>
        /// Retire un élément de la liste des bibliothèques
        /// </summary>
        private void XML_RemoveFromHistory(string _name)
        {
            XmlNodeList AllList = doc.GetElementsByTagName("Biblio");
            XmlNode list = doc.SelectSingleNode("Bibliotheque/AllList");
            foreach (XmlNode node in AllList)
                if(node.Attributes["name"].Value == _name)
                    list.RemoveChild(node);
        }

        /// <summary>
        /// Retourne le chemin de la bbiliotheque
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CurrentPath;
        }
    }
}