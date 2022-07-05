namespace MoneyPro
{
    partial class fmPlanejamentoManutencao
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
            System.Windows.Forms.Label apelidoLabel;
            System.Windows.Forms.Label contaIDLabel;
            System.Windows.Forms.Label categoriaIDLabel;
            System.Windows.Forms.Label grupoCategoriaIDLabel;
            System.Windows.Forms.Label valorLabel;
            System.Windows.Forms.Label lancamentoIDLabel;
            System.Windows.Forms.Label diaLabel;
            System.Windows.Forms.Label diferencaNaPrimeiraLabel;
            System.Windows.Forms.Label valorParcelaLabel;
            System.Windows.Forms.Label labelObservacao;
            this.repeticoesLabel = new System.Windows.Forms.Label();
            this.dtInicialLabel = new System.Windows.Forms.Label();
            this.apelidoTextBox = new System.Windows.Forms.TextBox();
            this.planejamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contaIDComboBox = new System.Windows.Forms.ComboBox();
            this.contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriaIDComboBox = new System.Windows.Forms.ComboBox();
            this.grupoCategoriaIDComboBox = new System.Windows.Forms.ComboBox();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.lancamentoIDComboBox = new System.Windows.Forms.ComboBox();
            this.totalComboBox = new System.Windows.Forms.ComboBox();
            this.dtInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.diaTextBox = new System.Windows.Forms.TextBox();
            this.diaFixoComboBox = new System.Windows.Forms.ComboBox();
            this.adiaSeNaoUtilComboBox = new System.Windows.Forms.ComboBox();
            this.diferencaNaPrimeiraComboBox = new System.Windows.Forms.ComboBox();
            this.repeticoesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGravarPlanejamento = new System.Windows.Forms.Button();
            this.buttonCancelarCategoria = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonEfetivarTodasParcelas = new System.Windows.Forms.Button();
            this.crdDebComboBox = new System.Windows.Forms.ComboBox();
            this.ativoCheckBox = new System.Windows.Forms.CheckBox();
            this.valorParcelaPanel = new System.Windows.Forms.Panel();
            this.valorParcelaTextBox = new System.Windows.Forms.TextBox();
            this.lancamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grupoCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            apelidoLabel = new System.Windows.Forms.Label();
            contaIDLabel = new System.Windows.Forms.Label();
            categoriaIDLabel = new System.Windows.Forms.Label();
            grupoCategoriaIDLabel = new System.Windows.Forms.Label();
            valorLabel = new System.Windows.Forms.Label();
            lancamentoIDLabel = new System.Windows.Forms.Label();
            diaLabel = new System.Windows.Forms.Label();
            diferencaNaPrimeiraLabel = new System.Windows.Forms.Label();
            valorParcelaLabel = new System.Windows.Forms.Label();
            labelObservacao = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).BeginInit();
            this.valorParcelaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoCategoriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonEfetivarTodasParcelas);
            this.panelRodape.Controls.Add(this.buttonGravarPlanejamento);
            this.panelRodape.Controls.Add(this.buttonCancelarCategoria);
            this.panelRodape.Location = new System.Drawing.Point(0, 448);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(460, 37);
            this.panelRodape.TabIndex = 16;
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonCancelarCategoria, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonGravarPlanejamento, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonEfetivarTodasParcelas, 0);
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
            this.panelTopo.Size = new System.Drawing.Size(460, 49);
            this.panelTopo.TabIndex = 4;
            // 
            // apelidoLabel
            // 
            apelidoLabel.AutoSize = true;
            apelidoLabel.Location = new System.Drawing.Point(12, 60);
            apelidoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            apelidoLabel.Name = "apelidoLabel";
            apelidoLabel.Size = new System.Drawing.Size(72, 16);
            apelidoLabel.TabIndex = 0;
            apelidoLabel.Text = "Descrição:";
            // 
            // contaIDLabel
            // 
            contaIDLabel.AutoSize = true;
            contaIDLabel.Location = new System.Drawing.Point(12, 92);
            contaIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            contaIDLabel.Name = "contaIDLabel";
            contaIDLabel.Size = new System.Drawing.Size(45, 16);
            contaIDLabel.TabIndex = 2;
            contaIDLabel.Text = "Conta:";
            // 
            // categoriaIDLabel
            // 
            categoriaIDLabel.AutoSize = true;
            categoriaIDLabel.Location = new System.Drawing.Point(12, 158);
            categoriaIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            categoriaIDLabel.Name = "categoriaIDLabel";
            categoriaIDLabel.Size = new System.Drawing.Size(69, 16);
            categoriaIDLabel.TabIndex = 6;
            categoriaIDLabel.Text = "Categoria:";
            // 
            // grupoCategoriaIDLabel
            // 
            grupoCategoriaIDLabel.AutoSize = true;
            grupoCategoriaIDLabel.Location = new System.Drawing.Point(12, 191);
            grupoCategoriaIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            grupoCategoriaIDLabel.Name = "grupoCategoriaIDLabel";
            grupoCategoriaIDLabel.Size = new System.Drawing.Size(47, 16);
            grupoCategoriaIDLabel.TabIndex = 8;
            grupoCategoriaIDLabel.Text = "Grupo:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new System.Drawing.Point(12, 254);
            valorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(42, 16);
            valorLabel.TabIndex = 10;
            valorLabel.Text = "Valor:";
            // 
            // lancamentoIDLabel
            // 
            lancamentoIDLabel.AutoSize = true;
            lancamentoIDLabel.Location = new System.Drawing.Point(12, 125);
            lancamentoIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lancamentoIDLabel.Name = "lancamentoIDLabel";
            lancamentoIDLabel.Size = new System.Drawing.Size(84, 16);
            lancamentoIDLabel.TabIndex = 4;
            lancamentoIDLabel.Text = "Lançamento:";
            // 
            // diaLabel
            // 
            diaLabel.AutoSize = true;
            diaLabel.Location = new System.Drawing.Point(12, 349);
            diaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            diaLabel.Name = "diaLabel";
            diaLabel.Size = new System.Drawing.Size(31, 16);
            diaLabel.TabIndex = 18;
            diaLabel.Text = "Dia:";
            // 
            // diferencaNaPrimeiraLabel
            // 
            diferencaNaPrimeiraLabel.AutoSize = true;
            diferencaNaPrimeiraLabel.Location = new System.Drawing.Point(12, 286);
            diferencaNaPrimeiraLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            diferencaNaPrimeiraLabel.Name = "diferencaNaPrimeiraLabel";
            diferencaNaPrimeiraLabel.Size = new System.Drawing.Size(68, 16);
            diferencaNaPrimeiraLabel.TabIndex = 14;
            diferencaNaPrimeiraLabel.Text = "Diferença:";
            // 
            // valorParcelaLabel
            // 
            valorParcelaLabel.AutoSize = true;
            valorParcelaLabel.Location = new System.Drawing.Point(12, 10);
            valorParcelaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            valorParcelaLabel.Name = "valorParcelaLabel";
            valorParcelaLabel.Size = new System.Drawing.Size(92, 16);
            valorParcelaLabel.TabIndex = 12;
            valorParcelaLabel.Text = "Valor Parcela:";
            // 
            // labelObservacao
            // 
            labelObservacao.AutoSize = true;
            labelObservacao.Location = new System.Drawing.Point(12, 223);
            labelObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelObservacao.Name = "labelObservacao";
            labelObservacao.Size = new System.Drawing.Size(85, 16);
            labelObservacao.TabIndex = 23;
            labelObservacao.Text = "Observação:";
            // 
            // repeticoesLabel
            // 
            this.repeticoesLabel.AutoSize = true;
            this.repeticoesLabel.Location = new System.Drawing.Point(12, 380);
            this.repeticoesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repeticoesLabel.Name = "repeticoesLabel";
            this.repeticoesLabel.Size = new System.Drawing.Size(64, 16);
            this.repeticoesLabel.TabIndex = 22;
            this.repeticoesLabel.Text = "Parcelas:";
            // 
            // dtInicialLabel
            // 
            this.dtInicialLabel.AutoSize = true;
            this.dtInicialLabel.Location = new System.Drawing.Point(12, 318);
            this.dtInicialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dtInicialLabel.Name = "dtInicialLabel";
            this.dtInicialLabel.Size = new System.Drawing.Size(89, 16);
            this.dtInicialLabel.TabIndex = 16;
            this.dtInicialLabel.Text = "Próxima data:";
            // 
            // apelidoTextBox
            // 
            this.apelidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "Apelido", true));
            this.apelidoTextBox.Location = new System.Drawing.Point(112, 57);
            this.apelidoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.apelidoTextBox.MaxLength = 100;
            this.apelidoTextBox.Name = "apelidoTextBox";
            this.apelidoTextBox.Size = new System.Drawing.Size(332, 22);
            this.apelidoTextBox.TabIndex = 0;
            this.apelidoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apelidoTextBox_KeyPress);
            // 
            // planejamentoBindingSource
            // 
            this.planejamentoBindingSource.DataSource = typeof(Modelos.Planejamento);
            // 
            // contaIDComboBox
            // 
            this.contaIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.planejamentoBindingSource, "ContaID", true));
            this.contaIDComboBox.DataSource = this.contaBindingSource;
            this.contaIDComboBox.DisplayMember = "Apelido";
            this.contaIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contaIDComboBox.FormattingEnabled = true;
            this.contaIDComboBox.Location = new System.Drawing.Point(112, 88);
            this.contaIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.contaIDComboBox.Name = "contaIDComboBox";
            this.contaIDComboBox.Size = new System.Drawing.Size(332, 24);
            this.contaIDComboBox.TabIndex = 1;
            this.contaIDComboBox.ValueMember = "ContaID";
            // 
            // contaBindingSource
            // 
            this.contaBindingSource.DataSource = typeof(Modelos.Conta);
            // 
            // categoriaIDComboBox
            // 
            this.categoriaIDComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.categoriaIDComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoriaIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.planejamentoBindingSource, "CategoriaID", true));
            this.categoriaIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "CategoriaID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.categoriaIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriaIDComboBox.FormattingEnabled = true;
            this.categoriaIDComboBox.Location = new System.Drawing.Point(112, 154);
            this.categoriaIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoriaIDComboBox.Name = "categoriaIDComboBox";
            this.categoriaIDComboBox.Size = new System.Drawing.Size(332, 24);
            this.categoriaIDComboBox.TabIndex = 3;
            // 
            // grupoCategoriaIDComboBox
            // 
            this.grupoCategoriaIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.planejamentoBindingSource, "GrupoCategoriaID", true));
            this.grupoCategoriaIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "GrupoCategoriaID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.grupoCategoriaIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grupoCategoriaIDComboBox.FormattingEnabled = true;
            this.grupoCategoriaIDComboBox.Location = new System.Drawing.Point(112, 187);
            this.grupoCategoriaIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.grupoCategoriaIDComboBox.Name = "grupoCategoriaIDComboBox";
            this.grupoCategoriaIDComboBox.Size = new System.Drawing.Size(332, 24);
            this.grupoCategoriaIDComboBox.TabIndex = 4;
            // 
            // valorTextBox
            // 
            this.valorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "Valor", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.valorTextBox.Location = new System.Drawing.Point(112, 251);
            this.valorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(107, 22);
            this.valorTextBox.TabIndex = 6;
            this.valorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorTextBox_KeyPress);
            // 
            // lancamentoIDComboBox
            // 
            this.lancamentoIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "LancamentoID", true));
            this.lancamentoIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lancamentoIDComboBox.FormattingEnabled = true;
            this.lancamentoIDComboBox.Location = new System.Drawing.Point(112, 121);
            this.lancamentoIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.lancamentoIDComboBox.Name = "lancamentoIDComboBox";
            this.lancamentoIDComboBox.Size = new System.Drawing.Size(332, 24);
            this.lancamentoIDComboBox.TabIndex = 2;
            // 
            // totalComboBox
            // 
            this.totalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.totalComboBox.FormattingEnabled = true;
            this.totalComboBox.Location = new System.Drawing.Point(329, 250);
            this.totalComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.totalComboBox.Name = "totalComboBox";
            this.totalComboBox.Size = new System.Drawing.Size(115, 24);
            this.totalComboBox.TabIndex = 8;
            this.totalComboBox.SelectedIndexChanged += new System.EventHandler(this.totalComboBox_SelectedIndexChanged);
            // 
            // dtInicialDateTimePicker
            // 
            this.dtInicialDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.planejamentoBindingSource, "DtInicial", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtInicialDateTimePicker.Location = new System.Drawing.Point(112, 315);
            this.dtInicialDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dtInicialDateTimePicker.Name = "dtInicialDateTimePicker";
            this.dtInicialDateTimePicker.Size = new System.Drawing.Size(332, 22);
            this.dtInicialDateTimePicker.TabIndex = 10;
            this.dtInicialDateTimePicker.ValueChanged += new System.EventHandler(this.dtInicialDateTimePicker_ValueChanged);
            // 
            // diaTextBox
            // 
            this.diaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "Dia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.diaTextBox.Location = new System.Drawing.Point(112, 346);
            this.diaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.diaTextBox.Name = "diaTextBox";
            this.diaTextBox.Size = new System.Drawing.Size(43, 22);
            this.diaTextBox.TabIndex = 11;
            this.diaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.diaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.diaTextBox_KeyPress);
            // 
            // diaFixoComboBox
            // 
            this.diaFixoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "DiaFixo", true));
            this.diaFixoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diaFixoComboBox.FormattingEnabled = true;
            this.diaFixoComboBox.Location = new System.Drawing.Point(164, 345);
            this.diaFixoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.diaFixoComboBox.Name = "diaFixoComboBox";
            this.diaFixoComboBox.Size = new System.Drawing.Size(80, 24);
            this.diaFixoComboBox.TabIndex = 12;
            // 
            // adiaSeNaoUtilComboBox
            // 
            this.adiaSeNaoUtilComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "AdiaSeNaoUtil", true));
            this.adiaSeNaoUtilComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adiaSeNaoUtilComboBox.FormattingEnabled = true;
            this.adiaSeNaoUtilComboBox.Location = new System.Drawing.Point(253, 345);
            this.adiaSeNaoUtilComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.adiaSeNaoUtilComboBox.Name = "adiaSeNaoUtilComboBox";
            this.adiaSeNaoUtilComboBox.Size = new System.Drawing.Size(191, 24);
            this.adiaSeNaoUtilComboBox.TabIndex = 13;
            // 
            // diferencaNaPrimeiraComboBox
            // 
            this.diferencaNaPrimeiraComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "DiferencaNaPrimeira", true));
            this.diferencaNaPrimeiraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diferencaNaPrimeiraComboBox.FormattingEnabled = true;
            this.diferencaNaPrimeiraComboBox.Location = new System.Drawing.Point(112, 282);
            this.diferencaNaPrimeiraComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.diferencaNaPrimeiraComboBox.Name = "diferencaNaPrimeiraComboBox";
            this.diferencaNaPrimeiraComboBox.Size = new System.Drawing.Size(332, 24);
            this.diferencaNaPrimeiraComboBox.TabIndex = 9;
            // 
            // repeticoesTextBox
            // 
            this.repeticoesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "Repeticoes", true));
            this.repeticoesTextBox.Location = new System.Drawing.Point(112, 377);
            this.repeticoesTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.repeticoesTextBox.MaxLength = 3;
            this.repeticoesTextBox.Name = "repeticoesTextBox";
            this.repeticoesTextBox.Size = new System.Drawing.Size(43, 22);
            this.repeticoesTextBox.TabIndex = 14;
            this.repeticoesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.repeticoesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.repeticoesTextBox_KeyPress);
            this.repeticoesTextBox.Leave += new System.EventHandler(this.repeticoesTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 380);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Zero se contínuo";
            // 
            // buttonGravarPlanejamento
            // 
            this.buttonGravarPlanejamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravarPlanejamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravarPlanejamento.Image = global::MoneyPro.Properties.Resources.ok;
            this.buttonGravarPlanejamento.Location = new System.Drawing.Point(383, 5);
            this.buttonGravarPlanejamento.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGravarPlanejamento.Name = "buttonGravarPlanejamento";
            this.buttonGravarPlanejamento.Size = new System.Drawing.Size(31, 28);
            this.buttonGravarPlanejamento.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonGravarPlanejamento, "Gravar planejamento");
            this.buttonGravarPlanejamento.UseVisualStyleBackColor = true;
            this.buttonGravarPlanejamento.Click += new System.EventHandler(this.buttonGravarPlanejamento_Click);
            // 
            // buttonCancelarCategoria
            // 
            this.buttonCancelarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelarCategoria.Image = global::MoneyPro.Properties.Resources.cancela;
            this.buttonCancelarCategoria.Location = new System.Drawing.Point(421, 5);
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
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonEfetivarTodasParcelas
            // 
            this.buttonEfetivarTodasParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEfetivarTodasParcelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEfetivarTodasParcelas.Image = global::MoneyPro.Properties.Resources.salvar;
            this.buttonEfetivarTodasParcelas.Location = new System.Drawing.Point(344, 5);
            this.buttonEfetivarTodasParcelas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEfetivarTodasParcelas.Name = "buttonEfetivarTodasParcelas";
            this.buttonEfetivarTodasParcelas.Size = new System.Drawing.Size(31, 28);
            this.buttonEfetivarTodasParcelas.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonEfetivarTodasParcelas, "Efetivar todas parcelas");
            this.buttonEfetivarTodasParcelas.UseVisualStyleBackColor = true;
            this.buttonEfetivarTodasParcelas.Click += new System.EventHandler(this.buttonEfetivarTodasParcelas_Click);
            // 
            // crdDebComboBox
            // 
            this.crdDebComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crdDebComboBox.FormattingEnabled = true;
            this.crdDebComboBox.Location = new System.Drawing.Point(228, 250);
            this.crdDebComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.crdDebComboBox.Name = "crdDebComboBox";
            this.crdDebComboBox.Size = new System.Drawing.Size(92, 24);
            this.crdDebComboBox.TabIndex = 7;
            // 
            // ativoCheckBox
            // 
            this.ativoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.planejamentoBindingSource, "Ativo", true));
            this.ativoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ativoCheckBox.Location = new System.Drawing.Point(384, 373);
            this.ativoCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ativoCheckBox.Name = "ativoCheckBox";
            this.ativoCheckBox.Size = new System.Drawing.Size(63, 30);
            this.ativoCheckBox.TabIndex = 15;
            this.ativoCheckBox.Text = "Ativo";
            this.ativoCheckBox.UseVisualStyleBackColor = true;
            // 
            // valorParcelaPanel
            // 
            this.valorParcelaPanel.Controls.Add(valorParcelaLabel);
            this.valorParcelaPanel.Controls.Add(this.valorParcelaTextBox);
            this.valorParcelaPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.valorParcelaPanel.Location = new System.Drawing.Point(0, 400);
            this.valorParcelaPanel.Name = "valorParcelaPanel";
            this.valorParcelaPanel.Size = new System.Drawing.Size(460, 48);
            this.valorParcelaPanel.TabIndex = 16;
            // 
            // valorParcelaTextBox
            // 
            this.valorParcelaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planejamentoBindingSource, "ValorParcela", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.valorParcelaTextBox.Location = new System.Drawing.Point(112, 7);
            this.valorParcelaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.valorParcelaTextBox.Name = "valorParcelaTextBox";
            this.valorParcelaTextBox.Size = new System.Drawing.Size(107, 22);
            this.valorParcelaTextBox.TabIndex = 16;
            this.valorParcelaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorParcelaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValorParcelaTextBox_KeyPress);
            // 
            // lancamentoBindingSource
            // 
            this.lancamentoBindingSource.DataSource = typeof(Modelos.Lancamento);
            // 
            // categoriaBindingSource
            // 
            this.categoriaBindingSource.DataSource = typeof(Modelos.Categoria);
            // 
            // grupoCategoriaBindingSource
            // 
            this.grupoCategoriaBindingSource.DataSource = typeof(Modelos.GrupoCategoria);
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.Location = new System.Drawing.Point(112, 220);
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(332, 22);
            this.observacaoTextBox.TabIndex = 5;
            // 
            // fmPlanejamentoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(460, 485);
            this.Controls.Add(this.observacaoTextBox);
            this.Controls.Add(labelObservacao);
            this.Controls.Add(this.valorParcelaPanel);
            this.Controls.Add(this.ativoCheckBox);
            this.Controls.Add(this.crdDebComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repeticoesLabel);
            this.Controls.Add(this.repeticoesTextBox);
            this.Controls.Add(diferencaNaPrimeiraLabel);
            this.Controls.Add(this.diferencaNaPrimeiraComboBox);
            this.Controls.Add(this.adiaSeNaoUtilComboBox);
            this.Controls.Add(this.diaFixoComboBox);
            this.Controls.Add(diaLabel);
            this.Controls.Add(this.diaTextBox);
            this.Controls.Add(this.dtInicialLabel);
            this.Controls.Add(this.dtInicialDateTimePicker);
            this.Controls.Add(this.totalComboBox);
            this.Controls.Add(lancamentoIDLabel);
            this.Controls.Add(this.lancamentoIDComboBox);
            this.Controls.Add(valorLabel);
            this.Controls.Add(this.valorTextBox);
            this.Controls.Add(grupoCategoriaIDLabel);
            this.Controls.Add(this.grupoCategoriaIDComboBox);
            this.Controls.Add(categoriaIDLabel);
            this.Controls.Add(this.categoriaIDComboBox);
            this.Controls.Add(contaIDLabel);
            this.Controls.Add(this.contaIDComboBox);
            this.Controls.Add(apelidoLabel);
            this.Controls.Add(this.apelidoTextBox);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmPlanejamentoManutencao";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmPlanejamentoManutencao_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.apelidoTextBox, 0);
            this.Controls.SetChildIndex(apelidoLabel, 0);
            this.Controls.SetChildIndex(this.contaIDComboBox, 0);
            this.Controls.SetChildIndex(contaIDLabel, 0);
            this.Controls.SetChildIndex(this.categoriaIDComboBox, 0);
            this.Controls.SetChildIndex(categoriaIDLabel, 0);
            this.Controls.SetChildIndex(this.grupoCategoriaIDComboBox, 0);
            this.Controls.SetChildIndex(grupoCategoriaIDLabel, 0);
            this.Controls.SetChildIndex(this.valorTextBox, 0);
            this.Controls.SetChildIndex(valorLabel, 0);
            this.Controls.SetChildIndex(this.lancamentoIDComboBox, 0);
            this.Controls.SetChildIndex(lancamentoIDLabel, 0);
            this.Controls.SetChildIndex(this.totalComboBox, 0);
            this.Controls.SetChildIndex(this.dtInicialDateTimePicker, 0);
            this.Controls.SetChildIndex(this.dtInicialLabel, 0);
            this.Controls.SetChildIndex(this.diaTextBox, 0);
            this.Controls.SetChildIndex(diaLabel, 0);
            this.Controls.SetChildIndex(this.diaFixoComboBox, 0);
            this.Controls.SetChildIndex(this.adiaSeNaoUtilComboBox, 0);
            this.Controls.SetChildIndex(this.diferencaNaPrimeiraComboBox, 0);
            this.Controls.SetChildIndex(diferencaNaPrimeiraLabel, 0);
            this.Controls.SetChildIndex(this.repeticoesTextBox, 0);
            this.Controls.SetChildIndex(this.repeticoesLabel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.crdDebComboBox, 0);
            this.Controls.SetChildIndex(this.ativoCheckBox, 0);
            this.Controls.SetChildIndex(this.valorParcelaPanel, 0);
            this.Controls.SetChildIndex(labelObservacao, 0);
            this.Controls.SetChildIndex(this.observacaoTextBox, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).EndInit();
            this.valorParcelaPanel.ResumeLayout(false);
            this.valorParcelaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoCategoriaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource planejamentoBindingSource;
        private System.Windows.Forms.TextBox apelidoTextBox;
        private System.Windows.Forms.ComboBox contaIDComboBox;
        private System.Windows.Forms.BindingSource contaBindingSource;
        private System.Windows.Forms.BindingSource lancamentoBindingSource;
        private System.Windows.Forms.BindingSource categoriaBindingSource;
        private System.Windows.Forms.ComboBox categoriaIDComboBox;
        private System.Windows.Forms.ComboBox grupoCategoriaIDComboBox;
        private System.Windows.Forms.BindingSource grupoCategoriaBindingSource;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.ComboBox lancamentoIDComboBox;
        private System.Windows.Forms.ComboBox totalComboBox;
        private System.Windows.Forms.DateTimePicker dtInicialDateTimePicker;
        private System.Windows.Forms.TextBox diaTextBox;
        private System.Windows.Forms.ComboBox diaFixoComboBox;
        private System.Windows.Forms.ComboBox adiaSeNaoUtilComboBox;
        private System.Windows.Forms.ComboBox diferencaNaPrimeiraComboBox;
        private System.Windows.Forms.TextBox repeticoesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGravarPlanejamento;
        private System.Windows.Forms.Button buttonCancelarCategoria;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox crdDebComboBox;
        private System.Windows.Forms.Label dtInicialLabel;
        private System.Windows.Forms.Label repeticoesLabel;
        private System.Windows.Forms.CheckBox ativoCheckBox;
        private System.Windows.Forms.Panel valorParcelaPanel;
        private System.Windows.Forms.TextBox valorParcelaTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.Button buttonEfetivarTodasParcelas;
    }
}
