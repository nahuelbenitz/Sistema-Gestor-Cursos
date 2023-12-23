using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;

namespace negocio
{
    public class CursoNegocio
    {
        public List<Curso> Listar()
        {
            List<Curso> lista = new List<Curso>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"SELECT   cur.id,cur.nombre, cur.descripcion, est.descripcion as Estado, cur.idEstado, cur.fechafin, cate.Descripción as Categoria, cur.IdCategoria, cur.urlcertificado, emi.Descripción as Emisor, cur.IdEmisor
                                        FROM Cursos cur, Categoria cate, Emisores emi, Estados est
                                        WHERE cate.Id = cur.IdCategoria 
                                        and emi.Id = cur.IdEmisor
										and est.Id = cur.idEstado
                                        and activo = 1");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.Id = (int)datos.Lector["id"];
                    curso.Nombre = (string)datos.Lector["nombre"];
                    curso.Descripcion = (string)datos.Lector["descripcion"];
                    curso.Estado = new Estado();
                    curso.Estado.Id = (int)datos.Lector["idEstado"];
                    curso.Estado.Descripcion = (string)datos.Lector["Estado"];
                    curso.FechaFin = (DateTime)datos.Lector["fechafin"];
                    curso.Categoria = new Categoria();
                    curso.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    curso.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["urlcertificado"] is DBNull))
                        curso.UrlCertificado = (string)datos.Lector["urlcertificado"];
                    curso.Emisor = new Emisor();
                    curso.Emisor.Id = (int)datos.Lector["IdEmisor"];
                    curso.Emisor.Descripcion = (string)datos.Lector["Emisor"];

                    lista.Add(curso);
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

        public List<Curso> Filtrar(string columna, string condicion)
        {
            List<Curso> lista = new List<Curso>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = $@"SELECT   cur.id,cur.nombre, cur.descripcion, est.descripcion as Estado, cur.idEstado, cur.fechafin, cate.Descripción as Categoria, cur.IdCategoria, cur.urlcertificado, emi.Descripción as Emisor, cur.IdEmisor
                                        FROM Cursos cur, Categoria cate, Emisores emi, Estados est
                                        WHERE cate.Id = cur.IdCategoria 
                                        and emi.Id = cur.IdEmisor
										and est.Id = cur.idEstado
                                        and activo = 1  
                                        and {columna} {condicion} ";


                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.Id = (int)datos.Lector["id"];
                    curso.Nombre = (string)datos.Lector["nombre"];
                    curso.Descripcion = (string)datos.Lector["descripcion"];
                    curso.Estado = new Estado();
                    curso.Estado.Id = (int)datos.Lector["idEstado"];
                    curso.Estado.Descripcion = (string)datos.Lector["Estado"];
                    curso.FechaFin = (DateTime)datos.Lector["fechafin"];
                    curso.Categoria = new Categoria();
                    curso.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    curso.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["urlcertificado"] is DBNull))
                        curso.UrlCertificado = (string)datos.Lector["urlcertificado"];
                    curso.Emisor = new Emisor();
                    curso.Emisor.Id = (int)datos.Lector["IdEmisor"];
                    curso.Emisor.Descripcion = (string)datos.Lector["Emisor"];

                    lista.Add(curso);
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

        public void Agregar(Curso curso)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"INSERT INTO Cursos (Nombre, Descripcion, idEstado, FechaFin, IdCategoria, UrlCertificado, IdEmisor, Activo)
                                          VALUES (@nombre, @descripcion, @idEstado, @fechaFin, @idCategoria, @urlCertificado, @idEmisor, 1)");
                
                datos.SetearParametros("@nombre", curso.Nombre);
                datos.SetearParametros("@descripcion", curso.Descripcion);
                datos.SetearParametros("@idEstado", curso.Estado.Id);
                datos.SetearParametros("@fechaFin", curso.FechaFin);
                datos.SetearParametros("@idCategoria", curso.Categoria.Id);
                datos.SetearParametros("@urlCertificado", curso.UrlCertificado);
                datos.SetearParametros("@idEmisor", curso.Emisor.Id);

                datos.EjecutarAccion();
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

        public void Modificar(Curso curso)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"UPDATE Cursos SET Nombre = @nombre, Descripcion = @descripcion, FechaFin = @fechaFin, IdCategoria = @idCategoria,
                                       UrlCertificado = @urlCertificado, IdEmisor = @idEmisor, idEstado = @idEstado
                                       WHERE Id = @id");
                datos.SetearParametros("@id", curso.Id);
                datos.SetearParametros("@nombre", curso.Nombre);
                datos.SetearParametros("@descripcion", curso.Descripcion);
                datos.SetearParametros("@fechaFin", curso.FechaFin);
                datos.SetearParametros("@idCategoria", curso.Categoria.Id);
                datos.SetearParametros("@urlCertificado", curso.UrlCertificado);
                datos.SetearParametros("@idEmisor", curso.Emisor.Id);
                datos.SetearParametros("@idEstado", curso.Estado.Id);

                datos.EjecutarAccion();
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE cursos set Activo = 0 where Id = @id");
                datos.SetearParametros("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
