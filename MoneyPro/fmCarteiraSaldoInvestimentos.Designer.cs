namespace MoneyPro
{
    partial class fmCarteiraSaldoInvestimentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.SaldoInvestimentosDataGridView = new System.Windows.Forms.DataGridView();
            this.saldoinicial_Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_TipoLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_SaldoInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_Entradas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_Saidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_saldoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_proventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_LucroPrejuizo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_LucroPrejuizoPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_PercTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_RiscoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoinicial_Risco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoInvestimentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelPeriodo = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.labelAte = new System.Windows.Forms.Label();
            this.flowLayoutPanelRotulo = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUltimaAtualizacao = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSaldoInvestimentos = new System.Windows.Forms.Button();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.buttonAno = new System.Windows.Forms.Button();
            this.buttonMesAnterior = new System.Windows.Forms.Button();
            this.buttonMes = new System.Windows.Forms.Button();
            this.button1M = new System.Windows.Forms.Button();
            this.button3M = new System.Windows.Forms.Button();
            this.button6M = new System.Windows.Forms.Button();
            this.button1A = new System.Windows.Forms.Button();
            this.buttonMaximo = new System.Windows.Forms.Button();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoInvestimentosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoInvestimentosBindingSource)).BeginInit();
            this.flowLayoutPanelRotulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRodape.Controls.Add(this.buttonMaximo);
            this.panelRodape.Controls.Add(this.button1A);
            this.panelRodape.Controls.Add(this.button6M);
            this.panelRodape.Controls.Add(this.button3M);
            this.panelRodape.Controls.Add(this.button1M);
            this.panelRodape.Controls.Add(this.buttonMes);
            this.panelRodape.Controls.Add(this.buttonMesAnterior);
            this.panelRodape.Controls.Add(this.buttonAno);
            this.panelRodape.Controls.Add(this.flowLayoutPanelRotulo);
            this.panelRodape.Location = new System.Drawing.Point(0, 409);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(3);
            this.panelRodape.Size = new System.Drawing.Size(754, 37);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.flowLayoutPanelRotulo, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonAno, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonMesAnterior, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonMes, 0);
            this.panelRodape.Controls.SetChildIndex(this.button1M, 0);
            this.panelRodape.Controls.SetChildIndex(this.button3M, 0);
            this.panelRodape.Controls.SetChildIndex(this.button6M, 0);
            this.panelRodape.Controls.SetChildIndex(this.button1A, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonMaximo, 0);
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
            this.panelTopo.Controls.Add(this.buttonSaldoInvestimentos);
            this.panelTopo.Controls.Add(this.dateTimePickerFim);
            this.panelTopo.Controls.Add(this.labelAte);
            this.panelTopo.Controls.Add(this.dateTimePickerInicio);
            this.panelTopo.Controls.Add(this.labelPeriodo);
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Size = new System.Drawing.Size(754, 49);
            this.panelTopo.TabIndex = 2;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            this.panelTopo.Controls.SetChildIndex(this.labelPeriodo, 0);
            this.panelTopo.Controls.SetChildIndex(this.dateTimePickerInicio, 0);
            this.panelTopo.Controls.SetChildIndex(this.labelAte, 0);
            this.panelTopo.Controls.SetChildIndex(this.dateTimePickerFim, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonSaldoInvestimentos, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(319, 32);
            this.labelTopo.Text = "Saldo de Investimentos";
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(710, 10);
            this.buttonFecharDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(31, 28);
            this.buttonFecharDetalhes.TabIndex = 18;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.ButtonFecharDetalhes_Click);
            // 
            // SaldoInvestimentosDataGridView
            // 
            this.SaldoInvestimentosDataGridView.AllowUserToAddRows = false;
            this.SaldoInvestimentosDataGridView.AllowUserToDeleteRows = false;
            this.SaldoInvestimentosDataGridView.AllowUserToResizeColumns = false;
            this.SaldoInvestimentosDataGridView.AllowUserToResizeRows = false;
            this.SaldoInvestimentosDataGridView.AutoGenerateColumns = false;
            this.SaldoInvestimentosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SaldoInvestimentosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.saldoinicial_Ordem,
            this.saldoinicial_TipoLinha,
            this.saldoinicial_Titulo,
            this.Consulta,
            this.saldoinicial_SaldoInicial,
            this.saldoinicial_Entradas,
            this.saldoinicial_Saidas,
            this.saldoinicial_saldoFinal,
            this.saldoinicial_proventos,
            this.saldoinicial_LucroPrejuizo,
            this.saldoinicial_LucroPrejuizoPerc,
            this.saldoinicial_PercTotal,
            this.saldoinicial_RiscoID,
            this.saldoinicial_Risco});
            this.SaldoInvestimentosDataGridView.DataSource = this.SaldoInvestimentosBindingSource;
            this.SaldoInvestimentosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaldoInvestimentosDataGridView.Location = new System.Drawing.Point(0, 49);
            this.SaldoInvestimentosDataGridView.Name = "SaldoInvestimentosDataGridView";
            this.SaldoInvestimentosDataGridView.ReadOnly = true;
            this.SaldoInvestimentosDataGridView.RowHeadersVisible = false;
            this.SaldoInvestimentosDataGridView.RowHeadersWidth = 51;
            this.SaldoInvestimentosDataGridView.RowTemplate.Height = 20;
            this.SaldoInvestimentosDataGridView.RowTemplate.ReadOnly = true;
            this.SaldoInvestimentosDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SaldoInvestimentosDataGridView.ShowCellToolTips = false;
            this.SaldoInvestimentosDataGridView.Size = new System.Drawing.Size(754, 360);
            this.SaldoInvestimentosDataGridView.TabIndex = 0;
            this.SaldoInvestimentosDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SaldoInvestimentosDataGridView_CellFormatting);
            // 
            // saldoinicial_Ordem
            // 
            this.saldoinicial_Ordem.DataPropertyName = "Ordem";
            this.saldoinicial_Ordem.HeaderText = "Ordem";
            this.saldoinicial_Ordem.MinimumWidth = 6;
            this.saldoinicial_Ordem.Name = "saldoinicial_Ordem";
            this.saldoinicial_Ordem.ReadOnly = true;
            this.saldoinicial_Ordem.Visible = false;
            this.saldoinicial_Ordem.Width = 125;
            // 
            // saldoinicial_TipoLinha
            // 
            this.saldoinicial_TipoLinha.DataPropertyName = "TipoLinha";
            this.saldoinicial_TipoLinha.HeaderText = "TipoLinha";
            this.saldoinicial_TipoLinha.MinimumWidth = 6;
            this.saldoinicial_TipoLinha.Name = "saldoinicial_TipoLinha";
            this.saldoinicial_TipoLinha.ReadOnly = true;
            this.saldoinicial_TipoLinha.Visible = false;
            this.saldoinicial_TipoLinha.Width = 125;
            // 
            // saldoinicial_Titulo
            // 
            this.saldoinicial_Titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.saldoinicial_Titulo.DataPropertyName = "Titulo";
            this.saldoinicial_Titulo.HeaderText = "Título";
            this.saldoinicial_Titulo.MinimumWidth = 100;
            this.saldoinicial_Titulo.Name = "saldoinicial_Titulo";
            this.saldoinicial_Titulo.ReadOnly = true;
            // 
            // Consulta
            // 
            this.Consulta.DataPropertyName = "Consulta";
            this.Consulta.HeaderText = "Consulta";
            this.Consulta.MinimumWidth = 6;
            this.Consulta.Name = "Consulta";
            this.Consulta.ReadOnly = true;
            this.Consulta.Width = 125;
            // 
            // saldoinicial_SaldoInicial
            // 
            this.saldoinicial_SaldoInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_SaldoInicial.DataPropertyName = "SaldoInicial";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.saldoinicial_SaldoInicial.DefaultCellStyle = dataGridViewCellStyle1;
            this.saldoinicial_SaldoInicial.HeaderText = "Saldo Inicial";
            this.saldoinicial_SaldoInicial.MinimumWidth = 6;
            this.saldoinicial_SaldoInicial.Name = "saldoinicial_SaldoInicial";
            this.saldoinicial_SaldoInicial.ReadOnly = true;
            this.saldoinicial_SaldoInicial.Width = 109;
            // 
            // saldoinicial_Entradas
            // 
            this.saldoinicial_Entradas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_Entradas.DataPropertyName = "Entradas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.saldoinicial_Entradas.DefaultCellStyle = dataGridViewCellStyle2;
            this.saldoinicial_Entradas.HeaderText = "Entradas";
            this.saldoinicial_Entradas.MinimumWidth = 6;
            this.saldoinicial_Entradas.Name = "saldoinicial_Entradas";
            this.saldoinicial_Entradas.ReadOnly = true;
            this.saldoinicial_Entradas.Width = 90;
            // 
            // saldoinicial_Saidas
            // 
            this.saldoinicial_Saidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_Saidas.DataPropertyName = "Saidas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.saldoinicial_Saidas.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldoinicial_Saidas.HeaderText = "Saídas";
            this.saldoinicial_Saidas.MinimumWidth = 6;
            this.saldoinicial_Saidas.Name = "saldoinicial_Saidas";
            this.saldoinicial_Saidas.ReadOnly = true;
            this.saldoinicial_Saidas.Width = 79;
            // 
            // saldoinicial_saldoFinal
            // 
            this.saldoinicial_saldoFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_saldoFinal.DataPropertyName = "SaldoFinal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.saldoinicial_saldoFinal.DefaultCellStyle = dataGridViewCellStyle4;
            this.saldoinicial_saldoFinal.HeaderText = "Saldo Final";
            this.saldoinicial_saldoFinal.MinimumWidth = 6;
            this.saldoinicial_saldoFinal.Name = "saldoinicial_saldoFinal";
            this.saldoinicial_saldoFinal.ReadOnly = true;
            this.saldoinicial_saldoFinal.Width = 104;
            // 
            // saldoinicial_proventos
            // 
            this.saldoinicial_proventos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_proventos.DataPropertyName = "Proventos";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.saldoinicial_proventos.DefaultCellStyle = dataGridViewCellStyle5;
            this.saldoinicial_proventos.HeaderText = "Proventos";
            this.saldoinicial_proventos.MinimumWidth = 6;
            this.saldoinicial_proventos.Name = "saldoinicial_proventos";
            this.saldoinicial_proventos.ReadOnly = true;
            this.saldoinicial_proventos.Width = 97;
            // 
            // saldoinicial_LucroPrejuizo
            // 
            this.saldoinicial_LucroPrejuizo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_LucroPrejuizo.DataPropertyName = "LucroPrejuizo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.saldoinicial_LucroPrejuizo.DefaultCellStyle = dataGridViewCellStyle6;
            this.saldoinicial_LucroPrejuizo.HeaderText = "Resultado";
            this.saldoinicial_LucroPrejuizo.MinimumWidth = 6;
            this.saldoinicial_LucroPrejuizo.Name = "saldoinicial_LucroPrejuizo";
            this.saldoinicial_LucroPrejuizo.ReadOnly = true;
            this.saldoinicial_LucroPrejuizo.Width = 98;
            // 
            // saldoinicial_LucroPrejuizoPerc
            // 
            this.saldoinicial_LucroPrejuizoPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_LucroPrejuizoPerc.DataPropertyName = "LucroPrejuizoPerc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.Format = "N4";
            this.saldoinicial_LucroPrejuizoPerc.DefaultCellStyle = dataGridViewCellStyle7;
            this.saldoinicial_LucroPrejuizoPerc.HeaderText = "Resultado %";
            this.saldoinicial_LucroPrejuizoPerc.MinimumWidth = 6;
            this.saldoinicial_LucroPrejuizoPerc.Name = "saldoinicial_LucroPrejuizoPerc";
            this.saldoinicial_LucroPrejuizoPerc.ReadOnly = true;
            this.saldoinicial_LucroPrejuizoPerc.Width = 113;
            // 
            // saldoinicial_PercTotal
            // 
            this.saldoinicial_PercTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_PercTotal.DataPropertyName = "PercTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N4";
            this.saldoinicial_PercTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.saldoinicial_PercTotal.HeaderText = "Total %";
            this.saldoinicial_PercTotal.MinimumWidth = 6;
            this.saldoinicial_PercTotal.Name = "saldoinicial_PercTotal";
            this.saldoinicial_PercTotal.ReadOnly = true;
            this.saldoinicial_PercTotal.Width = 82;
            // 
            // saldoinicial_RiscoID
            // 
            this.saldoinicial_RiscoID.DataPropertyName = "RiscoID";
            this.saldoinicial_RiscoID.HeaderText = "RiscoID";
            this.saldoinicial_RiscoID.MinimumWidth = 6;
            this.saldoinicial_RiscoID.Name = "saldoinicial_RiscoID";
            this.saldoinicial_RiscoID.ReadOnly = true;
            this.saldoinicial_RiscoID.Visible = false;
            this.saldoinicial_RiscoID.Width = 125;
            // 
            // saldoinicial_Risco
            // 
            this.saldoinicial_Risco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.saldoinicial_Risco.DataPropertyName = "Risco";
            this.saldoinicial_Risco.HeaderText = "Risco";
            this.saldoinicial_Risco.MinimumWidth = 6;
            this.saldoinicial_Risco.Name = "saldoinicial_Risco";
            this.saldoinicial_Risco.ReadOnly = true;
            this.saldoinicial_Risco.Width = 71;
            // 
            // SaldoInvestimentosBindingSource
            // 
            this.SaldoInvestimentosBindingSource.DataSource = typeof(Modelos.SaldoInvestimento);
            // 
            // labelPeriodo
            // 
            this.labelPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriodo.AutoSize = true;
            this.labelPeriodo.Location = new System.Drawing.Point(344, 16);
            this.labelPeriodo.Name = "labelPeriodo";
            this.labelPeriodo.Size = new System.Drawing.Size(55, 16);
            this.labelPeriodo.TabIndex = 20;
            this.labelPeriodo.Text = "Período";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerInicio.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(405, 13);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(110, 22);
            this.dateTimePickerInicio.TabIndex = 19;
            // 
            // labelAte
            // 
            this.labelAte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAte.AutoSize = true;
            this.labelAte.Location = new System.Drawing.Point(521, 16);
            this.labelAte.Name = "labelAte";
            this.labelAte.Size = new System.Drawing.Size(27, 16);
            this.labelAte.TabIndex = 21;
            this.labelAte.Text = "Até";
            // 
            // flowLayoutPanelRotulo
            // 
            this.flowLayoutPanelRotulo.AutoSize = true;
            this.flowLayoutPanelRotulo.Controls.Add(this.labelUltimaAtualizacao);
            this.flowLayoutPanelRotulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRotulo.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelRotulo.Location = new System.Drawing.Point(637, 0);
            this.flowLayoutPanelRotulo.Name = "flowLayoutPanelRotulo";
            this.flowLayoutPanelRotulo.Size = new System.Drawing.Size(113, 33);
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
            // buttonSaldoInvestimentos
            // 
            this.buttonSaldoInvestimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaldoInvestimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaldoInvestimentos.Image = global::MoneyPro.Properties.Resources.z16lupa;
            this.buttonSaldoInvestimentos.Location = new System.Drawing.Point(671, 10);
            this.buttonSaldoInvestimentos.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaldoInvestimentos.Name = "buttonSaldoInvestimentos";
            this.buttonSaldoInvestimentos.Size = new System.Drawing.Size(31, 28);
            this.buttonSaldoInvestimentos.TabIndex = 23;
            this.toolTip.SetToolTip(this.buttonSaldoInvestimentos, "Carrega o Saldo dos Investimentos");
            this.buttonSaldoInvestimentos.UseVisualStyleBackColor = true;
            this.buttonSaldoInvestimentos.Click += new System.EventHandler(this.buttonSaldoInvestimentos_Click);
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFim.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFim.Location = new System.Drawing.Point(554, 13);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(110, 22);
            this.dateTimePickerFim.TabIndex = 22;
            // 
            // buttonAno
            // 
            this.buttonAno.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAno.Location = new System.Drawing.Point(0, 0);
            this.buttonAno.Margin = new System.Windows.Forms.Padding(8);
            this.buttonAno.Name = "buttonAno";
            this.buttonAno.Size = new System.Drawing.Size(75, 33);
            this.buttonAno.TabIndex = 8;
            this.buttonAno.Text = "Ano";
            this.buttonAno.UseVisualStyleBackColor = true;
            this.buttonAno.Click += new System.EventHandler(this.buttonAno_Click);
            // 
            // buttonMesAnterior
            // 
            this.buttonMesAnterior.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMesAnterior.Location = new System.Drawing.Point(75, 0);
            this.buttonMesAnterior.Name = "buttonMesAnterior";
            this.buttonMesAnterior.Size = new System.Drawing.Size(75, 33);
            this.buttonMesAnterior.TabIndex = 15;
            this.buttonMesAnterior.Text = "Anterior";
            this.buttonMesAnterior.UseVisualStyleBackColor = true;
            this.buttonMesAnterior.Click += new System.EventHandler(this.buttonMesAnterior_Click);
            // 
            // buttonMes
            // 
            this.buttonMes.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMes.Location = new System.Drawing.Point(150, 0);
            this.buttonMes.Name = "buttonMes";
            this.buttonMes.Size = new System.Drawing.Size(75, 33);
            this.buttonMes.TabIndex = 9;
            this.buttonMes.Text = "Mes";
            this.buttonMes.UseVisualStyleBackColor = true;
            this.buttonMes.Click += new System.EventHandler(this.buttonMes_Click);
            // 
            // button1M
            // 
            this.button1M.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1M.Location = new System.Drawing.Point(225, 0);
            this.button1M.Name = "button1M";
            this.button1M.Size = new System.Drawing.Size(75, 33);
            this.button1M.TabIndex = 10;
            this.button1M.Text = "1 Mês";
            this.button1M.UseVisualStyleBackColor = true;
            this.button1M.Click += new System.EventHandler(this.button1M_Click);
            // 
            // button3M
            // 
            this.button3M.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3M.Location = new System.Drawing.Point(300, 0);
            this.button3M.Name = "button3M";
            this.button3M.Size = new System.Drawing.Size(75, 33);
            this.button3M.TabIndex = 11;
            this.button3M.Text = "3 Meses";
            this.button3M.UseVisualStyleBackColor = true;
            this.button3M.Click += new System.EventHandler(this.button3M_Click);
            // 
            // button6M
            // 
            this.button6M.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6M.Location = new System.Drawing.Point(375, 0);
            this.button6M.Name = "button6M";
            this.button6M.Size = new System.Drawing.Size(75, 33);
            this.button6M.TabIndex = 12;
            this.button6M.Text = "6 Meses";
            this.button6M.UseVisualStyleBackColor = true;
            this.button6M.Click += new System.EventHandler(this.button6M_Click);
            // 
            // button1A
            // 
            this.button1A.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1A.Location = new System.Drawing.Point(450, 0);
            this.button1A.Name = "button1A";
            this.button1A.Size = new System.Drawing.Size(75, 33);
            this.button1A.TabIndex = 13;
            this.button1A.Text = "1 Ano";
            this.button1A.UseVisualStyleBackColor = true;
            this.button1A.Click += new System.EventHandler(this.button1A_Click);
            // 
            // buttonMaximo
            // 
            this.buttonMaximo.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMaximo.Location = new System.Drawing.Point(525, 0);
            this.buttonMaximo.Name = "buttonMaximo";
            this.buttonMaximo.Size = new System.Drawing.Size(75, 33);
            this.buttonMaximo.TabIndex = 14;
            this.buttonMaximo.Text = "Máximo";
            this.buttonMaximo.UseVisualStyleBackColor = true;
            this.buttonMaximo.Click += new System.EventHandler(this.buttonMaximo_Click);
            // 
            // fmCarteiraSaldoInvestimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(754, 446);
            this.Controls.Add(this.SaldoInvestimentosDataGridView);
            this.Name = "fmCarteiraSaldoInvestimentos";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.SaldoInvestimentosDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoInvestimentosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoInvestimentosBindingSource)).EndInit();
            this.flowLayoutPanelRotulo.ResumeLayout(false);
            this.flowLayoutPanelRotulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.BindingSource SaldoInvestimentosBindingSource;
        private System.Windows.Forms.DataGridView SaldoInvestimentosDataGridView;
        private System.Windows.Forms.Label labelPeriodo;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRotulo;
        private System.Windows.Forms.Label labelUltimaAtualizacao;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelAte;
        private System.Windows.Forms.DateTimePicker dateTimePickerFim;
        private System.Windows.Forms.Button buttonSaldoInvestimentos;
        private System.Windows.Forms.Button buttonMes;
        private System.Windows.Forms.Button buttonAno;
        private System.Windows.Forms.Button button1A;
        private System.Windows.Forms.Button button6M;
        private System.Windows.Forms.Button button3M;
        private System.Windows.Forms.Button button1M;
        private System.Windows.Forms.Button buttonMaximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_TipoLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_SaldoInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_Entradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_Saidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_saldoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_proventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_LucroPrejuizo;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_LucroPrejuizoPerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_PercTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_RiscoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoinicial_Risco;
        private System.Windows.Forms.Button buttonMesAnterior;
    }
}
