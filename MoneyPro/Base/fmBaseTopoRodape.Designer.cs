namespace MoneyPro.Base
{
    partial class fmBaseTopoRodape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmBaseTopoRodape));
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonIncluir = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTopo.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.Size = new System.Drawing.Size(452, 40);
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRodape.Controls.Add(this.buttonExcluir);
            this.panelRodape.Controls.Add(this.buttonIncluir);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 232);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(452, 30);
            this.panelRodape.TabIndex = 4;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluir.Image")));
            this.buttonExcluir.Location = new System.Drawing.Point(32, 3);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(23, 23);
            this.buttonExcluir.TabIndex = 1;
            this.buttonExcluir.TabStop = false;
            this.buttonExcluir.Tag = "Basico";
            this.toolTip.SetToolTip(this.buttonExcluir, "Excluir [Ctrl+Del]");
            this.buttonExcluir.UseVisualStyleBackColor = true;
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncluir.Image")));
            this.buttonIncluir.Location = new System.Drawing.Point(3, 3);
            this.buttonIncluir.Name = "buttonIncluir";
            this.buttonIncluir.Size = new System.Drawing.Size(23, 23);
            this.buttonIncluir.TabIndex = 0;
            this.buttonIncluir.TabStop = false;
            this.buttonIncluir.Tag = "Basico";
            this.toolTip.SetToolTip(this.buttonIncluir, "Incluir [Ins]");
            this.buttonIncluir.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // fmBaseTopoRodape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.panelRodape);
            this.Name = "fmBaseTopoRodape";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmBaseTopoRodape";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelRodape;
        protected System.Windows.Forms.Button buttonExcluir;
        protected System.Windows.Forms.Button buttonIncluir;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
