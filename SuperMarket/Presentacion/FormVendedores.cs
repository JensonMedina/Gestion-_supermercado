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
    public partial class FormVendedores : Form
    {
        List<Vendedor> ListaVendedores;
        public FormVendedores()
        {
            InitializeComponent();
        }

        private void lblCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormVendedores_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            VendedorDatos Datos = new VendedorDatos();
            try
            {
                ListaVendedores = Datos.ListarVendedores();
                dgvVendedores.DataSource = ListaVendedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos Productos = new FormProductos();
            Productos.Show();
            this.Hide();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormCategorias Categorias = new FormCategorias();
            Categorias.Show();
            this.Hide();
        }
    }
}
