namespace MoneyPro
{
    partial class fmCarteiraGraficoRendimentoDiario
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonFecharDetalhes = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonMesCorrente = new System.Windows.Forms.Button();
            this.toolTipGrafico = new System.Windows.Forms.ToolTip(this.components);
            this.labelInicio = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
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
            this.panelRodape.TabIndex = 0;
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
            this.buttonExcluir.Location = new System.Drawing.Point(417, 4);
            this.buttonExcluir.Visible = false;
            // 
            // buttonIncluir
            // 
            this.buttonIncluir.Location = new System.Drawing.Point(388, 4);
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
            this.labelTopo.Size = new System.Drawing.Size(321, 24);
            this.labelTopo.Text = "Rendimento Diário Acumulado";
            // 
            // chart
            // 
            this.chart.BorderlineWidth = 2;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 40);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series10.Legend = "Legend1";
            series10.Name = "Series2";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series11.Legend = "Legend1";
            series11.Name = "Series3";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series12.Legend = "Legend1";
            series12.Name = "Series4";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series13.Legend = "Legend1";
            series13.Name = "Series5";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series14.Legend = "Legend1";
            series14.Name = "Series6";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series15.Legend = "Legend1";
            series15.Name = "Series7";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series16.Legend = "Legend1";
            series16.Name = "Series8";
            this.chart.Series.Add(series9);
            this.chart.Series.Add(series10);
            this.chart.Series.Add(series11);
            this.chart.Series.Add(series12);
            this.chart.Series.Add(series13);
            this.chart.Series.Add(series14);
            this.chart.Series.Add(series15);
            this.chart.Series.Add(series16);
            this.chart.Size = new System.Drawing.Size(452, 192);
            this.chart.TabIndex = 6;
            this.chart.Text = "chart1";
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
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
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gold;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtualizar.Image = global::MoneyPro.Properties.Resources.z16refresh;
            this.buttonAtualizar.Location = new System.Drawing.Point(159, 4);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(23, 23);
            this.buttonAtualizar.TabIndex = 0;
            this.buttonAtualizar.TabStop = false;
            this.buttonAtualizar.Tag = "";
            this.toolTip.SetToolTip(this.buttonAtualizar, "Atualizar o gráfico");
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonMesCorrente
            // 
            this.buttonMesCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMesCorrente.Image = global::MoneyPro.Properties.Resources.z16calendario;
            this.buttonMesCorrente.Location = new System.Drawing.Point(188, 4);
            this.buttonMesCorrente.Name = "buttonMesCorrente";
            this.buttonMesCorrente.Size = new System.Drawing.Size(23, 23);
            this.buttonMesCorrente.TabIndex = 1;
            this.buttonMesCorrente.TabStop = false;
            this.buttonMesCorrente.Tag = "";
            this.toolTip.SetToolTip(this.buttonMesCorrente, "Exibe somente o mês corrente");
            this.buttonMesCorrente.UseVisualStyleBackColor = true;
            this.buttonMesCorrente.Click += new System.EventHandler(this.buttonMesCorrente_Click);
            // 
            // toolTipGrafico
            // 
            this.toolTipGrafico.BackColor = System.Drawing.Color.Gold;
            this.toolTipGrafico.OwnerDraw = true;
            this.toolTipGrafico.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTipGrafico_Draw);
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(12, 9);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(37, 13);
            this.labelInicio.TabIndex = 2;
            this.labelInicio.Text = "Início:";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(55, 5);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(98, 20);
            this.dateTimePickerInicio.TabIndex = 2;
            this.dateTimePickerInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerInicio_KeyDown);
            // 
            // buttonUltimoInvestimento
            // 
            this.buttonUltimoInvestimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUltimoInvestimento.Image = global::MoneyPro.Properties.Resources.z16ultimodia;
            this.buttonUltimoInvestimento.Location = new System.Drawing.Point(215, 4);
            this.buttonUltimoInvestimento.Name = "buttonUltimoInvestimento";
            this.buttonUltimoInvestimento.Size = new System.Drawing.Size(23, 23);
            this.buttonUltimoInvestimento.TabIndex = 8;
            this.buttonUltimoInvestimento.TabStop = false;
            this.buttonUltimoInvestimento.Tag = "";
            this.toolTip.SetToolTip(this.buttonUltimoInvestimento, "Exibe a partir do último investimento");
            this.buttonUltimoInvestimento.UseVisualStyleBackColor = true;
            this.buttonUltimoInvestimento.Click += new System.EventHandler(this.buttonUltimoInvestimento_Click);
            // 
            // fmCarteiraGraficoRendimentoDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.chart);
            this.Name = "fmCarteiraGraficoRendimentoDiario";
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

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonFecharDetalhes;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTipGrafico;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Button buttonMesCorrente;
        private System.Windows.Forms.Button buttonUltimoInvestimento;
    }
}
