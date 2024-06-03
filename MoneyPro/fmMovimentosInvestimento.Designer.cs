namespace MoneyPro
{
    partial class fmMovimentosInvestimento
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
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label investimentoIDLabel;
            System.Windows.Forms.Label transacaoIDLabel;
            System.Windows.Forms.Label qtCotasLabel;
            System.Windows.Forms.Label vrCotaLabel;
            System.Windows.Forms.Label vrDespesaLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vrSubTotal = new System.Windows.Forms.Label();
            this.vrTotal = new System.Windows.Forms.Label();
            this.panelTransacao = new System.Windows.Forms.Panel();
            this.transacaoIDComboBox = new System.Windows.Forms.ComboBox();
            this.movimentoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelMovimento = new System.Windows.Forms.Panel();
            this.CVMcheckBox = new System.Windows.Forms.CheckBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.lblFormulaTotal = new System.Windows.Forms.Label();
            this.vrLiquidoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vrDespesaTextBox = new System.Windows.Forms.TextBox();
            this.movimentoInvestimentoDespesaDataGridView = new System.Windows.Forms.DataGridView();
            this.MovimentoInvestimentoDespesaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoInvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Despesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parceiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movimentoInvestimentoDespesaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vrBrutoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vrCotaTextBox = new System.Windows.Forms.TextBox();
            this.qtCotasTextBox = new System.Windows.Forms.TextBox();
            this.investimentoIDComboBox = new System.Windows.Forms.ComboBox();
            this.investimentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.investimentoDespesaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonGravarCategoria = new System.Windows.Forms.Button();
            this.buttonCancelarCategoria = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            dataLabel = new System.Windows.Forms.Label();
            investimentoIDLabel = new System.Windows.Forms.Label();
            transacaoIDLabel = new System.Windows.Forms.Label();
            qtCotasLabel = new System.Windows.Forms.Label();
            vrCotaLabel = new System.Windows.Forms.Label();
            vrDespesaLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            this.panelTransacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transacaoBindingSource)).BeginInit();
            this.panelMovimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoInvestimentoDespesaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoInvestimentoDespesaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonGravarCategoria);
            this.panelRodape.Controls.Add(this.buttonCancelarCategoria);
            this.panelRodape.Location = new System.Drawing.Point(0, 439);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(913, 37);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonCancelarCategoria, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonGravarCategoria, 0);
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
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(913, 49);
            this.panelTopo.TabIndex = 0;
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(198, 32);
            this.labelTopo.Text = "Investimentos";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Location = new System.Drawing.Point(16, 14);
            dataLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(39, 16);
            dataLabel.TabIndex = 6;
            dataLabel.Text = "Data:";
            // 
            // investimentoIDLabel
            // 
            investimentoIDLabel.AutoSize = true;
            investimentoIDLabel.Location = new System.Drawing.Point(16, 46);
            investimentoIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            investimentoIDLabel.Name = "investimentoIDLabel";
            investimentoIDLabel.Size = new System.Drawing.Size(85, 16);
            investimentoIDLabel.TabIndex = 7;
            investimentoIDLabel.Text = "Investimento:";
            // 
            // transacaoIDLabel
            // 
            transacaoIDLabel.AutoSize = true;
            transacaoIDLabel.Location = new System.Drawing.Point(16, 15);
            transacaoIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            transacaoIDLabel.Name = "transacaoIDLabel";
            transacaoIDLabel.Size = new System.Drawing.Size(76, 16);
            transacaoIDLabel.TabIndex = 0;
            transacaoIDLabel.Text = "Transação:";
            // 
            // qtCotasLabel
            // 
            qtCotasLabel.AutoSize = true;
            qtCotasLabel.Location = new System.Drawing.Point(408, 14);
            qtCotasLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            qtCotasLabel.Name = "qtCotasLabel";
            qtCotasLabel.Size = new System.Drawing.Size(137, 16);
            qtCotasLabel.TabIndex = 7;
            qtCotasLabel.Text = "Quantidade de Cotas:";
            // 
            // vrCotaLabel
            // 
            vrCotaLabel.AutoSize = true;
            vrCotaLabel.Location = new System.Drawing.Point(408, 46);
            vrCotaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            vrCotaLabel.Name = "vrCotaLabel";
            vrCotaLabel.Size = new System.Drawing.Size(96, 16);
            vrCotaLabel.TabIndex = 8;
            vrCotaLabel.Text = "Preço da Cota:";
            // 
            // vrSubTotal
            // 
            this.vrSubTotal.AutoSize = true;
            this.vrSubTotal.Location = new System.Drawing.Point(408, 86);
            this.vrSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vrSubTotal.Name = "vrSubTotal";
            this.vrSubTotal.Size = new System.Drawing.Size(110, 16);
            this.vrSubTotal.TabIndex = 22;
            this.vrSubTotal.Text = "Valor Total Bruto:";
            // 
            // vrDespesaLabel
            // 
            vrDespesaLabel.AutoSize = true;
            vrDespesaLabel.Location = new System.Drawing.Point(408, 263);
            vrDespesaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            vrDespesaLabel.Name = "vrDespesaLabel";
            vrDespesaLabel.Size = new System.Drawing.Size(126, 16);
            vrDespesaLabel.TabIndex = 24;
            vrDespesaLabel.Text = "Total de Despesas:";
            // 
            // vrTotal
            // 
            this.vrTotal.AutoSize = true;
            this.vrTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vrTotal.Location = new System.Drawing.Point(408, 295);
            this.vrTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vrTotal.Name = "vrTotal";
            this.vrTotal.Size = new System.Drawing.Size(151, 17);
            this.vrTotal.TabIndex = 26;
            this.vrTotal.Text = "Valor Total Líquido:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(16, 86);
            descricaoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(72, 16);
            descricaoLabel.TabIndex = 28;
            descricaoLabel.Text = "Descrição:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(16, 114);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 16);
            label6.TabIndex = 29;
            label6.Text = "Despesas:";
            // 
            // panelTransacao
            // 
            this.panelTransacao.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTransacao.Controls.Add(transacaoIDLabel);
            this.panelTransacao.Controls.Add(this.transacaoIDComboBox);
            this.panelTransacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTransacao.Location = new System.Drawing.Point(0, 49);
            this.panelTransacao.Margin = new System.Windows.Forms.Padding(4);
            this.panelTransacao.Name = "panelTransacao";
            this.panelTransacao.Size = new System.Drawing.Size(913, 48);
            this.panelTransacao.TabIndex = 0;
            // 
            // transacaoIDComboBox
            // 
            this.transacaoIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.movimentoContaBindingSource, "TransacaoID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.transacaoIDComboBox.DataSource = this.transacaoBindingSource;
            this.transacaoIDComboBox.DisplayMember = "Apelido";
            this.transacaoIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transacaoIDComboBox.FormattingEnabled = true;
            this.transacaoIDComboBox.Location = new System.Drawing.Point(120, 11);
            this.transacaoIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.transacaoIDComboBox.Name = "transacaoIDComboBox";
            this.transacaoIDComboBox.Size = new System.Drawing.Size(257, 24);
            this.transacaoIDComboBox.TabIndex = 1;
            this.transacaoIDComboBox.ValueMember = "TransacaoID";
            this.transacaoIDComboBox.SelectedIndexChanged += new System.EventHandler(this.transacaoIDComboBox_SelectedIndexChanged);
            this.transacaoIDComboBox.Leave += new System.EventHandler(this.transacaoIDComboBox_Leave);
            // 
            // movimentoContaBindingSource
            // 
            this.movimentoContaBindingSource.DataSource = typeof(Modelos.MovimentoConta);
            this.movimentoContaBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.movimentoContaBindingSource_AddingNew);
            this.movimentoContaBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.movimentoContaBindingSource_BindingComplete);
            // 
            // transacaoBindingSource
            // 
            this.transacaoBindingSource.DataSource = typeof(Modelos.Transacao);
            // 
            // panelMovimento
            // 
            this.panelMovimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMovimento.Controls.Add(this.CVMcheckBox);
            this.panelMovimento.Controls.Add(label6);
            this.panelMovimento.Controls.Add(descricaoLabel);
            this.panelMovimento.Controls.Add(this.descricaoTextBox);
            this.panelMovimento.Controls.Add(this.lblFormulaTotal);
            this.panelMovimento.Controls.Add(this.vrTotal);
            this.panelMovimento.Controls.Add(this.vrLiquidoTextBox);
            this.panelMovimento.Controls.Add(this.label4);
            this.panelMovimento.Controls.Add(vrDespesaLabel);
            this.panelMovimento.Controls.Add(this.vrDespesaTextBox);
            this.panelMovimento.Controls.Add(this.movimentoInvestimentoDespesaDataGridView);
            this.panelMovimento.Controls.Add(this.label3);
            this.panelMovimento.Controls.Add(this.vrSubTotal);
            this.panelMovimento.Controls.Add(this.vrBrutoTextBox);
            this.panelMovimento.Controls.Add(this.label2);
            this.panelMovimento.Controls.Add(this.label1);
            this.panelMovimento.Controls.Add(this.panel2);
            this.panelMovimento.Controls.Add(vrCotaLabel);
            this.panelMovimento.Controls.Add(this.vrCotaTextBox);
            this.panelMovimento.Controls.Add(qtCotasLabel);
            this.panelMovimento.Controls.Add(this.qtCotasTextBox);
            this.panelMovimento.Controls.Add(investimentoIDLabel);
            this.panelMovimento.Controls.Add(this.investimentoIDComboBox);
            this.panelMovimento.Controls.Add(dataLabel);
            this.panelMovimento.Controls.Add(this.dataDateTimePicker);
            this.panelMovimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMovimento.Location = new System.Drawing.Point(0, 97);
            this.panelMovimento.Margin = new System.Windows.Forms.Padding(4);
            this.panelMovimento.Name = "panelMovimento";
            this.panelMovimento.Size = new System.Drawing.Size(913, 342);
            this.panelMovimento.TabIndex = 1;
            // 
            // CVMcheckBox
            // 
            this.CVMcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CVMcheckBox.AutoSize = true;
            this.CVMcheckBox.Location = new System.Drawing.Point(846, 44);
            this.CVMcheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CVMcheckBox.Name = "CVMcheckBox";
            this.CVMcheckBox.Size = new System.Drawing.Size(58, 20);
            this.CVMcheckBox.TabIndex = 30;
            this.CVMcheckBox.Text = "CVM";
            this.toolTip.SetToolTip(this.CVMcheckBox, "Informa se a cotação é proveniente da CVM");
            this.CVMcheckBox.UseVisualStyleBackColor = true;
            this.CVMcheckBox.CheckedChanged += new System.EventHandler(this.CVMcheckBox_CheckedChanged);
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.movimentoContaBindingSource, "Descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(119, 81);
            this.descricaoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(256, 22);
            this.descricaoTextBox.TabIndex = 2;
            // 
            // lblFormulaTotal
            // 
            this.lblFormulaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormulaTotal.AutoSize = true;
            this.lblFormulaTotal.Location = new System.Drawing.Point(809, 295);
            this.lblFormulaTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormulaTotal.Name = "lblFormulaTotal";
            this.lblFormulaTotal.Size = new System.Drawing.Size(61, 16);
            this.lblFormulaTotal.TabIndex = 28;
            this.lblFormulaTotal.Text = "e = (c - d)";
            // 
            // vrLiquidoTextBox
            // 
            this.vrLiquidoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vrLiquidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.movimentoContaBindingSource, "VrLiquido", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.vrLiquidoTextBox.Location = new System.Drawing.Point(581, 290);
            this.vrLiquidoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.vrLiquidoTextBox.Name = "vrLiquidoTextBox";
            this.vrLiquidoTextBox.Size = new System.Drawing.Size(159, 22);
            this.vrLiquidoTextBox.TabIndex = 8;
            this.vrLiquidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vrLiquidoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vrLiquidoTextBox_KeyDown);
            this.vrLiquidoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vrLiquidoTextBox_KeyPress);
            this.vrLiquidoTextBox.Leave += new System.EventHandler(this.vrLiquidoTextBox_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(809, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "d";
            // 
            // vrDespesaTextBox
            // 
            this.vrDespesaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vrDespesaTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.vrDespesaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.movimentoContaBindingSource, "VrDespesa", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.vrDespesaTextBox.Location = new System.Drawing.Point(581, 258);
            this.vrDespesaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.vrDespesaTextBox.Name = "vrDespesaTextBox";
            this.vrDespesaTextBox.ReadOnly = true;
            this.vrDespesaTextBox.Size = new System.Drawing.Size(159, 22);
            this.vrDespesaTextBox.TabIndex = 7;
            this.vrDespesaTextBox.TabStop = false;
            this.vrDespesaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // movimentoInvestimentoDespesaDataGridView
            // 
            this.movimentoInvestimentoDespesaDataGridView.AllowUserToAddRows = false;
            this.movimentoInvestimentoDespesaDataGridView.AllowUserToDeleteRows = false;
            this.movimentoInvestimentoDespesaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movimentoInvestimentoDespesaDataGridView.AutoGenerateColumns = false;
            this.movimentoInvestimentoDespesaDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.movimentoInvestimentoDespesaDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.movimentoInvestimentoDespesaDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.movimentoInvestimentoDespesaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movimentoInvestimentoDespesaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MovimentoInvestimentoDespesaID,
            this.MovimentoInvestimentoID,
            this.CategoriaID,
            this.Despesa,
            this.Parceiro,
            this.Valor});
            this.movimentoInvestimentoDespesaDataGridView.DataSource = this.movimentoInvestimentoDespesaBindingSource;
            this.movimentoInvestimentoDespesaDataGridView.Location = new System.Drawing.Point(119, 114);
            this.movimentoInvestimentoDespesaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.movimentoInvestimentoDespesaDataGridView.MultiSelect = false;
            this.movimentoInvestimentoDespesaDataGridView.Name = "movimentoInvestimentoDespesaDataGridView";
            this.movimentoInvestimentoDespesaDataGridView.RowHeadersVisible = false;
            this.movimentoInvestimentoDespesaDataGridView.RowHeadersWidth = 51;
            this.movimentoInvestimentoDespesaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.movimentoInvestimentoDespesaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.movimentoInvestimentoDespesaDataGridView.Size = new System.Drawing.Size(623, 137);
            this.movimentoInvestimentoDespesaDataGridView.TabIndex = 6;
            this.movimentoInvestimentoDespesaDataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.movimentoInvestimentoDespesaDataGridView_RowValidated);
            // 
            // MovimentoInvestimentoDespesaID
            // 
            this.MovimentoInvestimentoDespesaID.DataPropertyName = "MovimentoInvestimentoDespesaID";
            this.MovimentoInvestimentoDespesaID.Frozen = true;
            this.MovimentoInvestimentoDespesaID.HeaderText = "MovimentoInvestimentoDespesaID";
            this.MovimentoInvestimentoDespesaID.MinimumWidth = 6;
            this.MovimentoInvestimentoDespesaID.Name = "MovimentoInvestimentoDespesaID";
            this.MovimentoInvestimentoDespesaID.ReadOnly = true;
            this.MovimentoInvestimentoDespesaID.Visible = false;
            this.MovimentoInvestimentoDespesaID.Width = 125;
            // 
            // MovimentoInvestimentoID
            // 
            this.MovimentoInvestimentoID.DataPropertyName = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.Frozen = true;
            this.MovimentoInvestimentoID.HeaderText = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.MinimumWidth = 6;
            this.MovimentoInvestimentoID.Name = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.ReadOnly = true;
            this.MovimentoInvestimentoID.Visible = false;
            this.MovimentoInvestimentoID.Width = 125;
            // 
            // CategoriaID
            // 
            this.CategoriaID.DataPropertyName = "CategoriaID";
            this.CategoriaID.Frozen = true;
            this.CategoriaID.HeaderText = "CategoriaID";
            this.CategoriaID.MinimumWidth = 6;
            this.CategoriaID.Name = "CategoriaID";
            this.CategoriaID.Visible = false;
            this.CategoriaID.Width = 125;
            // 
            // Despesa
            // 
            this.Despesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Despesa.DataPropertyName = "Despesa";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Despesa.DefaultCellStyle = dataGridViewCellStyle3;
            this.Despesa.FillWeight = 150F;
            this.Despesa.Frozen = true;
            this.Despesa.HeaderText = "Despesa";
            this.Despesa.MinimumWidth = 150;
            this.Despesa.Name = "Despesa";
            this.Despesa.ReadOnly = true;
            this.Despesa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Despesa.Width = 150;
            // 
            // Parceiro
            // 
            this.Parceiro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Parceiro.DataPropertyName = "Parceiro";
            this.Parceiro.FillWeight = 90F;
            this.Parceiro.HeaderText = "Lançamento";
            this.Parceiro.MinimumWidth = 90;
            this.Parceiro.Name = "Parceiro";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F2";
            dataGridViewCellStyle4.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.FillWeight = 70F;
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.Width = 70;
            // 
            // movimentoInvestimentoDespesaBindingSource
            // 
            this.movimentoInvestimentoDespesaBindingSource.DataSource = typeof(Modelos.MovimentoInvestimentoDespesa);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "c = (a * b)";
            // 
            // vrBrutoTextBox
            // 
            this.vrBrutoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vrBrutoTextBox.Location = new System.Drawing.Point(581, 81);
            this.vrBrutoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.vrBrutoTextBox.Name = "vrBrutoTextBox";
            this.vrBrutoTextBox.Size = new System.Drawing.Size(156, 22);
            this.vrBrutoTextBox.TabIndex = 5;
            this.vrBrutoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vrBrutoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vrBrutoTextBox_KeyDown);
            this.vrBrutoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vrBrutoTextBox_KeyPress);
            this.vrBrutoTextBox.Leave += new System.EventHandler(this.vrBrutoTextBox_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(809, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "b";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(809, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "a";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(412, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 1);
            this.panel2.TabIndex = 20;
            // 
            // vrCotaTextBox
            // 
            this.vrCotaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vrCotaTextBox.Location = new System.Drawing.Point(581, 41);
            this.vrCotaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.vrCotaTextBox.Name = "vrCotaTextBox";
            this.vrCotaTextBox.Size = new System.Drawing.Size(212, 22);
            this.vrCotaTextBox.TabIndex = 4;
            this.vrCotaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vrCotaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vrCotaTextBox_KeyDown);
            this.vrCotaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vrCotaTextBox_KeyPress);
            this.vrCotaTextBox.Leave += new System.EventHandler(this.vrCotaTextBox_Leave);
            // 
            // qtCotasTextBox
            // 
            this.qtCotasTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtCotasTextBox.Location = new System.Drawing.Point(581, 9);
            this.qtCotasTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.qtCotasTextBox.Name = "qtCotasTextBox";
            this.qtCotasTextBox.Size = new System.Drawing.Size(212, 22);
            this.qtCotasTextBox.TabIndex = 3;
            this.qtCotasTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtCotasTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qtCotasTextBox_KeyDown);
            this.qtCotasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtCotasTextBox_KeyPress);
            this.qtCotasTextBox.Leave += new System.EventHandler(this.qtCotasTextBox_Leave);
            // 
            // investimentoIDComboBox
            // 
            this.investimentoIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.movimentoContaBindingSource, "InvestimentoID", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.investimentoIDComboBox.DataSource = this.investimentoBindingSource;
            this.investimentoIDComboBox.DisplayMember = "Apelido";
            this.investimentoIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.investimentoIDComboBox.FormattingEnabled = true;
            this.investimentoIDComboBox.Location = new System.Drawing.Point(117, 41);
            this.investimentoIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.investimentoIDComboBox.Name = "investimentoIDComboBox";
            this.investimentoIDComboBox.Size = new System.Drawing.Size(257, 24);
            this.investimentoIDComboBox.TabIndex = 1;
            this.investimentoIDComboBox.ValueMember = "InvestimentoID";
            this.investimentoIDComboBox.SelectedIndexChanged += new System.EventHandler(this.investimentoIDComboBox_SelectedIndexChanged);
            // 
            // investimentoBindingSource
            // 
            this.investimentoBindingSource.DataSource = typeof(Modelos.Investimento);
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.CustomFormat = "dddd, dd/MM/yyyy";
            this.dataDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.movimentoContaBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.dataDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataDateTimePicker.Location = new System.Drawing.Point(119, 9);
            this.dataDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(256, 22);
            this.dataDateTimePicker.TabIndex = 0;
            this.dataDateTimePicker.Leave += new System.EventHandler(this.dataDateTimePicker_Leave);
            // 
            // investimentoDespesaBindingSource
            // 
            this.investimentoDespesaBindingSource.DataSource = typeof(Modelos.InvestimentoDespesa);
            // 
            // buttonGravarCategoria
            // 
            this.buttonGravarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravarCategoria.Image = global::MoneyPro.Properties.Resources.ok;
            this.buttonGravarCategoria.Location = new System.Drawing.Point(828, 5);
            this.buttonGravarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGravarCategoria.Name = "buttonGravarCategoria";
            this.buttonGravarCategoria.Size = new System.Drawing.Size(31, 28);
            this.buttonGravarCategoria.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonGravarCategoria, "Gravar");
            this.buttonGravarCategoria.UseVisualStyleBackColor = true;
            this.buttonGravarCategoria.Click += new System.EventHandler(this.buttonGravarCategoria_Click);
            // 
            // buttonCancelarCategoria
            // 
            this.buttonCancelarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelarCategoria.Image = global::MoneyPro.Properties.Resources.cancela;
            this.buttonCancelarCategoria.Location = new System.Drawing.Point(866, 5);
            this.buttonCancelarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelarCategoria.Name = "buttonCancelarCategoria";
            this.buttonCancelarCategoria.Size = new System.Drawing.Size(31, 28);
            this.buttonCancelarCategoria.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonCancelarCategoria, "Cancelar");
            this.buttonCancelarCategoria.UseVisualStyleBackColor = true;
            this.buttonCancelarCategoria.Click += new System.EventHandler(this.buttonCancelarCategoria_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmMovimentosInvestimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(913, 476);
            this.Controls.Add(this.panelMovimento);
            this.Controls.Add(this.panelTransacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmMovimentosInvestimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MoneyPro";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FmMovimentosInvestimento_KeyPress);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.panelTransacao, 0);
            this.Controls.SetChildIndex(this.panelMovimento, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.panelTransacao.ResumeLayout(false);
            this.panelTransacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transacaoBindingSource)).EndInit();
            this.panelMovimento.ResumeLayout(false);
            this.panelMovimento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoInvestimentoDespesaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoInvestimentoDespesaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTransacao;
        private System.Windows.Forms.Panel panelMovimento;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.ComboBox investimentoIDComboBox;
        private System.Windows.Forms.BindingSource transacaoBindingSource;
        private System.Windows.Forms.ComboBox transacaoIDComboBox;
        private System.Windows.Forms.BindingSource investimentoBindingSource;
        private System.Windows.Forms.TextBox qtCotasTextBox;
        private System.Windows.Forms.TextBox vrCotaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox vrBrutoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource investimentoDespesaBindingSource;
        private System.Windows.Forms.DataGridView movimentoInvestimentoDespesaDataGridView;
        private System.Windows.Forms.BindingSource movimentoInvestimentoDespesaBindingSource;
        private System.Windows.Forms.BindingSource movimentoContaBindingSource;
//        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoInvestimentoDespesaID;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.TextBox vrDespesaTextBox;
        private System.Windows.Forms.Label lblFormulaTotal;
        private System.Windows.Forms.TextBox vrLiquidoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGravarCategoria;
        private System.Windows.Forms.Button buttonCancelarCategoria;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoInvestimentoDespesaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoInvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Despesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parceiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.CheckBox CVMcheckBox;
        private System.Windows.Forms.Label vrSubTotal;
        private System.Windows.Forms.Label vrTotal;
    }
}
