namespace MoneyPro
{
    partial class fmCarteiraTabelaDetalhes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.investimentoDetalhesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investimentoDetalhesDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totalizador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetalheID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtMovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtCotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoCotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrCotacaoDiaFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrCustoFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrBrutoFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrImpostosFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrLiquidoFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrLucroOuPerda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrLucroOuPerdaFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercLucroOuPerdaFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indicador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesDataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            // 
            // investimentoDetalhesBindingSource
            // 
            this.investimentoDetalhesBindingSource.DataSource = typeof(Modelos.InvestimentoDetalhes);
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
            this.ContaID,
            this.MovimentoID,
            this.Totalizador,
            this.LoteID,
            this.DetalheID,
            this.Transacao,
            this.dataGridViewTextBoxColumn7,
            this.DtMovimento,
            this.QtCotas,
            this.SaldoCotas,
            this.VrCotacaoDiaFormatado,
            this.VrCustoFormatado,
            this.VrBrutoFormatado,
            this.VrImpostosFormatado,
            this.VrLiquidoFormatado,
            this.VrLucroOuPerda,
            this.VrLucroOuPerdaFormatado,
            this.PercLucroOuPerdaFormatado,
            this.Indicador});
            this.investimentoDetalhesDataGridView.DataSource = this.investimentoDetalhesBindingSource;
            this.investimentoDetalhesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.investimentoDetalhesDataGridView.Location = new System.Drawing.Point(0, 40);
            this.investimentoDetalhesDataGridView.Name = "investimentoDetalhesDataGridView";
            this.investimentoDetalhesDataGridView.ReadOnly = true;
            this.investimentoDetalhesDataGridView.RowHeadersVisible = false;
            this.investimentoDetalhesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.investimentoDetalhesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.investimentoDetalhesDataGridView.Size = new System.Drawing.Size(452, 192);
            this.investimentoDetalhesDataGridView.TabIndex = 13;
            this.investimentoDetalhesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.investimentoDetalhesDataGridView_CellFormatting);
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(417, 9);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(23, 23);
            this.buttonFecharDetalhes.TabIndex = 14;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.toolTip.SetToolTip(this.buttonFecharDetalhes, "Retornar à tela anterior");
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.buttonFecharDetalhes_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // ContaID
            // 
            this.ContaID.DataPropertyName = "ContaID";
            this.ContaID.HeaderText = "ContaID";
            this.ContaID.Name = "ContaID";
            this.ContaID.ReadOnly = true;
            this.ContaID.Visible = false;
            // 
            // MovimentoID
            // 
            this.MovimentoID.DataPropertyName = "MovimentoID";
            this.MovimentoID.HeaderText = "MovimentoID";
            this.MovimentoID.Name = "MovimentoID";
            this.MovimentoID.ReadOnly = true;
            this.MovimentoID.Visible = false;
            // 
            // Totalizador
            // 
            this.Totalizador.DataPropertyName = "Totalizador";
            this.Totalizador.HeaderText = "Totalizador";
            this.Totalizador.Name = "Totalizador";
            this.Totalizador.ReadOnly = true;
            this.Totalizador.Visible = false;
            // 
            // LoteID
            // 
            this.LoteID.DataPropertyName = "LoteID";
            this.LoteID.HeaderText = "LoteID";
            this.LoteID.Name = "LoteID";
            this.LoteID.ReadOnly = true;
            this.LoteID.Visible = false;
            // 
            // DetalheID
            // 
            this.DetalheID.DataPropertyName = "DetalheID";
            this.DetalheID.HeaderText = "DetalheID";
            this.DetalheID.Name = "DetalheID";
            this.DetalheID.ReadOnly = true;
            this.DetalheID.Visible = false;
            // 
            // Transacao
            // 
            this.Transacao.DataPropertyName = "Transacao";
            this.Transacao.FillWeight = 180F;
            this.Transacao.HeaderText = "Transação";
            this.Transacao.MinimumWidth = 180;
            this.Transacao.Name = "Transacao";
            this.Transacao.ReadOnly = true;
            this.Transacao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Transacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Transacao.Width = 180;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Lote";
            this.dataGridViewTextBoxColumn7.HeaderText = "Lote";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DtMovimento
            // 
            this.DtMovimento.DataPropertyName = "DtMovimento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DtMovimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.DtMovimento.FillWeight = 72F;
            this.DtMovimento.HeaderText = "Data";
            this.DtMovimento.MinimumWidth = 72;
            this.DtMovimento.Name = "DtMovimento";
            this.DtMovimento.ReadOnly = true;
            this.DtMovimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DtMovimento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DtMovimento.Width = 72;
            // 
            // QtCotas
            // 
            this.QtCotas.DataPropertyName = "QtCotas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N6";
            dataGridViewCellStyle3.NullValue = null;
            this.QtCotas.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtCotas.FillWeight = 80F;
            this.QtCotas.HeaderText = "Qtde Cotas";
            this.QtCotas.MinimumWidth = 80;
            this.QtCotas.Name = "QtCotas";
            this.QtCotas.ReadOnly = true;
            this.QtCotas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtCotas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtCotas.Width = 80;
            // 
            // SaldoCotas
            // 
            this.SaldoCotas.DataPropertyName = "SaldoCotas";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N6";
            this.SaldoCotas.DefaultCellStyle = dataGridViewCellStyle4;
            this.SaldoCotas.FillWeight = 80F;
            this.SaldoCotas.HeaderText = "Saldo Cotas";
            this.SaldoCotas.MinimumWidth = 80;
            this.SaldoCotas.Name = "SaldoCotas";
            this.SaldoCotas.ReadOnly = true;
            this.SaldoCotas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SaldoCotas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SaldoCotas.Width = 80;
            // 
            // VrCotacaoDiaFormatado
            // 
            this.VrCotacaoDiaFormatado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VrCotacaoDiaFormatado.DataPropertyName = "VrCotacaoDiaFormatado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrCotacaoDiaFormatado.DefaultCellStyle = dataGridViewCellStyle5;
            this.VrCotacaoDiaFormatado.FillWeight = 95F;
            this.VrCotacaoDiaFormatado.HeaderText = "Cotação";
            this.VrCotacaoDiaFormatado.MinimumWidth = 95;
            this.VrCotacaoDiaFormatado.Name = "VrCotacaoDiaFormatado";
            this.VrCotacaoDiaFormatado.ReadOnly = true;
            this.VrCotacaoDiaFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrCotacaoDiaFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrCotacaoDiaFormatado.Width = 95;
            // 
            // VrCustoFormatado
            // 
            this.VrCustoFormatado.DataPropertyName = "VrCustoFormatado";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrCustoFormatado.DefaultCellStyle = dataGridViewCellStyle6;
            this.VrCustoFormatado.FillWeight = 90F;
            this.VrCustoFormatado.HeaderText = "Custo";
            this.VrCustoFormatado.MinimumWidth = 90;
            this.VrCustoFormatado.Name = "VrCustoFormatado";
            this.VrCustoFormatado.ReadOnly = true;
            this.VrCustoFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrCustoFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrCustoFormatado.Width = 90;
            // 
            // VrBrutoFormatado
            // 
            this.VrBrutoFormatado.DataPropertyName = "VrBrutoFormatado";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrBrutoFormatado.DefaultCellStyle = dataGridViewCellStyle7;
            this.VrBrutoFormatado.FillWeight = 90F;
            this.VrBrutoFormatado.HeaderText = "Vr Bruto";
            this.VrBrutoFormatado.Name = "VrBrutoFormatado";
            this.VrBrutoFormatado.ReadOnly = true;
            this.VrBrutoFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrBrutoFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrBrutoFormatado.Width = 90;
            // 
            // VrImpostosFormatado
            // 
            this.VrImpostosFormatado.DataPropertyName = "VrImpostosFormatado";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrImpostosFormatado.DefaultCellStyle = dataGridViewCellStyle8;
            this.VrImpostosFormatado.FillWeight = 65F;
            this.VrImpostosFormatado.HeaderText = "Impostos *";
            this.VrImpostosFormatado.Name = "VrImpostosFormatado";
            this.VrImpostosFormatado.ReadOnly = true;
            this.VrImpostosFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrImpostosFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrImpostosFormatado.ToolTipText = "IR e IOF";
            this.VrImpostosFormatado.Width = 65;
            // 
            // VrLiquidoFormatado
            // 
            this.VrLiquidoFormatado.DataPropertyName = "VrLiquidoFormatado";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrLiquidoFormatado.DefaultCellStyle = dataGridViewCellStyle9;
            this.VrLiquidoFormatado.FillWeight = 90F;
            this.VrLiquidoFormatado.HeaderText = "Vr Líquido";
            this.VrLiquidoFormatado.Name = "VrLiquidoFormatado";
            this.VrLiquidoFormatado.ReadOnly = true;
            this.VrLiquidoFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrLiquidoFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrLiquidoFormatado.Width = 90;
            // 
            // VrLucroOuPerda
            // 
            this.VrLucroOuPerda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VrLucroOuPerda.DataPropertyName = "VrLucroOuPerda";
            this.VrLucroOuPerda.HeaderText = "VrLucroOuPerda";
            this.VrLucroOuPerda.Name = "VrLucroOuPerda";
            this.VrLucroOuPerda.ReadOnly = true;
            this.VrLucroOuPerda.Visible = false;
            this.VrLucroOuPerda.Width = 111;
            // 
            // VrLucroOuPerdaFormatado
            // 
            this.VrLucroOuPerdaFormatado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VrLucroOuPerdaFormatado.DataPropertyName = "VrLucroOuPerdaFormatado";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VrLucroOuPerdaFormatado.DefaultCellStyle = dataGridViewCellStyle10;
            this.VrLucroOuPerdaFormatado.FillWeight = 80F;
            this.VrLucroOuPerdaFormatado.HeaderText = "Lucro/Perda";
            this.VrLucroOuPerdaFormatado.MinimumWidth = 60;
            this.VrLucroOuPerdaFormatado.Name = "VrLucroOuPerdaFormatado";
            this.VrLucroOuPerdaFormatado.ReadOnly = true;
            this.VrLucroOuPerdaFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VrLucroOuPerdaFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VrLucroOuPerdaFormatado.Width = 73;
            // 
            // PercLucroOuPerdaFormatado
            // 
            this.PercLucroOuPerdaFormatado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PercLucroOuPerdaFormatado.DataPropertyName = "PercLucroOuPerdaFormatado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PercLucroOuPerdaFormatado.DefaultCellStyle = dataGridViewCellStyle11;
            this.PercLucroOuPerdaFormatado.FillWeight = 82F;
            this.PercLucroOuPerdaFormatado.HeaderText = "% *";
            this.PercLucroOuPerdaFormatado.MinimumWidth = 70;
            this.PercLucroOuPerdaFormatado.Name = "PercLucroOuPerdaFormatado";
            this.PercLucroOuPerdaFormatado.ReadOnly = true;
            this.PercLucroOuPerdaFormatado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PercLucroOuPerdaFormatado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PercLucroOuPerdaFormatado.ToolTipText = "Porcentagem do Lucro ou da Perda";
            this.PercLucroOuPerdaFormatado.Width = 70;
            // 
            // Indicador
            // 
            this.Indicador.DataPropertyName = "Indicador";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Wingdings", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Indicador.DefaultCellStyle = dataGridViewCellStyle12;
            this.Indicador.FillWeight = 20F;
            this.Indicador.HeaderText = "";
            this.Indicador.MinimumWidth = 20;
            this.Indicador.Name = "Indicador";
            this.Indicador.ReadOnly = true;
            this.Indicador.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Indicador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Indicador.Width = 20;
            // 
            // fmCarteiraDetalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.investimentoDetalhesDataGridView);
            this.Name = "fmCarteiraDetalhe";
            this.Text = "fmCarteiraDetalhe";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.investimentoDetalhesDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDetalhesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource investimentoDetalhesBindingSource;
        private System.Windows.Forms.DataGridView investimentoDetalhesDataGridView;
        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totalizador;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetalheID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtMovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtCotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoCotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrCotacaoDiaFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrCustoFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrBrutoFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrImpostosFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrLiquidoFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrLucroOuPerda;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrLucroOuPerdaFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercLucroOuPerdaFormatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indicador;
    }
}
