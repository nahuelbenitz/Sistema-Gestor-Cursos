using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaFin { get; set; }
        public Categoria Categoria { get; set; }
        public string UrlCertificado { get; set; }
        public Emisor Emisor { get; set; }
    }
}
