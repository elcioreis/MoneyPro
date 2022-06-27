namespace MoneyPro
{
    partial class fmCarteiraVariacaoUltimosDiasUteis
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
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.variacaoDezDiasInvestimentosDataGridView = new System.Windows.Forms.DataGridView();
            this.variacao_VarR0102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_VarR0203 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_VarR0304 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_VarR0405 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanelRotulo = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUltimaAtualizacao = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.variacao_Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_ListaDatasISO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_TipoLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_InvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_RiscoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Dia01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Perc0102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Dia02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Perc0203 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Dia03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Perc0304 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Dia04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Perc0405 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Dia05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacao_Risco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacaoDezDiasInvestimentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelDataReferencia = new System.Windows.Forms.Label();
            this.dateTimePickerDataBase = new System.Windows.Forms.DateTimePicker();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoDezDiasInvestimentosDataGridView)).BeginInit();
            this.flowLayoutPanelRotulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoDezDiasInvestimentosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.flowLayoutPanelRotulo);
            this.panelRodape.Location = new System.Drawing.Point(0, 378);
            this.panelRodape.Size = new System.Drawing.Size(729, 37);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.flowLayoutPanelRotulo, 0);
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
            this.panelTopo.Controls.Add(this.labelDataReferencia);
            this.panelTopo.Controls.Add(this.dateTimePickerDataBase);
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Size = new System.Drawing.Size(729, 49);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            this.panelTopo.Controls.SetChildIndex(this.dateTimePickerDataBase, 0);
            this.panelTopo.Controls.SetChildIndex(this.labelDataReferencia, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(413, 32);
            this.labelTopo.Text = "Variação de Investimentos até";
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(685, 10);
            this.buttonFecharDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(31, 28);
            this.buttonFecharDetalhes.TabIndex = 18;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.ButtonFecharDetalhes_Click);
            // 
            // variacaoDezDiasInvestimentosDataGridView
            // 
            this.variacaoDezDiasInvestimentosDataGridView.AllowUserToAddRows = false;
            this.variacaoDezDiasInvestimentosDataGridView.AllowUserToDeleteRows = false;
            this.variacaoDezDiasInvestimentosDataGridView.AllowUserToResizeColumns = false;
            this.variacaoDezDiasInvestimentosDataGridView.AllowUserToResizeRows = false;
            this.variacaoDezDiasInvestimentosDataGridView.AutoGenerateColumns = false;
            this.variacaoDezDiasInvestimentosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variacaoDezDiasInvestimentosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variacao_Apelido,
            this.variacao_ListaDatasISO,
            this.variacao_Ordem,
            this.variacao_TipoLinha,
            this.variacao_InvestimentoID,
            this.variacao_ContaID,
            this.variacao_Tipo,
            this.variacao_RiscoID,
            this.variacao_Dia01,
            this.variacao_VarR0102,
            this.variacao_Perc0102,
            this.variacao_Dia02,
            this.variacao_VarR0203,
            this.variacao_Perc0203,
            this.variacao_Dia03,
            this.variacao_VarR0304,
            this.variacao_Perc0304,
            this.variacao_Dia04,
            this.variacao_VarR0405,
            this.variacao_Perc0405,
            this.variacao_Dia05,
            this.variacao_Risco});
            this.variacaoDezDiasInvestimentosDataGridView.DataSource = this.variacaoDezDiasInvestimentosBindingSource;
            this.variacaoDezDiasInvestimentosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variacaoDezDiasInvestimentosDataGridView.Location = new System.Drawing.Point(0, 49);
            this.variacaoDezDiasInvestimentosDataGridView.Name = "variacaoDezDiasInvestimentosDataGridView";
            this.variacaoDezDiasInvestimentosDataGridView.RowHeadersVisible = false;
            this.variacaoDezDiasInvestimentosDataGridView.RowHeadersWidth = 51;
            this.variacaoDezDiasInvestimentosDataGridView.RowTemplate.Height = 20;
            this.variacaoDezDiasInvestimentosDataGridView.RowTemplate.ReadOnly = true;
            this.variacaoDezDiasInvestimentosDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.variacaoDezDiasInvestimentosDataGridView.ShowCellToolTips = false;
            this.variacaoDezDiasInvestimentosDataGridView.Size = new System.Drawing.Size(729, 329);
            this.variacaoDezDiasInvestimentosDataGridView.TabIndex = 0;
            this.variacaoDezDiasInvestimentosDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.VariacaoDezDiasInvestimentosDataGridView_CellFormatting);
            this.variacaoDezDiasInvestimentosDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VariacaoDezDiasInvestimentosDataGridView_CellMouseMove);
            this.variacaoDezDiasInvestimentosDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.VariacaoDezDiasInvestimentosDataGridView_CellPainting);
            // 
            // variacao_VarR0102
            // 
            this.variacao_VarR0102.DataPropertyName = "VarR0102";
            this.variacao_VarR0102.HeaderText = "VarR0102";
            this.variacao_VarR0102.MinimumWidth = 6;
            this.variacao_VarR0102.Name = "variacao_VarR0102";
            this.variacao_VarR0102.Width = 125;
            // 
            // variacao_VarR0203
            // 
            this.variacao_VarR0203.DataPropertyName = "VarR0203";
            this.variacao_VarR0203.HeaderText = "VarR0203";
            this.variacao_VarR0203.MinimumWidth = 6;
            this.variacao_VarR0203.Name = "variacao_VarR0203";
            this.variacao_VarR0203.Width = 125;
            // 
            // variacao_VarR0304
            // 
            this.variacao_VarR0304.DataPropertyName = "VarR0304";
            this.variacao_VarR0304.HeaderText = "VarR0304";
            this.variacao_VarR0304.MinimumWidth = 6;
            this.variacao_VarR0304.Name = "variacao_VarR0304";
            this.variacao_VarR0304.Width = 125;
            // 
            // variacao_VarR0405
            // 
            this.variacao_VarR0405.DataPropertyName = "VarR0405";
            this.variacao_VarR0405.HeaderText = "VarR0405";
            this.variacao_VarR0405.MinimumWidth = 6;
            this.variacao_VarR0405.Name = "variacao_VarR0405";
            this.variacao_VarR0405.Width = 125;
            // 
            // flowLayoutPanelRotulo
            // 
            this.flowLayoutPanelRotulo.AutoSize = true;
            this.flowLayoutPanelRotulo.Controls.Add(this.labelUltimaAtualizacao);
            this.flowLayoutPanelRotulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRotulo.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelRotulo.Location = new System.Drawing.Point(616, 0);
            this.flowLayoutPanelRotulo.Name = "flowLayoutPanelRotulo";
            this.flowLayoutPanelRotulo.Size = new System.Drawing.Size(113, 37);
            this.flowLayoutPanelRotulo.TabIndex = 7;
            // 
            // labelUltimaAtualizacao
            // 
            this.labelUltimaAtualizacao.AutoSize = true;
            this.labelUltimaAtualizacao.BackColor = System.Drawing.Color.Gold;
            this.labelUltimaAtualizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelUltimaAtualizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimaAtualizacao.Location = new System.Drawing.Point(3, 10);
            this.labelUltimaAtualizacao.Margin = new System.Windows.Forms.Padding(3, 10, 8, 0);
            this.labelUltimaAtualizacao.Name = "labelUltimaAtualizacao";
            this.labelUltimaAtualizacao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelUltimaAtualizacao.Size = new System.Drawing.Size(102, 20);
            this.labelUltimaAtualizacao.TabIndex = 8;
            this.labelUltimaAtualizacao.Text = "Atualizado até";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip_Draw);
            // 
            // variacao_Apelido
            // 
            this.variacao_Apelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variacao_Apelido.DataPropertyName = "Apelido";
            this.variacao_Apelido.HeaderText = "Investimento";
            this.variacao_Apelido.MinimumWidth = 6;
            this.variacao_Apelido.Name = "variacao_Apelido";
            // 
            // variacao_ListaDatasISO
            // 
            this.variacao_ListaDatasISO.DataPropertyName = "ListaDatasISO";
            this.variacao_ListaDatasISO.HeaderText = "ListaDatasISO";
            this.variacao_ListaDatasISO.MinimumWidth = 6;
            this.variacao_ListaDatasISO.Name = "variacao_ListaDatasISO";
            this.variacao_ListaDatasISO.Visible = false;
            this.variacao_ListaDatasISO.Width = 125;
            // 
            // variacao_Ordem
            // 
            this.variacao_Ordem.DataPropertyName = "Ordem";
            this.variacao_Ordem.HeaderText = "Ordem";
            this.variacao_Ordem.MinimumWidth = 6;
            this.variacao_Ordem.Name = "variacao_Ordem";
            this.variacao_Ordem.Visible = false;
            this.variacao_Ordem.Width = 125;
            // 
            // variacao_TipoLinha
            // 
            this.variacao_TipoLinha.DataPropertyName = "TipoLinha";
            this.variacao_TipoLinha.HeaderText = "TipoLinha";
            this.variacao_TipoLinha.MinimumWidth = 6;
            this.variacao_TipoLinha.Name = "variacao_TipoLinha";
            this.variacao_TipoLinha.Visible = false;
            this.variacao_TipoLinha.Width = 125;
            // 
            // variacao_InvestimentoID
            // 
            this.variacao_InvestimentoID.DataPropertyName = "InvestimentoID";
            this.variacao_InvestimentoID.HeaderText = "InvestimentoID";
            this.variacao_InvestimentoID.MinimumWidth = 6;
            this.variacao_InvestimentoID.Name = "variacao_InvestimentoID";
            this.variacao_InvestimentoID.Visible = false;
            this.variacao_InvestimentoID.Width = 125;
            // 
            // variacao_ContaID
            // 
            this.variacao_ContaID.DataPropertyName = "ContaID";
            this.variacao_ContaID.HeaderText = "ContaID";
            this.variacao_ContaID.MinimumWidth = 6;
            this.variacao_ContaID.Name = "variacao_ContaID";
            this.variacao_ContaID.Visible = false;
            this.variacao_ContaID.Width = 125;
            // 
            // variacao_Tipo
            // 
            this.variacao_Tipo.DataPropertyName = "Tipo";
            this.variacao_Tipo.HeaderText = "Tipo";
            this.variacao_Tipo.MinimumWidth = 6;
            this.variacao_Tipo.Name = "variacao_Tipo";
            this.variacao_Tipo.Visible = false;
            this.variacao_Tipo.Width = 125;
            // 
            // variacao_RiscoID
            // 
            this.variacao_RiscoID.DataPropertyName = "RiscoID";
            this.variacao_RiscoID.HeaderText = "RiscoID";
            this.variacao_RiscoID.MinimumWidth = 6;
            this.variacao_RiscoID.Name = "variacao_RiscoID";
            this.variacao_RiscoID.Visible = false;
            this.variacao_RiscoID.Width = 125;
            // 
            // variacao_Dia01
            // 
            this.variacao_Dia01.DataPropertyName = "Dia01";
            this.variacao_Dia01.HeaderText = "Dia01";
            this.variacao_Dia01.MinimumWidth = 6;
            this.variacao_Dia01.Name = "variacao_Dia01";
            this.variacao_Dia01.Width = 125;
            // 
            // variacao_Perc0102
            // 
            this.variacao_Perc0102.DataPropertyName = "Perc0102";
            this.variacao_Perc0102.HeaderText = "Perc0102";
            this.variacao_Perc0102.MinimumWidth = 6;
            this.variacao_Perc0102.Name = "variacao_Perc0102";
            this.variacao_Perc0102.Width = 125;
            // 
            // variacao_Dia02
            // 
            this.variacao_Dia02.DataPropertyName = "Dia02";
            this.variacao_Dia02.HeaderText = "Dia02";
            this.variacao_Dia02.MinimumWidth = 6;
            this.variacao_Dia02.Name = "variacao_Dia02";
            this.variacao_Dia02.Width = 125;
            // 
            // variacao_Perc0203
            // 
            this.variacao_Perc0203.DataPropertyName = "Perc0203";
            this.variacao_Perc0203.HeaderText = "Perc0203";
            this.variacao_Perc0203.MinimumWidth = 6;
            this.variacao_Perc0203.Name = "variacao_Perc0203";
            this.variacao_Perc0203.Width = 125;
            // 
            // variacao_Dia03
            // 
            this.variacao_Dia03.DataPropertyName = "Dia03";
            this.variacao_Dia03.HeaderText = "Dia03";
            this.variacao_Dia03.MinimumWidth = 6;
            this.variacao_Dia03.Name = "variacao_Dia03";
            this.variacao_Dia03.Width = 125;
            // 
            // variacao_Perc0304
            // 
            this.variacao_Perc0304.DataPropertyName = "Perc0304";
            this.variacao_Perc0304.HeaderText = "Perc0304";
            this.variacao_Perc0304.MinimumWidth = 6;
            this.variacao_Perc0304.Name = "variacao_Perc0304";
            this.variacao_Perc0304.Width = 125;
            // 
            // variacao_Dia04
            // 
            this.variacao_Dia04.DataPropertyName = "Dia04";
            this.variacao_Dia04.HeaderText = "Dia04";
            this.variacao_Dia04.MinimumWidth = 6;
            this.variacao_Dia04.Name = "variacao_Dia04";
            this.variacao_Dia04.Width = 125;
            // 
            // variacao_Perc0405
            // 
            this.variacao_Perc0405.DataPropertyName = "Perc0405";
            this.variacao_Perc0405.HeaderText = "Perc0405";
            this.variacao_Perc0405.MinimumWidth = 6;
            this.variacao_Perc0405.Name = "variacao_Perc0405";
            this.variacao_Perc0405.Width = 125;
            // 
            // variacao_Dia05
            // 
            this.variacao_Dia05.DataPropertyName = "Dia05";
            this.variacao_Dia05.HeaderText = "Dia05";
            this.variacao_Dia05.MinimumWidth = 6;
            this.variacao_Dia05.Name = "variacao_Dia05";
            this.variacao_Dia05.Width = 125;
            // 
            // variacao_Risco
            // 
            this.variacao_Risco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.variacao_Risco.DataPropertyName = "Risco";
            this.variacao_Risco.HeaderText = "Risco";
            this.variacao_Risco.MinimumWidth = 70;
            this.variacao_Risco.Name = "variacao_Risco";
            this.variacao_Risco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.variacao_Risco.Width = 70;
            // 
            // variacaoDezDiasInvestimentosBindingSource
            // 
            this.variacaoDezDiasInvestimentosBindingSource.DataSource = typeof(Modelos.VariacaoUltimosDiasInvestimentos);
            // 
            // labelDataReferencia
            // 
            this.labelDataReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDataReferencia.AutoSize = true;
            this.labelDataReferencia.Location = new System.Drawing.Point(525, 16);
            this.labelDataReferencia.Name = "labelDataReferencia";
            this.labelDataReferencia.Size = new System.Drawing.Size(42, 17);
            this.labelDataReferencia.TabIndex = 22;
            this.labelDataReferencia.Text = "Data:";
            // 
            // dateTimePickerDataBase
            // 
            this.dateTimePickerDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDataBase.CustomFormat = "MM/yyyy";
            this.dateTimePickerDataBase.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataBase.Location = new System.Drawing.Point(573, 13);
            this.dateTimePickerDataBase.Name = "dateTimePickerDataBase";
            this.dateTimePickerDataBase.Size = new System.Drawing.Size(105, 22);
            this.dateTimePickerDataBase.TabIndex = 21;
            this.dateTimePickerDataBase.ValueChanged += new System.EventHandler(this.DateTimePickerDataBase_ValueChanged);
            // 
            // fmCarteiraVariacaoUltimosDiasUteis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(729, 415);
            this.Controls.Add(this.variacaoDezDiasInvestimentosDataGridView);
            this.Name = "fmCarteiraVariacaoUltimosDiasUteis";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FmCarteiraVariacaoUltimosDiasUteis_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.variacaoDezDiasInvestimentosDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoDezDiasInvestimentosDataGridView)).EndInit();
            this.flowLayoutPanelRotulo.ResumeLayout(false);
            this.flowLayoutPanelRotulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoDezDiasInvestimentosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.BindingSource variacaoDezDiasInvestimentosBindingSource;
        private System.Windows.Forms.DataGridView variacaoDezDiasInvestimentosDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRotulo;
        private System.Windows.Forms.Label labelUltimaAtualizacao;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_ListaDatasISO;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_TipoLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_InvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_RiscoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Dia01;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_VarR0102;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Perc0102;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Dia02;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_VarR0203;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Perc0203;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Dia03;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_VarR0304;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Perc0304;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Dia04;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_VarR0405;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Perc0405;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Dia05;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacao_Risco;
        private System.Windows.Forms.Label labelDataReferencia;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataBase;
    }
}
