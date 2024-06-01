namespace MoneyPro
{
    partial class fmDownloadCotacoes
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
            this.panelTopo = new System.Windows.Forms.Panel();
            this.labelTopo = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInterromper = new System.Windows.Forms.Button();
            this.listBoxDatasAtualizadas = new System.Windows.Forms.ListBox();
            this.panelTopo.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.labelTopo);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Margin = new System.Windows.Forms.Padding(4);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(625, 49);
            this.panelTopo.TabIndex = 0;
            this.panelTopo.DoubleClick += new System.EventHandler(this.PanelTopo_DoubleClick);
            // 
            // labelTopo
            // 
            this.labelTopo.AutoSize = true;
            this.labelTopo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopo.Location = new System.Drawing.Point(11, 10);
            this.labelTopo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTopo.Name = "labelTopo";
            this.labelTopo.Size = new System.Drawing.Size(340, 32);
            this.labelTopo.TabIndex = 0;
            this.labelTopo.Text = "Atualização de Cotações";
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.SystemColors.Control;
            this.panelRodape.Controls.Add(this.label1);
            this.panelRodape.Controls.Add(this.buttonInterromper);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 308);
            this.panelRodape.Margin = new System.Windows.Forms.Padding(4);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(625, 37);
            this.panelRodape.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "F6 - Atualiza apenas o último lote; Ctrl+F6 Atualiza todos disponíveis";
            // 
            // buttonInterromper
            // 
            this.buttonInterromper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInterromper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInterromper.Location = new System.Drawing.Point(509, 4);
            this.buttonInterromper.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInterromper.Name = "buttonInterromper";
            this.buttonInterromper.Size = new System.Drawing.Size(100, 28);
            this.buttonInterromper.TabIndex = 0;
            this.buttonInterromper.Text = "Interromper";
            this.buttonInterromper.UseVisualStyleBackColor = true;
            this.buttonInterromper.Click += new System.EventHandler(this.buttonInterromper_Click);
            // 
            // listBoxDatasAtualizadas
            // 
            this.listBoxDatasAtualizadas.BackColor = System.Drawing.SystemColors.Highlight;
            this.listBoxDatasAtualizadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxDatasAtualizadas.CausesValidation = false;
            this.listBoxDatasAtualizadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDatasAtualizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDatasAtualizadas.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.listBoxDatasAtualizadas.FormattingEnabled = true;
            this.listBoxDatasAtualizadas.IntegralHeight = false;
            this.listBoxDatasAtualizadas.ItemHeight = 18;
            this.listBoxDatasAtualizadas.Items.AddRange(new object[] {
            "Por favor, aguarde..."});
            this.listBoxDatasAtualizadas.Location = new System.Drawing.Point(0, 49);
            this.listBoxDatasAtualizadas.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxDatasAtualizadas.Name = "listBoxDatasAtualizadas";
            this.listBoxDatasAtualizadas.Size = new System.Drawing.Size(625, 259);
            this.listBoxDatasAtualizadas.TabIndex = 2;
            // 
            // fmDownloadCotacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 345);
            this.Controls.Add(this.listBoxDatasAtualizadas);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.panelTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDownloadCotacoes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoneyPro";
            this.Shown += new System.EventHandler(this.fmProcessamentoCVM_Shown);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Label labelTopo;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonInterromper;
        internal System.Windows.Forms.ListBox listBoxDatasAtualizadas;
        private System.Windows.Forms.Label label1;
    }
}