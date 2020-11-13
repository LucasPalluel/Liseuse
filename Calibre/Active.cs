using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE
{
    public class Active
    {
        public bool visible { get; set; }
        public Form form { get; set; }
        public Active(bool _visible, Form _form)
        {
            visible = _visible;
            form = _form;
            //visibleForm(visible);
        }

        public Active() : this(false, null) { }

        public void visibleForm(bool active)
        {
            if (active == true)
            {
                form.Show();
            }
            else
            {
                form.Hide();
            }
        }
    }
}