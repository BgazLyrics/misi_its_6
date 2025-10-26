using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KoneksiDatabase
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();

            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);

            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        private void TampilkanPenjualanPerHari()
        {
            chartPenjualan.Series.Clear();
            chartPenjualan.ChartAreas.Clear();
            ChartArea area = new ChartArea("AreaUtama");
            chartPenjualan.ChartAreas.Add(area);
            Series series = new Series("Penjualan Per Hari");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Date;
            chartPenjualan.Series.Add(series);

            DateTime dariTanggal = dtpDariTanggal.Value.Date;
            DateTime sampaiTanggal = dtpSampaiTanggal.Value.Date;

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();

                string query = @"SELECT CAST(Tanggal AS DATE) AS Tgl, SUM(TotalHarga) AS Total 
                                 FROM Penjualan 
                                 WHERE CAST(Tanggal AS DATE) BETWEEN @DariTanggal AND @SampaiTanggal
                                 GROUP BY CAST(Tanggal AS DATE) 
                                 ORDER BY Tgl";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DariTanggal", dariTanggal);
                cmd.Parameters.AddWithValue("@SampaiTanggal", sampaiTanggal);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime tanggal = Convert.ToDateTime(reader["Tgl"]);
                    decimal total = Convert.ToDecimal(reader["Total"]);
                    series.Points.AddXY(tanggal.ToString("dd-MM"), total);
                }
                reader.Close();
            }
            chartPenjualan.Titles.Clear();
            chartPenjualan.Titles.Add("Grafik Penjualan per Hari");
        }

        private void TampilkanPenjualanPerKategori()
        {
            chartPenjualan.Series.Clear();
            chartPenjualan.ChartAreas.Clear();
            ChartArea area = new ChartArea("AreaKategori");
            chartPenjualan.ChartAreas.Add(area);
            Series series = new Series("Penjualan per Kategori");
            series.ChartType = SeriesChartType.Pie;
            chartPenjualan.Series.Add(series);

            DateTime dariTanggal = dtpDariTanggal.Value.Date;
            DateTime sampaiTanggal = dtpSampaiTanggal.Value.Date;

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT k.NamaKategori, SUM(pd.Subtotal) AS Total
                    FROM PenjualanDetail pd
                    JOIN Produk p ON p.Id = pd.ProdukId
                    JOIN Kategori k ON k.Id = p.KategoriId
                    JOIN Penjualan pj ON pj.Id = pd.PenjualanId 
                    WHERE CAST(pj.Tanggal AS DATE) BETWEEN @DariTanggal AND @SampaiTanggal
                    GROUP BY k.NamaKategori";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DariTanggal", dariTanggal);
                cmd.Parameters.AddWithValue("@SampaiTanggal", sampaiTanggal);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string kategori = reader["NamaKategori"].ToString();
                    decimal total = Convert.ToDecimal(reader["Total"]);
                    series.Points.AddXY(kategori, total);
                }
                reader.Close();
            }
            chartPenjualan.Titles.Clear();
            chartPenjualan.Titles.Add("Grafik Penjualan per Kategori");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            dtpDariTanggal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSampaiTanggal.Value = DateTime.Now;

            TampilkanTotalMingguan();

            if (cmbTipeLaporan.Items.Count > 0)
            {
                cmbTipeLaporan.SelectedIndex = 0;
            }

            TampilkanPenjualanPerHari();
        }

        private void chartPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipeLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTipeLaporan.SelectedItem.ToString() == "Harian")
            {
                TampilkanPenjualanPerHari();
            }
            else
            {
                TampilkanPenjualanPerKategori();
            }

            // TAMBAHKAN BARIS INI
            TampilkanTotalMingguan();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            string judul = chartPenjualan.Titles.Count > 0 ? chartPenjualan.Titles[0].Text : "Laporan Penjualan";
            Font fontJudul = new Font("Arial", 16, FontStyle.Bold);
            g.DrawString(judul, fontJudul, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);

            Rectangle rectChart = new Rectangle(
                e.MarginBounds.Left,
                e.MarginBounds.Top + 40,
                e.MarginBounds.Width,
                e.MarginBounds.Height - 60
            );

            chartPenjualan.Printing.PrintPaint(g, rectChart);
        }

        private void TampilkanTotalMingguan() // Nama method tetap, tapi logikanya diubah
        {
            decimal total = 0;

            // 1. Ambil rentang tanggal dari filter, sama seperti chart
            DateTime dariTanggal = dtpDariTanggal.Value.Date;
            DateTime sampaiTanggal = dtpSampaiTanggal.Value.Date;

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();

                // 2. Query diubah untuk menghitung SUM() berdasarkan rentang filter
                string query = @"SELECT SUM(TotalHarga) 
                         FROM Penjualan
                         WHERE CAST(Tanggal AS DATE) BETWEEN @DariTanggal AND @SampaiTanggal";

                SqlCommand cmd = new SqlCommand(query, conn);

                // 3. Tambahkan parameter yang sama
                cmd.Parameters.AddWithValue("@DariTanggal", dariTanggal);
                cmd.Parameters.AddWithValue("@SampaiTanggal", sampaiTanggal);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    total = Convert.ToDecimal(result);
                }
            }

            CultureInfo ci = new CultureInfo("id-ID");

            // 4. Ubah teks label agar lebih jelas
            lblTotalMingguan.Text = $"Total Penjualan (Filter): {total.ToString("C", ci)}";
            lblTotalMingguan.Font = new Font(lblTotalMingguan.Font, FontStyle.Bold);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTotalMingguan_Click(object sender, EventArgs e)
        {

        }
    }
}