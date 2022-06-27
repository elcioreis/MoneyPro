namespace MoneyPro
{
    partial class fmContas
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnMoedas = new System.Windows.Forms.Button();
            this.btnTipoConta = new System.Windows.Forms.Button();
            this.btnInstituicao = new System.Windows.Forms.Button();
            this.btnExibeTodasContas = new System.Windows.Forms.Button();
            this.btnExibeSomenteContasAtivas = new System.Windows.Forms.Button();
            this.contaDataGridView = new System.Windows.Forms.DataGridView();
            this.contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstituicaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoedaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Decimais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsaHora = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OFX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CSV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TipoArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExibirProjecao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 370);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(1056, 37);
            this.panelRodape.TabIndex = 1;
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
            this.panelTopo.Controls.Add(this.btnExibeSomenteContasAtivas);
            this.panelTopo.Controls.Add(this.btnExibeTodasContas);
            this.panelTopo.Controls.Add(this.btnInstituicao);
            this.panelTopo.Controls.Add(this.btnTipoConta);
            this.panelTopo.Controls.Add(this.btnMoedas);
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(1056, 49);
            this.panelTopo.TabIndex = 2;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnMoedas, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnTipoConta, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnInstituicao, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnExibeTodasContas, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnExibeSomenteContasAtivas, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(277, 32);
            this.labelTopo.Text = "Cadastro de Contas";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // btnMoedas
            // 
            this.btnMoedas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoedas.Image = global::MoneyPro.Properties.Resources.z16moedas;
            this.btnMoedas.Location = new System.Drawing.Point(973, 10);
            this.btnMoedas.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoedas.Name = "btnMoedas";
            this.btnMoedas.Size = new System.Drawing.Size(31, 28);
            this.btnMoedas.TabIndex = 3;
            this.btnMoedas.TabStop = false;
            this.toolTip.SetToolTip(this.btnMoedas, "Moedas [Alt+M]");
            this.btnMoedas.UseVisualStyleBackColor = true;
            this.btnMoedas.Click += new System.EventHandler(this.btnMoedas_Click);
            // 
            // btnTipoConta
            // 
            this.btnTipoConta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipoConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoConta.Image = global::MoneyPro.Properties.Resources.z16tipoContas;
            this.btnTipoConta.Location = new System.Drawing.Point(896, 10);
            this.btnTipoConta.Margin = new System.Windows.Forms.Padding(4);
            this.btnTipoConta.Name = "btnTipoConta";
            this.btnTipoConta.Size = new System.Drawing.Size(31, 28);
            this.btnTipoConta.TabIndex = 1;
            this.btnTipoConta.TabStop = false;
            this.toolTip.SetToolTip(this.btnTipoConta, "Tipos de Contas [Alt+T]");
            this.btnTipoConta.UseVisualStyleBackColor = true;
            this.btnTipoConta.Click += new System.EventHandler(this.btnTipoConta_Click);
            // 
            // btnInstituicao
            // 
            this.btnInstituicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstituicao.Image = global::MoneyPro.Properties.Resources.z16instituicao;
            this.btnInstituicao.Location = new System.Drawing.Point(935, 10);
            this.btnInstituicao.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstituicao.Name = "btnInstituicao";
            this.btnInstituicao.Size = new System.Drawing.Size(31, 28);
            this.btnInstituicao.TabIndex = 2;
            this.btnInstituicao.TabStop = false;
            this.toolTip.SetToolTip(this.btnInstituicao, "Instituições [Alt+I]");
            this.btnInstituicao.UseVisualStyleBackColor = true;
            this.btnInstituicao.Click += new System.EventHandler(this.btnInstituicao_Click);
            // 
            // btnExibeTodasContas
            // 
            this.btnExibeTodasContas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibeTodasContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibeTodasContas.Image = global::MoneyPro.Properties.Resources.z16radio_off_button;
            this.btnExibeTodasContas.Location = new System.Drawing.Point(1012, 10);
            this.btnExibeTodasContas.Margin = new System.Windows.Forms.Padding(4);
            this.btnExibeTodasContas.Name = "btnExibeTodasContas";
            this.btnExibeTodasContas.Size = new System.Drawing.Size(31, 28);
            this.btnExibeTodasContas.TabIndex = 4;
            this.btnExibeTodasContas.TabStop = false;
            this.toolTip.SetToolTip(this.btnExibeTodasContas, "Exibe todas as contas");
            this.btnExibeTodasContas.UseVisualStyleBackColor = true;
            this.btnExibeTodasContas.Visible = false;
            this.btnExibeTodasContas.Click += new System.EventHandler(this.BtnExibeTodasContas_Click);
            // 
            // btnExibeSomenteContasAtivas
            // 
            this.btnExibeSomenteContasAtivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibeSomenteContasAtivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibeSomenteContasAtivas.Image = global::MoneyPro.Properties.Resources.z16radio_on_button;
            this.btnExibeSomenteContasAtivas.Location = new System.Drawing.Point(1012, 10);
            this.btnExibeSomenteContasAtivas.Margin = new System.Windows.Forms.Padding(4);
            this.btnExibeSomenteContasAtivas.Name = "btnExibeSomenteContasAtivas";
            this.btnExibeSomenteContasAtivas.Size = new System.Drawing.Size(31, 28);
            this.btnExibeSomenteContasAtivas.TabIndex = 5;
            this.btnExibeSomenteContasAtivas.TabStop = false;
            this.toolTip.SetToolTip(this.btnExibeSomenteContasAtivas, "Exibe somente contas ativas");
            this.btnExibeSomenteContasAtivas.UseVisualStyleBackColor = true;
            this.btnExibeSomenteContasAtivas.Visible = false;
            this.btnExibeSomenteContasAtivas.Click += new System.EventHandler(this.BtnExibeTodasContas_Click);
            // 
            // contaDataGridView
            // 
            this.contaDataGridView.AllowUserToAddRows = false;
            this.contaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.contaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.contaDataGridView.AutoGenerateColumns = false;
            this.contaDataGridView.CausesValidation = false;
            this.contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContaID,
            this.UsuarioID,
            this.Apelido,
            this.DataAbertura,
            this.InstituicaoID,
            this.TipoContaID,
            this.MoedaID,
            this.SaldoInicial,
            this.Limite,
            this.Decimais,
            this.Descricao,
            this.UsaHora,
            this.OFX,
            this.CSV,
            this.TipoArquivo,
            this.ExibirProjecao,
            this.Ativo});
            this.contaDataGridView.DataSource = this.contaBindingSource;
            this.contaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contaDataGridView.Location = new System.Drawing.Point(0, 49);
            this.contaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.contaDataGridView.Name = "contaDataGridView";
            this.contaDataGridView.RowHeadersVisible = false;
            this.contaDataGridView.RowHeadersWidth = 51;
            this.contaDataGridView.RowTemplate.Height = 21;
            this.contaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.contaDataGridView.Size = new System.Drawing.Size(1056, 321);
            this.contaDataGridView.TabIndex = 0;
            this.contaDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.contaDataGridView_CellFormatting);
            this.contaDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.contaDataGridView_EditingControlShowing);
            this.contaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.contaDataGridView_RowValidating);
            this.contaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contaDataGridView_KeyPress);
            // 
            // contaBindingSource
            // 
            this.contaBindingSource.DataSource = typeof(Modelos.Conta);
            // 
            // ContaID
            // 
            this.ContaID.DataPropertyName = "ContaID";
            this.ContaID.HeaderText = "ContaID";
            this.ContaID.MinimumWidth = 6;
            this.ContaID.Name = "ContaID";
            this.ContaID.Visible = false;
            this.ContaID.Width = 125;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
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
            dataGridViewCellStyle2.NullValue = "null";
            this.Apelido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Apelido.FillWeight = 120F;
            this.Apelido.HeaderText = "Nº da Conta";
            this.Apelido.MinimumWidth = 120;
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 120;
            // 
            // DataAbertura
            // 
            this.DataAbertura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataAbertura.DataPropertyName = "DataAbertura";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DataAbertura.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataAbertura.FillWeight = 80F;
            this.DataAbertura.HeaderText = "Abertura";
            this.DataAbertura.MinimumWidth = 6;
            this.DataAbertura.Name = "DataAbertura";
            this.DataAbertura.Width = 92;
            // 
            // InstituicaoID
            // 
            this.InstituicaoID.DataPropertyName = "InstituicaoID";
            this.InstituicaoID.HeaderText = "InstituicaoID";
            this.InstituicaoID.MinimumWidth = 6;
            this.InstituicaoID.Name = "InstituicaoID";
            this.InstituicaoID.Width = 125;
            // 
            // TipoContaID
            // 
            this.TipoContaID.DataPropertyName = "TipoContaID";
            this.TipoContaID.HeaderText = "TipoContaID";
            this.TipoContaID.MinimumWidth = 6;
            this.TipoContaID.Name = "TipoContaID";
            this.TipoContaID.Width = 125;
            // 
            // MoedaID
            // 
            this.MoedaID.DataPropertyName = "MoedaID";
            this.MoedaID.HeaderText = "MoedaID";
            this.MoedaID.MinimumWidth = 6;
            this.MoedaID.Name = "MoedaID";
            this.MoedaID.Width = 125;
            // 
            // SaldoInicial
            // 
            this.SaldoInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SaldoInicial.DataPropertyName = "SaldoInicial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N8";
            this.SaldoInicial.DefaultCellStyle = dataGridViewCellStyle4;
            this.SaldoInicial.HeaderText = "Saldo Inicial";
            this.SaldoInicial.MinimumWidth = 75;
            this.SaldoInicial.Name = "SaldoInicial";
            this.SaldoInicial.Width = 112;
            // 
            // Limite
            // 
            this.Limite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Limite.DataPropertyName = "Limite";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0.00";
            this.Limite.DefaultCellStyle = dataGridViewCellStyle5;
            this.Limite.HeaderText = "Limite";
            this.Limite.MinimumWidth = 75;
            this.Limite.Name = "Limite";
            this.Limite.Width = 75;
            // 
            // Decimais
            // 
            this.Decimais.DataPropertyName = "Decimais";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#0";
            this.Decimais.DefaultCellStyle = dataGridViewCellStyle6;
            this.Decimais.FillWeight = 75F;
            this.Decimais.HeaderText = "Decimais";
            this.Decimais.MinimumWidth = 75;
            this.Decimais.Name = "Decimais";
            this.Decimais.ToolTipText = "Casas decimais utilizadas para a conta.";
            this.Decimais.Width = 75;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle7.NullValue = "null";
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle7;
            this.Descricao.FillWeight = 200F;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 200;
            this.Descricao.Name = "Descricao";
            // 
            // UsaHora
            // 
            this.UsaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UsaHora.DataPropertyName = "UsaHora";
            this.UsaHora.FillWeight = 50F;
            this.UsaHora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsaHora.HeaderText = "Hora";
            this.UsaHora.MinimumWidth = 6;
            this.UsaHora.Name = "UsaHora";
            this.UsaHora.ToolTipText = "Usa transações com hora, minuto e segundo.";
            this.UsaHora.Width = 45;
            // 
            // OFX
            // 
            this.OFX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OFX.DataPropertyName = "OFX";
            this.OFX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OFX.HeaderText = "OFX";
            this.OFX.MinimumWidth = 6;
            this.OFX.Name = "OFX";
            this.OFX.ToolTipText = "Utiliza arquivo OFX para conciliação";
            this.OFX.Width = 42;
            // 
            // CSV
            // 
            this.CSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CSV.DataPropertyName = "CSV";
            this.CSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CSV.HeaderText = "CSV";
            this.CSV.MinimumWidth = 6;
            this.CSV.Name = "CSV";
            this.CSV.ToolTipText = "Utiliza arquivo CSV para conciliação";
            this.CSV.Width = 41;
            // 
            // TipoArquivo
            // 
            this.TipoArquivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoArquivo.DataPropertyName = "TipoArquivo";
            this.TipoArquivo.HeaderText = "Origem Arquivo";
            this.TipoArquivo.MaxInputLength = 25;
            this.TipoArquivo.MinimumWidth = 6;
            this.TipoArquivo.Name = "TipoArquivo";
            this.TipoArquivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TipoArquivo.ToolTipText = "Origem Arquivo CSV";
            this.TipoArquivo.Width = 101;
            // 
            // ExibirProjecao
            // 
            this.ExibirProjecao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExibirProjecao.DataPropertyName = "ExibirProjecao";
            this.ExibirProjecao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExibirProjecao.HeaderText = "Projeção";
            this.ExibirProjecao.MinimumWidth = 6;
            this.ExibirProjecao.Name = "ExibirProjecao";
            this.ExibirProjecao.Width = 70;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.MinimumWidth = 6;
            this.Ativo.Name = "Ativo";
            this.Ativo.Width = 45;
            // 
            // fmContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1056, 407);
            this.Controls.Add(this.contaDataGridView);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmContas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmContas_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.contaDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnMoedas;
        private System.Windows.Forms.Button btnTipoConta;
        private System.Windows.Forms.Button btnInstituicao;
        private System.Windows.Forms.BindingSource contaBindingSource;
        private System.Windows.Forms.DataGridView contaDataGridView;
        private System.Windows.Forms.Button btnExibeTodasContas;
        private System.Windows.Forms.Button btnExibeSomenteContasAtivas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstituicaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoedaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Decimais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UsaHora;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OFX;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArquivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExibirProjecao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
