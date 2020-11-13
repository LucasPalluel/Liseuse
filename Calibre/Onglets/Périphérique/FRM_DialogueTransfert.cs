using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE
{
    public partial class FRM_DialogueTransfert : Form
    {
        public FRM_DialogueTransfert()
        {
            InitializeComponent();
            LB_Livres.Items.Add(new Liseuse.Livre("1", "file://azdoazdipazdazdopazdopazdpoa/zadazdazdazdp.epub", 'G'));
            LB_Livres.Items.Add(new Liseuse.Livre("2", "file://azdoazdipazdazdopazdopazdpoa/zadazdazdazdp.epub", 'G'));
            LB_Livres.Items.Add(new Liseuse.Livre("3", "file://azdoazdipazdazdopazdopazdpoa/zadazdazdazdp.epub", 'G'));
            LB_Livres.Items.Add(new Liseuse.Livre("4", "file://azdoazdipazdazdopazdopazdpoa/zadazdazdazdp.epub", 'G'));

        }

        public FRM_DialogueTransfert(List<Liseuse.Livre> livres)
        {
            InitializeComponent();

            foreach(Liseuse.Livre livre in livres)
            {
                LB_Livres.Items.Add(livre);
            }

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            RectangleF fond = new Rectangle(0, 0, this.Width, this.Height);
            RectangleF dessus_fond = new Rectangle(5, 20, this.Width - 10, this.Height - 40);

            e.Graphics.FillRectangle(new Pen(Color.FromArgb(241, 64, 75)).Brush, fond);
            e.Graphics.FillRectangle(Brushes.White, dessus_fond);


        }

        private void BTN_CLOSE_Click(object sender, EventArgs e)
        {

        }
    }
}
