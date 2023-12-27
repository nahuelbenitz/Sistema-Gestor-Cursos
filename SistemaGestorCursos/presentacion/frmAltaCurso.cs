using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;


namespace presentacion
{
    public partial class frmAltaCurso : Form
    {
        private Curso curso = null;
        private OpenFileDialog archivo = null;
        public frmAltaCurso()
        {
            InitializeComponent();
            lblTituloAoM.Text = "Agregar";
        }
        public frmAltaCurso(Curso curso)
        {
            InitializeComponent();
            this.curso = curso;
            Text = "Modificar Curso";
            lblTituloAoM.Text = "Modificar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var negocio = new CursoNegocio();
            try
            {
                if (curso == null)
                    curso = new Curso();

                if(txtNombre.Text != "" && txtDescripcion.Text != "")
                {
                    curso.Nombre = txtNombre.Text;
                    curso.Descripcion = txtDescripcion.Text;
                    curso.Estado = (Estado)cboEstado.SelectedItem;
                    curso.FechaFin = dtpFecha.Value;
                    curso.Categoria = (Categoria)cboCategoria.SelectedItem;
                    curso.UrlCertificado = txtUrlCertificado.Text;
                    curso.Emisor = (Emisor)cboEmisor.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Por favor, complete todo los campos obligatorios (*)", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (curso.Id != 0)
                {
                    negocio.Modificar(curso);
                    MessageBox.Show("Modificado exitosamente!");
                }
                else
                {
                    negocio.Agregar(curso);
                    MessageBox.Show("Agregado exitosamente!");
                }

                if(archivo != null && !(txtUrlCertificado.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAltaCurso_Load(object sender, EventArgs e)
        {
            var categoriaNegocio = new CategoriaNegocio();
            var emisorNegocio = new EmisorNegocio();
            var estadoNegocio = new EstadoNegocio();
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
                    txtNombre.Text = curso.Nombre.TrimEnd();
                    txtDescripcion.Text = curso.Descripcion.TrimEnd();
                    dtpFecha.Text = curso.FechaFin.ToString();
                    txtUrlCertificado.Text = curso.UrlCertificado.TrimEnd();
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = ("jpg|*.jpg;|png|*.png");
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlCertificado.Text = archivo.FileName;
                CargarImagen(archivo.FileName);

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }
        }
    }
}
