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
    public partial class FRM_LoadingLiseuse : Form
    {

        public string Phrase = "Veuillez patienter pendant la lecture de la liseuse.";
        public FRM_LoadingLiseuse() : this(100)
        {
        }

        public FRM_LoadingLiseuse(int NB_step)
        {
            InitializeComponent();
            PB_bar.Maximum = NB_step;
        }


        //Paint le contour en rouge 
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            RectangleF fond = new Rectangle(0, 0, this.Width, this.Height);
            RectangleF dessus_fond = new Rectangle(5, 20, this.Width - 10, this.Height - 40);

            

            e.Graphics.FillRectangle(new Pen(Color.FromArgb(241, 64, 75)).Brush, fond);
            e.Graphics.FillRectangle(Brushes.White, dessus_fond);

            e.Graphics.DrawString(Phrase, new System.Drawing.Font("Microsoft Sans Serif", 11F), Brushes.Black, new System.Drawing.Point(63, 64));
        }


        //Réalise un pas et réécrit le texte d'information
        public void pas()
        {
            PB_bar.PerformStep();
        }
    }
}
