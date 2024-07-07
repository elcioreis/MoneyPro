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
            this.buttonDespesas = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoInvestimentoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonDespesas);
            this.panelRodape.Location = new System.Drawing.Point(0, 413);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(761, 37);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonDespesas, 0);
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
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(761, 49);
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(317, 32);
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
            this.tipoInvestimentoDataGridView.Location = new System.Drawing.Point(0, 49);
            this.tipoInvestimentoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.tipoInvestimentoDataGridView.Name = "tipoInvestimentoDataGridView";
            this.tipoInvestimentoDataGridView.RowHeadersVisible = false;
            this.tipoInvestimentoDataGridView.RowHeadersWidth = 51;
            this.tipoInvestimentoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipoInvestimentoDataGridView.Size = new System.Drawing.Size(761, 364);
            this.tipoInvestimentoDataGridView.TabIndex = 5;
            this.tipoInvestimentoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tipoInvestimentoDataGridView_EditingControlShowing);
            this.tipoInvestimentoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tipoInvestimentoDataGridView_RowValidating);
            this.tipoInvestimentoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoInvestimentoDataGridView_KeyPress);
            // 
            // TipoInvestimentoID
            // 
            this.TipoInvestimentoID.DataPropertyName = "TipoInvestimentoID";
            this.TipoInvestimentoID.HeaderText = "TipoInvestimentoID";
            this.TipoInvestimentoID.MinimumWidth = 6;
            this.TipoInvestimentoID.Name = "TipoInvestimentoID";
            this.TipoInvestimentoID.Visible = false;
            this.TipoInvestimentoID.Width = 125;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.HeaderText = "UsuarioID";
            this.UsuarioID.MinimumWidth = 6;
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.Visible = false;
            this.UsuarioID.Width = 125;
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
            this.Acao.MinimumWidth = 6;
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
            this.Fundo.MinimumWidth = 6;
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
            this.ComeCota.MinimumWidth = 6;
            this.ComeCota.Name = "ComeCota";
            this.ComeCota.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ComeCota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ComeCota.Width = 103;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.MinimumWidth = 6;
            this.Ativo.Name = "Ativo";
            this.Ativo.Width = 43;
            // 
            // buttonDespesas
            // 
            this.buttonDespesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDespesas.Image = global::MoneyPro.Properties.Resources.z16taxas;
            this.buttonDespesas.Location = new System.Drawing.Point(82, 4);
            this.buttonDespesas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDespesas.Name = "buttonDespesas";
            this.buttonDespesas.Size = new System.Drawing.Size(31, 28);
            this.buttonDespesas.TabIndex = 3;
            this.buttonDespesas.TabStop = false;
            this.toolTip.SetToolTip(this.buttonDespesas, "Despesas sobre o investimento");
            this.buttonDespesas.UseVisualStyleBackColor = true;
            this.buttonDespesas.Click += new System.EventHandler(this.buttonDespesas_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmTiposInvestimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(761, 450);
            this.Controls.Add(this.tipoInvestimentoDataGridView);
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
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
        public System.Windows.Forms.Button buttonDespesas;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
