namespace MoneyPro
{
    partial class fmPrevisaoSaldoNegativo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.previsaoSaldoNegativoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.previsaoSaldoNegativoDataGridView = new System.Windows.Forms.DataGridView();
            this.previsao_ContaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previsao_Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previsao_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previsao_Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.previsaoSaldoNegativoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previsaoSaldoNegativoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // previsaoSaldoNegativoBindingSource
            // 
            this.previsaoSaldoNegativoBindingSource.DataSource = typeof(Modelos.PrevisaoSaldoNegativo);
            // 
            // previsaoSaldoNegativoDataGridView
            // 
            this.previsaoSaldoNegativoDataGridView.AllowUserToAddRows = false;
            this.previsaoSaldoNegativoDataGridView.AllowUserToDeleteRows = false;
            this.previsaoSaldoNegativoDataGridView.AllowUserToResizeColumns = false;
            this.previsaoSaldoNegativoDataGridView.AllowUserToResizeRows = false;
            this.previsaoSaldoNegativoDataGridView.AutoGenerateColumns = false;
            this.previsaoSaldoNegativoDataGridView.BackgroundColor = System.Drawing.Color.Tomato;
            this.previsaoSaldoNegativoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previsaoSaldoNegativoDataGridView.CausesValidation = false;
            this.previsaoSaldoNegativoDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.previsaoSaldoNegativoDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.previsaoSaldoNegativoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.previsaoSaldoNegativoDataGridView.ColumnHeadersVisible = false;
            this.previsaoSaldoNegativoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.previsao_ContaId,
            this.previsao_Dia,
            this.previsao_Conta,
            this.previsao_Saldo});
            this.previsaoSaldoNegativoDataGridView.DataSource = this.previsaoSaldoNegativoBindingSource;
            this.previsaoSaldoNegativoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previsaoSaldoNegativoDataGridView.Location = new System.Drawing.Point(0, 0);
            this.previsaoSaldoNegativoDataGridView.MultiSelect = false;
            this.previsaoSaldoNegativoDataGridView.Name = "previsaoSaldoNegativoDataGridView";
            this.previsaoSaldoNegativoDataGridView.ReadOnly = true;
            this.previsaoSaldoNegativoDataGridView.RowHeadersVisible = false;
            this.previsaoSaldoNegativoDataGridView.RowHeadersWidth = 51;
            this.previsaoSaldoNegativoDataGridView.RowTemplate.Height = 20;
            this.previsaoSaldoNegativoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.previsaoSaldoNegativoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.previsaoSaldoNegativoDataGridView.Size = new System.Drawing.Size(459, 204);
            this.previsaoSaldoNegativoDataGridView.TabIndex = 0;
            this.previsaoSaldoNegativoDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrevisaoSaldoNegativoDataGridView_CellClick);
            this.previsaoSaldoNegativoDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PrevisaoSaldoNegativoDataGridView_CellFormatting);
            this.previsaoSaldoNegativoDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.PrevisaoSaldoNegativoDataGridView_RowPrePaint);
            // 
            // previsao_ContaId
            // 
            this.previsao_ContaId.DataPropertyName = "ContaID";
            this.previsao_ContaId.HeaderText = "ContaID";
            this.previsao_ContaId.MinimumWidth = 6;
            this.previsao_ContaId.Name = "previsao_ContaId";
            this.previsao_ContaId.ReadOnly = true;
            this.previsao_ContaId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.previsao_ContaId.Visible = false;
            this.previsao_ContaId.Width = 125;
            // 
            // previsao_Dia
            // 
            this.previsao_Dia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.previsao_Dia.DataPropertyName = "Dia";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.Format = "d";
            dataGridViewCellStyle16.NullValue = null;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.previsao_Dia.DefaultCellStyle = dataGridViewCellStyle16;
            this.previsao_Dia.HeaderText = "Data";
            this.previsao_Dia.MinimumWidth = 65;
            this.previsao_Dia.Name = "previsao_Dia";
            this.previsao_Dia.ReadOnly = true;
            this.previsao_Dia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.previsao_Dia.Width = 65;
            // 
            // previsao_Conta
            // 
            this.previsao_Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.previsao_Conta.DataPropertyName = "Conta";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.previsao_Conta.DefaultCellStyle = dataGridViewCellStyle17;
            this.previsao_Conta.HeaderText = "Conta";
            this.previsao_Conta.MinimumWidth = 150;
            this.previsao_Conta.Name = "previsao_Conta";
            this.previsao_Conta.ReadOnly = true;
            this.previsao_Conta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.previsao_Conta.Width = 150;
            // 
            // previsao_Saldo
            // 
            this.previsao_Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.previsao_Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            this.previsao_Saldo.DefaultCellStyle = dataGridViewCellStyle18;
            this.previsao_Saldo.HeaderText = "Saldo";
            this.previsao_Saldo.MinimumWidth = 70;
            this.previsao_Saldo.Name = "previsao_Saldo";
            this.previsao_Saldo.ReadOnly = true;
            this.previsao_Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.previsao_Saldo.Width = 70;
            // 
            // fmPrevisaoSaldoNegativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(459, 204);
            this.ControlBox = false;
            this.Controls.Add(this.previsaoSaldoNegativoDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmPrevisaoSaldoNegativo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FmPrevisaoSaldoNegativo_Load);
            this.Shown += new System.EventHandler(this.FmPrevisaoSaldoNegativo_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FmPrevisaoSaldoNegativo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.previsaoSaldoNegativoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previsaoSaldoNegativoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource previsaoSaldoNegativoBindingSource;
        private System.Windows.Forms.DataGridView previsaoSaldoNegativoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn previsao_ContaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn previsao_Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn previsao_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn previsao_Saldo;
    }
}