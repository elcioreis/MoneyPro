namespace MoneyPro
{
    partial class fmConciliacao
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
            this.movimentoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLancamentos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelArquivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelFundo = new System.Windows.Forms.Panel();
            this.groupBoxLancamento = new System.Windows.Forms.GroupBox();
            this.buttonConciliado = new System.Windows.Forms.Button();
            this.buttonAtencao = new System.Windows.Forms.Button();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelCrdDeb = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.panelConciliacao = new System.Windows.Forms.Panel();
            this.movimentoContaDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonProximo = new System.Windows.Forms.Button();
            this.buttonAnterior = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonLigar = new System.Windows.Forms.Button();
            this.buttonSeparar = new System.Windows.Forms.Button();
            this.buttonAjustarData = new System.Windows.Forms.Button();
            this.timerAtencao = new System.Windows.Forms.Timer(this.components);
            this.MovimentoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentoInvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LancamentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeiculoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conciliacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrdDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificacaoOFX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaBindingSource)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panelFundo.SuspendLayout();
            this.groupBoxLancamento.SuspendLayout();
            this.panelConciliacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonAjustarData);
            this.panelRodape.Controls.Add(this.buttonSeparar);
            this.panelRodape.Controls.Add(this.buttonLigar);
            this.panelRodape.Controls.Add(this.buttonAnterior);
            this.panelRodape.Controls.Add(this.buttonProximo);
            this.panelRodape.Location = new System.Drawing.Point(0, 525);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(1539, 37);
            this.panelRodape.TabIndex = 1;
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonProximo, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonAnterior, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonLigar, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonSeparar, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonAjustarData, 0);
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
            this.panelTopo.Size = new System.Drawing.Size(1539, 49);
            this.panelTopo.TabIndex = 0;
            // 
            // movimentoContaBindingSource
            // 
            this.movimentoContaBindingSource.DataSource = typeof(Modelos.MovimentoConta);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLancamentos,
            this.toolStripStatusLabelArquivo});
            this.statusStrip.Location = new System.Drawing.Point(0, 562);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1539, 30);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLancamentos
            // 
            this.toolStripStatusLabelLancamentos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelLancamentos.Name = "toolStripStatusLabelLancamentos";
            this.toolStripStatusLabelLancamentos.Size = new System.Drawing.Size(100, 24);
            this.toolStripStatusLabelLancamentos.Text = "Lançamentos";
            // 
            // toolStripStatusLabelArquivo
            // 
            this.toolStripStatusLabelArquivo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelArquivo.Name = "toolStripStatusLabelArquivo";
            this.toolStripStatusLabelArquivo.Size = new System.Drawing.Size(65, 24);
            this.toolStripStatusLabelArquivo.Text = "Arquivo";
            // 
            // panelFundo
            // 
            this.panelFundo.BackColor = System.Drawing.Color.Silver;
            this.panelFundo.Controls.Add(this.groupBoxLancamento);
            this.panelFundo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFundo.Location = new System.Drawing.Point(0, 449);
            this.panelFundo.Margin = new System.Windows.Forms.Padding(4);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.Padding = new System.Windows.Forms.Padding(5);
            this.panelFundo.Size = new System.Drawing.Size(1539, 76);
            this.panelFundo.TabIndex = 1;
            // 
            // groupBoxLancamento
            // 
            this.groupBoxLancamento.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxLancamento.Controls.Add(this.buttonConciliado);
            this.groupBoxLancamento.Controls.Add(this.buttonAtencao);
            this.groupBoxLancamento.Controls.Add(this.textBoxValor);
            this.groupBoxLancamento.Controls.Add(this.labelValor);
            this.groupBoxLancamento.Controls.Add(this.labelCrdDeb);
            this.groupBoxLancamento.Controls.Add(this.labelDescricao);
            this.groupBoxLancamento.Controls.Add(this.dateTimePickerData);
            this.groupBoxLancamento.Controls.Add(this.textBoxDescricao);
            this.groupBoxLancamento.Controls.Add(this.labelData);
            this.groupBoxLancamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLancamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxLancamento.Location = new System.Drawing.Point(5, 5);
            this.groupBoxLancamento.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLancamento.Name = "groupBoxLancamento";
            this.groupBoxLancamento.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLancamento.Size = new System.Drawing.Size(1529, 66);
            this.groupBoxLancamento.TabIndex = 0;
            this.groupBoxLancamento.TabStop = false;
            this.groupBoxLancamento.Text = "Lançamento do Arquivo";
            // 
            // buttonConciliado
            // 
            this.buttonConciliado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConciliado.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonConciliado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConciliado.Image = global::MoneyPro.Properties.Resources.z16info;
            this.buttonConciliado.Location = new System.Drawing.Point(1488, 28);
            this.buttonConciliado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConciliado.Name = "buttonConciliado";
            this.buttonConciliado.Size = new System.Drawing.Size(31, 28);
            this.buttonConciliado.TabIndex = 8;
            this.buttonConciliado.UseVisualStyleBackColor = false;
            this.buttonConciliado.Visible = false;
            // 
            // buttonAtencao
            // 
            this.buttonAtencao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAtencao.BackColor = System.Drawing.Color.Gold;
            this.buttonAtencao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtencao.Image = global::MoneyPro.Properties.Resources.z16atencao;
            this.buttonAtencao.Location = new System.Drawing.Point(1488, 28);
            this.buttonAtencao.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAtencao.Name = "buttonAtencao";
            this.buttonAtencao.Size = new System.Drawing.Size(31, 28);
            this.buttonAtencao.TabIndex = 7;
            this.buttonAtencao.UseVisualStyleBackColor = false;
            this.buttonAtencao.Visible = false;
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(776, 30);
            this.textBoxValor.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.ReadOnly = true;
            this.textBoxValor.Size = new System.Drawing.Size(143, 22);
            this.textBoxValor.TabIndex = 6;
            this.textBoxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(723, 34);
            this.labelValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(42, 16);
            this.labelValor.TabIndex = 5;
            this.labelValor.Text = "Valor:";
            // 
            // labelCrdDeb
            // 
            this.labelCrdDeb.AutoSize = true;
            this.labelCrdDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrdDeb.Location = new System.Drawing.Point(951, 34);
            this.labelCrdDeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrdDeb.Name = "labelCrdDeb";
            this.labelCrdDeb.Size = new System.Drawing.Size(55, 17);
            this.labelCrdDeb.TabIndex = 4;
            this.labelCrdDeb.Text = "Débito";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(229, 34);
            this.labelDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(72, 16);
            this.labelDescricao.TabIndex = 3;
            this.labelDescricao.Text = "Descrição:";
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerData.Location = new System.Drawing.Point(64, 30);
            this.dateTimePickerData.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.Size = new System.Drawing.Size(136, 22);
            this.dateTimePickerData.TabIndex = 2;
            this.dateTimePickerData.ValueChanged += new System.EventHandler(this.dateTimePickerData_ValueChanged);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(315, 30);
            this.textBoxDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.ReadOnly = true;
            this.textBoxDescricao.Size = new System.Drawing.Size(372, 22);
            this.textBoxDescricao.TabIndex = 1;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(12, 34);
            this.labelData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(39, 16);
            this.labelData.TabIndex = 0;
            this.labelData.Text = "Data:";
            // 
            // panelConciliacao
            // 
            this.panelConciliacao.Controls.Add(this.movimentoContaDataGridView);
            this.panelConciliacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConciliacao.Location = new System.Drawing.Point(0, 49);
            this.panelConciliacao.Margin = new System.Windows.Forms.Padding(4);
            this.panelConciliacao.Name = "panelConciliacao";
            this.panelConciliacao.Padding = new System.Windows.Forms.Padding(5);
            this.panelConciliacao.Size = new System.Drawing.Size(1539, 400);
            this.panelConciliacao.TabIndex = 0;
            // 
            // movimentoContaDataGridView
            // 
            this.movimentoContaDataGridView.AllowUserToAddRows = false;
            this.movimentoContaDataGridView.AllowUserToDeleteRows = false;
            this.movimentoContaDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.movimentoContaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.movimentoContaDataGridView.AutoGenerateColumns = false;
            this.movimentoContaDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.movimentoContaDataGridView.ColumnHeadersHeight = 29;
            this.movimentoContaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.movimentoContaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MovimentoContaID,
            this.MovimentoInvestimentoID,
            this.ContaID,
            this.UsuarioID,
            this.Data,
            this.Numero,
            this.LancamentoID,
            this.Lancamento,
            this.Descricao,
            this.CategoriaID,
            this.Categoria,
            this.GrupoCategoriaID,
            this.GrupoCategoria,
            this.VeiculoID,
            this.Veiculo,
            this.Debito,
            this.Credito,
            this.Valor,
            this.Conciliacao,
            this.CrdDeb,
            this.IdentificacaoOFX});
            this.movimentoContaDataGridView.DataSource = this.movimentoContaBindingSource;
            this.movimentoContaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movimentoContaDataGridView.EnableHeadersVisualStyles = false;
            this.movimentoContaDataGridView.Location = new System.Drawing.Point(5, 5);
            this.movimentoContaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.movimentoContaDataGridView.Name = "movimentoContaDataGridView";
            this.movimentoContaDataGridView.ReadOnly = true;
            this.movimentoContaDataGridView.RowHeadersVisible = false;
            this.movimentoContaDataGridView.RowHeadersWidth = 51;
            this.movimentoContaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.movimentoContaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.movimentoContaDataGridView.Size = new System.Drawing.Size(1529, 390);
            this.movimentoContaDataGridView.TabIndex = 0;
            this.movimentoContaDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.movimentoContaDataGridView_CellFormatting);
            this.movimentoContaDataGridView.DoubleClick += new System.EventHandler(this.movimentoContaDataGridView_DoubleClick);
            // 
            // buttonProximo
            // 
            this.buttonProximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProximo.Image = global::MoneyPro.Properties.Resources.z16proximo;
            this.buttonProximo.Location = new System.Drawing.Point(1492, 5);
            this.buttonProximo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProximo.Name = "buttonProximo";
            this.buttonProximo.Size = new System.Drawing.Size(31, 28);
            this.buttonProximo.TabIndex = 2;
            this.buttonProximo.UseVisualStyleBackColor = true;
            this.buttonProximo.Click += new System.EventHandler(this.buttonProximo_Click);
            // 
            // buttonAnterior
            // 
            this.buttonAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnterior.Image = global::MoneyPro.Properties.Resources.z16anterior;
            this.buttonAnterior.Location = new System.Drawing.Point(1454, 5);
            this.buttonAnterior.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAnterior.Name = "buttonAnterior";
            this.buttonAnterior.Size = new System.Drawing.Size(31, 28);
            this.buttonAnterior.TabIndex = 3;
            this.buttonAnterior.UseVisualStyleBackColor = true;
            this.buttonAnterior.Click += new System.EventHandler(this.buttonAnterior_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonLigar
            // 
            this.buttonLigar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLigar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLigar.Image = global::MoneyPro.Properties.Resources.z16link;
            this.buttonLigar.Location = new System.Drawing.Point(1415, 5);
            this.buttonLigar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLigar.Name = "buttonLigar";
            this.buttonLigar.Size = new System.Drawing.Size(31, 28);
            this.buttonLigar.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonLigar, "Ligar lançamentos");
            this.buttonLigar.UseVisualStyleBackColor = true;
            this.buttonLigar.Click += new System.EventHandler(this.buttonLigar_Click);
            // 
            // buttonSeparar
            // 
            this.buttonSeparar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeparar.Image = global::MoneyPro.Properties.Resources.z16unlink;
            this.buttonSeparar.Location = new System.Drawing.Point(1376, 5);
            this.buttonSeparar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeparar.Name = "buttonSeparar";
            this.buttonSeparar.Size = new System.Drawing.Size(31, 28);
            this.buttonSeparar.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonSeparar, "Ligar lançamentos");
            this.buttonSeparar.UseVisualStyleBackColor = true;
            // 
            // buttonAjustarData
            // 
            this.buttonAjustarData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjustarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjustarData.Image = global::MoneyPro.Properties.Resources.z16editar;
            this.buttonAjustarData.Location = new System.Drawing.Point(1338, 5);
            this.buttonAjustarData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAjustarData.Name = "buttonAjustarData";
            this.buttonAjustarData.Size = new System.Drawing.Size(31, 28);
            this.buttonAjustarData.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonAjustarData, "Atualizar a data do lançamento");
            this.buttonAjustarData.UseVisualStyleBackColor = true;
            this.buttonAjustarData.Click += new System.EventHandler(this.buttonAjustarData_Click);
            // 
            // timerAtencao
            // 
            this.timerAtencao.Enabled = true;
            this.timerAtencao.Interval = 500;
            this.timerAtencao.Tick += new System.EventHandler(this.timerAtencao_Tick);
            // 
            // MovimentoContaID
            // 
            this.MovimentoContaID.DataPropertyName = "MovimentoContaID";
            this.MovimentoContaID.HeaderText = "MovimentoContaID";
            this.MovimentoContaID.MinimumWidth = 6;
            this.MovimentoContaID.Name = "MovimentoContaID";
            this.MovimentoContaID.ReadOnly = true;
            this.MovimentoContaID.Visible = false;
            this.MovimentoContaID.Width = 125;
            // 
            // MovimentoInvestimentoID
            // 
            this.MovimentoInvestimentoID.DataPropertyName = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.HeaderText = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.MinimumWidth = 6;
            this.MovimentoInvestimentoID.Name = "MovimentoInvestimentoID";
            this.MovimentoInvestimentoID.ReadOnly = true;
            this.MovimentoInvestimentoID.Visible = false;
            this.MovimentoInvestimentoID.Width = 125;
            // 
            // ContaID
            // 
            this.ContaID.DataPropertyName = "ContaID";
            this.ContaID.HeaderText = "ContaID";
            this.ContaID.MinimumWidth = 6;
            this.ContaID.Name = "ContaID";
            this.ContaID.ReadOnly = true;
            this.ContaID.Visible = false;
            this.ContaID.Width = 125;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.HeaderText = "UsuarioID";
            this.UsuarioID.MinimumWidth = 6;
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.ReadOnly = true;
            this.UsuarioID.Visible = false;
            this.UsuarioID.Width = 125;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.FillWeight = 68F;
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Data.Width = 68;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.FillWeight = 50F;
            this.Numero.HeaderText = "Número";
            this.Numero.MinimumWidth = 6;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Numero.Width = 60;
            // 
            // LancamentoID
            // 
            this.LancamentoID.DataPropertyName = "LancamentoID";
            this.LancamentoID.HeaderText = "LancamentoID";
            this.LancamentoID.MinimumWidth = 6;
            this.LancamentoID.Name = "LancamentoID";
            this.LancamentoID.ReadOnly = true;
            this.LancamentoID.Visible = false;
            this.LancamentoID.Width = 125;
            // 
            // Lancamento
            // 
            this.Lancamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Lancamento.DataPropertyName = "Lancamento";
            this.Lancamento.FillWeight = 180F;
            this.Lancamento.HeaderText = "Parceiro";
            this.Lancamento.MinimumWidth = 120;
            this.Lancamento.Name = "Lancamento";
            this.Lancamento.ReadOnly = true;
            this.Lancamento.Width = 180;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 6;
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CategoriaID
            // 
            this.CategoriaID.DataPropertyName = "CategoriaID";
            this.CategoriaID.HeaderText = "CategoriaID";
            this.CategoriaID.MinimumWidth = 6;
            this.CategoriaID.Name = "CategoriaID";
            this.CategoriaID.ReadOnly = true;
            this.CategoriaID.Visible = false;
            this.CategoriaID.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 140F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 120;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 140;
            // 
            // GrupoCategoriaID
            // 
            this.GrupoCategoriaID.DataPropertyName = "GrupoCategoriaID";
            this.GrupoCategoriaID.HeaderText = "GrupoCategoriaID";
            this.GrupoCategoriaID.MinimumWidth = 6;
            this.GrupoCategoriaID.Name = "GrupoCategoriaID";
            this.GrupoCategoriaID.ReadOnly = true;
            this.GrupoCategoriaID.Visible = false;
            this.GrupoCategoriaID.Width = 125;
            // 
            // GrupoCategoria
            // 
            this.GrupoCategoria.DataPropertyName = "GrupoCategoria";
            this.GrupoCategoria.FillWeight = 80F;
            this.GrupoCategoria.HeaderText = "Grupo";
            this.GrupoCategoria.MinimumWidth = 6;
            this.GrupoCategoria.Name = "GrupoCategoria";
            this.GrupoCategoria.ReadOnly = true;
            this.GrupoCategoria.Width = 80;
            // 
            // VeiculoID
            // 
            this.VeiculoID.DataPropertyName = "VeiculoID";
            this.VeiculoID.HeaderText = "VeiculoID";
            this.VeiculoID.MinimumWidth = 6;
            this.VeiculoID.Name = "VeiculoID";
            this.VeiculoID.ReadOnly = true;
            this.VeiculoID.Visible = false;
            this.VeiculoID.Width = 125;
            // 
            // Veiculo
            // 
            this.Veiculo.DataPropertyName = "Veiculo";
            this.Veiculo.FillWeight = 80F;
            this.Veiculo.HeaderText = "Veículo";
            this.Veiculo.MinimumWidth = 6;
            this.Veiculo.Name = "Veiculo";
            this.Veiculo.ReadOnly = true;
            this.Veiculo.Width = 80;
            // 
            // Debito
            // 
            this.Debito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Debito.DefaultCellStyle = dataGridViewCellStyle3;
            this.Debito.FillWeight = 80F;
            this.Debito.HeaderText = "Débito";
            this.Debito.MinimumWidth = 80;
            this.Debito.Name = "Debito";
            this.Debito.ReadOnly = true;
            this.Debito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Debito.Width = 80;
            // 
            // Credito
            // 
            this.Credito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Credito.DefaultCellStyle = dataGridViewCellStyle4;
            this.Credito.FillWeight = 80F;
            this.Credito.HeaderText = "Crédito";
            this.Credito.MinimumWidth = 80;
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            this.Credito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Credito.Width = 80;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle5;
            this.Valor.FillWeight = 80F;
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 80;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Valor.Width = 80;
            // 
            // Conciliacao
            // 
            this.Conciliacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Conciliacao.DataPropertyName = "Conciliacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Conciliacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.Conciliacao.FillWeight = 15F;
            this.Conciliacao.HeaderText = "";
            this.Conciliacao.MinimumWidth = 15;
            this.Conciliacao.Name = "Conciliacao";
            this.Conciliacao.ReadOnly = true;
            this.Conciliacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Conciliacao.Width = 15;
            // 
            // CrdDeb
            // 
            this.CrdDeb.DataPropertyName = "CrdDeb";
            this.CrdDeb.HeaderText = "CrdDeb";
            this.CrdDeb.MinimumWidth = 6;
            this.CrdDeb.Name = "CrdDeb";
            this.CrdDeb.ReadOnly = true;
            this.CrdDeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CrdDeb.Visible = false;
            this.CrdDeb.Width = 125;
            // 
            // IdentificacaoOFX
            // 
            this.IdentificacaoOFX.DataPropertyName = "IdentificacaoOFX";
            this.IdentificacaoOFX.HeaderText = "IdentificacaoOFX";
            this.IdentificacaoOFX.MinimumWidth = 6;
            this.IdentificacaoOFX.Name = "IdentificacaoOFX";
            this.IdentificacaoOFX.ReadOnly = true;
            this.IdentificacaoOFX.Visible = false;
            this.IdentificacaoOFX.Width = 125;
            // 
            // fmConciliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1539, 592);
            this.Controls.Add(this.panelConciliacao);
            this.Controls.Add(this.panelFundo);
            this.Controls.Add(this.statusStrip);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmConciliacao";
            this.Text = "Concilição por Arquivo";
            this.Shown += new System.EventHandler(this.fmConciliacao_Shown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.statusStrip, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.panelFundo, 0);
            this.Controls.SetChildIndex(this.panelConciliacao, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaBindingSource)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelFundo.ResumeLayout(false);
            this.groupBoxLancamento.ResumeLayout(false);
            this.groupBoxLancamento.PerformLayout();
            this.panelConciliacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movimentoContaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource movimentoContaBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLancamentos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelArquivo;
        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.GroupBox groupBoxLancamento;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelCrdDeb;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.DateTimePicker dateTimePickerData;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Panel panelConciliacao;
        private System.Windows.Forms.DataGridView movimentoContaDataGridView;
        private System.Windows.Forms.Button buttonProximo;
        private System.Windows.Forms.Button buttonAnterior;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonLigar;
        private System.Windows.Forms.Button buttonSeparar;
        private System.Windows.Forms.Button buttonAtencao;
        private System.Windows.Forms.Timer timerAtencao;
        private System.Windows.Forms.Button buttonConciliado;
        private System.Windows.Forms.Button buttonAjustarData;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentoInvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn LancamentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeiculoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrdDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacaoOFX;
    }
}
