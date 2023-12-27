using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmisorNegocio
    {
        public List<Emisor> listar()
        {
            var lista = new List<Emisor>();
            var datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, descripción from Emisores");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    var emisor = new Emisor();
                    emisor.Id = (int)datos.Lector["id"];
                    emisor.Descripcion = (string)datos.Lector["descripción"];

                    lista.Add(emisor);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
