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
    public partial class ConfirmationSupprBiblio : Form
    {

        private readonly FRM_NumeriBook _book;

        public ConfirmationSupprBiblio()
        {
            InitializeComponent();         
        }

        public ConfirmationSupprBiblio(FRM_NumeriBook book) : this()
        {
            _book = book;
        }
        private void B_Non_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void B_Oui_Click(object sender, EventArgs e)
        {            
            _book.SupprToutBase();
            this.Close();
        }

        private void B_NonLocal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void B_OuiLocal_Click(object sender, EventArgs e)
        {                    
            _book.SupprTout();
            this.Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void ConfirmationSupprBiblio_Load(object sender, EventArgs e)
        {
            //FRM_NumeriBook book = new FRM_NumeriBook();

            if (_book.i == 3)
            {
                B_Oui.Visible = true;
                B_Non.Visible = true;
            }
            if (_book.i == 4)
            {
                B_OuiLocal.Visible = true;
                B_NonLocal.Visible = true;
            }
        }
    }
}
