using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using VersOne.Epub;
using VersOne.Epub.Schema;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE
{
    public partial class FRM_Visualiser : Form
    {
        public Panel[] Totor;
        private ClassEpubRead EPubReader;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private int mov, movX, movY, textSize = 12;
        private string displayText;
        int height = Screen.PrimaryScreen.Bounds.Height; //récupère la largueur et la longueur de l'écran
        int width = Screen.PrimaryScreen.Bounds.Width;
        int if_fullscreen = 0;
        readonly private Livres livre;
        private void PL_Transversale_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1; movX = e.X; movY = e.Y;
        }
        private void PL_Transversale_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void PL_Transversale_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        ///////// FORM /////////
        public FRM_Visualiser(Livres _livre)
        {
            livre = _livre;
            InitializeComponent();
            EPubReader = new ClassEpubRead(livre.full_chemin_livre);
            EpubBook epubBook = EpubReader.ReadBook(livre.full_chemin_livre);
            foreach (EpubTextContentFile textContentFile in epubBook.ReadingOrder)
            {
                string htmlContent = textContentFile.Content;
                RTB_Test.Text = htmlContent;
            }
            if_fullscreen = 0;
            displayText = RTB_Test.Text;
            WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + (WB_Pages.Width - 55) + "px; margin-left:15px; margin-right:auto;'>" + displayText + "</div></html>";
        }

        private void FRM_Visualiser_Load(object sender, EventArgs e)
        {
            if (TXT_Search.Text == "")
                TXT_Search.Text = "Recherche...";
            LBL_TitreLivre.Text += "" + EPubReader.auteur + " -  " + EPubReader.titre;
            WB_Infos.Hide();
            //WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;'>" + displayText + "</div></html>";
            RTB_FontUp.Hide(); RTB_FontDown.Hide(); RTB_Chapter.Hide(); RTB_Annot.Hide(); RTB_Infos.Hide(); RTB_FullScreen.Hide(); RTB_Print.Hide(); RTB_PageN.Hide(); RTB_PageL.Hide();
        }

        ///////// EVENT CLICK /////////

        //Réduire logiciel
        private void BT_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Fermer logiciel
        private void BT_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Passer le texte en plein écran
        private void BT_FullScreen_Click(object sender, EventArgs e)
        {
            if_fullscreen = 1;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            WB_Pages.BringToFront();
            WB_Pages.Location = new Point(0, 0);
            WB_Pages.Height = WB_Pages.Document.Window.Size.Height + height;
            WB_Pages.Width = WB_Pages.Document.Window.Size.Width + Screen.PrimaryScreen.Bounds.Width;
            textSize = 24;
            WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + (Screen.PrimaryScreen.Bounds.Width - 30) + "px; margin-left:15px; margin-right:100px;'>" + displayText + "</div></html>";
        }

        //Augmenter police
        public void BT_FontUp_Click(object sender, EventArgs e)
        {
            if (textSize <= 42)
            {
                textSize += 2;
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                }
                WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + width + "px; margin-left:15px; margin-right:auto;'>" + displayText + "</div></html>";
            }
        }

        //Réduire police
        public void BT_FontDown_Click(object sender, EventArgs e)
        {
            if (textSize >= 12)
            {
                textSize -= 2;
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                }
                WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + width + "px; margin-left:15px; margin-right:auto;'>" + displayText + "</div></html>";
            }
        }

        //Impression
        private void BT_Print_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Voulez-vous lancer l'impression ?", "Confirmation Impression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
                WB_Pages.ShowPrintDialog();
        }

        //Infos sur le livre
        private void BT_Info_Click(object sender, EventArgs e)
        {
            WB_Infos.DocumentText = "<html><body style=\"background: LightGray\" style = \"font-family:arial\"><b>Titre :</b> " + EPubReader.titre + "<br><br><b>Auteur :</b> " + EPubReader.auteur + "<br><br><b>Publié :</b> " + EPubReader.date + "<br><br><b>Langue :</b> " + EPubReader.langage + "<br><br><b>Genre :</b> " + EPubReader.genre + "<br><br><br><br>" + EPubReader.descri;
            if (WB_Infos.Visible == false)
            {
                WB_Infos.BringToFront();
                BT_Info.BackColor = Color.LightGray;
                WB_Infos.Show();
                BT_PgLeft.Hide();
                BT_PgNext.Hide();
                BT_Annotation.Enabled = false;
                BT_FontUp.Enabled = false;
                BT_FontDown.Enabled = false;
                BT_PgNext.Enabled = false;
                BT_PgLeft.Enabled = false;
            }
            else
            {
                BT_Info.BackColor = Color.White;
                WB_Infos.Hide();
                BT_PgLeft.Show();
                BT_PgNext.Show();
                BT_Annotation.Enabled = true;
                BT_FontUp.Enabled = true;
                BT_FontDown.Enabled = true;
                BT_PgNext.Enabled = true;
                BT_PgLeft.Enabled = true;
            }
        }

        //Raccourcis clavier
        private void FRM_Visualiser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                WB_Pages.Location = new Point(74, 65);
                WB_Pages.Height = 684;
                WB_Pages.Width = 559;
                WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + (WB_Pages.Width - 55) + "px; margin-left:15px; margin-right:auto;'>" + displayText + "</div></html>";
                TopMost = false;
                if (WB_Infos.Visible == true)
                {
                    WB_Infos.Visible = false;
                    BT_Info.BackColor = Color.White;
                    BT_PgLeft.Show();
                    BT_PgNext.Show();
                    BT_Annotation.Enabled = true;
                    BT_FontUp.Enabled = true;
                    BT_FontDown.Enabled = true;
                    BT_PgNext.Enabled = true;
                    BT_PgLeft.Enabled = true;
                }
                if_fullscreen = 0;
            }
            if (e.Control && (e.KeyCode == Keys.NumPad8))
            {
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                    BT_FontUp_Click(null, null);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                    BT_FontUp_Click(null, null);
                }
            }
            if (e.Control && (e.KeyCode == Keys.NumPad2))
            {
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                    BT_FontDown_Click(null, null);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                    BT_FontDown_Click(null, null);
                }
            }
        }

        private void WB_Pages_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                WB_Pages.Location = new Point(74, 65);
                WB_Pages.Height = 684;
                WB_Pages.Width = 559;
                WB_Pages.DocumentText = "<html><div style='font-size:" + textSize + "px;width:" + (WB_Pages.Width - 55) + "px; margin-left:15px; margin-right:auto;'>" + displayText + "</div></html>";
                TopMost = false;
                if (WB_Infos.Visible == true)
                {
                    WB_Infos.Visible = false;
                    BT_Info.BackColor = Color.White;
                    BT_PgLeft.Show();
                    BT_PgNext.Show();
                    BT_Annotation.Enabled = true;
                    BT_FontUp.Enabled = true;
                    BT_FontDown.Enabled = true;
                    BT_PgNext.Enabled = true;
                    BT_PgLeft.Enabled = true;
                }
                if_fullscreen = 0;
            }
            if (e.Control && (e.KeyCode == Keys.NumPad8))
            {
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                    BT_FontUp_Click(null, null);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                    BT_FontUp_Click(null, null);
                }
            }
            if (e.Control && (e.KeyCode == Keys.NumPad2))
            {
                if (if_fullscreen == 1)
                {
                    width = (Screen.PrimaryScreen.Bounds.Width - 30);
                    BT_FontDown_Click(null, null);
                }
                if (if_fullscreen == 0)
                {
                    width = (WB_Pages.Width - 55);
                    BT_FontDown_Click(null, null);
                }
            }
        }


        ///////// EVENT SOURIS /////////


        private void BT_Chapter_MouseEnter(object sender, EventArgs e)
        {
            RTB_Chapter.Show();
            RTB_Chapter.BringToFront();
        }
        private void BT_Chapter_MouseLeave(object sender, EventArgs e)
        {
            RTB_Chapter.Hide();
        }
        private void BT_Annotation_MouseEnter(object sender, EventArgs e)
        {
            RTB_Annot.Show();
            RTB_Annot.BringToFront();
        }
        private void BT_Annotation_MouseLeave(object sender, EventArgs e)
        {
            RTB_Annot.Hide();
        }
        private void BT_Info_MouseEnter(object sender, EventArgs e)
        {
            RTB_Infos.Show();
            RTB_Infos.BringToFront();
        }
        private void BT_Info_MouseLeave(object sender, EventArgs e)
        {
            RTB_Infos.Hide();
        }
        private void BT_FullScreen_MouseEnter(object sender, EventArgs e)
        {
            RTB_FullScreen.Show();
            RTB_FullScreen.BringToFront();
        }
        private void BT_FullScreen_MouseLeave(object sender, EventArgs e)
        {
            RTB_FullScreen.Hide();
        }
        private void BT_Print_MouseEnter(object sender, EventArgs e)
        {
            RTB_Print.Show();
            RTB_Print.BringToFront();
        }
        private void BT_Print_MouseLeave(object sender, EventArgs e)
        {
            RTB_Print.Hide();
        }
        private void BT_FontUp_MouseEnter(object sender, EventArgs e)
        {
            RTB_FontUp.Show();
            RTB_FontUp.BringToFront();
        }
        private void BT_FontUp_MouseLeave(object sender, EventArgs e)
        {
            RTB_FontUp.Hide();
        }
        private void BT_FontDown_MouseEnter(object sender, EventArgs e)
        {
            RTB_FontDown.Show();
            RTB_FontDown.BringToFront();
        }
        private void BT_FontDown_MouseLeave(object sender, EventArgs e)
        {
            RTB_FontDown.Hide();
        }
        private void BT_PgLeft_MouseEnter(object sender, EventArgs e)
        {
            RTB_PageL.Show();
            RTB_PageL.BringToFront();
        }
        private void BT_PgLeft_MouseLeave(object sender, EventArgs e)
        {
            RTB_PageL.Hide();
        }
        private void BT_PgNext_MouseEnter(object sender, EventArgs e)
        {
            RTB_PageN.Show();
            RTB_PageN.BringToFront();
        }
        private void BT_PgNext_MouseLeave(object sender, EventArgs e)
        {
            RTB_PageN.Hide();
        }
    }
}