using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Producto> Lista = new List<Producto>();
            try
            {
                string Consulta = "select P.Id, P.Nombre, P.Categoria IdCategoria, C.Nombre Categoria, P.Precio, P.Stock from Productos P, Categorias C where P.Categoria = C.Id";
                Datos.SetConsulta(Consulta);
                Datos.EjecutarLectura();
                while (Datos.lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)Datos.lector["Id"];
                    aux.Nombre = (string)Datos.lector["Nombre"];
                    aux.Precio = (double)Datos.lector["Precio"];
                    aux.Stock = (int)Datos.lector["Stock"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)Datos.lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)Datos.lector["Categoria"];
                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al ejecutar el metodo Listar", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public void AgregarProducto(Producto producto)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                string Consulta = "insert into Productos values (@Nombre, @Categoria, @Precio, @Stock)";
                Datos.SetConsulta(Consulta);
                Datos.SetParametros("@Nombre", producto.Nombre);
                Datos.SetParametros("@Categoria", producto.Categoria.Id);
                Datos.SetParametros("@Precio", producto.Precio);
                Datos.SetParametros("@Stock", producto.Stock);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al ejecutar el metodo Agregar Producto", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public void EditarProducto(Producto producto)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                string Consulta = "update Productos set Nombre = @Nombre, Categoria = @Categoria, Precio  = @Precio, Stock = @Stock where Id = @Id";
                Datos.SetConsulta(Consulta);
                Datos.SetParametros("@Nombre", producto.Nombre);
                Datos.SetParametros("@Categoria", producto.Categoria.Id);
                Datos.SetParametros("@Precio", producto.Precio);
                Datos.SetParametros("@Stock", producto.Stock);
                Datos.SetParametros("@Id", producto.Id);

                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al ejecutar el metodo Editar Producto", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public void EliminarProducto(int Id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                string Consulta = "delete from Productos where Id = @Id";
                Datos.SetConsulta(Consulta);
                Datos.SetParametros("@Id", Id);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al ejecutar el metodo Eliminar Producto", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
