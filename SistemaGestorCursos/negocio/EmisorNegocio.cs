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
            List<Emisor> lista = new List<Emisor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, descripción from Emisores");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Emisor emisor = new Emisor();
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
