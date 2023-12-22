using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace presentacion
{
    public partial class frmAltaCurso : Form
    {
        private Curso curso = null;
        public frmAltaCurso()
        {
            InitializeComponent();
        }
        public frmAltaCurso(Curso curso)
        {
            InitializeComponent();
            this.curso = curso;
            Text = "Modificar Curso";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CursoNegocio negocio = new CursoNegocio();
            try
            {
                if (curso == null)
                    curso = new Curso();
                curso.Nombre = txtNombre.Text;
                curso.Descripcion = txtDescripcion.Text;
                curso.Estado = (Estado)cboEstado.SelectedItem;
                curso.FechaFin = dtpFecha.Value;
                curso.Categoria = (Categoria)cboCategoria.SelectedItem;
                curso.UrlCertificado = txtUrlCertificado.Text;
                curso.Emisor = (Emisor)cboEmisor.SelectedItem;

                if(curso.Id != 0)
                {
                    negocio.Modificar(curso);
                    MessageBox.Show("Modificado exitosamente!");
                }
                else
                {
                    negocio.Agregar(curso);
                    MessageBox.Show("Agregado exitosamente!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAltaCurso_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            EmisorNegocio emisorNegocio = new EmisorNegocio();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            try
            {
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboEmisor.DataSource = emisorNegocio.listar();
                cboEmisor.ValueMember = "Id";
                cboEmisor.DisplayMember = "Descripcion";
                cboEstado.DataSource = estadoNegocio.listar();
                cboEstado.ValueMember = "Id";
                cboEstado.DisplayMember = "Descripcion";

                if (curso != null)
                {
                    txtNombre.Text = curso.Nombre;
                    txtDescripcion.Text = curso.Descripcion;
                    dtpFecha.Text = curso.FechaFin.ToString();
                    txtUrlCertificado.Text = curso.UrlCertificado;
                    CargarImagen(curso.UrlCertificado);
                    cboCategoria.SelectedValue = curso.Categoria.Id;
                    cboEmisor.SelectedValue = curso.Emisor.Id;
                    cboEstado.SelectedValue = curso.Estado.Id;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlCertificado_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlCertificado.Text);
        }

        private void CargarImagen(string image)
        {
            try
            {
                pbxAltaCertificado.Load(image);

            }
            catch (Exception ex)
            {
                pbxAltaCertificado.Load("https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png");
            }
        }

     
    }
}
