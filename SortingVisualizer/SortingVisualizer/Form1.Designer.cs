namespace SortingVisualizer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.initSortbtn = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.listSortAlgos = new System.Windows.Forms.ListBox();
            this.barSamples = new System.Windows.Forms.TrackBar();
            this.txtSamples = new System.Windows.Forms.TextBox();
            this.btnCancelSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.AccessibleDescription = "";
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.mainChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.mainChart.Legends.Add(legend2);
            this.mainChart.Location = new System.Drawing.Point(12, 0);
            this.mainChart.Name = "mainChart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.CustomProperties = "PointWidth=1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.mainChart.Series.Add(series2);
            this.mainChart.Size = new System.Drawing.Size(945, 431);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // initSortbtn
            // 
            this.initSortbtn.Location = new System.Drawing.Point(515, 512);
            this.initSortbtn.Name = "initSortbtn";
            this.initSortbtn.Size = new System.Drawing.Size(75, 23);
            this.initSortbtn.TabIndex = 1;
            this.initSortbtn.Text = "Sort";
            this.initSortbtn.UseVisualStyleBackColor = true;
            this.initSortbtn.Click += new System.EventHandler(this.InitSortbtn_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(61, 512);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Scramble";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // listSortAlgos
            // 
            this.listSortAlgos.FormattingEnabled = true;
            this.listSortAlgos.ItemHeight = 16;
            this.listSortAlgos.Location = new System.Drawing.Point(436, 452);
            this.listSortAlgos.Name = "listSortAlgos";
            this.listSortAlgos.Size = new System.Drawing.Size(73, 84);
            this.listSortAlgos.TabIndex = 4;
            // 
            // barSamples
            // 
            this.barSamples.Location = new System.Drawing.Point(12, 452);
            this.barSamples.Maximum = 1000;
            this.barSamples.Name = "barSamples";
            this.barSamples.Size = new System.Drawing.Size(278, 56);
            this.barSamples.TabIndex = 5;
            this.barSamples.TickFrequency = 100;
            this.barSamples.Value = 100;
            this.barSamples.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // txtSamples
            // 
            this.txtSamples.Location = new System.Drawing.Point(12, 513);
            this.txtSamples.Name = "txtSamples";
            this.txtSamples.Size = new System.Drawing.Size(43, 22);
            this.txtSamples.TabIndex = 6;
            this.txtSamples.Text = "100";
            this.txtSamples.TextChanged += new System.EventHandler(this.TxtSamples_TextChanged);
            // 
            // btnCancelSort
            // 
            this.btnCancelSort.Enabled = false;
            this.btnCancelSort.Location = new System.Drawing.Point(596, 512);
            this.btnCancelSort.Name = "btnCancelSort";
            this.btnCancelSort.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSort.TabIndex = 7;
            this.btnCancelSort.Text = "Cancel";
            this.btnCancelSort.UseVisualStyleBackColor = true;
            this.btnCancelSort.Click += new System.EventHandler(this.BtnCancelSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 547);
            this.Controls.Add(this.btnCancelSort);
            this.Controls.Add(this.txtSamples);
            this.Controls.Add(this.barSamples);
            this.Controls.Add(this.listSortAlgos);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.initSortbtn);
            this.Controls.Add(this.mainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSamples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button initSortbtn;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox listSortAlgos;
        private System.Windows.Forms.TrackBar barSamples;
        private System.Windows.Forms.TextBox txtSamples;
        internal System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button btnCancelSort;
    }
}

