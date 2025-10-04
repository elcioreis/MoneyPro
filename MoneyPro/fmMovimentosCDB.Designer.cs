namespace MoneyPro
{
    partial class fmMovimentosCDB
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
            System.Windows.Forms.Label cdbLabel;
            System.Windows.Forms.Label dataLabel;
            this.panelMovimento = new System.Windows.Forms.Panel();
            this.categoriaComboBox = new System.Windows.Forms.ComboBox();
            this.categoriaLabel = new System.Windows.Forms.Label();
            this.lancamentoComboBox = new System.Windows.Forms.ComboBox();
            this.lancamentoLabel = new System.Windows.Forms.Label();
            this.diferencaLabel = new System.Windows.Forms.Label();
            this.diferencaTextBox = new System.Windows.Forms.TextBox();
            this.novoValorLabel = new System.Windows.Forms.Label();
            this.valorAtualLabel = new System.Windows.Forms.Label();
            this.novoSaldoTextBox = new System.Windows.Forms.TextBox();
            this.saldoAtualTextBox = new System.Windows.Forms.TextBox();
            this.descricaoLabel = new System.Windows.Forms.Label();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.numeroCDB = new System.Windows.Forms.TextBox();
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            cdbLabel = new System.Windows.Forms.Label();
            dataLabel = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            this.panelMovimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonGravar);
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Location = new System.Drawing.Point(0, 309);
            this.panelRodape.Size = new System.Drawing.Size(599, 37);
            this.panelRodape.TabIndex = 1;
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonCancelar, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonGravar, 0);
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
            this.panelTopo.Size = new System.Drawing.Size(599, 49);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(315, 32);
            this.labelTopo.Text = "Atualizar saldo do CDB";
            // 
            // cdbLabel
            // 
            cdbLabel.AutoSize = true;
            cdbLabel.Location = new System.Drawing.Point(16, 12);
            cdbLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cdbLabel.Name = "cdbLabel";
            cdbLabel.Size = new System.Drawing.Size(45, 16);
            cdbLabel.TabIndex = 6;
            cdbLabel.Text = "CDB #";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Location = new System.Drawing.Point(16, 136);
            dataLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(131, 16);
            dataLabel.TabIndex = 9;
            dataLabel.Text = "Data de Atualização:";
            // 
            // panelMovimento
            // 
            this.panelMovimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMovimento.Controls.Add(this.categoriaComboBox);
            this.panelMovimento.Controls.Add(this.categoriaLabel);
            this.panelMovimento.Controls.Add(this.lancamentoComboBox);
            this.panelMovimento.Controls.Add(this.lancamentoLabel);
            this.panelMovimento.Controls.Add(this.diferencaLabel);
            this.panelMovimento.Controls.Add(this.diferencaTextBox);
            this.panelMovimento.Controls.Add(this.novoValorLabel);
            this.panelMovimento.Controls.Add(this.valorAtualLabel);
            this.panelMovimento.Controls.Add(this.novoSaldoTextBox);
            this.panelMovimento.Controls.Add(this.saldoAtualTextBox);
            this.panelMovimento.Controls.Add(dataLabel);
            this.panelMovimento.Controls.Add(this.descricaoLabel);
            this.panelMovimento.Controls.Add(this.descricaoTextBox);
            this.panelMovimento.Controls.Add(this.numeroCDB);
            this.panelMovimento.Controls.Add(cdbLabel);
            this.panelMovimento.Controls.Add(this.dataDateTimePicker);
            this.panelMovimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMovimento.Location = new System.Drawing.Point(0, 49);
            this.panelMovimento.Margin = new System.Windows.Forms.Padding(4);
            this.panelMovimento.Name = "panelMovimento";
            this.panelMovimento.Size = new System.Drawing.Size(599, 260);
            this.panelMovimento.TabIndex = 0;
            // 
            // categoriaComboBox
            // 
            this.categoriaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.categoriaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoriaComboBox.DisplayMember = "Apelido";
            this.categoriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriaComboBox.FormattingEnabled = true;
            this.categoriaComboBox.Location = new System.Drawing.Point(159, 71);
            this.categoriaComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoriaComboBox.Name = "categoriaComboBox";
            this.categoriaComboBox.Size = new System.Drawing.Size(228, 24);
            this.categoriaComboBox.TabIndex = 2;
            this.categoriaComboBox.ValueMember = "CategoriaID";
            // 
            // categoriaLabel
            // 
            this.categoriaLabel.AutoSize = true;
            this.categoriaLabel.Location = new System.Drawing.Point(16, 75);
            this.categoriaLabel.Name = "categoriaLabel";
            this.categoriaLabel.Size = new System.Drawing.Size(69, 16);
            this.categoriaLabel.TabIndex = 18;
            this.categoriaLabel.Text = "Categoria:";
            // 
            // lancamentoComboBox
            // 
            this.lancamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lancamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lancamentoComboBox.DisplayMember = "Apelido";
            this.lancamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lancamentoComboBox.FormattingEnabled = true;
            this.lancamentoComboBox.Location = new System.Drawing.Point(159, 39);
            this.lancamentoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lancamentoComboBox.Name = "lancamentoComboBox";
            this.lancamentoComboBox.Size = new System.Drawing.Size(228, 24);
            this.lancamentoComboBox.TabIndex = 1;
            this.lancamentoComboBox.ValueMember = "LancamentoID";
            // 
            // lancamentoLabel
            // 
            this.lancamentoLabel.AutoSize = true;
            this.lancamentoLabel.Location = new System.Drawing.Point(16, 42);
            this.lancamentoLabel.Name = "lancamentoLabel";
            this.lancamentoLabel.Size = new System.Drawing.Size(84, 16);
            this.lancamentoLabel.TabIndex = 16;
            this.lancamentoLabel.Text = "Lançamento:";
            // 
            // diferencaLabel
            // 
            this.diferencaLabel.AutoSize = true;
            this.diferencaLabel.Location = new System.Drawing.Point(16, 226);
            this.diferencaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diferencaLabel.Name = "diferencaLabel";
            this.diferencaLabel.Size = new System.Drawing.Size(68, 16);
            this.diferencaLabel.TabIndex = 15;
            this.diferencaLabel.Text = "Diferença:";
            // 
            // diferencaTextBox
            // 
            this.diferencaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diferencaTextBox.Location = new System.Drawing.Point(159, 223);
            this.diferencaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.diferencaTextBox.Name = "diferencaTextBox";
            this.diferencaTextBox.ReadOnly = true;
            this.diferencaTextBox.Size = new System.Drawing.Size(119, 22);
            this.diferencaTextBox.TabIndex = 7;
            this.diferencaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // novoValorLabel
            // 
            this.novoValorLabel.AutoSize = true;
            this.novoValorLabel.Location = new System.Drawing.Point(16, 196);
            this.novoValorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.novoValorLabel.Name = "novoValorLabel";
            this.novoValorLabel.Size = new System.Drawing.Size(82, 16);
            this.novoValorLabel.TabIndex = 13;
            this.novoValorLabel.Text = "Novo Saldo:";
            // 
            // valorAtualLabel
            // 
            this.valorAtualLabel.AutoSize = true;
            this.valorAtualLabel.Location = new System.Drawing.Point(16, 166);
            this.valorAtualLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valorAtualLabel.Name = "valorAtualLabel";
            this.valorAtualLabel.Size = new System.Drawing.Size(79, 16);
            this.valorAtualLabel.TabIndex = 12;
            this.valorAtualLabel.Text = "Saldo Atual:";
            // 
            // novoSaldoTextBox
            // 
            this.novoSaldoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.novoSaldoTextBox.Location = new System.Drawing.Point(159, 193);
            this.novoSaldoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.novoSaldoTextBox.Name = "novoSaldoTextBox";
            this.novoSaldoTextBox.Size = new System.Drawing.Size(119, 22);
            this.novoSaldoTextBox.TabIndex = 6;
            this.novoSaldoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.novoSaldoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.novoSaldoTextBox_KeyDown);
            this.novoSaldoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.novoSaldoTextBox_KeyPress);
            this.novoSaldoTextBox.Leave += new System.EventHandler(this.novoSaldoTextBox_Leave);
            // 
            // saldoAtualTextBox
            // 
            this.saldoAtualTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saldoAtualTextBox.Location = new System.Drawing.Point(159, 163);
            this.saldoAtualTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.saldoAtualTextBox.Name = "saldoAtualTextBox";
            this.saldoAtualTextBox.ReadOnly = true;
            this.saldoAtualTextBox.Size = new System.Drawing.Size(119, 22);
            this.saldoAtualTextBox.TabIndex = 5;
            this.saldoAtualTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.AutoSize = true;
            this.descricaoLabel.Location = new System.Drawing.Point(16, 106);
            this.descricaoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(72, 16);
            this.descricaoLabel.TabIndex = 8;
            this.descricaoLabel.Text = "Descrição:";
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoTextBox.Location = new System.Drawing.Point(159, 103);
            this.descricaoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(420, 22);
            this.descricaoTextBox.TabIndex = 3;
            // 
            // numeroCDB
            // 
            this.numeroCDB.Location = new System.Drawing.Point(159, 9);
            this.numeroCDB.Margin = new System.Windows.Forms.Padding(4);
            this.numeroCDB.Name = "numeroCDB";
            this.numeroCDB.ReadOnly = true;
            this.numeroCDB.Size = new System.Drawing.Size(119, 22);
            this.numeroCDB.TabIndex = 0;
            this.numeroCDB.TabStop = false;
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.CustomFormat = "dddd, dd/MM/yyyy";
            this.dataDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataDateTimePicker.Location = new System.Drawing.Point(159, 133);
            this.dataDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(228, 22);
            this.dataDateTimePicker.TabIndex = 4;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Image = global::MoneyPro.Properties.Resources.ok;
            this.buttonGravar.Location = new System.Drawing.Point(510, 4);
            this.buttonGravar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(31, 28);
            this.buttonGravar.TabIndex = 0;
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Image = global::MoneyPro.Properties.Resources.cancela;
            this.buttonCancelar.Location = new System.Drawing.Point(549, 4);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(31, 28);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // fmMovimentosCDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(599, 346);
            this.Controls.Add(this.panelMovimento);
            this.Name = "fmMovimentosCDB";
            this.Text = "MoneyPro";
            this.Shown += new System.EventHandler(this.fmMovimentosCDB_Shown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.panelMovimento, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.panelMovimento.ResumeLayout(false);
            this.panelMovimento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMovimento;
        private System.Windows.Forms.Label descricaoLabel;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox numeroCDB;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.Label novoValorLabel;
        private System.Windows.Forms.Label valorAtualLabel;
        private System.Windows.Forms.TextBox novoSaldoTextBox;
        private System.Windows.Forms.TextBox saldoAtualTextBox;
        private System.Windows.Forms.Label diferencaLabel;
        private System.Windows.Forms.TextBox diferencaTextBox;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox lancamentoComboBox;
        private System.Windows.Forms.Label lancamentoLabel;
        private System.Windows.Forms.ComboBox categoriaComboBox;
        private System.Windows.Forms.Label categoriaLabel;
    }
}
