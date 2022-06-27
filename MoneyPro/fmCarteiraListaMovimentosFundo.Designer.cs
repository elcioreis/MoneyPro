namespace MoneyPro
{
    partial class fmCarteiraListaMovimentosFundo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.listaMovimentosFundoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investimentoDetalhesDataGridView = new System.Windows.Forms.DataGridView();
            this.TipoLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtCotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtCotasAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaMovimentosFundoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 370);
            this.panelRodape.Size = new System.Drawing.Size(707, 37);
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Size = new System.Drawing.Size(707, 49);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(663, 10);
            this.buttonFecharDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(31, 28);
            this.buttonFecharDetalhes.TabIndex = 15;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.ButtonFecharDetalhes_Click);
            // 
            // listaMovimentosFundoBindingSource
            // 
            this.listaMovimentosFundoBindingSource.DataSource = typeof(Modelos.ListaMovimentosFundo);
            // 
            // investimentoDetalhesDataGridView
            // 
            this.investimentoDetalhesDataGridView.AllowUserToAddRows = false;
            this.investimentoDetalhesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.investimentoDetalhesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.investimentoDetalhesDataGridView.AutoGenerateColumns = false;
            this.investimentoDetalhesDataGridView.CausesValidation = false;
            this.investimentoDetalhesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.investimentoDetalhesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoLinha,
            this.MovimentoContaID,
            this.Conta,
            this.Data,
            this.Lancamento,
            this.Transacao,
            this.Descricao,
            this.Categoria,
            this.QtCotas,
            this.QtCotasAcumulado,
            this.Debito,
            this.Credito,
            this.TotalAplicacao});
            this.investimentoDetalhesDataGridView.DataSource = this.listaMovimentosFundoBindingSource;
            this.investimentoDetalhesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.investimentoDetalhesDataGridView.Location = new System.Drawing.Point(0, 49);
            this.investimentoDetalhesDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.investimentoDetalhesDataGridView.Name = "investimentoDetalhesDataGridView";
            this.investimentoDetalhesDataGridView.ReadOnly = true;
            this.investimentoDetalhesDataGridView.RowHeadersVisible = false;
            this.investimentoDetalhesDataGridView.RowHeadersWidth = 51;
            this.investimentoDetalhesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.investimentoDetalhesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.investimentoDetalhesDataGridView.Size = new System.Drawing.Size(707, 321);
            this.investimentoDetalhesDataGridView.TabIndex = 14;
            this.investimentoDetalhesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.InvestimentoDetalhesDataGridView_CellFormatting);
            // 
            // TipoLinha
            // 
            this.TipoLinha.DataPropertyName = "TipoLinha";
            this.TipoLinha.HeaderText = "TipoLinha";
            this.TipoLinha.MinimumWidth = 6;
            this.TipoLinha.Name = "TipoLinha";
            this.TipoLinha.ReadOnly = true;
            this.TipoLinha.Visible = false;
            this.TipoLinha.Width = 125;
            // 
            // MovimentoContaID
            // 
            this.MovimentoContaID.DataPropertyName = "MovimentoContaID";
            this.MovimentoContaID.HeaderText = "MovimentoContaID";
            this.MovimentoContaID.MinimumWidth = 6;
            this.MovimentoContaID.Name = "MovimentoContaID";
            this.MovimentoContaID.ReadOnly = true;
            this.MovimentoContaID.Visible = false;
            this.MovimentoContaID.Width = 125;
            // 
            // Conta
            // 
            this.Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Conta.DataPropertyName = "Conta";
            this.Conta.HeaderText = "Conta";
            this.Conta.MinimumWidth = 6;
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Width = 74;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.FillWeight = 75F;
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 75;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 75;
            // 
            // Lancamento
            // 
            this.Lancamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Lancamento.DataPropertyName = "Lancamento";
            this.Lancamento.HeaderText = "Lançamento";
            this.Lancamento.MinimumWidth = 6;
            this.Lancamento.Name = "Lancamento";
            this.Lancamento.ReadOnly = true;
            this.Lancamento.Width = 115;
            // 
            // Transacao
            // 
            this.Transacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transacao.DataPropertyName = "Transacao";
            this.Transacao.HeaderText = "Transação";
            this.Transacao.MinimumWidth = 6;
            this.Transacao.Name = "Transacao";
            this.Transacao.ReadOnly = true;
            this.Transacao.Width = 105;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 6;
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 98;
            // 
            // QtCotas
            // 
            this.QtCotas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QtCotas.DataPropertyName = "QtCotas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N8";
            this.QtCotas.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtCotas.HeaderText = "Cotas";
            this.QtCotas.MinimumWidth = 6;
            this.QtCotas.Name = "QtCotas";
            this.QtCotas.ReadOnly = true;
            this.QtCotas.Width = 73;
            // 
            // QtCotasAcumulado
            // 
            this.QtCotasAcumulado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QtCotasAcumulado.DataPropertyName = "QtCotasAcumulado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N8";
            this.QtCotasAcumulado.DefaultCellStyle = dataGridViewCellStyle4;
            this.QtCotasAcumulado.HeaderText = "Acumuladas";
            this.QtCotasAcumulado.MinimumWidth = 6;
            this.QtCotasAcumulado.Name = "QtCotasAcumulado";
            this.QtCotasAcumulado.ReadOnly = true;
            this.QtCotasAcumulado.ToolTipText = "Cotas Acumuladas";
            this.QtCotasAcumulado.Width = 114;
            // 
            // Debito
            // 
            this.Debito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Debito.DefaultCellStyle = dataGridViewCellStyle5;
            this.Debito.HeaderText = "Débito";
            this.Debito.MinimumWidth = 6;
            this.Debito.Name = "Debito";
            this.Debito.ReadOnly = true;
            this.Debito.Width = 78;
            // 
            // Credito
            // 
            this.Credito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Credito.DefaultCellStyle = dataGridViewCellStyle6;
            this.Credito.HeaderText = "Crédito";
            this.Credito.MinimumWidth = 6;
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            this.Credito.Width = 82;
            // 
            // TotalAplicacao
            // 
            this.TotalAplicacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalAplicacao.DataPropertyName = "TotalAplicacao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.TotalAplicacao.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalAplicacao.HeaderText = "Total";
            this.TotalAplicacao.MinimumWidth = 6;
            this.TotalAplicacao.Name = "TotalAplicacao";
            this.TotalAplicacao.ReadOnly = true;
            this.TotalAplicacao.Width = 69;
            // 
            // fmCarteiraListaMovimentosFundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(707, 407);
            this.Controls.Add(this.investimentoDetalhesDataGridView);
            this.Name = "fmCarteiraListaMovimentosFundo";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.investimentoDetalhesDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaMovimentosFundoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.BindingSource listaMovimentosFundoBindingSource;
        private System.Windows.Forms.DataGridView investimentoDetalhesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtCotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtCotasAcumulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAplicacao;
    }
}
