﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            var lista = new List<Estado>();
            var datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, descripcion from estados");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    var estado = new Estado();
                    estado.Id = (int)datos.Lector["id"];
                    estado.Descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(estado);
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
