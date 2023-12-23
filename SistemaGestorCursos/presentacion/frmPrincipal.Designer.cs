namespace presentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.pbxCertificado = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.chkFiltrar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.gbxNombre = new System.Windows.Forms.GroupBox();
            this.gbxFecha = new System.Windows.Forms.GroupBox();
            this.gbxCombos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cboFiltroFinal = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCertificado)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.gbxNombre.SuspendLayout();
            this.gbxFecha.SuspendLayout();
            this.gbxCombos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCursos
            // 
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCursos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvCursos.Location = new System.Drawing.Point(12, 140);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(667, 252);
            this.dgvCursos.TabIndex = 0;
            this.dgvCursos.SelectionChanged += new System.EventHandler(this.dgvCursos_SelectionChanged);
            // 
            // pbxCertificado
            // 
            this.pbxCertificado.Location = new System.Drawing.Point(202, 407);
            this.pbxCertificado.Name = "pbxCertificado";
            this.pbxCertificado.Size = new System.Drawing.Size(300, 159);
            this.pbxCertificado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCertificado.TabIndex = 1;
            this.pbxCertificado.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(639, 501);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(28, 483);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(540, 501);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // chkFiltrar
            // 
            this.chkFiltrar.AutoSize = true;
            this.chkFiltrar.Location = new System.Drawing.Point(31, 23);
            this.chkFiltrar.Name = "chkFiltrar";
            this.chkFiltrar.Size = new System.Drawing.Size(51, 17);
            this.chkFiltrar.TabIndex = 7;
            this.chkFiltrar.Text = "Filtrar";
            this.chkFiltrar.UseVisualStyleBackColor = true;
            this.chkFiltrar.CheckedChanged += new System.EventHandler(this.chkFiltrar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtrar por: ";
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Location = new System.Drawing.Point(81, 28);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(121, 21);
            this.cboFiltro.TabIndex = 6;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.Controls.Add(this.btnResetear);
            this.gbxFiltros.Controls.Add(this.btnFiltrar);
            this.gbxFiltros.Controls.Add(this.gbxFecha);
            this.gbxFiltros.Controls.Add(this.gbxCombos);
            this.gbxFiltros.Controls.Add(this.gbxNombre);
            this.gbxFiltros.Controls.Add(this.cboFiltro);
            this.gbxFiltros.Controls.Add(this.label1);
            this.gbxFiltros.Location = new System.Drawing.Point(116, 23);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(710, 111);
            this.gbxFiltros.TabIndex = 8;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Text = "Filtros";
            // 
            // gbxNombre
            // 
            this.gbxNombre.Controls.Add(this.txtFiltroNombre);
            this.gbxNombre.Controls.Add(this.label2);
            this.gbxNombre.Location = new System.Drawing.Point(251, 19);
            this.gbxNombre.Name = "gbxNombre";
            this.gbxNombre.Size = new System.Drawing.Size(347, 69);
            this.gbxNombre.TabIndex = 7;
            this.gbxNombre.TabStop = false;
            // 
            // gbxFecha
            // 
            this.gbxFecha.Controls.Add(this.dtpHasta);
            this.gbxFecha.Controls.Add(this.dtpDesde);
            this.gbxFecha.Controls.Add(this.label4);
            this.gbxFecha.Controls.Add(this.label3);
            this.gbxFecha.Location = new System.Drawing.Point(251, 19);
            this.gbxFecha.Name = "gbxFecha";
            this.gbxFecha.Size = new System.Drawing.Size(347, 69);
            this.gbxFecha.TabIndex = 8;
            this.gbxFecha.TabStop = false;
            // 
            // gbxCombos
            // 
            this.gbxCombos.Controls.Add(this.cboFiltroFinal);
            this.gbxCombos.Location = new System.Drawing.Point(250, 22);
            this.gbxCombos.Name = "gbxCombos";
            this.gbxCombos.Size = new System.Drawing.Size(347, 69);
            this.gbxCombos.TabIndex = 8;
            this.gbxCombos.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre: ";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(79, 28);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Desde: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hasta: ";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(76, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(76, 46);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // cboFiltroFinal
            // 
            this.cboFiltroFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroFinal.FormattingEnabled = true;
            this.cboFiltroFinal.Location = new System.Drawing.Point(19, 31);
            this.cboFiltroFinal.Name = "cboFiltroFinal";
            this.cboFiltroFinal.Size = new System.Drawing.Size(121, 21);
            this.cboFiltroFinal.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(47, 69);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(128, 69);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 10;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 579);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.chkFiltrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbxCertificado);
            this.Controls.Add(this.dgvCursos);
            this.Name = "frmPrincipal";
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCertificado)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.gbxNombre.ResumeLayout(false);
            this.gbxNombre.PerformLayout();
            this.gbxFecha.ResumeLayout(false);
            this.gbxFecha.PerformLayout();
            this.gbxCombos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.PictureBox pbxCertificado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.CheckBox chkFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.GroupBox gbxNombre;
        private System.Windows.Forms.GroupBox gbxFecha;
        private System.Windows.Forms.GroupBox gbxCombos;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFiltroFinal;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnResetear;
    }
}

