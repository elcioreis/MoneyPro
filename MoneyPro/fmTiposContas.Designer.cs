namespace MoneyPro
{
    partial class fmTiposContas
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnGruposContas = new System.Windows.Forms.Button();
            this.tipoContaDataGridView = new System.Windows.Forms.DataGridView();
            this.tipoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TipoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoContaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Poupanca = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cartao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cambio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Investimento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CDB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 484);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(938, 37);
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
            this.panelTopo.Controls.Add(this.btnGruposContas);
            this.panelTopo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelTopo.Size = new System.Drawing.Size(938, 49);
            this.panelTopo.TabIndex = 0;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnGruposContas, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(395, 32);
            this.labelTopo.TabIndex = 1;
            this.labelTopo.Text = "Cadastro de Tipos de Contas";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // btnGruposContas
            // 
            this.btnGruposContas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGruposContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGruposContas.Image = global::MoneyPro.Properties.Resources.z16grupoContas;
            this.btnGruposContas.Location = new System.Drawing.Point(891, 11);
            this.btnGruposContas.Margin = new System.Windows.Forms.Padding(4);
            this.btnGruposContas.Name = "btnGruposContas";
            this.btnGruposContas.Size = new System.Drawing.Size(31, 28);
            this.btnGruposContas.TabIndex = 0;
            this.toolTip.SetToolTip(this.btnGruposContas, "Cadastro de Grupos de Contas");
            this.btnGruposContas.UseVisualStyleBackColor = true;
            this.btnGruposContas.Click += new System.EventHandler(this.btnGruposContas_Click);
            // 
            // tipoContaDataGridView
            // 
            this.tipoContaDataGridView.AllowUserToAddRows = false;
            this.tipoContaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.tipoContaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tipoContaDataGridView.AutoGenerateColumns = false;
            this.tipoContaDataGridView.CausesValidation = false;
            this.tipoContaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipoContaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoContaID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.GrupoContaID,
            this.Banco,
            this.Poupanca,
            this.Cartao,
            this.Cambio,
            this.Investimento,
            this.CDB,
            this.Ativo});
            this.tipoContaDataGridView.DataSource = this.tipoContaBindingSource;
            this.tipoContaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipoContaDataGridView.Location = new System.Drawing.Point(0, 49);
            this.tipoContaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.tipoContaDataGridView.Name = "tipoContaDataGridView";
            this.tipoContaDataGridView.RowHeadersVisible = false;
            this.tipoContaDataGridView.RowHeadersWidth = 51;
            this.tipoContaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tipoContaDataGridView.Size = new System.Drawing.Size(938, 435);
            this.tipoContaDataGridView.TabIndex = 0;
            this.tipoContaDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tipoContaDataGridView_EditingControlShowing);
            this.tipoContaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tipoContaDataGridView_RowValidating);
            this.tipoContaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoContaDataGridView_KeyPress);
            // 
            // tipoContaBindingSource
            // 
            this.tipoContaBindingSource.DataSource = typeof(Modelos.TipoConta);
            // 
            // TipoContaID
            // 
            this.TipoContaID.DataPropertyName = "TipoContaID";
            this.TipoContaID.HeaderText = "TipoContaID";
            this.TipoContaID.MinimumWidth = 6;
            this.TipoContaID.Name = "TipoContaID";
            this.TipoContaID.Visible = false;
            this.TipoContaID.Width = 125;
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
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 40;
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 83;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle3.NullValue = "null";
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 6;
            this.Descricao.Name = "Descricao";
            // 
            // GrupoContaID
            // 
            this.GrupoContaID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoContaID.DataPropertyName = "GrupoContaID";
            this.GrupoContaID.FillWeight = 120F;
            this.GrupoContaID.HeaderText = "Grupo de Contas";
            this.GrupoContaID.MinimumWidth = 120;
            this.GrupoContaID.Name = "GrupoContaID";
            this.GrupoContaID.Width = 126;
            // 
            // Banco
            // 
            this.Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Banco.DataPropertyName = "Banco";
            this.Banco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Banco.HeaderText = "Banco";
            this.Banco.MinimumWidth = 6;
            this.Banco.Name = "Banco";
            this.Banco.Width = 52;
            // 
            // Poupanca
            // 
            this.Poupanca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Poupanca.DataPropertyName = "Poupanca";
            this.Poupanca.FillWeight = 80F;
            this.Poupanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Poupanca.HeaderText = "Poupança";
            this.Poupanca.MinimumWidth = 6;
            this.Poupanca.Name = "Poupanca";
            this.Poupanca.Width = 75;
            // 
            // Cartao
            // 
            this.Cartao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cartao.DataPropertyName = "Cartao";
            this.Cartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cartao.HeaderText = "Cartão";
            this.Cartao.MinimumWidth = 6;
            this.Cartao.Name = "Cartao";
            this.Cartao.Width = 53;
            // 
            // Cambio
            // 
            this.Cambio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cambio.DataPropertyName = "Cambio";
            this.Cambio.FillWeight = 50F;
            this.Cambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cambio.HeaderText = "Câmbio";
            this.Cambio.MinimumWidth = 6;
            this.Cambio.Name = "Cambio";
            this.Cambio.Width = 60;
            // 
            // Investimento
            // 
            this.Investimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Investimento.DataPropertyName = "Investimento";
            this.Investimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Investimento.HeaderText = "Investimento";
            this.Investimento.MinimumWidth = 6;
            this.Investimento.Name = "Investimento";
            this.Investimento.Width = 88;
            // 
            // CDB
            // 
            this.CDB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CDB.DataPropertyName = "CDB";
            this.CDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CDB.HeaderText = "CDB";
            this.CDB.MinimumWidth = 6;
            this.CDB.Name = "CDB";
            this.CDB.Width = 41;
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
            // fmTiposContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(938, 521);
            this.Controls.Add(this.tipoContaDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmTiposContas";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTiposContas_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.tipoContaDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnGruposContas;
        private System.Windows.Forms.BindingSource tipoContaBindingSource;
        private System.Windows.Forms.DataGridView tipoContaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoContaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoContaID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Banco;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Poupanca;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cartao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cambio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Investimento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CDB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
