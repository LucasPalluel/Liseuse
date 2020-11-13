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
    public partial class ConfirmationContinuation : Form
    {
        private FRM_NumeriBook _book;
        public ConfirmationContinuation()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public ConfirmationContinuation(FRM_NumeriBook book) : this()
        {
            _book = book;
        }
        private void ConfirmationContinuation_Load(object sender, EventArgs e)
        {
            if (_book.i == 2)
            {
                B_Oui.Visible = true;
                B_Non.Visible = true;
            }
            if (_book.i == 1)
            {
                B_OuiLocal.Visible = true;
                B_NonLocal.Visible = true;
            }
        }

        private void B_Non_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void B_Oui_Click(object sender, EventArgs e)
        {           
            _book.SupprChoisiBase();
            this.Close();
        }

        private void B_OuiLocal_Click(object sender, EventArgs e)
        {
            _book.SupprChoisi();
            this.Close();
        }

        private void B_NonLocal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
