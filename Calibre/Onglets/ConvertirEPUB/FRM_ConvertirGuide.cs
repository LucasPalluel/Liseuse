using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//EPUB
using VersOne.Epub;
using VersOne.Epub.Schema;
using eBdb.EpubReader;
//File
using System.IO;
using Aspose.Pdf;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

namespace PPE
{
    public partial class FRM_ConvertirGuide : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        int mov;
        int movX;
        int movY;
        Livres ch;
        public FRM_ConvertirGuide(Livres chemin)
        {
            ch = chemin;
            InitializeComponent();
            GB_meta.Visible = true;
            SelectionLivre(ch.full_chemin_livre);
        }
        private void PL_Top_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void PL_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }
        private void PL_Top_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        public void SelectionLivre(string chemin)
        {
            PB_meta.BackgroundImage = null;
            ClassEpubRead classEpubRead = new ClassEpubRead(chemin);

            CB_Auteurs.Text = classEpubRead.auteur;
            TXT_titre.Text = classEpubRead.titre;
            PB_meta.Image = classEpubRead.picture;
            CB_editeur.Text = classEpubRead.editeur;
            WB_Description.DocumentText = classEpubRead.descri;
            WB_Description2.DocumentText = classEpubRead.descri;
            TXT_titredetails.Text = classEpubRead.titre;

            FileInfo(chemin);
        }
        public void FileInfo(string cheminlivre) // ListView affiche image et du la taille d'un fichier.
        {
            LV_format.SmallImageList = null;
            LV_format.Items.Clear();
            LV_format.Columns.Clear();

            FileInfo fileInfo = new FileInfo(cheminlivre); // Info fichier
            string size = fileInfo.Length.ToString();

            LV_format.View = View.Details;
            LV_format.Columns.Add("Taille fichier");
            LV_format.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(50, 50);

            String[] paths = { };
            paths = Directory.GetFiles(Application.StartupPath + "/Resources"); // dossier image

            try
            {
                foreach (String path in paths)
                    imgs.Images.Add(System.Drawing.Image.FromFile(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LV_format.SmallImageList = imgs;
            LV_format.Items.Add("   " + ConvertisseurOct(size).ToString("0.000") + " Mo", 0);
        }

        public double ConvertisseurOct(string octet)
        {
            double SizeKo;
            double SizeMo;
            SizeKo = double.Parse(octet);
            SizeKo = SizeKo / 1024;
            SizeMo = SizeKo / 1024;
            return SizeMo;
        }

        private void ConvertPDF() //Fonction convertir epub en pdf
        {
            // ExStart:1
            // The path to the documents directory
            try
            {
                SelectionLivre(ch.full_chemin_livre);
                string chemin = ch.full_chemin_livre;

                // Source EPUB document  
                FileStream fileStream = File.OpenRead(ch.full_chemin_livre.ToString() /*+ " input.epub "*/);
                // Initialize pdfSaveOptions 
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions()
                {
                    JpegQuality = 100
                };
                // Output file path 
                string outputFile = ch.full_chemin_livre + "EPUBtoPDF_Output.pdf";
                // Convert EPUB to PDF 
                Converter.ConvertEPUB(fileStream, options, outputFile);
                // ExEnd:1
                //EXIT
                this.Close();
                MessageBox.Show("Convertion terminée");
            }
            catch (Exception e)
            {
                ExceptionHandler.ExeptionCatch(e);
            }
        }

        private void B_recherche_Click(object sender, EventArgs e)
        {
            GB_details.Visible = true;
            GB_meta.Visible = false;
        }

        private void B_annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B_Fermeture_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LV_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileInfo(openFileDialog.FileName);
        }

        private void B_meta_Click(object sender, EventArgs e)
        {
            GB_meta.Visible = true;
            GB_details.Visible = false;
        }

        private void B_convertir_Click(object sender, EventArgs e)
        {
            if (CB_formatconvertion.Text == "PDF")
                ConvertPDF();
            else
                MessageBox.Show("Format non spécifié");
        }

        private void BT_Rediriger_Click(object sender, EventArgs e)
        {
            string motclef = CB_formatconvertion.Text;
            if (motclef == "")
                MessageBox.Show("Format non spécifié");
            if (motclef == "PDF")
                System.Diagnostics.Process.Start("https://pdfcandy.com/fr/epub-to-pdf.html");
            if (motclef == "Aucun")
                System.Diagnostics.Process.Start("http://www.google.com.au/search?q=" + "Conversion Epub vers ");
        }
    }
}
