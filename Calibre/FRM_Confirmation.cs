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
    public partial class FRM_Sortie : Form
    {
        private ConnectSQLite Database;
        public FRM_Sortie(ConnectSQLite _db)
        {
            Database = _db;
            InitializeComponent();
        }
        private void B_Oui_Click(object sender, EventArgs e)
        {
            Database.FermerBDD();
            System.Environment.Exit(1);
            Application.Exit();    
        }
        private void B_Non_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }
        private void FRM_Sortie_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
