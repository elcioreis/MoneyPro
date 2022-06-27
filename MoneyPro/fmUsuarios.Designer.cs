namespace MoneyPro
{
    partial class fmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmUsuarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonResetaSenha = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonIncluir = new System.Windows.Forms.Button();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.labelTopo = new System.Windows.Forms.Label();
            this.usuarioDataGridView = new System.Windows.Forms.DataGridView();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sistema = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRodape.Controls.Add(this.buttonResetaSenha);
            this.panelRodape.Controls.Add(this.buttonExcluir);
            this.panelRodape.Controls.Add(this.buttonIncluir);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 232);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(637, 30);
            this.panelRodape.TabIndex = 1;
            // 
            // buttonResetaSenha
            // 
            this.buttonResetaSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetaSenha.Image = global::MoneyPro.Properties.Resources.z16senhaPadrao;
            this.buttonResetaSenha.Location = new System.Drawing.Point(61, 3);
            this.buttonResetaSenha.Name = "buttonResetaSenha";
            this.buttonResetaSenha.Size = new System.Drawing.Size(23, 23);
            this.buttonResetaSenha.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonResetaSenha, "Senha Padrão");
            this.buttonResetaSenha.UseVisualStyleBackColor = true;
            this.buttonResetaSenha.Click += new System.EventHandler(this.buttonResetaSenha_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluir.Image")));
            this.buttonExcluir.Location = new System.Drawing.Point(32, 3);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(23, 23);
            this.buttonExcluir.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonExcluir, "Excluir usuário");
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncluir.Image")));
            this.buttonIncluir.Location = new System.Drawing.Point(3, 3);
            this.buttonIncluir.Name = "buttonIncluir";
            this.buttonIncluir.Size = new System.Drawing.Size(23, 23);
            this.buttonIncluir.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonIncluir, "Incluir usuário");
            this.buttonIncluir.UseVisualStyleBackColor = true;
            this.buttonIncluir.Click += new System.EventHandler(this.buttonIncluir_Click);
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTopo.Controls.Add(this.labelTopo);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(637, 40);
            this.panelTopo.TabIndex = 2;
            // 
            // labelTopo
            // 
            this.labelTopo.AutoSize = true;
            this.labelTopo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopo.Location = new System.Drawing.Point(8, 8);
            this.labelTopo.Name = "labelTopo";
            this.labelTopo.Size = new System.Drawing.Size(229, 24);
            this.labelTopo.TabIndex = 0;
            this.labelTopo.Text = "Cadastro de Usuários";
            // 
            // usuarioDataGridView
            // 
            this.usuarioDataGridView.AllowUserToAddRows = false;
            this.usuarioDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.usuarioDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.usuarioDataGridView.AutoGenerateColumns = false;
            this.usuarioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuarioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsuarioID,
            this.apelido,
            this.nome,
            this.email,
            this.ativo,
            this.sistema,
            this.senha});
            this.usuarioDataGridView.DataSource = this.usuariosBindingSource;
            this.usuarioDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarioDataGridView.Location = new System.Drawing.Point(0, 40);
            this.usuarioDataGridView.Name = "usuarioDataGridView";
            this.usuarioDataGridView.RowHeadersVisible = false;
            this.usuarioDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.usuarioDataGridView.Size = new System.Drawing.Size(637, 192);
            this.usuarioDataGridView.TabIndex = 0;
            this.usuarioDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridUsuarios_CellFormatting);
            this.usuarioDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridUsuarios_EditingControlShowing);
            this.usuarioDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridUsuarios_RowValidating);
            this.usuarioDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridUsuarios_KeyPress);
            // 
            // UsuarioID
            // 
            this.UsuarioID.DataPropertyName = "UsuarioID";
            this.UsuarioID.HeaderText = "UsuarioID";
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.ReadOnly = true;
            this.UsuarioID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UsuarioID.Visible = false;
            // 
            // apelido
            // 
            this.apelido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.apelido.DataPropertyName = "Apelido";
            this.apelido.FillWeight = 120F;
            this.apelido.HeaderText = "Apelido";
            this.apelido.MinimumWidth = 120;
            this.apelido.Name = "apelido";
            this.apelido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.apelido.Width = 120;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.nome.DataPropertyName = "Nome";
            this.nome.FillWeight = 200F;
            this.nome.HeaderText = "Nome";
            this.nome.MinimumWidth = 200;
            this.nome.Name = "nome";
            this.nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nome.Width = 200;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ativo
            // 
            this.ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ativo.DataPropertyName = "Ativo";
            this.ativo.FillWeight = 50F;
            this.ativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.Width = 37;
            // 
            // sistema
            // 
            this.sistema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sistema.DataPropertyName = "Sistema";
            this.sistema.FillWeight = 50F;
            this.sistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sistema.HeaderText = "Sistema";
            this.sistema.Name = "sistema";
            this.sistema.ReadOnly = true;
            this.sistema.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sistema.Width = 50;
            // 
            // senha
            // 
            this.senha.DataPropertyName = "Senha";
            this.senha.HeaderText = "Senha";
            this.senha.Name = "senha";
            this.senha.ReadOnly = true;
            this.senha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.senha.Visible = false;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataSource = typeof(Modelos.Usuario);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 262);
            this.Controls.Add(this.usuarioDataGridView);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.panelTopo);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmUsuarios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "fmUsuarios";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmUsuarios_KeyDown);
            this.panelRodape.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Label labelTopo;
        private System.Windows.Forms.DataGridView usuarioDataGridView;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private System.Windows.Forms.Button buttonIncluir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonResetaSenha;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ativo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn senha;
    }
}