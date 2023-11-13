using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Datos
{
    public class CategoriaDatos
    {
        public List<Categoria> ListarCategorias()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Categoria> Lista = new List<Categoria>();
            try
            {
                string Consulta = "select Id, Nombre, Descripcion from Categorias";
                Datos.SetConsulta(Consulta);
                Datos.EjecutarLectura();
                while (Datos.lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)Datos.lector["Id"];
                    aux.Nombre = (string)Datos.lector["Nombre"];
                    aux.Descripcion = (string)Datos.lector["Descripcion"];
                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al ejecutar el metodo ListarCategorias", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
