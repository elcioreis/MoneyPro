namespace MoneyPro
{
    partial class fmImposto
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
            this.groupBoxImposto = new System.Windows.Forms.GroupBox();
            this.impostoDataGridView = new System.Windows.Forms.DataGridView();
            this.ImpostoImpostoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpostoApelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpostoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpostoAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.impostoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxFaixas = new System.Windows.Forms.GroupBox();
            this.impostoFaixaDataGridView = new System.Windows.Forms.DataGridView();
            this.FaixaFaixaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaixaImpostoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaixaApelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaixaDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaixaPorcentagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impostoFaixaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instituicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            this.groupBoxImposto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impostoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impostoBindingSource)).BeginInit();
            this.groupBoxFaixas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impostoFaixaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impostoFaixaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Location = new System.Drawing.Point(0, 389);
            this.panelRodape.Size = new System.Drawing.Size(528, 30);
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
            this.panelTopo.Size = new System.Drawing.Size(528, 40);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(300, 24);
            this.labelTopo.Text = "Tributação sobre Aplicações";
            // 
            // groupBoxImposto
            // 
            this.groupBoxImposto.Controls.Add(this.impostoDataGridView);
            this.groupBoxImposto.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxImposto.Location = new System.Drawing.Point(0, 40);
            this.groupBoxImposto.Name = "groupBoxImposto";
            this.groupBoxImposto.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.groupBoxImposto.Size = new System.Drawing.Size(528, 112);
            this.groupBoxImposto.TabIndex = 5;
            this.groupBoxImposto.TabStop = false;
            this.groupBoxImposto.Text = "Imposto";
            // 
            // impostoDataGridView
            // 
            this.impostoDataGridView.AllowUserToAddRows = false;
            this.impostoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.impostoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.impostoDataGridView.AutoGenerateColumns = false;
            this.impostoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.impostoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImpostoImpostoID,
            this.ImpostoApelido,
            this.ImpostoDescricao,
            this.ImpostoAtivo});
            this.impostoDataGridView.DataSource = this.impostoBindingSource;
            this.impostoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.impostoDataGridView.Location = new System.Drawing.Point(5, 16);
            this.impostoDataGridView.Name = "impostoDataGridView";
            this.impostoDataGridView.RowHeadersVisible = false;
            this.impostoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.impostoDataGridView.Size = new System.Drawing.Size(518, 91);
            this.impostoDataGridView.TabIndex = 0;
            this.impostoDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.impostoDataGridView_CellEnter);
            this.impostoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.impostoDataGridView_EditingControlShowing);
            this.impostoDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.impostoDataGridView_RowValidating);
            this.impostoDataGridView.Enter += new System.EventHandler(this.impostoDataGridView_Enter);
            this.impostoDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.impostoDataGridView_KeyPress);
            // 
            // ImpostoImpostoID
            // 
            this.ImpostoImpostoID.DataPropertyName = "ImpostoID";
            this.ImpostoImpostoID.HeaderText = "ImpostoID";
            this.ImpostoImpostoID.Name = "ImpostoImpostoID";
            this.ImpostoImpostoID.Visible = false;
            // 
            // ImpostoApelido
            // 
            this.ImpostoApelido.DataPropertyName = "Apelido";
            this.ImpostoApelido.FillWeight = 200F;
            this.ImpostoApelido.HeaderText = "Apelido";
            this.ImpostoApelido.Name = "ImpostoApelido";
            this.ImpostoApelido.Width = 200;
            // 
            // ImpostoDescricao
            // 
            this.ImpostoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImpostoDescricao.DataPropertyName = "Descricao";
            this.ImpostoDescricao.HeaderText = "Descrição";
            this.ImpostoDescricao.Name = "ImpostoDescricao";
            // 
            // ImpostoAtivo
            // 
            this.ImpostoAtivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ImpostoAtivo.DataPropertyName = "Ativo";
            this.ImpostoAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImpostoAtivo.HeaderText = "Ativo";
            this.ImpostoAtivo.Name = "ImpostoAtivo";
            this.ImpostoAtivo.Width = 37;
            // 
            // impostoBindingSource
            // 
            this.impostoBindingSource.DataSource = typeof(Modelos.Imposto);
            // 
            // groupBoxFaixas
            // 
            this.groupBoxFaixas.Controls.Add(this.impostoFaixaDataGridView);
            this.groupBoxFaixas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFaixas.Location = new System.Drawing.Point(0, 152);
            this.groupBoxFaixas.Name = "groupBoxFaixas";
            this.groupBoxFaixas.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.groupBoxFaixas.Size = new System.Drawing.Size(528, 237);
            this.groupBoxFaixas.TabIndex = 6;
            this.groupBoxFaixas.TabStop = false;
            this.groupBoxFaixas.Text = "Faixas";
            // 
            // impostoFaixaDataGridView
            // 
            this.impostoFaixaDataGridView.AllowUserToAddRows = false;
            this.impostoFaixaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.impostoFaixaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.impostoFaixaDataGridView.AutoGenerateColumns = false;
            this.impostoFaixaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.impostoFaixaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FaixaFaixaID,
            this.FaixaImpostoID,
            this.FaixaApelido,
            this.FaixaDias,
            this.FaixaPorcentagem});
            this.impostoFaixaDataGridView.DataSource = this.impostoFaixaBindingSource;
            this.impostoFaixaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.impostoFaixaDataGridView.Location = new System.Drawing.Point(5, 16);
            this.impostoFaixaDataGridView.Name = "impostoFaixaDataGridView";
            this.impostoFaixaDataGridView.RowHeadersVisible = false;
            this.impostoFaixaDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.impostoFaixaDataGridView.Size = new System.Drawing.Size(518, 216);
            this.impostoFaixaDataGridView.TabIndex = 0;
            this.impostoFaixaDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.impostoFaixaDataGridView_EditingControlShowing);
            this.impostoFaixaDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.impostoFaixaDataGridView_RowValidating);
            this.impostoFaixaDataGridView.Enter += new System.EventHandler(this.impostoFaixaDataGridView_Enter);
            this.impostoFaixaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.impostoFaixaDataGridView_KeyPress);
            // 
            // FaixaFaixaID
            // 
            this.FaixaFaixaID.DataPropertyName = "FaixaID";
            this.FaixaFaixaID.HeaderText = "FaixaID";
            this.FaixaFaixaID.Name = "FaixaFaixaID";
            this.FaixaFaixaID.Visible = false;
            // 
            // FaixaImpostoID
            // 
            this.FaixaImpostoID.DataPropertyName = "ImpostoID";
            this.FaixaImpostoID.HeaderText = "ImpostoID";
            this.FaixaImpostoID.Name = "FaixaImpostoID";
            this.FaixaImpostoID.Visible = false;
            // 
            // FaixaApelido
            // 
            this.FaixaApelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FaixaApelido.DataPropertyName = "Apelido";
            this.FaixaApelido.FillWeight = 200F;
            this.FaixaApelido.HeaderText = "Prazo da Aplicação";
            this.FaixaApelido.Name = "FaixaApelido";
            // 
            // FaixaDias
            // 
            this.FaixaDias.DataPropertyName = "Dias";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FaixaDias.DefaultCellStyle = dataGridViewCellStyle3;
            this.FaixaDias.HeaderText = "Dias";
            this.FaixaDias.Name = "FaixaDias";
            // 
            // FaixaPorcentagem
            // 
            this.FaixaPorcentagem.DataPropertyName = "Porcentagem";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.FaixaPorcentagem.DefaultCellStyle = dataGridViewCellStyle4;
            this.FaixaPorcentagem.HeaderText = "Alíquota";
            this.FaixaPorcentagem.Name = "FaixaPorcentagem";
            // 
            // impostoFaixaBindingSource
            // 
            this.impostoFaixaBindingSource.DataSource = typeof(Modelos.ImpostoFaixa);
            // 
            // instituicaoBindingSource
            // 
            this.instituicaoBindingSource.DataSource = typeof(Modelos.Instituicao);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 152);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(528, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // fmImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(528, 419);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBoxFaixas);
            this.Controls.Add(this.groupBoxImposto);
            this.Name = "fmImposto";
            this.Text = "MoneyPro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmImposto_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.groupBoxImposto, 0);
            this.Controls.SetChildIndex(this.groupBoxFaixas, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.groupBoxImposto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.impostoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impostoBindingSource)).EndInit();
            this.groupBoxFaixas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.impostoFaixaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impostoFaixaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instituicaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxImposto;
        private System.Windows.Forms.GroupBox groupBoxFaixas;
        private System.Windows.Forms.DataGridView impostoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpostoImpostoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpostoApelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpostoDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImpostoAtivo;
        private System.Windows.Forms.BindingSource impostoBindingSource;
        private System.Windows.Forms.BindingSource instituicaoBindingSource;
        private System.Windows.Forms.DataGridView impostoFaixaDataGridView;
        private System.Windows.Forms.BindingSource impostoFaixaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaixaFaixaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaixaImpostoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaixaApelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaixaDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaixaPorcentagem;
        private System.Windows.Forms.Splitter splitter1;
    }
}
