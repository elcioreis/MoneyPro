namespace MoneyPro
{
    partial class fmPagamentoCartaoCredito
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
            this.labelDataReferencia = new System.Windows.Forms.Label();
            this.dateTimePickerDataBase = new System.Windows.Forms.DateTimePicker();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.pagamentoCartaoCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pagamentoCartaoCreditoDataGridView = new System.Windows.Forms.DataGridView();
            this.pagamento_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_TipoLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Mes12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_Media = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento_DataReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanelRotulo = new System.Windows.Forms.FlowLayoutPanel();
            this.labelProximaFatura = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoCartaoCreditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoCartaoCreditoDataGridView)).BeginInit();
            this.flowLayoutPanelRotulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.flowLayoutPanelRotulo);
            this.panelRodape.Location = new System.Drawing.Point(0, 386);
            this.panelRodape.Size = new System.Drawing.Size(712, 37);
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
            this.panelTopo.Size = new System.Drawing.Size(712, 49);
            this.panelTopo.TabIndex = 1;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            this.panelTopo.Controls.SetChildIndex(this.dateTimePickerDataBase, 0);
            this.panelTopo.Controls.SetChildIndex(this.labelDataReferencia, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(446, 32);
            this.labelTopo.Text = "Pagamento de Cartão de Crédito";
            // 
            // labelDataReferencia
            // 
            this.labelDataReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDataReferencia.AutoSize = true;
            this.labelDataReferencia.Location = new System.Drawing.Point(489, 16);
            this.labelDataReferencia.Name = "labelDataReferencia";
            this.labelDataReferencia.Size = new System.Drawing.Size(67, 17);
            this.labelDataReferencia.TabIndex = 23;
            this.labelDataReferencia.Text = "Mês/Ano:";
            // 
            // dateTimePickerDataBase
            // 
            this.dateTimePickerDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDataBase.CustomFormat = "MM/yyyy";
            this.dateTimePickerDataBase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataBase.Location = new System.Drawing.Point(562, 13);
            this.dateTimePickerDataBase.Name = "dateTimePickerDataBase";
            this.dateTimePickerDataBase.Size = new System.Drawing.Size(99, 22);
            this.dateTimePickerDataBase.TabIndex = 22;
            this.dateTimePickerDataBase.ValueChanged += new System.EventHandler(this.DateTimePickerDataBase_ValueChanged);
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(668, 10);
            this.buttonFecharDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(31, 28);
            this.buttonFecharDetalhes.TabIndex = 21;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.ButtonFecharDetalhes_Click);
            // 
            // pagamentoCartaoCreditoBindingSource
            // 
            this.pagamentoCartaoCreditoBindingSource.DataSource = typeof(Modelos.PagamentoCartaoCredito);
            // 
            // pagamentoCartaoCreditoDataGridView
            // 
            this.pagamentoCartaoCreditoDataGridView.AllowUserToAddRows = false;
            this.pagamentoCartaoCreditoDataGridView.AllowUserToDeleteRows = false;
            this.pagamentoCartaoCreditoDataGridView.AllowUserToResizeColumns = false;
            this.pagamentoCartaoCreditoDataGridView.AllowUserToResizeRows = false;
            this.pagamentoCartaoCreditoDataGridView.AutoGenerateColumns = false;
            this.pagamentoCartaoCreditoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pagamentoCartaoCreditoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pagamento_Conta,
            this.pagamento_TipoLinha,
            this.pagamento_ContaID,
            this.pagamento_Mes01,
            this.pagamento_Mes02,
            this.pagamento_Mes03,
            this.pagamento_Mes04,
            this.pagamento_Mes05,
            this.pagamento_Mes06,
            this.pagamento_Mes07,
            this.pagamento_Mes08,
            this.pagamento_Mes09,
            this.pagamento_Mes10,
            this.pagamento_Mes11,
            this.pagamento_Mes12,
            this.pagamento_Total,
            this.pagamento_Media,
            this.pagamento_DataReferencia});
            this.pagamentoCartaoCreditoDataGridView.DataSource = this.pagamentoCartaoCreditoBindingSource;
            this.pagamentoCartaoCreditoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagamentoCartaoCreditoDataGridView.Location = new System.Drawing.Point(0, 49);
            this.pagamentoCartaoCreditoDataGridView.Name = "pagamentoCartaoCreditoDataGridView";
            this.pagamentoCartaoCreditoDataGridView.RowHeadersVisible = false;
            this.pagamentoCartaoCreditoDataGridView.RowHeadersWidth = 51;
            this.pagamentoCartaoCreditoDataGridView.RowTemplate.Height = 20;
            this.pagamentoCartaoCreditoDataGridView.Size = new System.Drawing.Size(712, 337);
            this.pagamentoCartaoCreditoDataGridView.TabIndex = 0;
            this.pagamentoCartaoCreditoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PagamentoCartaoCreditoDataGridView_CellFormatting);
            this.pagamentoCartaoCreditoDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PagamentoCartaoCreditoDataGridView_CellPainting);
            // 
            // pagamento_Conta
            // 
            this.pagamento_Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pagamento_Conta.DataPropertyName = "Conta";
            this.pagamento_Conta.HeaderText = "Conta";
            this.pagamento_Conta.MinimumWidth = 6;
            this.pagamento_Conta.Name = "pagamento_Conta";
            this.pagamento_Conta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pagamento_TipoLinha
            // 
            this.pagamento_TipoLinha.DataPropertyName = "TipoLinha";
            this.pagamento_TipoLinha.HeaderText = "TipoLinha";
            this.pagamento_TipoLinha.MinimumWidth = 6;
            this.pagamento_TipoLinha.Name = "pagamento_TipoLinha";
            this.pagamento_TipoLinha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_TipoLinha.Visible = false;
            this.pagamento_TipoLinha.Width = 125;
            // 
            // pagamento_ContaID
            // 
            this.pagamento_ContaID.DataPropertyName = "ContaID";
            this.pagamento_ContaID.HeaderText = "ContaID";
            this.pagamento_ContaID.MinimumWidth = 6;
            this.pagamento_ContaID.Name = "pagamento_ContaID";
            this.pagamento_ContaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_ContaID.Visible = false;
            this.pagamento_ContaID.Width = 125;
            // 
            // pagamento_Mes01
            // 
            this.pagamento_Mes01.DataPropertyName = "Mes01";
            this.pagamento_Mes01.HeaderText = "Mes01";
            this.pagamento_Mes01.MinimumWidth = 6;
            this.pagamento_Mes01.Name = "pagamento_Mes01";
            this.pagamento_Mes01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes01.Width = 125;
            // 
            // pagamento_Mes02
            // 
            this.pagamento_Mes02.DataPropertyName = "Mes02";
            this.pagamento_Mes02.HeaderText = "Mes02";
            this.pagamento_Mes02.MinimumWidth = 6;
            this.pagamento_Mes02.Name = "pagamento_Mes02";
            this.pagamento_Mes02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes02.Width = 125;
            // 
            // pagamento_Mes03
            // 
            this.pagamento_Mes03.DataPropertyName = "Mes03";
            this.pagamento_Mes03.HeaderText = "Mes03";
            this.pagamento_Mes03.MinimumWidth = 6;
            this.pagamento_Mes03.Name = "pagamento_Mes03";
            this.pagamento_Mes03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes03.Width = 125;
            // 
            // pagamento_Mes04
            // 
            this.pagamento_Mes04.DataPropertyName = "Mes04";
            this.pagamento_Mes04.HeaderText = "Mes04";
            this.pagamento_Mes04.MinimumWidth = 6;
            this.pagamento_Mes04.Name = "pagamento_Mes04";
            this.pagamento_Mes04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes04.Width = 125;
            // 
            // pagamento_Mes05
            // 
            this.pagamento_Mes05.DataPropertyName = "Mes05";
            this.pagamento_Mes05.HeaderText = "Mes05";
            this.pagamento_Mes05.MinimumWidth = 6;
            this.pagamento_Mes05.Name = "pagamento_Mes05";
            this.pagamento_Mes05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes05.Width = 125;
            // 
            // pagamento_Mes06
            // 
            this.pagamento_Mes06.DataPropertyName = "Mes06";
            this.pagamento_Mes06.HeaderText = "Mes06";
            this.pagamento_Mes06.MinimumWidth = 6;
            this.pagamento_Mes06.Name = "pagamento_Mes06";
            this.pagamento_Mes06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes06.Width = 125;
            // 
            // pagamento_Mes07
            // 
            this.pagamento_Mes07.DataPropertyName = "Mes07";
            this.pagamento_Mes07.HeaderText = "Mes07";
            this.pagamento_Mes07.MinimumWidth = 6;
            this.pagamento_Mes07.Name = "pagamento_Mes07";
            this.pagamento_Mes07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes07.Width = 125;
            // 
            // pagamento_Mes08
            // 
            this.pagamento_Mes08.DataPropertyName = "Mes08";
            this.pagamento_Mes08.HeaderText = "Mes08";
            this.pagamento_Mes08.MinimumWidth = 6;
            this.pagamento_Mes08.Name = "pagamento_Mes08";
            this.pagamento_Mes08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes08.Width = 125;
            // 
            // pagamento_Mes09
            // 
            this.pagamento_Mes09.DataPropertyName = "Mes09";
            this.pagamento_Mes09.HeaderText = "Mes09";
            this.pagamento_Mes09.MinimumWidth = 6;
            this.pagamento_Mes09.Name = "pagamento_Mes09";
            this.pagamento_Mes09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes09.Width = 125;
            // 
            // pagamento_Mes10
            // 
            this.pagamento_Mes10.DataPropertyName = "Mes10";
            this.pagamento_Mes10.HeaderText = "Mes10";
            this.pagamento_Mes10.MinimumWidth = 6;
            this.pagamento_Mes10.Name = "pagamento_Mes10";
            this.pagamento_Mes10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes10.Width = 125;
            // 
            // pagamento_Mes11
            // 
            this.pagamento_Mes11.DataPropertyName = "Mes11";
            this.pagamento_Mes11.HeaderText = "Mes11";
            this.pagamento_Mes11.MinimumWidth = 6;
            this.pagamento_Mes11.Name = "pagamento_Mes11";
            this.pagamento_Mes11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes11.Width = 125;
            // 
            // pagamento_Mes12
            // 
            this.pagamento_Mes12.DataPropertyName = "Mes12";
            this.pagamento_Mes12.HeaderText = "Mes12";
            this.pagamento_Mes12.MinimumWidth = 6;
            this.pagamento_Mes12.Name = "pagamento_Mes12";
            this.pagamento_Mes12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Mes12.Width = 125;
            // 
            // pagamento_Total
            // 
            this.pagamento_Total.DataPropertyName = "Total";
            this.pagamento_Total.HeaderText = "Total";
            this.pagamento_Total.MinimumWidth = 6;
            this.pagamento_Total.Name = "pagamento_Total";
            this.pagamento_Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Total.Width = 125;
            // 
            // pagamento_Media
            // 
            this.pagamento_Media.DataPropertyName = "Media";
            this.pagamento_Media.HeaderText = "Media";
            this.pagamento_Media.MinimumWidth = 6;
            this.pagamento_Media.Name = "pagamento_Media";
            this.pagamento_Media.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_Media.Width = 125;
            // 
            // pagamento_DataReferencia
            // 
            this.pagamento_DataReferencia.DataPropertyName = "DataReferencia";
            this.pagamento_DataReferencia.HeaderText = "DataReferencia";
            this.pagamento_DataReferencia.MinimumWidth = 6;
            this.pagamento_DataReferencia.Name = "pagamento_DataReferencia";
            this.pagamento_DataReferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pagamento_DataReferencia.Visible = false;
            this.pagamento_DataReferencia.Width = 125;
            // 
            // flowLayoutPanelRotulo
            // 
            this.flowLayoutPanelRotulo.AutoSize = true;
            this.flowLayoutPanelRotulo.Controls.Add(this.labelProximaFatura);
            this.flowLayoutPanelRotulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRotulo.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelRotulo.Location = new System.Drawing.Point(599, 0);
            this.flowLayoutPanelRotulo.Name = "flowLayoutPanelRotulo";
            this.flowLayoutPanelRotulo.Size = new System.Drawing.Size(113, 37);
            this.flowLayoutPanelRotulo.TabIndex = 8;
            // 
            // labelProximaFatura
            // 
            this.labelProximaFatura.AutoSize = true;
            this.labelProximaFatura.BackColor = System.Drawing.Color.Gold;
            this.labelProximaFatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProximaFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProximaFatura.Location = new System.Drawing.Point(3, 10);
            this.labelProximaFatura.Margin = new System.Windows.Forms.Padding(3, 10, 8, 0);
            this.labelProximaFatura.Name = "labelProximaFatura";
            this.labelProximaFatura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelProximaFatura.Size = new System.Drawing.Size(102, 20);
            this.labelProximaFatura.TabIndex = 8;
            this.labelProximaFatura.Text = "Atualizado até";
            // 
            // fmPagamentoCartaoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(712, 423);
            this.Controls.Add(this.pagamentoCartaoCreditoDataGridView);
            this.Name = "fmPagamentoCartaoCredito";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FmPagamentoCartaoCredito_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.pagamentoCartaoCreditoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoCartaoCreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoCartaoCreditoDataGridView)).EndInit();
            this.flowLayoutPanelRotulo.ResumeLayout(false);
            this.flowLayoutPanelRotulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDataReferencia;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataBase;
        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.BindingSource pagamentoCartaoCreditoBindingSource;
        private System.Windows.Forms.DataGridView pagamentoCartaoCreditoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_TipoLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes01;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes02;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes03;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes04;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes05;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes06;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes07;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes08;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes09;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes10;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes11;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Mes12;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_Media;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagamento_DataReferencia;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRotulo;
        private System.Windows.Forms.Label labelProximaFatura;
    }
}
