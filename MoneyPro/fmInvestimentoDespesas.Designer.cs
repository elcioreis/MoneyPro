namespace MoneyPro
{
    partial class fmInvestimentoDespesas
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
            this.investimentoDespesaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investimentoDespesaDataGridView = new System.Windows.Forms.DataGridView();
            this.InvestimentoDespesaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvestimentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpostoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComeCota = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Saida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 310);
            this.panelRodape.Size = new System.Drawing.Size(779, 30);
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
            this.panelTopo.Size = new System.Drawing.Size(779, 40);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(328, 24);
            this.labelTopo.Text = "Despesas Sobre o Investimento";
            // 
            // investimentoDespesaBindingSource
            // 
            this.investimentoDespesaBindingSource.DataSource = typeof(Modelos.InvestimentoDespesa);
            // 
            // investimentoDespesaDataGridView
            // 
            this.investimentoDespesaDataGridView.AllowUserToAddRows = false;
            this.investimentoDespesaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.investimentoDespesaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.investimentoDespesaDataGridView.AutoGenerateColumns = false;
            this.investimentoDespesaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.investimentoDespesaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvestimentoDespesaID,
            this.InvestimentoID,
            this.CategoriaID,
            this.ImpostoID,
            this.Descricao,
            this.IOF,
            this.IR,
            this.ComeCota,
            this.Entrada,
            this.Saida,
            this.Ordem});
            this.investimentoDespesaDataGridView.DataSource = this.investimentoDespesaBindingSource;
            this.investimentoDespesaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.investimentoDespesaDataGridView.Location = new System.Drawing.Point(0, 40);
            this.investimentoDespesaDataGridView.Name = "investimentoDespesaDataGridView";
            this.investimentoDespesaDataGridView.RowHeadersVisible = false;
            this.investimentoDespesaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.investimentoDespesaDataGridView.Size = new System.Drawing.Size(779, 270);
            this.investimentoDespesaDataGridView.TabIndex = 5;
            this.investimentoDespesaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.investimentoDespesaDataGridView_RowValidating);
            this.investimentoDespesaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.investimentoDespesaDataGridView_KeyPress);
            // 
            // InvestimentoDespesaID
            // 
            this.InvestimentoDespesaID.DataPropertyName = "InvestimentoDespesaID";
            this.InvestimentoDespesaID.HeaderText = "InvestimentoDespesaID";
            this.InvestimentoDespesaID.Name = "InvestimentoDespesaID";
            this.InvestimentoDespesaID.Visible = false;
            // 
            // InvestimentoID
            // 
            this.InvestimentoID.DataPropertyName = "InvestimentoID";
            this.InvestimentoID.HeaderText = "InvestimentoID";
            this.InvestimentoID.Name = "InvestimentoID";
            this.InvestimentoID.Visible = false;
            // 
            // CategoriaID
            // 
            this.CategoriaID.DataPropertyName = "CategoriaID";
            this.CategoriaID.HeaderText = "CategoriaID";
            this.CategoriaID.Name = "CategoriaID";
            this.CategoriaID.Visible = false;
            // 
            // ImpostoID
            // 
            this.ImpostoID.DataPropertyName = "ImpostoID";
            this.ImpostoID.HeaderText = "ImpostoID";
            this.ImpostoID.Name = "ImpostoID";
            this.ImpostoID.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.MaxInputLength = 25;
            this.Descricao.Name = "Descricao";
            // 
            // IOF
            // 
            this.IOF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IOF.DataPropertyName = "IOF";
            this.IOF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IOF.HeaderText = "IOF";
            this.IOF.MinimumWidth = 50;
            this.IOF.Name = "IOF";
            this.IOF.Width = 50;
            // 
            // IR
            // 
            this.IR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IR.DataPropertyName = "IR";
            this.IR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IR.HeaderText = "IR";
            this.IR.MinimumWidth = 50;
            this.IR.Name = "IR";
            this.IR.Width = 50;
            // 
            // ComeCota
            // 
            this.ComeCota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComeCota.DataPropertyName = "ComeCota";
            this.ComeCota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComeCota.HeaderText = "Come Cota";
            this.ComeCota.MinimumWidth = 50;
            this.ComeCota.Name = "ComeCota";
            this.ComeCota.Width = 65;
            // 
            // Entrada
            // 
            this.Entrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Entrada.DataPropertyName = "Entrada";
            this.Entrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Entrada.HeaderText = "Entrada";
            this.Entrada.MinimumWidth = 50;
            this.Entrada.Name = "Entrada";
            this.Entrada.Width = 50;
            // 
            // Saida
            // 
            this.Saida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Saida.DataPropertyName = "Saida";
            this.Saida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Saida.HeaderText = "Saída";
            this.Saida.MinimumWidth = 50;
            this.Saida.Name = "Saida";
            this.Saida.Width = 50;
            // 
            // Ordem
            // 
            this.Ordem.DataPropertyName = "Ordem";
            this.Ordem.FillWeight = 50F;
            this.Ordem.HeaderText = "Ordem";
            this.Ordem.MinimumWidth = 50;
            this.Ordem.Name = "Ordem";
            this.Ordem.Width = 50;
            // 
            // fmInvestimentoDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(779, 340);
            this.Controls.Add(this.investimentoDespesaDataGridView);
            this.Name = "fmInvestimentoDespesas";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmInvestimentoDespesas_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.investimentoDespesaDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investimentoDespesaDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource investimentoDespesaBindingSource;
        private System.Windows.Forms.DataGridView investimentoDespesaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvestimentoDespesaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvestimentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpostoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IOF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ComeCota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Saida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
    }
}
