namespace MoneyPro
{
    partial class fmParceiros
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
            this.lancamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lancamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.LancamentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sistema = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 297);
            this.panelRodape.Size = new System.Drawing.Size(417, 30);
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
            this.panelTopo.Size = new System.Drawing.Size(417, 40);
            this.panelTopo.TabIndex = 2;
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(389, 24);
            this.labelTopo.Text = "Cadastro de Parceiros / Lançamentos";
            // 
            // lancamentoBindingSource
            // 
            this.lancamentoBindingSource.DataSource = typeof(Modelos.Lancamento);
            // 
            // lancamentoDataGridView
            // 
            this.lancamentoDataGridView.AllowUserToAddRows = false;
            this.lancamentoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.lancamentoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.lancamentoDataGridView.AutoGenerateColumns = false;
            this.lancamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lancamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LancamentoID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.Ativo,
            this.Sistema});
            this.lancamentoDataGridView.DataSource = this.lancamentoBindingSource;
            this.lancamentoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lancamentoDataGridView.Location = new System.Drawing.Point(0, 40);
            this.lancamentoDataGridView.Name = "lancamentoDataGridView";
            this.lancamentoDataGridView.RowHeadersVisible = false;
            this.lancamentoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lancamentoDataGridView.Size = new System.Drawing.Size(417, 257);
            this.lancamentoDataGridView.TabIndex = 0;
            this.lancamentoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.lancamentoDataGridView_CellFormatting);
            this.lancamentoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.lancamentoDataGridView_EditingControlShowing);
            this.lancamentoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.lancamentoDataGridView_RowValidating);
            this.lancamentoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lancamentoDataGridView_KeyPress);
            // 
            // LancamentoID
            // 
            this.LancamentoID.DataPropertyName = "LancamentoID";
            this.LancamentoID.HeaderText = "LancamentoID";
            this.LancamentoID.Name = "LancamentoID";
            this.LancamentoID.Visible = false;
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
            this.Apelido.FillWeight = 180F;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 120;
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 120;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle3.NullValue = "null";
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MinimumWidth = 100;
            this.Descricao.Name = "Descricao";
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
            // Sistema
            // 
            this.Sistema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sistema.DataPropertyName = "Sistema";
            this.Sistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sistema.HeaderText = "Sistema";
            this.Sistema.Name = "Sistema";
            this.Sistema.ReadOnly = true;
            this.Sistema.Width = 50;
            // 
            // fmParceiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(417, 327);
            this.Controls.Add(this.lancamentoDataGridView);
            this.Name = "fmParceiros";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmLancamentos_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.lancamentoDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lancamentoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource lancamentoBindingSource;
        private System.Windows.Forms.DataGridView lancamentoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn LancamentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sistema;
    }
}
