using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE
{
    public partial class USRCTRL_Notification : UserControl
    {
        
        private string Notif;
        private RectangleF[] dessin = new RectangleF[]
        {
            new RectangleF(0,0,150,150),
            new RectangleF(75,0,225,150),
            new RectangleF(0,75,300,125)
        };
        public USRCTRL_Notification() : this("Aucun") { }
        public USRCTRL_Notification(string notif)
        {
            Notif = notif;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(241, 64, 75), 3);
            Pen text = new Pen(Color.FromArgb(255, 255, 255), 3);
            e.Graphics.FillEllipse(pen.Brush, dessin[0]);
            e.Graphics.FillRectangle(pen.Brush, dessin[1]);
            e.Graphics.FillRectangle(pen.Brush, dessin[2]);
            e.Graphics.DrawString(Notif,
                new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                text.Brush, new PointF(25,35));
            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
