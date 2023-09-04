namespace MoneyPro
{
    partial class fmCarteiraGraficoValores
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonMesCorrente = new System.Windows.Forms.Button();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.toolTipGrafico = new System.Windows.Forms.ToolTip(this.components);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.labelInicio = new System.Windows.Forms.Label();
            this.buttonUltimoInvestimento = new System.Windows.Forms.Button();
            this.panelRodape.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonUltimoInvestimento);
            this.panelRodape.Controls.Add(this.buttonMesCorrente);
            this.panelRodape.Controls.Add(this.buttonAtualizar);
            this.panelRodape.Controls.Add(this.dateTimePickerInicio);
            this.panelRodape.Controls.Add(this.labelInicio);
            this.panelRodape.Controls.SetChildIndex(this.buttonIncluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonExcluir, 0);
            this.panelRodape.Controls.SetChildIndex(this.labelInicio, 0);
            this.panelRodape.Controls.SetChildIndex(this.dateTimePickerInicio, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonAtualizar, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonMesCorrente, 0);
            this.panelRodape.Controls.SetChildIndex(this.buttonUltimoInvestimento, 0);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(417, 3);
            this.buttonExcluir.Visible = false;
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.Location = new System.Drawing.Point(388, 3);
            this.buttonIncluir.Visible = false;
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.buttonFecharDetalhes);
            this.panelTopo.Controls.SetChildIndex(this.labelTopo, 0);
            this.panelTopo.Controls.SetChildIndex(this.buttonFecharDetalhes, 0);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonMesCorrente
            // 
            this.buttonMesCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMesCorrente.Image = global::MoneyPro.Properties.Resources.z16calendario;
            this.buttonMesCorrente.Location = new System.Drawing.Point(186, 4);
            this.buttonMesCorrente.Name = "buttonMesCorrente";
            this.buttonMesCorrente.Size = new System.Drawing.Size(23, 23);
            this.buttonMesCorrente.TabIndex = 4;
            this.buttonMesCorrente.TabStop = false;
            this.buttonMesCorrente.Tag = "";
            this.toolTip.SetToolTip(this.buttonMesCorrente, "Exibe somente o mês corrente");
            this.buttonMesCorrente.UseVisualStyleBackColor = true;
            this.buttonMesCorrente.Click += new System.EventHandler(this.buttonMesCorrente_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtualizar.Image = global::MoneyPro.Properties.Resources.z16refresh;
            this.buttonAtualizar.Location = new System.Drawing.Point(157, 4);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(23, 23);
            this.buttonAtualizar.TabIndex = 3;
            this.buttonAtualizar.TabStop = false;
            this.buttonAtualizar.Tag = "";
            this.toolTip.SetToolTip(this.buttonAtualizar, "Atualizar o gráfico");
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonFecharDetalhes
            // 
            this.buttonFecharDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFecharDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFecharDetalhes.Image = global::MoneyPro.Properties.Resources.z16fechar;
            this.buttonFecharDetalhes.Location = new System.Drawing.Point(417, 9);
            this.buttonFecharDetalhes.Name = "buttonFecharDetalhes";
            this.buttonFecharDetalhes.Size = new System.Drawing.Size(23, 23);
            this.buttonFecharDetalhes.TabIndex = 18;
            this.buttonFecharDetalhes.TabStop = false;
            this.buttonFecharDetalhes.Tag = "";
            this.toolTip.SetToolTip(this.buttonFecharDetalhes, "Retornar à tela anterior");
            this.buttonFecharDetalhes.UseVisualStyleBackColor = true;
            this.buttonFecharDetalhes.Click += new System.EventHandler(this.buttonFecharDetalhes_Click);
            // 
            // toolTipGrafico
            // 
            this.toolTipGrafico.BackColor = System.Drawing.Color.Gold;
            this.toolTipGrafico.OwnerDraw = true;
            this.toolTipGrafico.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // chart
            // 
            this.chart.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 40);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series7";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Series8";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Series.Add(series7);
            this.chart.Series.Add(series8);
            this.chart.Size = new System.Drawing.Size(452, 192);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart1";
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(53, 5);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(98, 20);
            this.dateTimePickerInicio.TabIndex = 5;
            this.dateTimePickerInicio.ValueChanged += new System.EventHandler(this.dateTimePickerInicio_ValueChanged);
            this.dateTimePickerInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerInicio_KeyDown);
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(10, 9);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(37, 13);
            this.labelInicio.TabIndex = 6;
            this.labelInicio.Text = "Início:";
            this.labelInicio.Click += new System.EventHandler(this.labelInicio_Click);
            // 
            // buttonUltimoInvestimento
            // 
            this.buttonUltimoInvestimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUltimoInvestimento.Image = global::MoneyPro.Properties.Resources.z16ultimodia;
            this.buttonUltimoInvestimento.Location = new System.Drawing.Point(215, 4);
            this.buttonUltimoInvestimento.Name = "buttonUltimoInvestimento";
            this.buttonUltimoInvestimento.Size = new System.Drawing.Size(23, 23);
            this.buttonUltimoInvestimento.TabIndex = 7;
            this.buttonUltimoInvestimento.TabStop = false;
            this.buttonUltimoInvestimento.Tag = "";
            this.toolTip.SetToolTip(this.buttonUltimoInvestimento, "Exibe a partir do último investimento");
            this.buttonUltimoInvestimento.UseVisualStyleBackColor = true;
            this.buttonUltimoInvestimento.Click += new System.EventHandler(this.buttonUltimoInvestimento_Click);
            // 
            // fmCarteiraGraficoValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.chart);
            this.Name = "fmCarteiraGraficoValores";
            this.Controls.SetChildIndex(this.panelTopo, 0);
            this.Controls.SetChildIndex(this.panelRodape, 0);
            this.Controls.SetChildIndex(this.chart, 0);
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTipGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonMesCorrente;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.Button buttonUltimoInvestimento;
    }
}
