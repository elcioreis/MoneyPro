namespace MoneyPro
{
    partial class fmInvestimentos
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnTiposInvestimentos = new System.Windows.Forms.Button();
            this.btnInstituicao = new System.Windows.Forms.Button();
            this.btnMoedas = new System.Windows.Forms.Button();
            this.buttonTaxas = new System.Windows.Forms.Button();
            this.btnTributacao = new System.Windows.Forms.Button();
            this.buttonGraficoComparativo = new System.Windows.Forms.Button();
            this.investimentoDataGridView = new System.Windows.Forms.DataGridView();
            this.investimentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoInvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstituicaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoedaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RiscoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoAnbima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxaAdministracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxaPerformance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InicialMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resgate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liquidacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ultimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAndHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DiaCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonTaxas);
            this.panelRodape.Location = new System.Drawing.Point(0, 377);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(1088, 37);
            this.panelRodape.TabIndex = 1;
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonTaxas, 0);
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
            this.panelTopo.Controls.Add(this.buttonGraficoComparativo);
            this.panelTopo.Controls.Add(this.btnTributacao);
            this.panelTopo.Controls.Add(this.btnInstituicao);
            this.panelTopo.Controls.Add(this.btnMoedas);
            this.panelTopo.Controls.Add(this.btnTiposInvestimentos);
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(1088, 49);
            this.panelTopo.TabIndex = 2;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnTiposInvestimentos, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnMoedas, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnInstituicao, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnTributacao, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonGraficoComparativo, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(367, 32);
            this.labelTopo.Text = "Cadastro de Investimentos";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // btnTiposInvestimentos
            // 
            this.btnTiposInvestimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTiposInvestimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiposInvestimentos.Image = global::MoneyPro.Properties.Resources.z16tipoInvestimento;
            this.btnTiposInvestimentos.Location = new System.Drawing.Point(925, 11);
            this.btnTiposInvestimentos.Margin = new System.Windows.Forms.Padding(4);
            this.btnTiposInvestimentos.Name = "btnTiposInvestimentos";
            this.btnTiposInvestimentos.Size = new System.Drawing.Size(31, 28);
            this.btnTiposInvestimentos.TabIndex = 0;
            this.btnTiposInvestimentos.TabStop = false;
            this.toolTip.SetToolTip(this.btnTiposInvestimentos, "Tipos de Investimentos");
            this.btnTiposInvestimentos.UseVisualStyleBackColor = true;
            this.btnTiposInvestimentos.Click += new System.EventHandler(this.btnTiposInvestimentos_Click);
            // 
            // btnInstituicao
            // 
            this.btnInstituicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstituicao.Image = global::MoneyPro.Properties.Resources.z16instituicao;
            this.btnInstituicao.Location = new System.Drawing.Point(964, 11);
            this.btnInstituicao.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstituicao.Name = "btnInstituicao";
            this.btnInstituicao.Size = new System.Drawing.Size(31, 28);
            this.btnInstituicao.TabIndex = 1;
            this.btnInstituicao.TabStop = false;
            this.toolTip.SetToolTip(this.btnInstituicao, "Instituições");
            this.btnInstituicao.UseVisualStyleBackColor = true;
            this.btnInstituicao.Click += new System.EventHandler(this.btnInstituicao_Click);
            // 
            // btnMoedas
            // 
            this.btnMoedas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoedas.Image = global::MoneyPro.Properties.Resources.z16moedas;
            this.btnMoedas.Location = new System.Drawing.Point(1041, 11);
            this.btnMoedas.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoedas.Name = "btnMoedas";
            this.btnMoedas.Size = new System.Drawing.Size(31, 28);
            this.btnMoedas.TabIndex = 3;
            this.btnMoedas.TabStop = false;
            this.toolTip.SetToolTip(this.btnMoedas, "Moedas");
            this.btnMoedas.UseVisualStyleBackColor = true;
            this.btnMoedas.Click += new System.EventHandler(this.btnMoedas_Click);
            // 
            // buttonTaxas
            // 
            this.buttonTaxas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaxas.Image = global::MoneyPro.Properties.Resources.z16taxas;
            this.buttonTaxas.Location = new System.Drawing.Point(81, 4);
            this.buttonTaxas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTaxas.Name = "buttonTaxas";
            this.buttonTaxas.Size = new System.Drawing.Size(31, 28);
            this.buttonTaxas.TabIndex = 2;
            this.buttonTaxas.TabStop = false;
            this.toolTip.SetToolTip(this.buttonTaxas, "Despesas sobre o investimento");
            this.buttonTaxas.UseVisualStyleBackColor = true;
            this.buttonTaxas.Click += new System.EventHandler(this.buttonTaxas_Click);
            // 
            // btnTributacao
            // 
            this.btnTributacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTributacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTributacao.Image = global::MoneyPro.Properties.Resources.z16tributacao;
            this.btnTributacao.Location = new System.Drawing.Point(1003, 11);
            this.btnTributacao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTributacao.Name = "btnTributacao";
            this.btnTributacao.Size = new System.Drawing.Size(31, 28);
            this.btnTributacao.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnTributacao, "Tributação");
            this.btnTributacao.UseVisualStyleBackColor = true;
            this.btnTributacao.Click += new System.EventHandler(this.btnTributacao_Click);
            // 
            // buttonGraficoComparativo
            // 
            this.buttonGraficoComparativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGraficoComparativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGraficoComparativo.Image = global::MoneyPro.Properties.Resources.z16grafico2linhas;
            this.buttonGraficoComparativo.Location = new System.Drawing.Point(887, 11);
            this.buttonGraficoComparativo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGraficoComparativo.Name = "buttonGraficoComparativo";
            this.buttonGraficoComparativo.Size = new System.Drawing.Size(31, 28);
            this.buttonGraficoComparativo.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonGraficoComparativo, "Gráfico Cotações");
            this.buttonGraficoComparativo.UseVisualStyleBackColor = true;
            this.buttonGraficoComparativo.Click += new System.EventHandler(this.buttonGraficoComparativo_Click);
            // 
            // investimentoDataGridView
            // 
            this.investimentoDataGridView.AllowUserToAddRows = false;
            this.investimentoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.investimentoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.investimentoDataGridView.AutoGenerateColumns = false;
            this.investimentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.investimentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvestimentoID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.TipoInvestimentoID,
            this.InstituicaoID,
            this.MoedaID,
            this.RiscoID,
            this.CodigoAnbima,
            this.Consulta,
            this.TaxaAdministracao,
            this.TaxaPerformance,
            this.InicialMinimo,
            this.MovimentoMinimo,
            this.SaldoMinimo,
            this.Aplicacao,
            this.Resgate,
            this.Liquidacao,
            this.DataInicio,
            this.Ultimo,
            this.BuyAndHold,
            this.DiaCom,
            this.Ativo});
            this.investimentoDataGridView.DataSource = this.investimentoBindingSource;
            this.investimentoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.investimentoDataGridView.Location = new System.Drawing.Point(0, 49);
            this.investimentoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.investimentoDataGridView.Name = "investimentoDataGridView";
            this.investimentoDataGridView.RowHeadersVisible = false;
            this.investimentoDataGridView.RowHeadersWidth = 51;
            this.investimentoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.investimentoDataGridView.Size = new System.Drawing.Size(1088, 328);
            this.investimentoDataGridView.TabIndex = 0;
            this.investimentoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.investimentoDataGridView_CellFormatting);
            this.investimentoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.investimentoDataGridView_EditingControlShowing);
            this.investimentoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.investimentoDataGridView_RowValidating);
            this.investimentoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.investimentoDataGridView_KeyPress);
            // 
            // investimentoBindingSource
            // 
            this.investimentoBindingSource.DataSource = typeof(Modelos.Investimento);
            // 
            // InvestimentoID
            // 
            this.InvestimentoID.DataPropertyName = "InvestimentoID";
            this.InvestimentoID.Frozen = true;
            this.InvestimentoID.HeaderText = "InvestimentoID";
            this.InvestimentoID.MinimumWidth = 6;
            this.InvestimentoID.Name = "InvestimentoID";
            this.InvestimentoID.Visible = false;
            this.InvestimentoID.Width = 125;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.Frozen = true;
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
            this.Apelido.Frozen = true;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 70;
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 83;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.FillWeight = 140F;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 140;
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 140;
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
            // InstituicaoID
            // 
            this.InstituicaoID.DataPropertyName = "InstituicaoID";
            this.InstituicaoID.HeaderText = "InstituicaoID";
            this.InstituicaoID.MinimumWidth = 6;
            this.InstituicaoID.Name = "InstituicaoID";
            this.InstituicaoID.Visible = false;
            this.InstituicaoID.Width = 125;
            // 
            // MoedaID
            // 
            this.MoedaID.DataPropertyName = "MoedaID";
            this.MoedaID.HeaderText = "MoedaID";
            this.MoedaID.MinimumWidth = 6;
            this.MoedaID.Name = "MoedaID";
            this.MoedaID.Visible = false;
            this.MoedaID.Width = 125;
            // 
            // RiscoID
            // 
            this.RiscoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RiscoID.DataPropertyName = "RiscoID";
            this.RiscoID.HeaderText = "RiscoID";
            this.RiscoID.MinimumWidth = 70;
            this.RiscoID.Name = "RiscoID";
            this.RiscoID.Visible = false;
            this.RiscoID.Width = 84;
            // 
            // CodigoAnbima
            // 
            this.CodigoAnbima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.CodigoAnbima.DataPropertyName = "CodigoAnbima";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "00000";
            dataGridViewCellStyle2.NullValue = null;
            this.CodigoAnbima.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodigoAnbima.FillWeight = 50F;
            this.CodigoAnbima.HeaderText = "Anbima";
            this.CodigoAnbima.MinimumWidth = 50;
            this.CodigoAnbima.Name = "CodigoAnbima";
            this.CodigoAnbima.ToolTipText = "Código Anbima";
            this.CodigoAnbima.Width = 50;
            // 
            // Consulta
            // 
            this.Consulta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Consulta.DataPropertyName = "Consulta";
            this.Consulta.HeaderText = "Consulta";
            this.Consulta.MinimumWidth = 80;
            this.Consulta.Name = "Consulta";
            this.Consulta.ToolTipText = "CNPJ do Fundo";
            this.Consulta.Width = 88;
            // 
            // TaxaAdministracao
            // 
            this.TaxaAdministracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TaxaAdministracao.DataPropertyName = "TaxaAdministracao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.TaxaAdministracao.DefaultCellStyle = dataGridViewCellStyle3;
            this.TaxaAdministracao.FillWeight = 70F;
            this.TaxaAdministracao.HeaderText = "Tx.Admin";
            this.TaxaAdministracao.MinimumWidth = 70;
            this.TaxaAdministracao.Name = "TaxaAdministracao";
            this.TaxaAdministracao.ToolTipText = "Taxa de Administração";
            this.TaxaAdministracao.Width = 70;
            // 
            // TaxaPerformance
            // 
            this.TaxaPerformance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TaxaPerformance.DataPropertyName = "TaxaPerformance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.TaxaPerformance.DefaultCellStyle = dataGridViewCellStyle4;
            this.TaxaPerformance.FillWeight = 70F;
            this.TaxaPerformance.HeaderText = "Tx.Perform";
            this.TaxaPerformance.MinimumWidth = 70;
            this.TaxaPerformance.Name = "TaxaPerformance";
            this.TaxaPerformance.ToolTipText = "Taxa de Performance";
            this.TaxaPerformance.Width = 70;
            // 
            // InicialMinimo
            // 
            this.InicialMinimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InicialMinimo.DataPropertyName = "InicialMinimo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.InicialMinimo.DefaultCellStyle = dataGridViewCellStyle5;
            this.InicialMinimo.FillWeight = 80F;
            this.InicialMinimo.HeaderText = "Aplicação";
            this.InicialMinimo.MinimumWidth = 80;
            this.InicialMinimo.Name = "InicialMinimo";
            this.InicialMinimo.ToolTipText = "Aplicação Inicial Mínima";
            this.InicialMinimo.Width = 80;
            // 
            // MovimentoMinimo
            // 
            this.MovimentoMinimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MovimentoMinimo.DataPropertyName = "MovimentoMinimo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.MovimentoMinimo.DefaultCellStyle = dataGridViewCellStyle6;
            this.MovimentoMinimo.FillWeight = 80F;
            this.MovimentoMinimo.HeaderText = "Movimento";
            this.MovimentoMinimo.MinimumWidth = 80;
            this.MovimentoMinimo.Name = "MovimentoMinimo";
            this.MovimentoMinimo.ToolTipText = "Movimentação Mínima";
            this.MovimentoMinimo.Width = 80;
            // 
            // SaldoMinimo
            // 
            this.SaldoMinimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaldoMinimo.DataPropertyName = "SaldoMinimo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.SaldoMinimo.DefaultCellStyle = dataGridViewCellStyle7;
            this.SaldoMinimo.FillWeight = 80F;
            this.SaldoMinimo.HeaderText = "Saldo";
            this.SaldoMinimo.MinimumWidth = 80;
            this.SaldoMinimo.Name = "SaldoMinimo";
            this.SaldoMinimo.ToolTipText = "Saldo de Permanência no Fundo";
            this.SaldoMinimo.Width = 80;
            // 
            // Aplicacao
            // 
            this.Aplicacao.DataPropertyName = "Aplicacao";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Aplicacao.DefaultCellStyle = dataGridViewCellStyle8;
            this.Aplicacao.FillWeight = 50F;
            this.Aplicacao.HeaderText = "Aplic.";
            this.Aplicacao.MinimumWidth = 50;
            this.Aplicacao.Name = "Aplicacao";
            this.Aplicacao.ToolTipText = "Aplicação";
            this.Aplicacao.Width = 50;
            // 
            // Resgate
            // 
            this.Resgate.DataPropertyName = "Resgate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Resgate.DefaultCellStyle = dataGridViewCellStyle9;
            this.Resgate.FillWeight = 50F;
            this.Resgate.HeaderText = "Resg.";
            this.Resgate.MinimumWidth = 50;
            this.Resgate.Name = "Resgate";
            this.Resgate.ToolTipText = "Resgate - Cotização";
            this.Resgate.Width = 50;
            // 
            // Liquidacao
            // 
            this.Liquidacao.DataPropertyName = "Liquidacao";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Liquidacao.DefaultCellStyle = dataGridViewCellStyle10;
            this.Liquidacao.FillWeight = 50F;
            this.Liquidacao.HeaderText = "Liquida";
            this.Liquidacao.MinimumWidth = 50;
            this.Liquidacao.Name = "Liquidacao";
            this.Liquidacao.ToolTipText = "Liquidação Financeira";
            this.Liquidacao.Width = 50;
            // 
            // DataInicio
            // 
            this.DataInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataInicio.DataPropertyName = "DataInicio";
            this.DataInicio.FillWeight = 70F;
            this.DataInicio.HeaderText = "Início";
            this.DataInicio.MinimumWidth = 50;
            this.DataInicio.Name = "DataInicio";
            this.DataInicio.ToolTipText = "Início do investimento";
            this.DataInicio.Width = 67;
            // 
            // Ultimo
            // 
            this.Ultimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ultimo.DataPropertyName = "Ultimo";
            this.Ultimo.FillWeight = 70F;
            this.Ultimo.HeaderText = "Última";
            this.Ultimo.MinimumWidth = 50;
            this.Ultimo.Name = "Ultimo";
            this.Ultimo.ToolTipText = "Última cotação disponível";
            this.Ultimo.Width = 74;
            // 
            // BuyAndHold
            // 
            this.BuyAndHold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BuyAndHold.DataPropertyName = "BuyAndHold";
            this.BuyAndHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuyAndHold.HeaderText = "B&H";
            this.BuyAndHold.MinimumWidth = 6;
            this.BuyAndHold.Name = "BuyAndHold";
            this.BuyAndHold.Width = 41;
            // 
            // DiaCom
            // 
            this.DiaCom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DiaCom.DataPropertyName = "DiaCom";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.DiaCom.DefaultCellStyle = dataGridViewCellStyle11;
            this.DiaCom.HeaderText = "DiaCom";
            this.DiaCom.MaxInputLength = 2;
            this.DiaCom.MinimumWidth = 6;
            this.DiaCom.Name = "DiaCom";
            this.DiaCom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiaCom.Width = 62;
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
            // fmInvestimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1088, 414);
            this.Controls.Add(this.investimentoDataGridView);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmInvestimentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmInvestimentos_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmInvestimentos_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.investimentoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnTiposInvestimentos;
        private System.Windows.Forms.BindingSource investimentoBindingSource;
        private System.Windows.Forms.DataGridView investimentoDataGridView;
        private System.Windows.Forms.Button btnInstituicao;
        private System.Windows.Forms.Button btnMoedas;
        private System.Windows.Forms.Button buttonTaxas;
        private System.Windows.Forms.Button btnTributacao;
        private System.Windows.Forms.Button buttonGraficoComparativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstituicaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoedaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RiscoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoAnbima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaAdministracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaPerformance;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicialMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resgate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liquidacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ultimo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BuyAndHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaCom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
