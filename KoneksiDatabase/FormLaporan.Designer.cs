namespace KoneksiDatabase
{
    partial class FormLaporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaporan));
            this.chartPenjualan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipeLaporan = new System.Windows.Forms.ComboBox();
            this.dtpDariTanggal = new System.Windows.Forms.DateTimePicker();
            this.aaa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSampaiTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblTotalMingguan = new System.Windows.Forms.Label();
            this.btnCetak = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPenjualan
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPenjualan.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartPenjualan.Legends.Add(legend4);
            this.chartPenjualan.Location = new System.Drawing.Point(67, 160);
            this.chartPenjualan.Name = "chartPenjualan";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartPenjualan.Series.Add(series4);
            this.chartPenjualan.Size = new System.Drawing.Size(659, 300);
            this.chartPenjualan.TabIndex = 0;
            this.chartPenjualan.Text = "chart1";
            this.chartPenjualan.Click += new System.EventHandler(this.chartPenjualan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "LAPORAN PENJUALAN";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(661, 87);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipe Laporan";
            // 
            // cmbTipeLaporan
            // 
            this.cmbTipeLaporan.FormattingEnabled = true;
            this.cmbTipeLaporan.Items.AddRange(new object[] {
            "Harian",
            "Kategori"});
            this.cmbTipeLaporan.Location = new System.Drawing.Point(143, 87);
            this.cmbTipeLaporan.Name = "cmbTipeLaporan";
            this.cmbTipeLaporan.Size = new System.Drawing.Size(121, 24);
            this.cmbTipeLaporan.TabIndex = 5;
            this.cmbTipeLaporan.SelectedIndexChanged += new System.EventHandler(this.cmbTipeLaporan_SelectedIndexChanged);
            // 
            // dtpDariTanggal
            // 
            this.dtpDariTanggal.Location = new System.Drawing.Point(155, 132);
            this.dtpDariTanggal.Name = "dtpDariTanggal";
            this.dtpDariTanggal.Size = new System.Drawing.Size(200, 22);
            this.dtpDariTanggal.TabIndex = 6;
            // 
            // aaa
            // 
            this.aaa.AutoSize = true;
            this.aaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aaa.Location = new System.Drawing.Point(44, 132);
            this.aaa.Name = "aaa";
            this.aaa.Size = new System.Drawing.Size(91, 18);
            this.aaa.TabIndex = 7;
            this.aaa.Text = "Dari Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sampai Tanggal";
            // 
            // dtpSampaiTanggal
            // 
            this.dtpSampaiTanggal.Location = new System.Drawing.Point(550, 132);
            this.dtpSampaiTanggal.Name = "dtpSampaiTanggal";
            this.dtpSampaiTanggal.Size = new System.Drawing.Size(200, 22);
            this.dtpSampaiTanggal.TabIndex = 8;
            // 
            // lblTotalMingguan
            // 
            this.lblTotalMingguan.AutoSize = true;
            this.lblTotalMingguan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMingguan.Location = new System.Drawing.Point(34, 481);
            this.lblTotalMingguan.Name = "lblTotalMingguan";
            this.lblTotalMingguan.Size = new System.Drawing.Size(109, 18);
            this.lblTotalMingguan.TabIndex = 10;
            this.lblTotalMingguan.Text = "Total Mingguan";
            this.lblTotalMingguan.Click += new System.EventHandler(this.lblTotalMingguan_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(675, 481);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(75, 23);
            this.btnCetak.TabIndex = 11;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(580, 86);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Tutup";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.lblTotalMingguan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpSampaiTanggal);
            this.Controls.Add(this.aaa);
            this.Controls.Add(this.dtpDariTanggal);
            this.Controls.Add(this.cmbTipeLaporan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartPenjualan);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPenjualan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipeLaporan;
        private System.Windows.Forms.DateTimePicker dtpDariTanggal;
        private System.Windows.Forms.Label aaa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSampaiTanggal;
        private System.Windows.Forms.Label lblTotalMingguan;
        private System.Windows.Forms.Button btnCetak;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnClose;
    }
}