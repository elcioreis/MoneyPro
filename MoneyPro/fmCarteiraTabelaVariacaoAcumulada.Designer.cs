namespace MoneyPro
{
    partial class fmCarteiraTabelaVariacaoAcumulada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.dataGridViewVariacao = new System.Windows.Forms.DataGridView();
            this.variacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnTudo = new System.Windows.Forms.Button();
            this.btnAcumulado = new System.Windows.Forms.Button();
            this.btnVariacao = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.btnVariacao);
            this.panelRodape.Controls.Add(this.btnAcumulado);
            this.panelRodape.Controls.Add(this.btnTudo);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.btnTudo, 0);
            this.panelRodape.Controls.SetChildIndex(this.btnAcumulado, 0);
            this.panelRodape.Controls.SetChildIndex(this.btnVariacao, 0);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(393, 3);
            this.buttonExcluir.Visible = false;
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.Location = new System.Drawing.Point(364, 3);
            this.buttonIncluir.Visible = false;
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(379, 24);
            this.labelTopo.Text = "Variação Acumulada do Rendimento";
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(417, 9);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(23, 23);
            this.buttonFecharDetalhes.TabIndex = 15;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.toolTip.SetToolTip(this.buttonFecharDetalhes, "Retornar à tela anterior");
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.buttonFecharDetalhes_Click);
            // 
            // dataGridViewVariacao
            // 
            this.dataGridViewVariacao.AllowUserToAddRows = false;
            this.dataGridViewVariacao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewVariacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewVariacao.CausesValidation = false;
            this.dataGridViewVariacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVariacao.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewVariacao.Name = "dataGridViewVariacao";
            this.dataGridViewVariacao.ReadOnly = true;
            this.dataGridViewVariacao.RowHeadersVisible = false;
            this.dataGridViewVariacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVariacao.Size = new System.Drawing.Size(452, 192);
            this.dataGridViewVariacao.TabIndex = 17;
            // 
            // btnTudo
            // 
            this.btnTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTudo.Image = global::MoneyPro.Properties.Resources.z16tudo;
            this.btnTudo.Location = new System.Drawing.Point(12, 4);
            this.btnTudo.Name = "btnTudo";
            this.btnTudo.Size = new System.Drawing.Size(23, 23);
            this.btnTudo.TabIndex = 16;
            this.btnTudo.TabStop = false;
            this.btnTudo.Tag = "";
            this.toolTip.SetToolTip(this.btnTudo, "Exibe tudo");
            this.btnTudo.UseVisualStyleBackColor = true;
            this.btnTudo.Click += new System.EventHandler(this.btnMudaExibicao);
            // 
            // btnAcumulado
            // 
            this.btnAcumulado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcumulado.Image = global::MoneyPro.Properties.Resources.z16acumulado;
            this.btnAcumulado.Location = new System.Drawing.Point(41, 4);
            this.btnAcumulado.Name = "btnAcumulado";
            this.btnAcumulado.Size = new System.Drawing.Size(23, 23);
            this.btnAcumulado.TabIndex = 17;
            this.btnAcumulado.TabStop = false;
            this.btnAcumulado.Tag = "";
            this.toolTip.SetToolTip(this.btnAcumulado, "Exibe apenas acumulado");
            this.btnAcumulado.UseVisualStyleBackColor = true;
            this.btnAcumulado.Click += new System.EventHandler(this.btnMudaExibicao);
            // 
            // btnVariacao
            // 
            this.btnVariacao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVariacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVariacao.Image = global::MoneyPro.Properties.Resources.z16variacao;
            this.btnVariacao.Location = new System.Drawing.Point(70, 4);
            this.btnVariacao.Name = "btnVariacao";
            this.btnVariacao.Size = new System.Drawing.Size(23, 23);
            this.btnVariacao.TabIndex = 18;
            this.btnVariacao.TabStop = false;
            this.btnVariacao.Tag = "";
            this.toolTip.SetToolTip(this.btnVariacao, "Exibe apenas variação");
            this.btnVariacao.UseVisualStyleBackColor = false;
            this.btnVariacao.Click += new System.EventHandler(this.btnMudaExibicao);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmCarteiraVariacaoAcumulada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.dataGridViewVariacao);
            this.Name = "fmCarteiraVariacaoAcumulada";
            this.Text = "fmCarteiraVariacaoAcumulada";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.dataGridViewVariacao, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variacaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.DataGridView dataGridViewVariacao;
        private System.Windows.Forms.BindingSource variacaoBindingSource;
        private System.Windows.Forms.Button btnVariacao;
        private System.Windows.Forms.Button btnAcumulado;
        private System.Windows.Forms.Button btnTudo;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
