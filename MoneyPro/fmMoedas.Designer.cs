namespace MoneyPro
{
    partial class fmMoedas
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
            this.moedaDataGridView = new System.Windows.Forms.DataGridView();
            this.moedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoedaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eletronica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoedaBancoCentral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Padrao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Virtual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PadraoVirtual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MercadoBitCoin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moedaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moedaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 362);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(5);
            this.panelRodape.Size = new System.Drawing.Size(793, 37);
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
            this.panelTopo.Size = new System.Drawing.Size(793, 49);
            this.panelTopo.TabIndex = 2;
            // 
            // labelTopo
            // 
            this.labelTopo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTopo.Size = new System.Drawing.Size(286, 32);
            this.labelTopo.Text = "Cadastro de Moedas";
            // 
            // moedaDataGridView
            // 
            this.moedaDataGridView.AllowUserToAddRows = false;
            this.moedaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.moedaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.moedaDataGridView.AutoGenerateColumns = false;
            this.moedaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moedaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoedaID,
            this.Apelido,
            this.Simbolo,
            this.Eletronica,
            this.CodigoMoedaBancoCentral,
            this.Padrao,
            this.Virtual,
            this.PadraoVirtual,
            this.MercadoBitCoin});
            this.moedaDataGridView.DataSource = this.moedaBindingSource;
            this.moedaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moedaDataGridView.Location = new System.Drawing.Point(0, 49);
            this.moedaDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.moedaDataGridView.MultiSelect = false;
            this.moedaDataGridView.Name = "moedaDataGridView";
            this.moedaDataGridView.RowHeadersVisible = false;
            this.moedaDataGridView.RowHeadersWidth = 51;
            this.moedaDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.moedaDataGridView.RowTemplate.Height = 21;
            this.moedaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.moedaDataGridView.Size = new System.Drawing.Size(793, 313);
            this.moedaDataGridView.TabIndex = 0;
            this.moedaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.moedaDataGridView_CellContentClick);
            this.moedaDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.moedaDataGridView_EditingControlShowing);
            this.moedaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.moedaDataGridView_RowValidating);
            this.moedaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moedaDataGridView_KeyPress);
            // 
            // moedaBindingSource
            // 
            this.moedaBindingSource.DataSource = typeof(Modelos.Moeda);
            // 
            // MoedaID
            // 
            this.MoedaID.DataPropertyName = "MoedaID";
            this.MoedaID.HeaderText = "MoedaID";
            this.MoedaID.MinimumWidth = 6;
            this.MoedaID.Name = "MoedaID";
            this.MoedaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MoedaID.Visible = false;
            this.MoedaID.Width = 125;
            // 
            // Apelido
            // 
            this.Apelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Apelido.DataPropertyName = "Apelido";
            dataGridViewCellStyle2.NullValue = "null";
            this.Apelido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 100;
            this.Apelido.Name = "Apelido";
            // 
            // Simbolo
            // 
            this.Simbolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Simbolo.DataPropertyName = "Simbolo";
            this.Simbolo.HeaderText = "Símbolo";
            this.Simbolo.MinimumWidth = 6;
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.Width = 87;
            // 
            // Eletronica
            // 
            this.Eletronica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eletronica.DataPropertyName = "Eletronica";
            this.Eletronica.HeaderText = "Eletrônica";
            this.Eletronica.MinimumWidth = 6;
            this.Eletronica.Name = "Eletronica";
            // 
            // CodigoMoedaBancoCentral
            // 
            this.CodigoMoedaBancoCentral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CodigoMoedaBancoCentral.DataPropertyName = "CodigoMoedaBancoCentral";
            this.CodigoMoedaBancoCentral.HeaderText = "Banco Central";
            this.CodigoMoedaBancoCentral.MinimumWidth = 6;
            this.CodigoMoedaBancoCentral.Name = "CodigoMoedaBancoCentral";
            this.CodigoMoedaBancoCentral.Width = 126;
            // 
            // Padrao
            // 
            this.Padrao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Padrao.DataPropertyName = "Padrao";
            this.Padrao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Padrao.HeaderText = "Padrão";
            this.Padrao.MinimumWidth = 6;
            this.Padrao.Name = "Padrao";
            this.Padrao.Width = 60;
            // 
            // Virtual
            // 
            this.Virtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Virtual.DataPropertyName = "Virtual";
            this.Virtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Virtual.HeaderText = "Virtual";
            this.Virtual.MinimumWidth = 6;
            this.Virtual.Name = "Virtual";
            this.Virtual.Width = 54;
            // 
            // PadraoVirtual
            // 
            this.PadraoVirtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PadraoVirtual.DataPropertyName = "PadraoVirtual";
            this.PadraoVirtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PadraoVirtual.HeaderText = "Padrão Virtual";
            this.PadraoVirtual.MinimumWidth = 6;
            this.PadraoVirtual.Name = "PadraoVirtual";
            this.PadraoVirtual.Width = 104;
            // 
            // MercadoBitCoin
            // 
            this.MercadoBitCoin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MercadoBitCoin.DataPropertyName = "MercadoBitCoin";
            this.MercadoBitCoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MercadoBitCoin.HeaderText = "Mercado BitCoin";
            this.MercadoBitCoin.MinimumWidth = 6;
            this.MercadoBitCoin.Name = "MercadoBitCoin";
            this.MercadoBitCoin.Width = 117;
            // 
            // fmMoedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(793, 399);
            this.Controls.Add(this.moedaDataGridView);
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "fmMoedas";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmMoedas_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.moedaDataGridView, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moedaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moedaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource moedaBindingSource;
        private System.Windows.Forms.DataGridView moedaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoedaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Eletronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoedaBancoCentral;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Padrao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Virtual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PadraoVirtual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MercadoBitCoin;
    }
}
