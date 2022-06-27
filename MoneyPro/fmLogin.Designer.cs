namespace MoneyPro
{
    partial class fmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLogin));
            this.pnlIdentificacao = new System.Windows.Forms.Panel();
            this.lblIdentificacao = new System.Windows.Forms.Label();
            this.pnlBotoeira = new System.Windows.Forms.Panel();
            this.btnAcessos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pbxImagem = new System.Windows.Forms.PictureBox();
            this.chkLembrarUsuario = new System.Windows.Forms.CheckBox();
            this.lblAcesso = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.comboAcesso = new System.Windows.Forms.ComboBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.pnlIdentificacao.SuspendLayout();
            this.pnlBotoeira.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIdentificacao
            // 
            this.pnlIdentificacao.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlIdentificacao.Controls.Add(this.lblIdentificacao);
            this.pnlIdentificacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIdentificacao.Location = new System.Drawing.Point(0, 0);
            this.pnlIdentificacao.Name = "pnlIdentificacao";
            this.pnlIdentificacao.Size = new System.Drawing.Size(445, 55);
            this.pnlIdentificacao.TabIndex = 0;
            // 
            // lblIdentificacao
            // 
            this.lblIdentificacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdentificacao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacao.ForeColor = System.Drawing.Color.White;
            this.lblIdentificacao.Location = new System.Drawing.Point(0, 0);
            this.lblIdentificacao.Name = "lblIdentificacao";
            this.lblIdentificacao.Size = new System.Drawing.Size(445, 55);
            this.lblIdentificacao.TabIndex = 0;
            this.lblIdentificacao.Text = "lblIdentificacao";
            this.lblIdentificacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBotoeira
            // 
            this.pnlBotoeira.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBotoeira.Controls.Add(this.btnAcessos);
            this.pnlBotoeira.Controls.Add(this.btnSair);
            this.pnlBotoeira.Controls.Add(this.btnEntrar);
            this.pnlBotoeira.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoeira.Location = new System.Drawing.Point(0, 180);
            this.pnlBotoeira.Name = "pnlBotoeira";
            this.pnlBotoeira.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBotoeira.Size = new System.Drawing.Size(445, 38);
            this.pnlBotoeira.TabIndex = 1;
            // 
            // btnAcessos
            // 
            this.btnAcessos.Location = new System.Drawing.Point(12, 7);
            this.btnAcessos.Name = "btnAcessos";
            this.btnAcessos.Size = new System.Drawing.Size(75, 23);
            this.btnAcessos.TabIndex = 2;
            this.btnAcessos.Text = "&Acessos";
            this.btnAcessos.UseVisualStyleBackColor = true;
            this.btnAcessos.Click += new System.EventHandler(this.btnAcessos_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.CausesValidation = false;
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Location = new System.Drawing.Point(277, 8);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEntrar.Location = new System.Drawing.Point(358, 8);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "&Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel.Controls.Add(this.lblUsuario, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtUsuario, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.pbxImagem, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.chkLembrarUsuario, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.lblAcesso, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblSenha, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.comboAcesso, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.txtSenha, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(445, 125);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.Enter += new System.EventHandler(this.tableLayoutPanel_Enter);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(153, 10);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(20, 10, 3, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MoneyPro.Properties.Settings.Default, "txtUsuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUsuario.Location = new System.Drawing.Point(216, 8);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(121, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = global::MoneyPro.Properties.Settings.Default.txtUsuario;
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // pbxImagem
            // 
            this.pbxImagem.BackColor = System.Drawing.Color.Lavender;
            this.pbxImagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbxImagem.Image = ((System.Drawing.Image)(resources.GetObject("pbxImagem.Image")));
            this.pbxImagem.Location = new System.Drawing.Point(3, 3);
            this.pbxImagem.Name = "pbxImagem";
            this.pbxImagem.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel.SetRowSpan(this.pbxImagem, 4);
            this.pbxImagem.Size = new System.Drawing.Size(127, 119);
            this.pbxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagem.TabIndex = 4;
            this.pbxImagem.TabStop = false;
            // 
            // chkLembrarUsuario
            // 
            this.chkLembrarUsuario.AutoSize = true;
            this.chkLembrarUsuario.Checked = global::MoneyPro.Properties.Settings.Default.chkLembrarUsuario;
            this.chkLembrarUsuario.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoneyPro.Properties.Settings.Default, "chkLembrarUsuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkLembrarUsuario.Location = new System.Drawing.Point(216, 101);
            this.chkLembrarUsuario.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.chkLembrarUsuario.Name = "chkLembrarUsuario";
            this.chkLembrarUsuario.Size = new System.Drawing.Size(150, 17);
            this.chkLembrarUsuario.TabIndex = 3;
            this.chkLembrarUsuario.Text = "Lembrar Usuário e Acesso";
            this.chkLembrarUsuario.UseVisualStyleBackColor = true;
            // 
            // lblAcesso
            // 
            this.lblAcesso.AutoSize = true;
            this.lblAcesso.Location = new System.Drawing.Point(153, 72);
            this.lblAcesso.Margin = new System.Windows.Forms.Padding(20, 10, 3, 0);
            this.lblAcesso.Name = "lblAcesso";
            this.lblAcesso.Size = new System.Drawing.Size(45, 13);
            this.lblAcesso.TabIndex = 2;
            this.lblAcesso.Text = "Acesso:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(153, 41);
            this.lblSenha.Margin = new System.Windows.Forms.Padding(20, 10, 3, 0);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 1;
            this.lblSenha.Text = "Senha:";
            // 
            // comboAcesso
            // 
            this.comboAcesso.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MoneyPro.Properties.Settings.Default, "comboAcesso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAcesso.FormattingEnabled = true;
            this.comboAcesso.Location = new System.Drawing.Point(216, 70);
            this.comboAcesso.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.comboAcesso.Name = "comboAcesso";
            this.comboAcesso.Size = new System.Drawing.Size(217, 21);
            this.comboAcesso.TabIndex = 2;
            this.comboAcesso.Text = global::MoneyPro.Properties.Settings.Default.comboAcesso;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(216, 39);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(121, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // fmLogin
            // 
            this.AcceptButton = this.btnEntrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(445, 218);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.pnlBotoeira);
            this.Controls.Add(this.pnlIdentificacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificação";
            this.pnlIdentificacao.ResumeLayout(false);
            this.pnlBotoeira.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIdentificacao;
        private System.Windows.Forms.Label lblIdentificacao;
        private System.Windows.Forms.Panel pnlBotoeira;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblAcesso;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox comboAcesso;
        private System.Windows.Forms.CheckBox chkLembrarUsuario;
        private System.Windows.Forms.PictureBox pbxImagem;
        private System.Windows.Forms.Button btnAcessos;
    }
}