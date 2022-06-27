namespace MoneyPro
{
    partial class fmInstituicoes
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
            this.btnTipoInstituicao = new System.Windows.Forms.Button();
            this.instituicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instituicaoDataGridView = new System.Windows.Forms.DataGridView();
            this.InstituicaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoInstituicaoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 342);
            this.panelRodape.Size = new System.Drawing.Size(634, 30);
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
            this.panelTopo.Controls.Add(this.btnTipoInstituicao);
            this.panelTopo.Size = new System.Drawing.Size(634, 40);
            this.panelTopo.TabIndex = 2;
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.btnTipoInstituicao, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(256, 24);
            this.labelTopo.Text = "Cadastro de Instituições";
            // 
            // btnTipoInstituicao
            // 
            this.btnTipoInstituicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipoInstituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoInstituicao.Image = global::MoneyPro.Properties.Resources.z16tipoInstituicao;
            this.btnTipoInstituicao.Location = new System.Drawing.Point(599, 9);
            this.btnTipoInstituicao.Name = "btnTipoInstituicao";
            this.btnTipoInstituicao.Size = new System.Drawing.Size(23, 23);
            this.btnTipoInstituicao.TabIndex = 0;
            this.btnTipoInstituicao.UseVisualStyleBackColor = true;
            this.btnTipoInstituicao.Click += new System.EventHandler(this.btnTipoInstituicao_Click);
            // 
            // instituicaoBindingSource
            // 
            this.instituicaoBindingSource.DataSource = typeof(Modelos.Instituicao);
            // 
            // instituicaoDataGridView
            // 
            this.instituicaoDataGridView.AllowUserToAddRows = false;
            this.instituicaoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.instituicaoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.instituicaoDataGridView.AutoGenerateColumns = false;
            this.instituicaoDataGridView.CausesValidation = false;
            this.instituicaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.instituicaoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstituicaoID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.TipoInstituicaoID,
            this.Banco,
            this.Ativo});
            this.instituicaoDataGridView.DataSource = this.instituicaoBindingSource;
            this.instituicaoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instituicaoDataGridView.Location = new System.Drawing.Point(0, 40);
            this.instituicaoDataGridView.Name = "instituicaoDataGridView";
            this.instituicaoDataGridView.RowHeadersVisible = false;
            this.instituicaoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.instituicaoDataGridView.Size = new System.Drawing.Size(634, 302);
            this.instituicaoDataGridView.TabIndex = 0;
            this.instituicaoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.instituicaoDataGridView_EditingControlShowing);
            this.instituicaoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.instituicaoDataGridView_RowValidating);
            this.instituicaoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.instituicaoDataGridView_KeyPress);
            // 
            // InstituicaoID
            // 
            this.InstituicaoID.DataPropertyName = "InstituicaoID";
            this.InstituicaoID.HeaderText = "InstituicaoID";
            this.InstituicaoID.Name = "InstituicaoID";
            this.InstituicaoID.Visible = false;
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.HeaderText = "UsuarioID";
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.Visible = false;
            // 
            // Apelido
            // 
            this.Apelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Apelido.DataPropertyName = "Apelido";
            dataGridViewCellStyle2.NullValue = "null";
            this.Apelido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 100;
            this.Apelido.Name = "Apelido";
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle3.NullValue = "null";
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // TipoInstituicaoID
            // 
            this.TipoInstituicaoID.DataPropertyName = "TipoInstituicaoID";
            this.TipoInstituicaoID.HeaderText = "TipoInstituicaoID";
            this.TipoInstituicaoID.Name = "TipoInstituicaoID";
            this.TipoInstituicaoID.Visible = false;
            // 
            // Banco
            // 
            this.Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Banco.DataPropertyName = "Banco";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "000";
            this.Banco.DefaultCellStyle = dataGridViewCellStyle4;
            this.Banco.FillWeight = 80F;
            this.Banco.HeaderText = "Banco";
            this.Banco.MinimumWidth = 80;
            this.Banco.Name = "Banco";
            this.Banco.Width = 80;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.Width = 37;
            // 
            // fmInstituicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 372);
            this.Controls.Add(this.instituicaoDataGridView);
            this.Name = "fmInstituicoes";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmInstituicoes_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.instituicaoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTipoInstituicao;
        private System.Windows.Forms.BindingSource instituicaoBindingSource;
        private System.Windows.Forms.DataGridView instituicaoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstituicaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInstituicaoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;

    }
}
