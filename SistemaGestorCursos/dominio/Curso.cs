using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        [DisplayName("Fecha de Certificado")]
        public DateTime FechaFin { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public string UrlCertificado { get; set; }
        public Emisor Emisor { get; set; }
    }
}
