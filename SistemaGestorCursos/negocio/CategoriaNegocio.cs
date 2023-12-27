using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            var lista = new List<Categoria>();
            var datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, descripción from categoria");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    var categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["id"];
                    categoria.Descripcion = (string)datos.Lector["descripción"];

                    lista.Add(categoria);
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
