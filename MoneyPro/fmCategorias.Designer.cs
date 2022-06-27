namespace MoneyPro
{
    partial class fmCategorias
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label apelidoLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCategorias));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grupoCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonEditarCategoria = new System.Windows.Forms.Button();
            this.buttonIncluirCategoria = new System.Windows.Forms.Button();
            this.buttonExcluirCategoria = new System.Windows.Forms.Button();
            this.buttonCancelarCategoria = new System.Windows.Forms.Button();
            this.buttonGravarCategoria = new System.Windows.Forms.Button();
            this.fixoCheckBox = new System.Windows.Forms.CheckBox();
            this.categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFundo = new System.Windows.Forms.Panel();
            this.pnlEsquerda = new System.Windows.Forms.Panel();
            this.pnlCategorias = new System.Windows.Forms.Panel();
            this.gpbEstrutura = new System.Windows.Forms.GroupBox();
            this.treeViewCategorias = new System.Windows.Forms.TreeView();
            this.gpbDetalhes = new System.Windows.Forms.GroupBox();
            this.pnlDetalhes = new System.Windows.Forms.Panel();
            this.cbxGrupo = new System.Windows.Forms.ComboBox();
            this.cbxAncestral = new System.Windows.Forms.ComboBox();
            this.ancestralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apelidoTextBox = new System.Windows.Forms.TextBox();
            this.ativoCheckBox = new System.Windows.Forms.CheckBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.sistemaCheckBox = new System.Windows.Forms.CheckBox();
            this.pnlRodapeEsquerdo = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlDireita = new System.Windows.Forms.Panel();
            this.gpbGrupoCategorias = new System.Windows.Forms.GroupBox();
            this.pnlGrupos = new System.Windows.Forms.Panel();
            this.gridGrupoCategoria = new System.Windows.Forms.DataGridView();
            this.pnlRodapeDireito = new System.Windows.Forms.Panel();
            this.buttonExcluirGrupos = new System.Windows.Forms.Button();
            this.buttonIncluirGrupos = new System.Windows.Forms.Button();
            this.GrupoCategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proporcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            apelidoLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoCategoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).BeginInit();
            this.pnlFundo.SuspendLayout();
            this.pnlEsquerda.SuspendLayout();
            this.pnlCategorias.SuspendLayout();
            this.gpbEstrutura.SuspendLayout();
            this.gpbDetalhes.SuspendLayout();
            this.pnlDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ancestralBindingSource)).BeginInit();
            this.pnlRodapeEsquerdo.SuspendLayout();
            this.pnlDireita.SuspendLayout();
            this.gpbGrupoCategorias.SuspendLayout();
            this.pnlGrupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoCategoria)).BeginInit();
            this.pnlRodapeDireito.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.Size = new System.Drawing.Size(870, 40);
            this.panelTopo.TabIndex = 0;
            // 
            // labelTopo
            // 
            this.labelTopo.Size = new System.Drawing.Size(249, 24);
            this.labelTopo.Text = "Cadastro de Categorias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(381, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 13);
            label2.TabIndex = 26;
            label2.Text = "Grupo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(381, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 25;
            label1.Text = "Ancestral:";
            // 
            // apelidoLabel
            // 
            apelidoLabel.AutoSize = true;
            apelidoLabel.Location = new System.Drawing.Point(6, 11);
            apelidoLabel.Name = "apelidoLabel";
            apelidoLabel.Size = new System.Drawing.Size(45, 13);
            apelidoLabel.TabIndex = 0;
            apelidoLabel.Text = "Apelido:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(6, 37);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(58, 13);
            descricaoLabel.TabIndex = 12;
            descricaoLabel.Text = "Descrição:";
            // 
            // grupoCategoriaBindingSource
            // 
            this.grupoCategoriaBindingSource.DataSource = typeof(Modelos.GrupoCategoria);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonEditarCategoria
            // 
            this.buttonEditarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditarCategoria.Image")));
            this.buttonEditarCategoria.Location = new System.Drawing.Point(6, 4);
            this.buttonEditarCategoria.Name = "buttonEditarCategoria";
            this.buttonEditarCategoria.Size = new System.Drawing.Size(23, 23);
            this.buttonEditarCategoria.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonEditarCategoria, "Alterar a Categoria Selecionada");
            this.buttonEditarCategoria.UseVisualStyleBackColor = true;
            this.buttonEditarCategoria.Click += new System.EventHandler(this.buttonEditarCategoria_Click);
            // 
            // buttonIncluirCategoria
            // 
            this.buttonIncluirCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncluirCategoria.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncluirCategoria.Image")));
            this.buttonIncluirCategoria.Location = new System.Drawing.Point(35, 4);
            this.buttonIncluirCategoria.Name = "buttonIncluirCategoria";
            this.buttonIncluirCategoria.Size = new System.Drawing.Size(23, 23);
            this.buttonIncluirCategoria.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonIncluirCategoria, "Incluir Categoria");
            this.buttonIncluirCategoria.UseVisualStyleBackColor = true;
            this.buttonIncluirCategoria.Click += new System.EventHandler(this.buttonIncluirCategoria_Click);
            // 
            // buttonExcluirCategoria
            // 
            this.buttonExcluirCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluirCategoria.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirCategoria.Image")));
            this.buttonExcluirCategoria.Location = new System.Drawing.Point(64, 4);
            this.buttonExcluirCategoria.Name = "buttonExcluirCategoria";
            this.buttonExcluirCategoria.Size = new System.Drawing.Size(23, 23);
            this.buttonExcluirCategoria.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonExcluirCategoria, "Excluir Categoria");
            this.buttonExcluirCategoria.UseVisualStyleBackColor = true;
            this.buttonExcluirCategoria.Click += new System.EventHandler(this.buttonExcluirCategoria_Click);
            // 
            // buttonCancelarCategoria
            // 
            this.buttonCancelarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelarCategoria.Image = global::MoneyPro.Properties.Resources.cancela;
            this.buttonCancelarCategoria.Location = new System.Drawing.Point(637, 4);
            this.buttonCancelarCategoria.Name = "buttonCancelarCategoria";
            this.buttonCancelarCategoria.Size = new System.Drawing.Size(23, 23);
            this.buttonCancelarCategoria.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonCancelarCategoria, "Cancelar");
            this.buttonCancelarCategoria.UseVisualStyleBackColor = true;
            this.buttonCancelarCategoria.Click += new System.EventHandler(this.buttonCancelarCategoria_Click);
            // 
            // buttonGravarCategoria
            // 
            this.buttonGravarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravarCategoria.Image = global::MoneyPro.Properties.Resources.ok;
            this.buttonGravarCategoria.Location = new System.Drawing.Point(608, 4);
            this.buttonGravarCategoria.Name = "buttonGravarCategoria";
            this.buttonGravarCategoria.Size = new System.Drawing.Size(23, 23);
            this.buttonGravarCategoria.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonGravarCategoria, "Gravar");
            this.buttonGravarCategoria.UseVisualStyleBackColor = true;
            this.buttonGravarCategoria.Click += new System.EventHandler(this.buttonGravarCategoria_Click);
            // 
            // fixoCheckBox
            // 
            this.fixoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.categoriaBindingSource, "Fixo", true));
            this.fixoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fixoCheckBox.Location = new System.Drawing.Point(70, 59);
            this.fixoCheckBox.Name = "fixoCheckBox";
            this.fixoCheckBox.Size = new System.Drawing.Size(76, 24);
            this.fixoCheckBox.TabIndex = 4;
            this.fixoCheckBox.Text = "Conta Fixa";
            this.toolTip.SetToolTip(this.fixoCheckBox, "Ocorre mensalmente");
            this.fixoCheckBox.UseVisualStyleBackColor = true;
            // 
            // categoriaBindingSource
            // 
            this.categoriaBindingSource.DataSource = typeof(Modelos.Categoria);
            // 
            // pnlFundo
            // 
            this.pnlFundo.Controls.Add(this.pnlEsquerda);
            this.pnlFundo.Controls.Add(this.splitter);
            this.pnlFundo.Controls.Add(this.pnlDireita);
            this.pnlFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFundo.Location = new System.Drawing.Point(0, 40);
            this.pnlFundo.Name = "pnlFundo";
            this.pnlFundo.Size = new System.Drawing.Size(870, 326);
            this.pnlFundo.TabIndex = 2;
            // 
            // pnlEsquerda
            // 
            this.pnlEsquerda.Controls.Add(this.pnlCategorias);
            this.pnlEsquerda.Controls.Add(this.pnlRodapeEsquerdo);
            this.pnlEsquerda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEsquerda.Location = new System.Drawing.Point(0, 0);
            this.pnlEsquerda.Name = "pnlEsquerda";
            this.pnlEsquerda.Size = new System.Drawing.Size(666, 326);
            this.pnlEsquerda.TabIndex = 0;
            // 
            // pnlCategorias
            // 
            this.pnlCategorias.Controls.Add(this.gpbEstrutura);
            this.pnlCategorias.Controls.Add(this.gpbDetalhes);
            this.pnlCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategorias.Location = new System.Drawing.Point(0, 0);
            this.pnlCategorias.Name = "pnlCategorias";
            this.pnlCategorias.Size = new System.Drawing.Size(666, 296);
            this.pnlCategorias.TabIndex = 1;
            // 
            // gpbEstrutura
            // 
            this.gpbEstrutura.Controls.Add(this.treeViewCategorias);
            this.gpbEstrutura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbEstrutura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEstrutura.Location = new System.Drawing.Point(0, 0);
            this.gpbEstrutura.Name = "gpbEstrutura";
            this.gpbEstrutura.Size = new System.Drawing.Size(666, 188);
            this.gpbEstrutura.TabIndex = 0;
            this.gpbEstrutura.TabStop = false;
            this.gpbEstrutura.Text = "Estrutura";
            // 
            // treeViewCategorias
            // 
            this.treeViewCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewCategorias.Location = new System.Drawing.Point(3, 16);
            this.treeViewCategorias.Name = "treeViewCategorias";
            this.treeViewCategorias.Size = new System.Drawing.Size(660, 169);
            this.treeViewCategorias.TabIndex = 0;
            this.treeViewCategorias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCategorias_AfterSelect);
            // 
            // gpbDetalhes
            // 
            this.gpbDetalhes.Controls.Add(this.pnlDetalhes);
            this.gpbDetalhes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpbDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDetalhes.Location = new System.Drawing.Point(0, 188);
            this.gpbDetalhes.Name = "gpbDetalhes";
            this.gpbDetalhes.Size = new System.Drawing.Size(666, 108);
            this.gpbDetalhes.TabIndex = 3;
            this.gpbDetalhes.TabStop = false;
            this.gpbDetalhes.Text = "Detalhes";
            // 
            // pnlDetalhes
            // 
            this.pnlDetalhes.Controls.Add(this.cbxGrupo);
            this.pnlDetalhes.Controls.Add(label2);
            this.pnlDetalhes.Controls.Add(label1);
            this.pnlDetalhes.Controls.Add(this.cbxAncestral);
            this.pnlDetalhes.Controls.Add(apelidoLabel);
            this.pnlDetalhes.Controls.Add(this.apelidoTextBox);
            this.pnlDetalhes.Controls.Add(this.ativoCheckBox);
            this.pnlDetalhes.Controls.Add(descricaoLabel);
            this.pnlDetalhes.Controls.Add(this.descricaoTextBox);
            this.pnlDetalhes.Controls.Add(this.fixoCheckBox);
            this.pnlDetalhes.Controls.Add(this.sistemaCheckBox);
            this.pnlDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDetalhes.Location = new System.Drawing.Point(3, 16);
            this.pnlDetalhes.Name = "pnlDetalhes";
            this.pnlDetalhes.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDetalhes.Size = new System.Drawing.Size(660, 89);
            this.pnlDetalhes.TabIndex = 0;
            // 
            // cbxGrupo
            // 
            this.cbxGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxGrupo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.categoriaBindingSource, "GrupoCategoriaID", true));
            this.cbxGrupo.DataSource = this.grupoCategoriaBindingSource;
            this.cbxGrupo.DisplayMember = "Apelido";
            this.cbxGrupo.FormattingEnabled = true;
            this.cbxGrupo.Location = new System.Drawing.Point(441, 30);
            this.cbxGrupo.Name = "cbxGrupo";
            this.cbxGrupo.Size = new System.Drawing.Size(207, 21);
            this.cbxGrupo.TabIndex = 3;
            this.cbxGrupo.ValueMember = "GrupoCategoriaID";
            // 
            // cbxAncestral
            // 
            this.cbxAncestral.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxAncestral.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAncestral.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.categoriaBindingSource, "CategoriaPaiID", true));
            this.cbxAncestral.DataSource = this.ancestralBindingSource;
            this.cbxAncestral.DisplayMember = "Apelido";
            this.cbxAncestral.FormattingEnabled = true;
            this.cbxAncestral.Location = new System.Drawing.Point(441, 7);
            this.cbxAncestral.Name = "cbxAncestral";
            this.cbxAncestral.Size = new System.Drawing.Size(207, 21);
            this.cbxAncestral.TabIndex = 1;
            this.cbxAncestral.ValueMember = "CategoriaID";
            // 
            // ancestralBindingSource
            // 
            this.ancestralBindingSource.DataSource = typeof(Modelos.Categoria);
            // 
            // apelidoTextBox
            // 
            this.apelidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoriaBindingSource, "Apelido", true));
            this.apelidoTextBox.Location = new System.Drawing.Point(70, 7);
            this.apelidoTextBox.MaxLength = 25;
            this.apelidoTextBox.Name = "apelidoTextBox";
            this.apelidoTextBox.Size = new System.Drawing.Size(167, 20);
            this.apelidoTextBox.TabIndex = 0;
            // 
            // ativoCheckBox
            // 
            this.ativoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.categoriaBindingSource, "Ativo", true));
            this.ativoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ativoCheckBox.Location = new System.Drawing.Point(170, 59);
            this.ativoCheckBox.Name = "ativoCheckBox";
            this.ativoCheckBox.Size = new System.Drawing.Size(98, 24);
            this.ativoCheckBox.TabIndex = 5;
            this.ativoCheckBox.Text = "Categoria Ativa";
            this.ativoCheckBox.UseVisualStyleBackColor = true;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoriaBindingSource, "Descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(70, 33);
            this.descricaoTextBox.MaxLength = 100;
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(276, 20);
            this.descricaoTextBox.TabIndex = 2;
            // 
            // sistemaCheckBox
            // 
            this.sistemaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.categoriaBindingSource, "Sistema", true));
            this.sistemaCheckBox.Enabled = false;
            this.sistemaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sistemaCheckBox.Location = new System.Drawing.Point(292, 59);
            this.sistemaCheckBox.Name = "sistemaCheckBox";
            this.sistemaCheckBox.Size = new System.Drawing.Size(127, 24);
            this.sistemaCheckBox.TabIndex = 6;
            this.sistemaCheckBox.Text = "Categoria do Sistema";
            this.sistemaCheckBox.UseVisualStyleBackColor = true;
            // 
            // pnlRodapeEsquerdo
            // 
            this.pnlRodapeEsquerdo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRodapeEsquerdo.Controls.Add(this.buttonGravarCategoria);
            this.pnlRodapeEsquerdo.Controls.Add(this.buttonCancelarCategoria);
            this.pnlRodapeEsquerdo.Controls.Add(this.buttonExcluirCategoria);
            this.pnlRodapeEsquerdo.Controls.Add(this.buttonIncluirCategoria);
            this.pnlRodapeEsquerdo.Controls.Add(this.buttonEditarCategoria);
            this.pnlRodapeEsquerdo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRodapeEsquerdo.Location = new System.Drawing.Point(0, 296);
            this.pnlRodapeEsquerdo.Name = "pnlRodapeEsquerdo";
            this.pnlRodapeEsquerdo.Size = new System.Drawing.Size(666, 30);
            this.pnlRodapeEsquerdo.TabIndex = 0;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(666, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(4, 326);
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            // 
            // pnlDireita
            // 
            this.pnlDireita.Controls.Add(this.gpbGrupoCategorias);
            this.pnlDireita.Controls.Add(this.pnlRodapeDireito);
            this.pnlDireita.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDireita.Location = new System.Drawing.Point(670, 0);
            this.pnlDireita.MaximumSize = new System.Drawing.Size(400, 0);
            this.pnlDireita.MinimumSize = new System.Drawing.Size(200, 0);
            this.pnlDireita.Name = "pnlDireita";
            this.pnlDireita.Size = new System.Drawing.Size(200, 326);
            this.pnlDireita.TabIndex = 7;
            // 
            // gpbGrupoCategorias
            // 
            this.gpbGrupoCategorias.Controls.Add(this.pnlGrupos);
            this.gpbGrupoCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbGrupoCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbGrupoCategorias.Location = new System.Drawing.Point(0, 0);
            this.gpbGrupoCategorias.Name = "gpbGrupoCategorias";
            this.gpbGrupoCategorias.Size = new System.Drawing.Size(200, 296);
            this.gpbGrupoCategorias.TabIndex = 0;
            this.gpbGrupoCategorias.TabStop = false;
            this.gpbGrupoCategorias.Text = "Grupos";
            // 
            // pnlGrupos
            // 
            this.pnlGrupos.Controls.Add(this.gridGrupoCategoria);
            this.pnlGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGrupos.Location = new System.Drawing.Point(3, 16);
            this.pnlGrupos.Name = "pnlGrupos";
            this.pnlGrupos.Size = new System.Drawing.Size(194, 277);
            this.pnlGrupos.TabIndex = 0;
            // 
            // gridGrupoCategoria
            // 
            this.gridGrupoCategoria.AllowUserToAddRows = false;
            this.gridGrupoCategoria.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.gridGrupoCategoria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridGrupoCategoria.AutoGenerateColumns = false;
            this.gridGrupoCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupoCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GrupoCategoriaID,
            this.UsuarioID,
            this.Apelido,
            this.Descricao,
            this.Proporcao,
            this.Ativo});
            this.gridGrupoCategoria.DataSource = this.grupoCategoriaBindingSource;
            this.gridGrupoCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoCategoria.Location = new System.Drawing.Point(0, 0);
            this.gridGrupoCategoria.MultiSelect = false;
            this.gridGrupoCategoria.Name = "gridGrupoCategoria";
            this.gridGrupoCategoria.RowHeadersVisible = false;
            this.gridGrupoCategoria.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridGrupoCategoria.Size = new System.Drawing.Size(194, 277);
            this.gridGrupoCategoria.TabIndex = 0;
            this.gridGrupoCategoria.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridGrupoCategoria_EditingControlShowing);
            // 
            // pnlRodapeDireito
            // 
            this.pnlRodapeDireito.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRodapeDireito.Controls.Add(this.buttonExcluirGrupos);
            this.pnlRodapeDireito.Controls.Add(this.buttonIncluirGrupos);
            this.pnlRodapeDireito.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRodapeDireito.Location = new System.Drawing.Point(0, 296);
            this.pnlRodapeDireito.Name = "pnlRodapeDireito";
            this.pnlRodapeDireito.Size = new System.Drawing.Size(200, 30);
            this.pnlRodapeDireito.TabIndex = 0;
            // 
            // buttonExcluirGrupos
            // 
            this.buttonExcluirGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluirGrupos.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirGrupos.Image")));
            this.buttonExcluirGrupos.Location = new System.Drawing.Point(35, 4);
            this.buttonExcluirGrupos.Name = "buttonExcluirGrupos";
            this.buttonExcluirGrupos.Size = new System.Drawing.Size(23, 23);
            this.buttonExcluirGrupos.TabIndex = 1;
            this.buttonExcluirGrupos.UseVisualStyleBackColor = true;
            this.buttonExcluirGrupos.Click += new System.EventHandler(this.buttonExcluirGrupos_Click);
            // 
            // buttonIncluirGrupos
            // 
            this.buttonIncluirGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncluirGrupos.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncluirGrupos.Image")));
            this.buttonIncluirGrupos.Location = new System.Drawing.Point(6, 4);
            this.buttonIncluirGrupos.Name = "buttonIncluirGrupos";
            this.buttonIncluirGrupos.Size = new System.Drawing.Size(23, 23);
            this.buttonIncluirGrupos.TabIndex = 0;
            this.buttonIncluirGrupos.UseVisualStyleBackColor = true;
            this.buttonIncluirGrupos.Click += new System.EventHandler(this.buttonIncluirGrupos_Click);
            // 
            // GrupoCategoriaID
            // 
            this.GrupoCategoriaID.DataPropertyName = "GrupoCategoriaID";
            this.GrupoCategoriaID.HeaderText = "GrupoCategoriaID";
            this.GrupoCategoriaID.Name = "GrupoCategoriaID";
            this.GrupoCategoriaID.Visible = false;
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
            this.Apelido.FillWeight = 50F;
            this.Apelido.HeaderText = "Apelido";
            this.Apelido.MinimumWidth = 50;
            this.Apelido.Name = "Apelido";
            this.Apelido.Width = 67;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // Proporcao
            // 
            this.Proporcao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Proporcao.DataPropertyName = "Proporcao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Proporcao.DefaultCellStyle = dataGridViewCellStyle2;
            this.Proporcao.FillWeight = 70F;
            this.Proporcao.HeaderText = "%";
            this.Proporcao.Name = "Proporcao";
            this.Proporcao.Width = 5;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.Visible = false;
            // 
            // fmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(870, 366);
            this.Controls.Add(this.pnlFundo);
            this.Name = "fmCategorias";
            this.Text = "fmCategorias";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmCategorias_KeyDown);
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.pnlFundo, 0);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoCategoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).EndInit();
            this.pnlFundo.ResumeLayout(false);
            this.pnlEsquerda.ResumeLayout(false);
            this.pnlCategorias.ResumeLayout(false);
            this.gpbEstrutura.ResumeLayout(false);
            this.gpbDetalhes.ResumeLayout(false);
            this.pnlDetalhes.ResumeLayout(false);
            this.pnlDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ancestralBindingSource)).EndInit();
            this.pnlRodapeEsquerdo.ResumeLayout(false);
            this.pnlDireita.ResumeLayout(false);
            this.gpbGrupoCategorias.ResumeLayout(false);
            this.pnlGrupos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoCategoria)).EndInit();
            this.pnlRodapeDireito.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource grupoCategoriaBindingSource;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel pnlFundo;
        private System.Windows.Forms.Panel pnlEsquerda;
        private System.Windows.Forms.Panel pnlRodapeEsquerdo;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlDireita;
        private System.Windows.Forms.GroupBox gpbGrupoCategorias;
        private System.Windows.Forms.Panel pnlRodapeDireito;
        private System.Windows.Forms.Button buttonExcluirGrupos;
        private System.Windows.Forms.Button buttonIncluirGrupos;
        private System.Windows.Forms.Panel pnlGrupos;
        private System.Windows.Forms.DataGridView gridGrupoCategoria;
        private System.Windows.Forms.BindingSource categoriaBindingSource;
        private System.Windows.Forms.BindingSource ancestralBindingSource;
        private System.Windows.Forms.Button buttonExcluirCategoria;
        private System.Windows.Forms.Button buttonIncluirCategoria;
        private System.Windows.Forms.Button buttonEditarCategoria;
        private System.Windows.Forms.Button buttonGravarCategoria;
        private System.Windows.Forms.Button buttonCancelarCategoria;
        private System.Windows.Forms.Panel pnlCategorias;
        private System.Windows.Forms.GroupBox gpbEstrutura;
        private System.Windows.Forms.TreeView treeViewCategorias;
        private System.Windows.Forms.GroupBox gpbDetalhes;
        private System.Windows.Forms.Panel pnlDetalhes;
        private System.Windows.Forms.ComboBox cbxGrupo;
        private System.Windows.Forms.ComboBox cbxAncestral;
        private System.Windows.Forms.TextBox apelidoTextBox;
        private System.Windows.Forms.CheckBox ativoCheckBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.CheckBox fixoCheckBox;
        private System.Windows.Forms.CheckBox sistemaCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apelido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proporcao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
}
