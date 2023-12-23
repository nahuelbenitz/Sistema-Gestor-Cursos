using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            OcultarOpcionesFiltro(true);
            cboFiltro.Items.Add("");
            cboFiltro.Items.Add("Nombre");
            cboFiltro.Items.Add("Estado");
            cboFiltro.Items.Add("Fecha");
            cboFiltro.Items.Add("Categoria");
            cboFiltro.Items.Add("Emisor");
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
                listaCurso = negocio.Listar();
                dgvCursos.DataSource = listaCurso;
                OcultarColumnas();
                CargarImagen(listaCurso[0].UrlCertificado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OcultarColumnas()
        {

            dgvCursos.Columns["urlcertificado"].Visible = false;
            dgvCursos.Columns["Id"].Visible = false;
        }
        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvCursos.CurrentRow != null || dgvCursos.Rows.Count > 0)
            {
                Curso seleccionado = (Curso) dgvCursos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.UrlCertificado);
            }
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

        private void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFiltrar.Checked)
            {
                cboFiltro.SelectedIndex = 0;
                OcultarOpcionesFiltro();
                gbxFiltros.Visible = true;
            }
            else
            {
                gbxFiltros.Visible = false;
            }
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            string seleccion = cboFiltro.SelectedItem.ToString();
            switch (seleccion)
            {
                case "Nombre":
                    gbxNombre.Visible = true;
                    gbxFecha.Visible = false;
                    gbxCombos.Visible = false;
                    break;
                case "Fecha":
                    gbxFecha.Visible = true;
                    gbxNombre.Visible = false;
                    gbxCombos.Visible = false;
                    break;
                case "Estado":
                case "Categoria":
                case "Emisor":
                    gbxCombos.Visible = true;
                    gbxNombre.Visible = false;
                    gbxFecha.Visible = false;
                    CargarCombosFiltro(seleccion);
                    break;
                default:
                    OcultarOpcionesFiltro();
                    break;
            }
        }

        private void CargarCombosFiltro(string seleccion)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            EmisorNegocio emisorNegocio = new EmisorNegocio();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            switch (seleccion)
            {
                case "Estado":
                    cboFiltroFinal.DataSource = null;
                    cboFiltroFinal.DataSource = estadoNegocio.listar();
                    cboFiltroFinal.ValueMember = "Id";
                    cboFiltroFinal.DisplayMember = "Descripcion";
                    break;
                case "Categoria":
                    cboFiltroFinal.DataSource = null;
                    cboFiltroFinal.DataSource = categoriaNegocio.listar();
                    cboFiltroFinal.ValueMember = "Id";
                    cboFiltroFinal.DisplayMember = "Descripcion";
                    break;
                case "Emisor":
                    cboFiltroFinal.DataSource = null;
                    cboFiltroFinal.DataSource = emisorNegocio.listar();
                    cboFiltroFinal.ValueMember = "Id";
                    cboFiltroFinal.DisplayMember = "Descripcion";
                    break;
            }
        }

        private void OcultarOpcionesFiltro(bool principal = false)
        {
            if (principal)
            {
                gbxFiltros.Visible = false;
                gbxNombre.Visible = false;
                gbxFecha.Visible = false;
                gbxCombos.Visible = false;
            }
            else
            {
                gbxNombre.Visible = false;
                gbxFecha.Visible = false;
                gbxCombos.Visible = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CursoNegocio negocio = new CursoNegocio();
            string columna = string.Empty;
            string condicion = string.Empty;
         

            try
            {
                if(cboFiltro.SelectedIndex == 0)
                {  
                    MessageBox.Show("Por favor, seleccione una opción", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboFiltro.SelectedItem.ToString() == "Nombre")
                {
                    columna = " cur.nombre ";
                    condicion = $" like '%{txtFiltroNombre.Text}%' ";
                }
                else if (cboFiltro.SelectedItem.ToString() == "Fecha")
                {
                    columna = " cur.fechafin ";
                    condicion = $" BETWEEN '{dtpDesde.Value.ToString("yyyy/MM/dd")}' and '{dtpHasta.Value.ToString("yyyy/MM/dd")}' ";
                }
                else
                {
                    if (cboFiltro.SelectedItem.ToString() == "Estado")
                    {
                        columna = " est.descripcion ";
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString()}%'";
                    }
                    else if (cboFiltro.SelectedItem.ToString() == "Categoria")
                    {
                        columna = " cate.Descripción ";
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString()}%'";
                    }
                    else
                    {
                        columna = " emi.Descripción ";
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString()}%'";
                    }
                }
                listaCurso = negocio.Filtrar(columna, condicion);
                dgvCursos.DataSource = listaCurso;
                OcultarColumnas();
                CargarImagen(listaCurso[0].UrlCertificado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            cboFiltro.SelectedIndex = 0;
            OcultarOpcionesFiltro();
            CargarGrilla();
        }
    }
}
