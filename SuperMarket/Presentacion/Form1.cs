using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_MouseHover(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.Red;
            btnIngresar.Cursor = Cursors.Hand;
        }

        private void lblCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblCerrarApp_MouseHover(object sender, EventArgs e)
        {
            lblCerrarApp.Cursor = Cursors.Hand;
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.OrangeRed;
        }
    }
}
