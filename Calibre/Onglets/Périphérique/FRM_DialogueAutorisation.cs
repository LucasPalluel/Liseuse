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
    public partial class FRM_DialogueAutorise : Form
    {
        private char _letter;
        public FRM_DialogueAutorise() : this('?')
        {
        }

        public FRM_DialogueAutorise(char letter)
        {
            _letter = letter;
            InitializeComponent();
            LBL_Explication.Text = "Une liseuse a été détecté en " + _letter.ToString() + ". Voulez-vous l'utiliser ?";
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
