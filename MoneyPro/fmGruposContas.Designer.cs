namespace MoneyPro
{
    partial class fmGruposContas
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
            this.grupoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grupoContaDataGridView = new System.Windows.Forms.DataGridView();
            this.GrupoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 338);
            this.panelRodape.Size = new System.Drawing.Size(597, 30);
            this.panelRodape.TabIndex = 2;
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
            this.panelTopo.Size = new System.Drawing.Size(597, 40);
            this.panelTopo.TabIndex = 0;
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(321, 24);
            this.labelTopo.Text = "Cadastro de Grupos de Contas";
            // 
            // grupoContaBindingSource
            // 
            this.grupoContaBindingSource.DataSource = typeof(Modelos.GrupoConta);
            // 
            // grupoContaDataGridView
            // 
            this.grupoContaDataGridView.AllowUserToAddRows = false;
            this.grupoContaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.grupoContaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grupoContaDataGridView.AutoGenerateColumns = false;
            this.grupoContaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grupoContaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GrupoContaID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.Ordem,
            this.Ativo});
            this.grupoContaDataGridView.DataSource = this.grupoContaBindingSource;
            this.grupoContaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoContaDataGridView.Location = new System.Drawing.Point(0, 40);
            this.grupoContaDataGridView.Name = "grupoContaDataGridView";
            this.grupoContaDataGridView.RowHeadersVisible = false;
            this.grupoContaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grupoContaDataGridView.Size = new System.Drawing.Size(597, 298);
            this.grupoContaDataGridView.TabIndex = 1;
            this.grupoContaDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grupoContaDataGridView_EditingControlShowing);
            this.grupoContaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grupoContaDataGridView_RowValidating);
            this.grupoContaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grupoContaDataGridView_KeyPress);
            // 
            // GrupoContaID
            // 
            this.GrupoContaID.DataPropertyName = "GrupoContaID";
            this.GrupoContaID.HeaderText = "GrupoContaID";
            this.GrupoContaID.Name = "GrupoContaID";
            this.GrupoContaID.Visible = false;
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
            // Ordem
            // 
            this.Ordem.DataPropertyName = "Ordem";
            this.Ordem.FillWeight = 60F;
            this.Ordem.HeaderText = "Ordem";
            this.Ordem.Name = "Ordem";
            this.Ordem.Width = 60;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FillWeight = 50F;
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.Width = 37;
            // 
            // fmGruposContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(597, 368);
            this.Controls.Add(this.grupoContaDataGridView);
            this.Name = "fmGruposContas";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmGruposContas_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.grupoContaDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource grupoContaBindingSource;
        private System.Windows.Forms.DataGridView grupoContaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
