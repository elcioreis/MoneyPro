namespace MoneyPro
{
    partial class fmCalendario
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.calendarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calendarioDataGridView = new System.Windows.Forms.DataGridView();
            this.FeriadoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fixo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarioDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 203);
            this.panelRodape.Size = new System.Drawing.Size(637, 30);
            this.panelRodape.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRodape_Paint);
            // 
            // panelTopo
            // 
            this.panelTopo.Size = new System.Drawing.Size(637, 40);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(237, 24);
            this.labelTopo.Text = "Calendário && Feriados";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar.Location = new System.Drawing.Point(0, 40);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 5;
            this.monthCalendar.TrailingForeColor = System.Drawing.Color.Red;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            this.monthCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.monthCalendar_MouseDown);
            // 
            // calendarioBindingSource
            // 
            this.calendarioBindingSource.DataSource = typeof(Modelos.Calendario);
            // 
            // calendarioDataGridView
            // 
            this.calendarioDataGridView.AllowUserToAddRows = false;
            this.calendarioDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.calendarioDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.calendarioDataGridView.AutoGenerateColumns = false;
            this.calendarioDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarioDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.calendarioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.calendarioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeriadoID,
            this.Dia,
            this.Mes,
            this.Ano,
            this.Data,
            this.Descricao,
            this.Fixo});
            this.calendarioDataGridView.DataSource = this.calendarioBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.calendarioDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.calendarioDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarioDataGridView.Location = new System.Drawing.Point(227, 40);
            this.calendarioDataGridView.Name = "calendarioDataGridView";
            this.calendarioDataGridView.RowHeadersVisible = false;
            this.calendarioDataGridView.Size = new System.Drawing.Size(410, 163);
            this.calendarioDataGridView.TabIndex = 6;
            this.calendarioDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.calendarioDataGridView_EditingControlShowing);
            this.calendarioDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.calendarioDataGridView_RowValidating);
            this.calendarioDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calendarioDataGridView_KeyPress);
            // 
            // FeriadoID
            // 
            this.FeriadoID.DataPropertyName = "FeriadoID";
            this.FeriadoID.HeaderText = "FeriadoID";
            this.FeriadoID.Name = "FeriadoID";
            this.FeriadoID.Visible = false;
            // 
            // Dia
            // 
            this.Dia.DataPropertyName = "Dia";
            this.Dia.HeaderText = "Dia";
            this.Dia.Name = "Dia";
            this.Dia.Visible = false;
            // 
            // Mes
            // 
            this.Mes.DataPropertyName = "Mes";
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.Visible = false;
            // 
            // Ano
            // 
            this.Ano.DataPropertyName = "Ano";
            this.Ano.HeaderText = "Ano";
            this.Ano.Name = "Ano";
            this.Ano.Visible = false;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Width = 55;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Feriado";
            this.Descricao.Name = "Descricao";
            // 
            // Fixo
            // 
            this.Fixo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fixo.DataPropertyName = "Fixo";
            this.Fixo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fixo.HeaderText = "Dia Fixo";
            this.Fixo.Name = "Fixo";
            this.Fixo.Width = 51;
            // 
            // fmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(637, 233);
            this.Controls.Add(this.calendarioDataGridView);
            this.Controls.Add(this.monthCalendar);
            this.Name = "fmCalendario";
            this.Text = "Calendário & Feriados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmCalendario_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.monthCalendar, 0);
            this.Controls.SetChildIndex(this.calendarioDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarioDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.BindingSource calendarioBindingSource;
        private System.Windows.Forms.DataGridView calendarioDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeriadoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fixo;
    }
}
