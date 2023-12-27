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
    public partial class frmCurso : Form
    {
        private List<Curso> listaCurso;
        public frmCurso()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            OcultarOpcionesFiltro(true);
            cboFiltro.Items.Add("");
            cboFiltro.Items.Add("Nombre");
            cboFiltro.Items.Add("Estado");
            cboFiltro.Items.Add("Fecha");
            cboFiltro.Items.Add("Categoria");
            cboFiltro.Items.Add("Emisor");
            dgvCursos.Rows[0].Selected = false;
        }

        private void CargarGrilla()
        {
            CursoNegocio negocio = new CursoNegocio();
            try
            {
                listaCurso = negocio.Listar();
                dgvCursos.DataSource = listaCurso;
                OcultarColumnas();
                if(listaCurso.Count > 0)
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
            if(dgvCursos.CurrentRow != null)
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
            catch (Exception)
            {
                pbxCertificado.Load("https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            try
            {
                frmAltaCurso frmAltaCurso = new frmAltaCurso();
                frmAltaCurso.ShowDialog();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
            {
                Modificar();
            }
            else
                MessageBox.Show("Por favor, seleccione un curso", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Modificar()
        {
            Curso seleccionado;
            try
            {                
                 seleccionado = (Curso)dgvCursos.CurrentRow.DataBoundItem;

                 frmAltaCurso frmModificarCurso = new frmAltaCurso(seleccionado);
                 frmModificarCurso.ShowDialog();
                 CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
                Eliminar();
            else
                MessageBox.Show("Por favor, seleccione un curso", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminar()
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
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString().TrimEnd()}%'";
                    }
                    else if (cboFiltro.SelectedItem.ToString() == "Categoria")
                    {
                        columna = " cate.Descripción ";
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString().TrimEnd()}%'";
                    }
                    else
                    {
                        columna = " emi.Descripción ";
                        condicion = $" like '%{cboFiltroFinal.SelectedItem.ToString().TrimEnd()}%'";
                    }
                }
                listaCurso = negocio.Filtrar(columna, condicion);
                dgvCursos.DataSource = listaCurso;
                OcultarColumnas();
                if(listaCurso.Count > 0)
                    CargarImagen(listaCurso[0].UrlCertificado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            OcultarOpcionesFiltro();
            cboFiltro.SelectedIndex = 0;
            CargarGrilla();
        }

        private void btnCambioColor_MouseEnter(object sender, EventArgs e)
        {
            var boton = (Button)sender;

            boton.BackColor = Color.FromArgb(163, 21, 21);
        }

        private void btnVuelvoColor_MouseLeave(object sender, EventArgs e)
        {
            var boton = (Button)sender;

            boton.BackColor = Color.FromArgb(47, 70, 148);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {

            if (dgvCursos.SelectedRows.Count > 0)
            {
                VerDetalle();
            }
            else
                MessageBox.Show("Por favor, seleccione un curso", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void VerDetalle()
        {
            Curso seleccionado;
            try
            {
                seleccionado = (Curso)dgvCursos.CurrentRow.DataBoundItem;

                frmDetalle frmDetalle = new frmDetalle(seleccionado);
                frmDetalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
