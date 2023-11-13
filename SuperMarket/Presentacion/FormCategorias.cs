using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FormCategorias : Form
    {
        List<Categoria> ListaCategorias;
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            CategoriaDatos Datos = new CategoriaDatos();
            try
            {
                ListaCategorias = Datos.ListarCategorias();
                dgvCategorias.DataSource = ListaCategorias;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void lblCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos Productos = new FormProductos();
            Productos.Show();
            this.Hide();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FormVendedores Vendedores = new FormVendedores();
            Vendedores.Show();
            this.Hide();
        }
    }
}
