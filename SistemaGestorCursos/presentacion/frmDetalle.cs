using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalle : Form
    {

        private Curso curso = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Curso curso)
        {
            InitializeComponent();
            this.curso = curso;
            Text = "Ver detalle del Curso";
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            EmisorNegocio emisorNegocio = new EmisorNegocio();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            try
            {
                if (curso != null)
                {
                    txtNombreDetalle.Text = curso.Nombre.TrimEnd();
                    txtDescripcionDetalle.Text = curso.Descripcion.TrimEnd();
                    txtFechaFin.Text = curso.FechaFin.ToString("D").TrimEnd();
                    txtUrlCertificadoDetalle.Text = curso.UrlCertificado.TrimEnd();
                    CargarImagen(curso.UrlCertificado);
                    txtEstado.Text = curso.Estado.Descripcion.TrimEnd();
                    txtCategoria.Text = curso.Categoria.Descripcion.TrimEnd();
                    txtEmisor.Text = curso.Emisor.Descripcion.TrimEnd();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarImagen(string image)
        {
            try
            {
                pbxAltaCertificadoDetalle.Load(image);

            }
            catch (Exception ex)
            {
                pbxAltaCertificadoDetalle.Load("https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
