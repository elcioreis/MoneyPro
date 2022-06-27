namespace MoneyPro
{
    partial class fmDetalhesMovimentacao
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.detalhesMovimentacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalhesMovimentacaoDataGridView = new System.Windows.Forms.DataGridView();
            this.Detalhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LancamentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrdDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conciliacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanejamentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanejamentoRepeticao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesMovimentacaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesMovimentacaoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 337);
            this.panelRodape.Size = new System.Drawing.Size(453, 30);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Visible = false;
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.Visible = false;
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Size = new System.Drawing.Size(453, 40);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(191, 24);
            this.labelTopo.Text = "Detalhes da conta";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(418, 9);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(23, 23);
            this.buttonFecharDetalhes.TabIndex = 13;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "OFX";
            this.toolTip.SetToolTip(this.buttonFecharDetalhes, "Retorna para movimentações");
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.buttonFecharDetalhes_Click);
            // 
            // detalhesMovimentacaoBindingSource
            // 
            this.detalhesMovimentacaoBindingSource.DataSource = typeof(Modelos.DetalhesMovimentacao);
            // 
            // detalhesMovimentacaoDataGridView
            // 
            this.detalhesMovimentacaoDataGridView.AllowUserToAddRows = false;
            this.detalhesMovimentacaoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.detalhesMovimentacaoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.detalhesMovimentacaoDataGridView.AutoGenerateColumns = false;
            this.detalhesMovimentacaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalhesMovimentacaoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalhe,
            this.MovimentoContaID,
            this.ContaID,
            this.Conta,
            this.Data,
            this.LancamentoID,
            this.Lancamento,
            this.Descricao,
            this.CategoriaID,
            this.Categoria,
            this.GrupoCategoriaID,
            this.GrupoCategoria,
            this.CrdDeb,
            this.Debito,
            this.Credito,
            this.Conciliacao,
            this.PlanejamentoID,
            this.PlanejamentoRepeticao});
            this.detalhesMovimentacaoDataGridView.DataSource = this.detalhesMovimentacaoBindingSource;
            this.detalhesMovimentacaoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalhesMovimentacaoDataGridView.Location = new System.Drawing.Point(0, 40);
            this.detalhesMovimentacaoDataGridView.Name = "detalhesMovimentacaoDataGridView";
            this.detalhesMovimentacaoDataGridView.ReadOnly = true;
            this.detalhesMovimentacaoDataGridView.RowHeadersVisible = false;
            this.detalhesMovimentacaoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detalhesMovimentacaoDataGridView.Size = new System.Drawing.Size(453, 297);
            this.detalhesMovimentacaoDataGridView.TabIndex = 5;
            this.detalhesMovimentacaoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.detalhesMovimentacaoDataGridView_CellFormatting);
            // 
            // Detalhe
            // 
            this.Detalhe.DataPropertyName = "Detalhe";
            this.Detalhe.HeaderText = "Detalhe";
            this.Detalhe.Name = "Detalhe";
            this.Detalhe.ReadOnly = true;
            this.Detalhe.Visible = false;
            // 
            // MovimentoContaID
            // 
            this.MovimentoContaID.DataPropertyName = "MovimentoContaID";
            this.MovimentoContaID.HeaderText = "MovimentoContaID";
            this.MovimentoContaID.Name = "MovimentoContaID";
            this.MovimentoContaID.ReadOnly = true;
            this.MovimentoContaID.Visible = false;
            // 
            // ContaID
            // 
            this.ContaID.DataPropertyName = "ContaID";
            this.ContaID.HeaderText = "ContaID";
            this.ContaID.Name = "ContaID";
            this.ContaID.ReadOnly = true;
            this.ContaID.Visible = false;
            // 
            // Conta
            // 
            this.Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Conta.DataPropertyName = "Conta";
            this.Conta.FillWeight = 180F;
            this.Conta.HeaderText = "Conta";
            this.Conta.MinimumWidth = 120;
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Width = 120;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 55;
            // 
            // LancamentoID
            // 
            this.LancamentoID.DataPropertyName = "LancamentoID";
            this.LancamentoID.HeaderText = "LancamentoID";
            this.LancamentoID.Name = "LancamentoID";
            this.LancamentoID.ReadOnly = true;
            this.LancamentoID.Visible = false;
            // 
            // Lancamento
            // 
            this.Lancamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Lancamento.DataPropertyName = "Lancamento";
            this.Lancamento.FillWeight = 180F;
            this.Lancamento.HeaderText = "Parceiro";
            this.Lancamento.MinimumWidth = 120;
            this.Lancamento.Name = "Lancamento";
            this.Lancamento.ReadOnly = true;
            this.Lancamento.Width = 120;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.FillWeight = 180F;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 120;
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // CategoriaID
            // 
            this.CategoriaID.DataPropertyName = "CategoriaID";
            this.CategoriaID.HeaderText = "CategoriaID";
            this.CategoriaID.Name = "CategoriaID";
            this.CategoriaID.ReadOnly = true;
            this.CategoriaID.Visible = false;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 180F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 120;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 120;
            // 
            // GrupoCategoriaID
            // 
            this.GrupoCategoriaID.DataPropertyName = "GrupoCategoriaID";
            this.GrupoCategoriaID.HeaderText = "GrupoCategoriaID";
            this.GrupoCategoriaID.Name = "GrupoCategoriaID";
            this.GrupoCategoriaID.ReadOnly = true;
            this.GrupoCategoriaID.Visible = false;
            // 
            // GrupoCategoria
            // 
            this.GrupoCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoCategoria.DataPropertyName = "GrupoCategoria";
            this.GrupoCategoria.FillWeight = 180F;
            this.GrupoCategoria.HeaderText = "Grupo";
            this.GrupoCategoria.MinimumWidth = 120;
            this.GrupoCategoria.Name = "GrupoCategoria";
            this.GrupoCategoria.ReadOnly = true;
            this.GrupoCategoria.Width = 120;
            // 
            // CrdDeb
            // 
            this.CrdDeb.DataPropertyName = "CrdDeb";
            this.CrdDeb.HeaderText = "CrdDeb";
            this.CrdDeb.Name = "CrdDeb";
            this.CrdDeb.ReadOnly = true;
            this.CrdDeb.Visible = false;
            // 
            // Debito
            // 
            this.Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Debito.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debito.FillWeight = 80F;
            this.Debito.HeaderText = "Débito";
            this.Debito.MinimumWidth = 80;
            this.Debito.Name = "Debito";
            this.Debito.ReadOnly = true;
            this.Debito.Width = 80;
            // 
            // Credito
            // 
            this.Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Credito.DefaultCellStyle = dataGridViewCellStyle3;
            this.Credito.FillWeight = 80F;
            this.Credito.HeaderText = "Crédito";
            this.Credito.MinimumWidth = 80;
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            this.Credito.Width = 80;
            // 
            // Conciliacao
            // 
            this.Conciliacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Conciliacao.DataPropertyName = "Conciliacao";
            this.Conciliacao.HeaderText = "";
            this.Conciliacao.Name = "Conciliacao";
            this.Conciliacao.ReadOnly = true;
            this.Conciliacao.Width = 19;
            // 
            // PlanejamentoID
            // 
            this.PlanejamentoID.DataPropertyName = "PlanejamentoID";
            this.PlanejamentoID.HeaderText = "PlanejamentoID";
            this.PlanejamentoID.Name = "PlanejamentoID";
            this.PlanejamentoID.ReadOnly = true;
            this.PlanejamentoID.Visible = false;
            // 
            // PlanejamentoRepeticao
            // 
            this.PlanejamentoRepeticao.DataPropertyName = "PlanejamentoRepeticao";
            this.PlanejamentoRepeticao.HeaderText = "PlanejamentoRepeticao";
            this.PlanejamentoRepeticao.Name = "PlanejamentoRepeticao";
            this.PlanejamentoRepeticao.ReadOnly = true;
            this.PlanejamentoRepeticao.Visible = false;
            // 
            // fmDetalhesMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(453, 367);
            this.Controls.Add(this.detalhesMovimentacaoDataGridView);
            this.Name = "fmDetalhesMovimentacao";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmDetalhes_FormClosed);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.detalhesMovimentacaoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesMovimentacaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesMovimentacaoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.BindingSource detalhesMovimentacaoBindingSource;
        private System.Windows.Forms.DataGridView detalhesMovimentacaoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn LancamentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrdDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanejamentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanejamentoRepeticao;
    }
}
