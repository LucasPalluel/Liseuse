using System;
using System.Windows.Forms;

namespace PPE
{
    public partial class FRM_Biblio : Form
    {
        private FRM_NumeriBook FormBase;
        private readonly Bibliotheque biblio;
        int mov;
        int movX;
        int movY;
        public FRM_Biblio(FRM_NumeriBook _base, Bibliotheque _biblio)
        {
            InitializeComponent();
            FormBase = _base;
            biblio = _biblio;
        }

        private void PL_Top_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void PL_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void PL_Top_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            if (biblio.Database != null)
            {
                FormBase.AfficheLesEnregistrementsEpub();
                this.Dispose();
            }
            else
                Application.Exit();
        }

        private void FRM_Biblio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
                RD_Option2.Checked = true;
            if (e.KeyCode == Keys.F2)
                RD_Option1.Checked = true;
            if (e.KeyCode == Keys.F3)
                RD_Option3.Checked = true;
            if (e.KeyCode == Keys.Escape)
                BTN_Exit_Click(null, null);
        }
    }
}
