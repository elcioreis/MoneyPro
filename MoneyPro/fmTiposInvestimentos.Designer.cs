namespace MoneyPro
{
    partial class fmTiposInvestimentos
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
            this.tipoInvestimentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoInvestimentoDataGridView = new System.Windows.Forms.DataGridView();
            this.TipoInvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fundo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComeCota = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 336);
            this.panelRodape.Size = new System.Drawing.Size(571, 30);
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
            this.panelTopo.Size = new System.Drawing.Size(571, 40);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(243, 24);
            this.labelTopo.Text = "Tipos de Investimentos";
            // 
            // tipoInvestimentoBindingSource
            // 
            this.tipoInvestimentoBindingSource.DataSource = typeof(Modelos.TipoInvestimento);
            // 
            // tipoInvestimentoDataGridView
            // 
            this.tipoInvestimentoDataGridView.AllowUserToAddRows = false;
            this.tipoInvestimentoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.tipoInvestimentoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tipoInvestimentoDataGridView.AutoGenerateColumns = false;
            this.tipoInvestimentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipoInvestimentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoInvestimentoID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.Acao,
            this.Fundo,
            this.ComeCota,
            this.Ativo});
            this.tipoInvestimentoDataGridView.DataSource = this.tipoInvestimentoBindingSource;
            this.tipoInvestimentoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipoInvestimentoDataGridView.Location = new System.Drawing.Point(0, 40);
            this.tipoInvestimentoDataGridView.Name = "tipoInvestimentoDataGridView";
            this.tipoInvestimentoDataGridView.RowHeadersVisible = false;
            this.tipoInvestimentoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipoInvestimentoDataGridView.Size = new System.Drawing.Size(571, 296);
            this.tipoInvestimentoDataGridView.TabIndex = 5;
            this.tipoInvestimentoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tipoInvestimentoDataGridView_EditingControlShowing);
            this.tipoInvestimentoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tipoInvestimentoDataGridView_RowValidating);
            this.tipoInvestimentoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoInvestimentoDataGridView_KeyPress);
            // 
            // TipoInvestimentoID
            // 
            this.TipoInvestimentoID.DataPropertyName = "TipoInvestimentoID";
            this.TipoInvestimentoID.HeaderText = "TipoInvestimentoID";
            this.TipoInvestimentoID.Name = "TipoInvestimentoID";
            this.TipoInvestimentoID.Visible = false;
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
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 100;
            this.Apelido.Name = "Apelido";
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 100;
            this.Descricao.Name = "Descricao";
            // 
            // Acao
            // 
            this.Acao.DataPropertyName = "Acao";
            this.Acao.FillWeight = 70F;
            this.Acao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Acao.HeaderText = "Ação";
            this.Acao.Name = "Acao";
            this.Acao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Acao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Acao.Width = 70;
            // 
            // Fundo
            // 
            this.Fundo.DataPropertyName = "Fundo";
            this.Fundo.FillWeight = 70F;
            this.Fundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fundo.HeaderText = "Fundo";
            this.Fundo.Name = "Fundo";
            this.Fundo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fundo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Fundo.Width = 70;
            // 
            // ComeCota
            // 
            this.ComeCota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComeCota.DataPropertyName = "ComeCota";
            this.ComeCota.FillWeight = 80F;
            this.ComeCota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComeCota.HeaderText = "Come Cota";
            this.ComeCota.Name = "ComeCota";
            this.ComeCota.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ComeCota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ComeCota.Width = 84;
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
            // fmTiposInvestimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(571, 366);
            this.Controls.Add(this.tipoInvestimentoDataGridView);
            this.Name = "fmTiposInvestimentos";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTiposInvestimentos_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.tipoInvestimentoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tipoInvestimentoBindingSource;
        private System.Windows.Forms.DataGridView tipoInvestimentoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Acao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fundo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ComeCota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
