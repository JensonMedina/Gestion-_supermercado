using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Datos
{
    public class VendedorDatos
    {
        public List<Vendedor> ListarVendedores()
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Vendedor> Lista = new List<Vendedor>();
            try
            {
                string Consulta = "select Id, Nombre, Edad, Telefono, Correo, Direccion, Contraseña from Vendedores";
                Datos.SetConsulta(Consulta);
                Datos.EjecutarLectura();
                while (Datos.lector.Read())
                {
                    Vendedor aux = new Vendedor();
                    aux.Id = (int)Datos.lector["Id"];
                    aux.Nombre = (string)Datos.lector["Nombre"];
                    aux.Edad = (int)Datos.lector["Edad"];
                    aux.Telefono = (string)Datos.lector["Telefono"];
                    aux.Correo = (string)Datos.lector["Correo"];
                    aux.Direccion = (string)Datos.lector["Direccion"];
                    aux.Contraseña = (string)Datos.lector["Contraseña"];
                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un error al ejecutar el metodo ListarVendedores", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
