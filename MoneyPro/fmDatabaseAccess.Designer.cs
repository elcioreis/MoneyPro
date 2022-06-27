namespace MoneyPro
{
    partial class fmDatabaseAccess
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
            this.pnlBotoeira = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlFundo = new System.Windows.Forms.Panel();
            this.gpbConfigurações = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.pnlAcessos = new System.Windows.Forms.Panel();
            this.gpbAcessos = new System.Windows.Forms.GroupBox();
            this.lbxAcessos = new System.Windows.Forms.ListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBotoeira.SuspendLayout();
            this.pnlFundo.SuspendLayout();
            this.gpbConfigurações.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.pnlAcessos.SuspendLayout();
            this.gpbAcessos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoeira
            // 
            this.pnlBotoeira.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBotoeira.Controls.Add(this.btnSalvar);
            this.pnlBotoeira.Controls.Add(this.btnExcluir);
            this.pnlBotoeira.Controls.Add(this.btnNovo);
            this.pnlBotoeira.Controls.Add(this.btnCancela);
            this.pnlBotoeira.Controls.Add(this.btnOk);
            this.pnlBotoeira.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoeira.Location = new System.Drawing.Point(0, 202);
            this.pnlBotoeira.Name = "pnlBotoeira";
            this.pnlBotoeira.Size = new System.Drawing.Size(501, 38);
            this.pnlBotoeira.TabIndex = 1;
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::MoneyPro.Properties.Resources.salvar;
            this.btnSalvar.Location = new System.Drawing.Point(66, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(23, 23);
            this.btnSalvar.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnSalvar, "Salvar Acesso");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::MoneyPro.Properties.Resources.excluir;
            this.btnExcluir.Location = new System.Drawing.Point(37, 8);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(23, 23);
            this.btnExcluir.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnExcluir, "Excluir Acesso");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::MoneyPro.Properties.Resources.novo;
            this.btnNovo.Location = new System.Drawing.Point(8, 8);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(23, 23);
            this.btnNovo.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnNovo, "Incluir Acesso");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancela.Location = new System.Drawing.Point(333, 8);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(75, 23);
            this.btnCancela.TabIndex = 1;
            this.btnCancela.Text = "&Cancelar";
            this.btnCancela.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(414, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // pnlFundo
            // 
            this.pnlFundo.Controls.Add(this.gpbConfigurações);
            this.pnlFundo.Controls.Add(this.pnlAcessos);
            this.pnlFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFundo.Location = new System.Drawing.Point(0, 3);
            this.pnlFundo.Name = "pnlFundo";
            this.pnlFundo.Size = new System.Drawing.Size(501, 199);
            this.pnlFundo.TabIndex = 2;
            // 
            // gpbConfigurações
            // 
            this.gpbConfigurações.Controls.Add(this.tableLayoutPanel);
            this.gpbConfigurações.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbConfigurações.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbConfigurações.Location = new System.Drawing.Point(178, 0);
            this.gpbConfigurações.Name = "gpbConfigurações";
            this.gpbConfigurações.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.gpbConfigurações.Size = new System.Drawing.Size(323, 199);
            this.gpbConfigurações.TabIndex = 2;
            this.gpbConfigurações.TabStop = false;
            this.gpbConfigurações.Text = "Configurações";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.txtNome, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtDataSource, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.txtInitialCatalog, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.txtUserID, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.txtPassword, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.txtAplicacao, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 20);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(307, 174);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Aplicação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Banco de Dados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Senha:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(113, 5);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(189, 21);
            this.txtNome.TabIndex = 5;
            this.txtNome.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtDataSource
            // 
            this.txtDataSource.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataSource.Location = new System.Drawing.Point(113, 33);
            this.txtDataSource.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(189, 21);
            this.txtDataSource.TabIndex = 6;
            this.txtDataSource.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(113, 61);
            this.txtInitialCatalog.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(189, 21);
            this.txtInitialCatalog.TabIndex = 7;
            this.txtInitialCatalog.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(113, 89);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(189, 21);
            this.txtUserID.TabIndex = 8;
            this.txtUserID.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(113, 117);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(189, 21);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.Location = new System.Drawing.Point(113, 145);
            this.txtAplicacao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.Size = new System.Drawing.Size(189, 21);
            this.txtAplicacao.TabIndex = 11;
            this.txtAplicacao.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // pnlAcessos
            // 
            this.pnlAcessos.Controls.Add(this.gpbAcessos);
            this.pnlAcessos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcessos.Location = new System.Drawing.Point(0, 0);
            this.pnlAcessos.Name = "pnlAcessos";
            this.pnlAcessos.Size = new System.Drawing.Size(178, 199);
            this.pnlAcessos.TabIndex = 1;
            // 
            // gpbAcessos
            // 
            this.gpbAcessos.Controls.Add(this.lbxAcessos);
            this.gpbAcessos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbAcessos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbAcessos.Location = new System.Drawing.Point(0, 0);
            this.gpbAcessos.Name = "gpbAcessos";
            this.gpbAcessos.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.gpbAcessos.Size = new System.Drawing.Size(178, 199);
            this.gpbAcessos.TabIndex = 3;
            this.gpbAcessos.TabStop = false;
            this.gpbAcessos.Text = "Acessos";
            // 
            // lbxAcessos
            // 
            this.lbxAcessos.BackColor = System.Drawing.Color.Lavender;
            this.lbxAcessos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxAcessos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxAcessos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAcessos.FormattingEnabled = true;
            this.lbxAcessos.ItemHeight = 15;
            this.lbxAcessos.Location = new System.Drawing.Point(8, 20);
            this.lbxAcessos.Name = "lbxAcessos";
            this.lbxAcessos.Size = new System.Drawing.Size(162, 174);
            this.lbxAcessos.TabIndex = 0;
            this.lbxAcessos.Click += new System.EventHandler(this.lbxAcessos_Click);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmDatabaseAccess
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnCancela;
            this.ClientSize = new System.Drawing.Size(501, 240);
            this.Controls.Add(this.pnlFundo);
            this.Controls.Add(this.pnlBotoeira);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDatabaseAccess";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Acessos";
            this.pnlBotoeira.ResumeLayout(false);
            this.pnlFundo.ResumeLayout(false);
            this.gpbConfigurações.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.pnlAcessos.ResumeLayout(false);
            this.gpbAcessos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotoeira;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlFundo;
        private System.Windows.Forms.Panel pnlAcessos;
        private System.Windows.Forms.GroupBox gpbConfigurações;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.GroupBox gpbAcessos;
        private System.Windows.Forms.ListBox lbxAcessos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
    }
}