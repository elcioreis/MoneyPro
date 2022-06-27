namespace MoneyPro
{
    partial class fmTiposInstituicoes
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
            this.tipoInstituicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoInstituicaoDataGridView = new System.Windows.Forms.DataGridView();
            this.TipoInstituicaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInstituicaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInstituicaoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 269);
            this.panelRodape.Size = new System.Drawing.Size(457, 30);
            this.panelRodape.TabIndex = 1;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.Click += new System.EventHandler(this.buttonIncluir_Click);
            // 
            // panelTopo
            // 
            this.panelTopo.Size = new System.Drawing.Size(457, 40);
            this.panelTopo.TabIndex = 2;
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(347, 24);
            this.labelTopo.Text = "Cadastro de Tipos de Instituições";
            // 
            // tipoInstituicaoBindingSource
            // 
            this.tipoInstituicaoBindingSource.DataSource = typeof(Modelos.TipoInstituicao);
            // 
            // tipoInstituicaoDataGridView
            // 
            this.tipoInstituicaoDataGridView.AllowUserToAddRows = false;
            this.tipoInstituicaoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.tipoInstituicaoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tipoInstituicaoDataGridView.AutoGenerateColumns = false;
            this.tipoInstituicaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipoInstituicaoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoInstituicaoID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.Ativo});
            this.tipoInstituicaoDataGridView.DataSource = this.tipoInstituicaoBindingSource;
            this.tipoInstituicaoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipoInstituicaoDataGridView.Location = new System.Drawing.Point(0, 40);
            this.tipoInstituicaoDataGridView.Name = "tipoInstituicaoDataGridView";
            this.tipoInstituicaoDataGridView.RowHeadersVisible = false;
            this.tipoInstituicaoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipoInstituicaoDataGridView.Size = new System.Drawing.Size(457, 229);
            this.tipoInstituicaoDataGridView.TabIndex = 0;
            this.tipoInstituicaoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tipoInstituicaoDataGridView_EditingControlShowing);
            this.tipoInstituicaoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tipoInstituicaoDataGridView_RowValidating);
            this.tipoInstituicaoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoInstituicaoDataGridView_KeyPress);
            // 
            // TipoInstituicaoID
            // 
            this.TipoInstituicaoID.DataPropertyName = "TipoInstituicaoID";
            this.TipoInstituicaoID.HeaderText = "TipoInstituicaoID";
            this.TipoInstituicaoID.Name = "TipoInstituicaoID";
            this.TipoInstituicaoID.Visible = false;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.HeaderText = "UsuarioID";
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.Visible = false;
            // 
            // Apelido
            // 
            this.Apelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Apelido.DataPropertyName = "Apelido";
            dataGridViewCellStyle2.NullValue = "null";
            this.Apelido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 67;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle3.NullValue = "null";
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.Width = 37;
            // 
            // fmTiposInstituicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 299);
            this.Controls.Add(this.tipoInstituicaoDataGridView);
            this.Name = "fmTiposInstituicoes";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTipoInstituicoes_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.tipoInstituicaoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInstituicaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInstituicaoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tipoInstituicaoBindingSource;
        private System.Windows.Forms.DataGridView tipoInstituicaoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInstituicaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
