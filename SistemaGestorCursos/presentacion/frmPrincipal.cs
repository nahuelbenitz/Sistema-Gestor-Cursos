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
    public partial class frmPrincipal : Form
    {
        private List<Curso> listaCurso;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            CursoNegocio negocio = new CursoNegocio();
            try
            {
                listaCurso = negocio.listar();
                dgvCursos.DataSource = listaCurso;
                dgvCursos.Columns["urlcertificado"].Visible = false;
                dgvCursos.Columns["Id"].Visible = false;
                CargarImagen(listaCurso[0].UrlCertificado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            Curso seleccionado = (Curso) dgvCursos.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.UrlCertificado);
        }

        private void CargarImagen(string image)
        {
            try
            {
                pbxCertificado.Load(image);

            }
            catch (Exception ex)
            {
                pbxCertificado.Load("https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaCurso frmAltaCurso = new frmAltaCurso();
            frmAltaCurso.ShowDialog();
            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Curso seleccionado;
            seleccionado = (Curso)dgvCursos.CurrentRow.DataBoundItem;

            frmAltaCurso frmModificarCurso = new frmAltaCurso(seleccionado);
            frmModificarCurso.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CursoNegocio cursoNegocio = new CursoNegocio();
            Curso cursoSeleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad deseas eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    cursoSeleccionado = (Curso)dgvCursos.CurrentRow.DataBoundItem;

                    cursoNegocio.Eliminar(cursoSeleccionado.Id);

                    CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

   
    }
}
