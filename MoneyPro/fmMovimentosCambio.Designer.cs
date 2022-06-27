namespace MoneyPro
{
    partial class fmMovimentosCambio
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
            System.Windows.Forms.Label transacaoIDLabel;
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label cotacaoLabel;
            this.labelContaDestino = new System.Windows.Forms.Label();
            this.simboloDestinoLabel = new System.Windows.Forms.Label();
            this.simboloOrigemLabel = new System.Windows.Forms.Label();
            this.panelTransacao = new System.Windows.Forms.Panel();
            this.contaDestinoComboBox = new System.Windows.Forms.ComboBox();
            this.contaDestinoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transacaoComboBox = new System.Windows.Forms.ComboBox();
            this.transacaoCambioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelMovimento = new System.Windows.Forms.Panel();
            this.cotacaoTextBox = new System.Windows.Forms.TextBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.origemRadioButton = new System.Windows.Forms.RadioButton();
            this.destinoRadioButton = new System.Windows.Forms.RadioButton();
            this.taxaLabel = new System.Windows.Forms.Label();
            this.taxaTextBox = new System.Windows.Forms.TextBox();
            this.valorDestinoTextBox = new System.Windows.Forms.TextBox();
            this.valorOrigemTextBox = new System.Windows.Forms.TextBox();
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonGravarCategoria = new System.Windows.Forms.Button();
            this.buttonCancelarCategoria = new System.Windows.Forms.Button();
            transacaoIDLabel = new System.Windows.Forms.Label();
            dataLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            cotacaoLabel = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            this.panelTransacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaDestinoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transacaoCambioBindingSource)).BeginInit();
            this.panelMovimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonGravarCategoria);
            this.panelRodape.Controls.Add(this.buttonCancelarCategoria);
            this.panelRodape.Location = new System.Drawing.Point(0, 376);
            this.panelRodape.Size = new System.Drawing.Size(459, 37);
            this.panelRodape.TabIndex = 2;
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonCancelarCategoria, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonGravarCategoria, 0);
            // 
            // panelTopo
            // 
            this.panelTopo.Size = new System.Drawing.Size(459, 49);
            // 
            // transacaoIDLabel
            // 
            transacaoIDLabel.AutoSize = true;
            transacaoIDLabel.Location = new System.Drawing.Point(16, 47);
            transacaoIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            transacaoIDLabel.Name = "transacaoIDLabel";
            transacaoIDLabel.Size = new System.Drawing.Size(80, 17);
            transacaoIDLabel.TabIndex = 0;
            transacaoIDLabel.Text = "Transação:";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Location = new System.Drawing.Point(16, 12);
            dataLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(89, 17);
            dataLabel.TabIndex = 6;
            dataLabel.Text = "Data e Hora:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(15, 103);
            descricaoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(75, 17);
            descricaoLabel.TabIndex = 30;
            descricaoLabel.Text = "Descrição:";
            // 
            // cotacaoLabel
            // 
            cotacaoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            cotacaoLabel.AutoSize = true;
            cotacaoLabel.Location = new System.Drawing.Point(15, 152);
            cotacaoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cotacaoLabel.Name = "cotacaoLabel";
            cotacaoLabel.Size = new System.Drawing.Size(64, 17);
            cotacaoLabel.TabIndex = 32;
            cotacaoLabel.Text = "Cotação:";
            // 
            // labelContaDestino
            // 
            this.labelContaDestino.AutoSize = true;
            this.labelContaDestino.Location = new System.Drawing.Point(16, 15);
            this.labelContaDestino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContaDestino.Name = "labelContaDestino";
            this.labelContaDestino.Size = new System.Drawing.Size(101, 17);
            this.labelContaDestino.TabIndex = 2;
            this.labelContaDestino.Text = "Conta Destino:";
            // 
            // simboloDestinoLabel
            // 
            this.simboloDestinoLabel.AutoSize = true;
            this.simboloDestinoLabel.Location = new System.Drawing.Point(16, 72);
            this.simboloDestinoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.simboloDestinoLabel.Name = "simboloDestinoLabel";
            this.simboloDestinoLabel.Size = new System.Drawing.Size(76, 17);
            this.simboloDestinoLabel.TabIndex = 8;
            this.simboloDestinoLabel.Text = "Valor em...";
            // 
            // simboloOrigemLabel
            // 
            this.simboloOrigemLabel.AutoSize = true;
            this.simboloOrigemLabel.Location = new System.Drawing.Point(16, 42);
            this.simboloOrigemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.simboloOrigemLabel.Name = "simboloOrigemLabel";
            this.simboloOrigemLabel.Size = new System.Drawing.Size(76, 17);
            this.simboloOrigemLabel.TabIndex = 7;
            this.simboloOrigemLabel.Text = "Valor em...";
            // 
            // panelTransacao
            // 
            this.panelTransacao.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTransacao.Controls.Add(this.contaDestinoComboBox);
            this.panelTransacao.Controls.Add(this.labelContaDestino);
            this.panelTransacao.Controls.Add(transacaoIDLabel);
            this.panelTransacao.Controls.Add(this.transacaoComboBox);
            this.panelTransacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTransacao.Location = new System.Drawing.Point(0, 49);
            this.panelTransacao.Margin = new System.Windows.Forms.Padding(4);
            this.panelTransacao.Name = "panelTransacao";
            this.panelTransacao.Size = new System.Drawing.Size(459, 83);
            this.panelTransacao.TabIndex = 0;
            // 
            // contaDestinoComboBox
            // 
            this.contaDestinoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contaDestinoComboBox.DataSource = this.contaDestinoBindingSource;
            this.contaDestinoComboBox.DisplayMember = "Apelido";
            this.contaDestinoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contaDestinoComboBox.FormattingEnabled = true;
            this.contaDestinoComboBox.Location = new System.Drawing.Point(128, 11);
            this.contaDestinoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.contaDestinoComboBox.Name = "contaDestinoComboBox";
            this.contaDestinoComboBox.Size = new System.Drawing.Size(307, 24);
            this.contaDestinoComboBox.TabIndex = 0;
            this.contaDestinoComboBox.ValueMember = "ContaID";
            this.contaDestinoComboBox.Leave += new System.EventHandler(this.contaDestinoComboBox_Leave);
            // 
            // contaDestinoBindingSource
            // 
            this.contaDestinoBindingSource.DataSource = typeof(Modelos.Conta);
            // 
            // transacaoComboBox
            // 
            this.transacaoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transacaoComboBox.DataSource = this.transacaoCambioBindingSource;
            this.transacaoComboBox.DisplayMember = "Transacao";
            this.transacaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transacaoComboBox.FormattingEnabled = true;
            this.transacaoComboBox.Location = new System.Drawing.Point(128, 43);
            this.transacaoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.transacaoComboBox.Name = "transacaoComboBox";
            this.transacaoComboBox.Size = new System.Drawing.Size(307, 24);
            this.transacaoComboBox.TabIndex = 1;
            this.transacaoComboBox.ValueMember = "IdFake";
            this.transacaoComboBox.Leave += new System.EventHandler(this.transacaoComboBox_Leave);
            // 
            // transacaoCambioBindingSource
            // 
            this.transacaoCambioBindingSource.DataSource = typeof(Modelos.TransacaoCambio);
            // 
            // panelMovimento
            // 
            this.panelMovimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMovimento.Controls.Add(cotacaoLabel);
            this.panelMovimento.Controls.Add(this.cotacaoTextBox);
            this.panelMovimento.Controls.Add(descricaoLabel);
            this.panelMovimento.Controls.Add(this.descricaoTextBox);
            this.panelMovimento.Controls.Add(this.label1);
            this.panelMovimento.Controls.Add(this.origemRadioButton);
            this.panelMovimento.Controls.Add(this.destinoRadioButton);
            this.panelMovimento.Controls.Add(this.taxaLabel);
            this.panelMovimento.Controls.Add(this.taxaTextBox);
            this.panelMovimento.Controls.Add(this.simboloDestinoLabel);
            this.panelMovimento.Controls.Add(this.valorDestinoTextBox);
            this.panelMovimento.Controls.Add(this.simboloOrigemLabel);
            this.panelMovimento.Controls.Add(this.valorOrigemTextBox);
            this.panelMovimento.Controls.Add(dataLabel);
            this.panelMovimento.Controls.Add(this.dataDateTimePicker);
            this.panelMovimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMovimento.Location = new System.Drawing.Point(0, 132);
            this.panelMovimento.Margin = new System.Windows.Forms.Padding(4);
            this.panelMovimento.Name = "panelMovimento";
            this.panelMovimento.Size = new System.Drawing.Size(459, 244);
            this.panelMovimento.TabIndex = 1;
            // 
            // cotacaoTextBox
            // 
            this.cotacaoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cotacaoTextBox.Location = new System.Drawing.Point(127, 149);
            this.cotacaoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cotacaoTextBox.MaxLength = 100;
            this.cotacaoTextBox.Name = "cotacaoTextBox";
            this.cotacaoTextBox.ReadOnly = true;
            this.cotacaoTextBox.Size = new System.Drawing.Size(307, 22);
            this.cotacaoTextBox.TabIndex = 4;
            this.cotacaoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTextBox.Location = new System.Drawing.Point(127, 100);
            this.descricaoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.descricaoTextBox.MaxLength = 100;
            this.descricaoTextBox.Multiline = true;
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(307, 41);
            this.descricaoTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Conta Taxa:";
            // 
            // origemRadioButton
            // 
            this.origemRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.origemRadioButton.AutoSize = true;
            this.origemRadioButton.Location = new System.Drawing.Point(128, 178);
            this.origemRadioButton.Name = "origemRadioButton";
            this.origemRadioButton.Size = new System.Drawing.Size(75, 21);
            this.origemRadioButton.TabIndex = 5;
            this.origemRadioButton.TabStop = true;
            this.origemRadioButton.Text = "Origem";
            this.origemRadioButton.UseVisualStyleBackColor = true;
            // 
            // destinoRadioButton
            // 
            this.destinoRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.destinoRadioButton.AutoSize = true;
            this.destinoRadioButton.Location = new System.Drawing.Point(209, 178);
            this.destinoRadioButton.Name = "destinoRadioButton";
            this.destinoRadioButton.Size = new System.Drawing.Size(77, 21);
            this.destinoRadioButton.TabIndex = 6;
            this.destinoRadioButton.TabStop = true;
            this.destinoRadioButton.Text = "Destino";
            this.destinoRadioButton.UseVisualStyleBackColor = true;
            // 
            // taxaLabel
            // 
            this.taxaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taxaLabel.AutoSize = true;
            this.taxaLabel.Location = new System.Drawing.Point(15, 209);
            this.taxaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.taxaLabel.Name = "taxaLabel";
            this.taxaLabel.Size = new System.Drawing.Size(43, 17);
            this.taxaLabel.TabIndex = 10;
            this.taxaLabel.Text = "Taxa:";
            // 
            // taxaTextBox
            // 
            this.taxaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taxaTextBox.Location = new System.Drawing.Point(127, 206);
            this.taxaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.taxaTextBox.Name = "taxaTextBox";
            this.taxaTextBox.Size = new System.Drawing.Size(307, 22);
            this.taxaTextBox.TabIndex = 7;
            this.taxaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.taxaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.taxaTextBox_KeyPress);
            // 
            // valorDestinoTextBox
            // 
            this.valorDestinoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valorDestinoTextBox.Location = new System.Drawing.Point(128, 69);
            this.valorDestinoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.valorDestinoTextBox.Name = "valorDestinoTextBox";
            this.valorDestinoTextBox.Size = new System.Drawing.Size(307, 22);
            this.valorDestinoTextBox.TabIndex = 2;
            this.valorDestinoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorDestinoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorDestinoTextBox_KeyPress);
            // 
            // valorOrigemTextBox
            // 
            this.valorOrigemTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valorOrigemTextBox.Location = new System.Drawing.Point(128, 39);
            this.valorOrigemTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.valorOrigemTextBox.Name = "valorOrigemTextBox";
            this.valorOrigemTextBox.Size = new System.Drawing.Size(307, 22);
            this.valorOrigemTextBox.TabIndex = 1;
            this.valorOrigemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorOrigemTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorOrigemTextBox_KeyPress);
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDateTimePicker.CustomFormat = "dddd, dd/MM/yyyy   HH:mm:ss";
            this.dataDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataDateTimePicker.Location = new System.Drawing.Point(128, 9);
            this.dataDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(307, 22);
            this.dataDateTimePicker.TabIndex = 0;
            // 
            // buttonGravarCategoria
            // 
            this.buttonGravarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravarCategoria.Image = global::MoneyPro.Properties.Resources.ok;
            this.buttonGravarCategoria.Location = new System.Drawing.Point(379, 4);
            this.buttonGravarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGravarCategoria.Name = "buttonGravarCategoria";
            this.buttonGravarCategoria.Size = new System.Drawing.Size(31, 28);
            this.buttonGravarCategoria.TabIndex = 2;
            this.buttonGravarCategoria.UseVisualStyleBackColor = true;
            this.buttonGravarCategoria.Click += new System.EventHandler(this.buttonGravarCategoria_Click);
            // 
            // buttonCancelarCategoria
            // 
            this.buttonCancelarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelarCategoria.Image = global::MoneyPro.Properties.Resources.cancela;
            this.buttonCancelarCategoria.Location = new System.Drawing.Point(417, 4);
            this.buttonCancelarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelarCategoria.Name = "buttonCancelarCategoria";
            this.buttonCancelarCategoria.Size = new System.Drawing.Size(31, 28);
            this.buttonCancelarCategoria.TabIndex = 3;
            this.buttonCancelarCategoria.UseVisualStyleBackColor = true;
            this.buttonCancelarCategoria.Click += new System.EventHandler(this.buttonCancelarCategoria_Click);
            // 
            // fmMovimentosCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(459, 413);
            this.Controls.Add(this.panelMovimento);
            this.Controls.Add(this.panelTransacao);
            this.Name = "fmMovimentosCambio";
            this.Text = "MoneyPro";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.panelTransacao, 0);
            this.Controls.SetChildIndex(this.panelMovimento, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.panelTransacao.ResumeLayout(false);
            this.panelTransacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaDestinoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transacaoCambioBindingSource)).EndInit();
            this.panelMovimento.ResumeLayout(false);
            this.panelMovimento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTransacao;
        private System.Windows.Forms.ComboBox transacaoComboBox;
        private System.Windows.Forms.BindingSource transacaoCambioBindingSource;
        private System.Windows.Forms.ComboBox contaDestinoComboBox;
        private System.Windows.Forms.BindingSource contaDestinoBindingSource;
        private System.Windows.Forms.Panel panelMovimento;
        private System.Windows.Forms.TextBox valorDestinoTextBox;
        private System.Windows.Forms.TextBox valorOrigemTextBox;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.Label simboloDestinoLabel;
        private System.Windows.Forms.Label simboloOrigemLabel;
        private System.Windows.Forms.Label taxaLabel;
        private System.Windows.Forms.TextBox taxaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton origemRadioButton;
        private System.Windows.Forms.RadioButton destinoRadioButton;
        private System.Windows.Forms.Button buttonGravarCategoria;
        private System.Windows.Forms.Button buttonCancelarCategoria;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox cotacaoTextBox;
        private System.Windows.Forms.Label labelContaDestino;
    }
}
