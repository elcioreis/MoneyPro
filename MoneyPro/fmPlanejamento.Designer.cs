namespace MoneyPro
{
    partial class fmPlanejamento
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
            this.planejamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonEfetivar = new System.Windows.Forms.Button();
            this.buttonCalendario = new System.Windows.Forms.Button();
            this.btnExibeSomentePlanejamentosAtivos = new System.Windows.Forms.Button();
            this.btnExibeTodosPlanejamentos = new System.Windows.Forms.Button();
            this.planejamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlanejamentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrdDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeNaoUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeDiferenca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoDiaMes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonEfetivar);
            this.panelRodape.Controls.Add(this.buttonEditar);
            this.panelRodape.Location = new System.Drawing.Point(0, 436);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(809, 37);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonEditar, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonEfetivar, 0);
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
            this.panelTopo.Controls.Add(this.btnExibeSomentePlanejamentosAtivos);
            this.panelTopo.Controls.Add(this.btnExibeTodosPlanejamentos);
            this.panelTopo.Controls.Add(this.buttonCalendario);
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(809, 49);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonCalendario, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnExibeTodosPlanejamentos, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnExibeSomentePlanejamentosAtivos, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(193, 32);
            this.labelTopo.Text = "Planejamento";
            // 
            // planejamentoDataGridView
            // 
            this.planejamentoDataGridView.AllowUserToAddRows = false;
            this.planejamentoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.planejamentoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.planejamentoDataGridView.AutoGenerateColumns = false;
            this.planejamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planejamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlanejamentoID,
            this.Descricao,
            this.Conta,
            this.Lancamento,
            this.Categoria,
            this.GrupoCategoria,
            this.CrdDeb,
            this.Valor,
            this.TipoTotal,
            this.Parcela,
            this.DtInicial,
            this.Dia,
            this.TipoDia,
            this.SeNaoUtil,
            this.SeDiferenca,
            this.Processados,
            this.Ativo,
            this.Observacao,
            this.UltimoDiaMes});
            this.planejamentoDataGridView.DataSource = this.planejamentoBindingSource;
            this.planejamentoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planejamentoDataGridView.Location = new System.Drawing.Point(0, 49);
            this.planejamentoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.planejamentoDataGridView.Name = "planejamentoDataGridView";
            this.planejamentoDataGridView.ReadOnly = true;
            this.planejamentoDataGridView.RowHeadersVisible = false;
            this.planejamentoDataGridView.RowHeadersWidth = 51;
            this.planejamentoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.planejamentoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planejamentoDataGridView.ShowCellToolTips = false;
            this.planejamentoDataGridView.Size = new System.Drawing.Size(809, 387);
            this.planejamentoDataGridView.TabIndex = 5;
            this.planejamentoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.planejamentoDataGridView_CellFormatting);
            this.planejamentoDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PlanejamentoDataGridView_CellMouseMove);
            // 
            // buttonEditar
            // 
            this.buttonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditar.Image = global::MoneyPro.Properties.Resources.z16editar;
            this.buttonEditar.Location = new System.Drawing.Point(81, 4);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(31, 28);
            this.buttonEditar.TabIndex = 5;
            this.buttonEditar.TabStop = false;
            this.buttonEditar.Tag = "";
            this.toolTip.SetToolTip(this.buttonEditar, "Editar item do planejamento [F2]");
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonEfetivar
            // 
            this.buttonEfetivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEfetivar.Image = global::MoneyPro.Properties.Resources.z16pagamento;
            this.buttonEfetivar.Location = new System.Drawing.Point(120, 4);
            this.buttonEfetivar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEfetivar.Name = "buttonEfetivar";
            this.buttonEfetivar.Size = new System.Drawing.Size(31, 28);
            this.buttonEfetivar.TabIndex = 6;
            this.buttonEfetivar.TabStop = false;
            this.buttonEfetivar.Tag = "";
            this.toolTip.SetToolTip(this.buttonEfetivar, "Efetivar item do planejamento [Ctrl+Enter]");
            this.buttonEfetivar.UseVisualStyleBackColor = true;
            this.buttonEfetivar.Click += new System.EventHandler(this.buttonEfetivar_Click);
            // 
            // buttonCalendario
            // 
            this.buttonCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalendario.Image = global::MoneyPro.Properties.Resources.z16calendario;
            this.buttonCalendario.Location = new System.Drawing.Point(728, 10);
            this.buttonCalendario.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalendario.Name = "buttonCalendario";
            this.buttonCalendario.Size = new System.Drawing.Size(31, 28);
            this.buttonCalendario.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonCalendario, "Calendário");
            this.buttonCalendario.UseVisualStyleBackColor = true;
            this.buttonCalendario.Click += new System.EventHandler(this.buttonCalendario_Click);
            // 
            // btnExibeSomentePlanejamentosAtivos
            // 
            this.btnExibeSomentePlanejamentosAtivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibeSomentePlanejamentosAtivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibeSomentePlanejamentosAtivos.Image = global::MoneyPro.Properties.Resources.z16radio_on_button;
            this.btnExibeSomentePlanejamentosAtivos.Location = new System.Drawing.Point(767, 10);
            this.btnExibeSomentePlanejamentosAtivos.Margin = new System.Windows.Forms.Padding(4);
            this.btnExibeSomentePlanejamentosAtivos.Name = "btnExibeSomentePlanejamentosAtivos";
            this.btnExibeSomentePlanejamentosAtivos.Size = new System.Drawing.Size(31, 28);
            this.btnExibeSomentePlanejamentosAtivos.TabIndex = 7;
            this.btnExibeSomentePlanejamentosAtivos.TabStop = false;
            this.toolTip.SetToolTip(this.btnExibeSomentePlanejamentosAtivos, "Exibe somente planejamentos ativos");
            this.btnExibeSomentePlanejamentosAtivos.UseVisualStyleBackColor = true;
            this.btnExibeSomentePlanejamentosAtivos.Visible = false;
            this.btnExibeSomentePlanejamentosAtivos.Click += new System.EventHandler(this.BtnExibeTodosPlanejamentos_Click);
            // 
            // btnExibeTodosPlanejamentos
            // 
            this.btnExibeTodosPlanejamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExibeTodosPlanejamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibeTodosPlanejamentos.Image = global::MoneyPro.Properties.Resources.z16radio_off_button;
            this.btnExibeTodosPlanejamentos.Location = new System.Drawing.Point(767, 10);
            this.btnExibeTodosPlanejamentos.Margin = new System.Windows.Forms.Padding(4);
            this.btnExibeTodosPlanejamentos.Name = "btnExibeTodosPlanejamentos";
            this.btnExibeTodosPlanejamentos.Size = new System.Drawing.Size(31, 28);
            this.btnExibeTodosPlanejamentos.TabIndex = 6;
            this.btnExibeTodosPlanejamentos.TabStop = false;
            this.toolTip.SetToolTip(this.btnExibeTodosPlanejamentos, "Exibe todos os planejamentos");
            this.btnExibeTodosPlanejamentos.UseVisualStyleBackColor = true;
            this.btnExibeTodosPlanejamentos.Visible = false;
            this.btnExibeTodosPlanejamentos.Click += new System.EventHandler(this.BtnExibeTodosPlanejamentos_Click);
            // 
            // planejamentoBindingSource
            // 
            this.planejamentoBindingSource.DataSource = typeof(Modelos.Planejamento);
            // 
            // PlanejamentoID
            // 
            this.PlanejamentoID.DataPropertyName = "PlanejamentoID";
            this.PlanejamentoID.HeaderText = "PlanejamentoID";
            this.PlanejamentoID.MinimumWidth = 6;
            this.PlanejamentoID.Name = "PlanejamentoID";
            this.PlanejamentoID.ReadOnly = true;
            this.PlanejamentoID.Visible = false;
            this.PlanejamentoID.Width = 125;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.FillWeight = 140F;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 6;
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Conta
            // 
            this.Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Conta.DataPropertyName = "Conta";
            this.Conta.HeaderText = "Conta";
            this.Conta.MinimumWidth = 6;
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Width = 74;
            // 
            // Lancamento
            // 
            this.Lancamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Lancamento.DataPropertyName = "Lancamento";
            this.Lancamento.HeaderText = "Lançamento";
            this.Lancamento.MinimumWidth = 6;
            this.Lancamento.Name = "Lancamento";
            this.Lancamento.ReadOnly = true;
            this.Lancamento.Width = 115;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 140F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 140;
            // 
            // GrupoCategoria
            // 
            this.GrupoCategoria.DataPropertyName = "GrupoCategoria";
            this.GrupoCategoria.FillWeight = 70F;
            this.GrupoCategoria.HeaderText = "Grupo";
            this.GrupoCategoria.MinimumWidth = 6;
            this.GrupoCategoria.Name = "GrupoCategoria";
            this.GrupoCategoria.ReadOnly = true;
            this.GrupoCategoria.Width = 70;
            // 
            // CrdDeb
            // 
            this.CrdDeb.DataPropertyName = "CrdDeb";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CrdDeb.DefaultCellStyle = dataGridViewCellStyle2;
            this.CrdDeb.FillWeight = 18F;
            this.CrdDeb.HeaderText = "";
            this.CrdDeb.MinimumWidth = 18;
            this.CrdDeb.Name = "CrdDeb";
            this.CrdDeb.ReadOnly = true;
            this.CrdDeb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CrdDeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CrdDeb.Visible = false;
            this.CrdDeb.Width = 18;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 70;
            // 
            // TipoTotal
            // 
            this.TipoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoTotal.DataPropertyName = "TipoTotal";
            this.TipoTotal.HeaderText = "Total";
            this.TipoTotal.MinimumWidth = 6;
            this.TipoTotal.Name = "TipoTotal";
            this.TipoTotal.ReadOnly = true;
            this.TipoTotal.Width = 69;
            // 
            // Parcela
            // 
            this.Parcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Parcela.DataPropertyName = "Parcela";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Parcela.DefaultCellStyle = dataGridViewCellStyle4;
            this.Parcela.HeaderText = "Parcela";
            this.Parcela.MinimumWidth = 6;
            this.Parcela.Name = "Parcela";
            this.Parcela.ReadOnly = true;
            this.Parcela.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Parcela.Width = 62;
            // 
            // DtInicial
            // 
            this.DtInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DtInicial.DataPropertyName = "DtInicial";
            this.DtInicial.HeaderText = "Próxima";
            this.DtInicial.MinimumWidth = 6;
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.ReadOnly = true;
            this.DtInicial.Width = 87;
            // 
            // Dia
            // 
            this.Dia.DataPropertyName = "Dia";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dia.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dia.FillWeight = 30F;
            this.Dia.HeaderText = "Dia";
            this.Dia.MinimumWidth = 30;
            this.Dia.Name = "Dia";
            this.Dia.ReadOnly = true;
            this.Dia.Width = 30;
            // 
            // TipoDia
            // 
            this.TipoDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoDia.DataPropertyName = "TipoDia";
            this.TipoDia.HeaderText = "Tipo";
            this.TipoDia.MinimumWidth = 6;
            this.TipoDia.Name = "TipoDia";
            this.TipoDia.ReadOnly = true;
            this.TipoDia.Width = 65;
            // 
            // SeNaoUtil
            // 
            this.SeNaoUtil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SeNaoUtil.DataPropertyName = "SeNaoUtil";
            this.SeNaoUtil.FillWeight = 60F;
            this.SeNaoUtil.HeaderText = "Não Útil";
            this.SeNaoUtil.MinimumWidth = 6;
            this.SeNaoUtil.Name = "SeNaoUtil";
            this.SeNaoUtil.ReadOnly = true;
            this.SeNaoUtil.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SeNaoUtil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SeNaoUtil.Width = 64;
            // 
            // SeDiferenca
            // 
            this.SeDiferenca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SeDiferenca.DataPropertyName = "SeDiferenca";
            this.SeDiferenca.FillWeight = 70F;
            this.SeDiferenca.HeaderText = "Diferença";
            this.SeDiferenca.MinimumWidth = 6;
            this.SeDiferenca.Name = "SeDiferenca";
            this.SeDiferenca.ReadOnly = true;
            this.SeDiferenca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SeDiferenca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SeDiferenca.Width = 75;
            // 
            // Processados
            // 
            this.Processados.DataPropertyName = "Processados";
            this.Processados.HeaderText = "Processados";
            this.Processados.MinimumWidth = 6;
            this.Processados.Name = "Processados";
            this.Processados.ReadOnly = true;
            this.Processados.Visible = false;
            this.Processados.Width = 125;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.MinimumWidth = 6;
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 45;
            // 
            // Observacao
            // 
            this.Observacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Observacao.DataPropertyName = "Observacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Observacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.Observacao.FillWeight = 25F;
            this.Observacao.HeaderText = "?";
            this.Observacao.MinimumWidth = 25;
            this.Observacao.Name = "Observacao";
            this.Observacao.ReadOnly = true;
            this.Observacao.ToolTipText = "Tem observação";
            this.Observacao.Width = 25;
            // 
            // UltimoDiaMes
            // 
            this.UltimoDiaMes.DataPropertyName = "UltimoDiaMes";
            this.UltimoDiaMes.HeaderText = "UltimoDiaMes";
            this.UltimoDiaMes.MinimumWidth = 6;
            this.UltimoDiaMes.Name = "UltimoDiaMes";
            this.UltimoDiaMes.ReadOnly = true;
            this.UltimoDiaMes.Visible = false;
            this.UltimoDiaMes.Width = 125;
            // 
            // fmPlanejamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(809, 473);
            this.Controls.Add(this.planejamentoDataGridView);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmPlanejamento";
            this.Text = "fmPlanejamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmPlanejamento_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.planejamentoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planejamentoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource planejamentoBindingSource;
        private System.Windows.Forms.DataGridView planejamentoDataGridView;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonEfetivar;
        private System.Windows.Forms.Button buttonCalendario;
        private System.Windows.Forms.Button btnExibeSomentePlanejamentosAtivos;
        private System.Windows.Forms.Button btnExibeTodosPlanejamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanejamentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrdDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeNaoUtil;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeDiferenca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UltimoDiaMes;
    }
}
