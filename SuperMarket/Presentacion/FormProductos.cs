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
    public partial class FormProductos : Form
    {
        List<Producto> ListaProductos;
        List<Categoria> ListaCategoria;
        private Producto producto = null;
        public FormProductos()
        {
            InitializeComponent();
        }

        private void lblCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

            Cargar();
            CargarComboBox();
            CargarCboFiltro();
            LimpiarCampos();
        }

        private void CargarComboBox()
        {
            CategoriaDatos Datos = new CategoriaDatos();
            try
            {
                ListaCategoria = Datos.ListarCategorias();
                cboCategoria.DataSource = ListaCategoria;
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Cargar()
        {
            ProductoDatos Datos = new ProductoDatos();
            try
            {
                ListaProductos = Datos.ListarProductos();
                dgvProductos.DataSource = ListaProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FormVendedores Vendedores = new FormVendedores();
            Vendedores.Show();
            this.Hide();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormCategorias Categorias = new FormCategorias();
            Categorias.Show();
            this.Hide();
        }

        private void CargarCboFiltro()
        {
            CategoriaDatos Datos = new CategoriaDatos();
            try
            {
                ListaCategoria = Datos.ListarCategorias();
                cboCategoriasFiltro.DataSource = ListaCategoria;
                cboCategoriasFiltro.DisplayMember = "Nombre";
                cboCategoriasFiltro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cboCategoriasFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Producto> ListaFiltrada;
            String Filtro = "";
            if (cboCategoriasFiltro.SelectedIndex >= 0)
                Filtro = cboCategoriasFiltro.SelectedItem.ToString();

            if (Filtro.Length >= 3)
                ListaFiltrada = ListaProductos.FindAll(x => x.Categoria.Nombre != null && x.Categoria.Nombre.ToUpper().Contains(Filtro.ToUpper()));
            else
                ListaFiltrada = ListaProductos;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = ListaFiltrada;
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();
            cboCategoriasFiltro.SelectedIndex = -1;
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            cboCategoria.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoDatos Datos = new ProductoDatos();
            try
            {
                Producto producto = new Producto();
                producto.Nombre = txtNombre.Text;
                producto.Categoria = (Categoria)cboCategoria.SelectedItem;
                producto.Precio = double.Parse(txtPrecio.Text);
                producto.Stock = int.Parse(txtStock.Text);
                if(ValidarCampos(producto.Nombre, producto.Categoria, producto.Precio, producto.Stock))
                {
                    Datos.AgregarProducto(producto);
                    MessageBox.Show("Producto agregado exitosamente");
                    Cargar();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool ValidarCampos(string Nombre, Categoria categoria, double precio, int stock )
        {
            if(Nombre == null || Nombre == "" || categoria == null || precio < 0 || precio == 0 || stock < 0 || stock == 0)
            {
                return false;
            }
            return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProductoDatos Datos = new ProductoDatos();
            try
            {
                Producto productoSeleccionado;
                productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                this.producto = productoSeleccionado;
                producto.Nombre = txtNombre.Text;
                producto.Categoria = (Categoria)cboCategoria.SelectedItem;
                producto.Precio = double.Parse(txtPrecio.Text);
                producto.Stock = int.Parse(txtStock.Text);
                Datos.EditarProducto(producto);
                MessageBox.Show("Producto editado exitosamente");
                Cargar();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Producto producto;
            try
            {
                if (dgvProductos.CurrentRow != null)
                {
                    producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                    txtNombre.Text = producto.Nombre;
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Nombre";
                    cboCategoria.SelectedValue = producto.Categoria.Id;
                    txtPrecio.Text = producto.Precio.ToString();
                    txtStock.Text = producto.Stock.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoDatos Datos = new ProductoDatos();
            try
            {
                Producto producto;
                producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                if(!(txtNombre.Text == null || txtNombre.Text == ""))
                {
                    DialogResult Resultado = MessageBox.Show("¿Esta seguro que quiere eliminar ? ", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (Resultado == DialogResult.Yes)
                    {
                        Datos.EliminarProducto(producto.Id);
                        MessageBox.Show("Producto eliminado exitosamente");
                        Cargar();
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
