namespace MoneyPro
{
    partial class fmSaldoFuturo
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
            this.saldoFuturoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saldoFuturoDataGridView = new System.Windows.Forms.DataGridView();
            this.Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitosFuturos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditosFuturos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoPrevisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saldoFuturoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldoFuturoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 387);
            this.panelRodape.Size = new System.Drawing.Size(968, 37);
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
            this.panelTopo.Size = new System.Drawing.Size(968, 49);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(182, 32);
            this.labelTopo.Text = "Saldo Futuro";
            // 
            // saldoFuturoBindingSource
            // 
            this.saldoFuturoBindingSource.DataSource = typeof(Modelos.SaldoFuturo);
            // 
            // saldoFuturoDataGridView
            // 
            this.saldoFuturoDataGridView.AllowUserToAddRows = false;
            this.saldoFuturoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.saldoFuturoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.saldoFuturoDataGridView.AutoGenerateColumns = false;
            this.saldoFuturoDataGridView.CausesValidation = false;
            this.saldoFuturoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saldoFuturoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ordem,
            this.Nivel,
            this.ContaID,
            this.Tipo,
            this.Descricao,
            this.SaldoAtual,
            this.DebitosFuturos,
            this.CreditosFuturos,
            this.SaldoPrevisto});
            this.saldoFuturoDataGridView.DataSource = this.saldoFuturoBindingSource;
            this.saldoFuturoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saldoFuturoDataGridView.Location = new System.Drawing.Point(0, 49);
            this.saldoFuturoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.saldoFuturoDataGridView.Name = "saldoFuturoDataGridView";
            this.saldoFuturoDataGridView.ReadOnly = true;
            this.saldoFuturoDataGridView.RowHeadersVisible = false;
            this.saldoFuturoDataGridView.RowHeadersWidth = 51;
            this.saldoFuturoDataGridView.RowTemplate.ReadOnly = true;
            this.saldoFuturoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.saldoFuturoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saldoFuturoDataGridView.Size = new System.Drawing.Size(968, 338);
            this.saldoFuturoDataGridView.TabIndex = 0;
            this.saldoFuturoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SaldoFuturoDataGridView_CellFormatting);
            // 
            // Ordem
            // 
            this.Ordem.DataPropertyName = "Ordem";
            this.Ordem.HeaderText = "Ordem";
            this.Ordem.MinimumWidth = 6;
            this.Ordem.Name = "Ordem";
            this.Ordem.ReadOnly = true;
            this.Ordem.Visible = false;
            this.Ordem.Width = 125;
            // 
            // Nivel
            // 
            this.Nivel.DataPropertyName = "Nivel";
            this.Nivel.HeaderText = "Nivel";
            this.Nivel.MinimumWidth = 6;
            this.Nivel.Name = "Nivel";
            this.Nivel.ReadOnly = true;
            this.Nivel.Visible = false;
            this.Nivel.Width = 125;
            // 
            // ContaID
            // 
            this.ContaID.DataPropertyName = "ContaID";
            this.ContaID.HeaderText = "ContaID";
            this.ContaID.MinimumWidth = 6;
            this.ContaID.Name = "ContaID";
            this.ContaID.ReadOnly = true;
            this.ContaID.Visible = false;
            this.ContaID.Width = 125;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 65;
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
            // SaldoAtual
            // 
            this.SaldoAtual.DataPropertyName = "SaldoAtual";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0.00";
            this.SaldoAtual.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaldoAtual.FillWeight = 125F;
            this.SaldoAtual.HeaderText = "Saldo Atual";
            this.SaldoAtual.MinimumWidth = 6;
            this.SaldoAtual.Name = "SaldoAtual";
            this.SaldoAtual.ReadOnly = true;
            this.SaldoAtual.Width = 125;
            // 
            // DebitosFuturos
            // 
            this.DebitosFuturos.DataPropertyName = "DebitosFuturos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0.00";
            this.DebitosFuturos.DefaultCellStyle = dataGridViewCellStyle3;
            this.DebitosFuturos.FillWeight = 125F;
            this.DebitosFuturos.HeaderText = "Débitos Futuros";
            this.DebitosFuturos.MinimumWidth = 6;
            this.DebitosFuturos.Name = "DebitosFuturos";
            this.DebitosFuturos.ReadOnly = true;
            this.DebitosFuturos.Width = 125;
            // 
            // CreditosFuturos
            // 
            this.CreditosFuturos.DataPropertyName = "CreditosFuturos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0.00";
            this.CreditosFuturos.DefaultCellStyle = dataGridViewCellStyle4;
            this.CreditosFuturos.FillWeight = 125F;
            this.CreditosFuturos.HeaderText = "Créditos Futuros";
            this.CreditosFuturos.MinimumWidth = 6;
            this.CreditosFuturos.Name = "CreditosFuturos";
            this.CreditosFuturos.ReadOnly = true;
            this.CreditosFuturos.Width = 125;
            // 
            // SaldoPrevisto
            // 
            this.SaldoPrevisto.DataPropertyName = "SaldoPrevisto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0.00";
            this.SaldoPrevisto.DefaultCellStyle = dataGridViewCellStyle5;
            this.SaldoPrevisto.FillWeight = 125F;
            this.SaldoPrevisto.HeaderText = "Saldo Previsto";
            this.SaldoPrevisto.MinimumWidth = 6;
            this.SaldoPrevisto.Name = "SaldoPrevisto";
            this.SaldoPrevisto.ReadOnly = true;
            this.SaldoPrevisto.Width = 125;
            // 
            // fmSaldoFuturo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(968, 424);
            this.Controls.Add(this.saldoFuturoDataGridView);
            this.Name = "fmSaldoFuturo";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.saldoFuturoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saldoFuturoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldoFuturoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource saldoFuturoBindingSource;
        private System.Windows.Forms.DataGridView saldoFuturoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitosFuturos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditosFuturos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoPrevisto;
    }
}
