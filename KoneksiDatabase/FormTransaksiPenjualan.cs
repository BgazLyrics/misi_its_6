using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoneksiDatabase
{
    public partial class FormTransaksiPenjualan : Form
    {
        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan yang diklik adalah kolom "Hapus" dan bukan header
            if (e.ColumnIndex == dgvItem.Columns["Hapus"].Index && e.RowIndex >= 0)
            {
                // Hapus baris yang tombolnya diklik
                dgvItem.Rows.RemoveAt(e.RowIndex);

                // Hitung ulang total setelah baris dihapus
                HitungTotal(); // [cite: 139]
            }
        }
        public FormTransaksiPenjualan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTransaksiPenjualan_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, NamaProduk FROM Produk",
                conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<int, string> produkDict = new Dictionary<int, string>();
                while (reader.Read())
                {
                    produkDict.Add((int)reader["Id"],
                    reader["NamaProduk"].ToString());
                }
                cmbProduk.DataSource = new BindingSource(produkDict, null);
                cmbProduk.DisplayMember = "Value";
                cmbProduk.ValueMember = "Key";
            }
            // Setup kolom dgvItem
            dgvItem.Columns.Add("ProdukId", "ProdukId");
            dgvItem.Columns["ProdukId"].Visible = false;
            dgvItem.Columns.Add("NamaProduk", "Nama Produk");
            dgvItem.Columns.Add("Harga", "Harga");
            dgvItem.Columns.Add("Jumlah", "Jumlah");
            dgvItem.Columns.Add("Subtotal", "Subtotal");

            // --- Tambahan untuk Misi 2 (Tambah Kolom Tombol) ---
            DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
            btnHapus.Name = "Hapus";
            btnHapus.HeaderText = "Aksi";
            btnHapus.Text = "Hapus";
            btnHapus.UseColumnTextForButtonValue = true; // Teks "Hapus" akan muncul di tombol
            dgvItem.Columns.Add(btnHapus);
            // --- Akhir Tambahan ---
        
        }

        private void HitungTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            lblTotal.Text = $"Total: Rp {total:N0}";
        }
        private decimal GetHargaProduk(int produkId)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Harga FROM Produk WHERE Id = @id", conn);
               cmd.Parameters.AddWithValue("@id", produkId);
                return (decimal)cmd.ExecuteScalar();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

            if (cmbProduk.SelectedItem == null || !int.TryParse(txtJumlah.Text, out
            int jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Pilih produk dan jumlah valid.");
                return;
            }
            var selected = (KeyValuePair<int, string>)cmbProduk.SelectedItem;
            int produkId = selected.Key;
            string namaProduk = selected.Value;

            int stokSekarang = GetStokProduk(produkId);
            if (jumlah > stokSekarang)
            {
                MessageBox.Show($"Stok tidak mencukupi. Stok {namaProduk} tersisa: {stokSekarang}");
                return;
            }

            decimal harga = GetHargaProduk(produkId);
            decimal subtotal = harga * jumlah;
            dgvItem.Rows.Add(produkId, namaProduk, harga, jumlah, subtotal);
            HitungTotal();

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada item ditambahkan.");
                return;
            }
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlTransaction trx = conn.BeginTransaction();
                try
                {
                    // 1. Insert ke Penjualan
                    decimal total = dgvItem.Rows.Cast<DataGridViewRow>()
                    .Sum(r => Convert.ToDecimal(r.Cells["Subtotal"].Value));
                    SqlCommand cmdPenjualan = new SqlCommand(
                    "INSERT INTO Penjualan (Tanggal, TotalHarga) VALUES (@tgl, @total); SELECT SCOPE_IDENTITY(); ",
                conn, trx);
                    cmdPenjualan.Parameters.AddWithValue("@tgl", DateTime.Now);
                    cmdPenjualan.Parameters.AddWithValue("@total", total);
                    int penjualanId = Convert.ToInt32(cmdPenjualan.ExecuteScalar());
                    // 2. Insert ke PenjualanDetail
                    foreach (DataGridViewRow row in dgvItem.Rows)
                    {
                        SqlCommand cmdDetail = new SqlCommand(
                        @"INSERT INTO PenjualanDetail (PenjualanId, ProdukId, Jumlah, Subtotal) VALUES (@pjId, @prodId, @jumlah, @subtotal)", conn, trx);
                        cmdDetail.Parameters.AddWithValue("@pjId", penjualanId);
                        cmdDetail.Parameters.AddWithValue("@prodId",
                        row.Cells["ProdukId"].Value);
                        cmdDetail.Parameters.AddWithValue("@jumlah",
                        row.Cells["Jumlah"].Value);
                        cmdDetail.Parameters.AddWithValue("@subtotal",
                        row.Cells["Subtotal"].Value);
                        cmdDetail.ExecuteNonQuery();
                    
                    SqlCommand cmdUpdateStok = new SqlCommand(
            "UPDATE Produk SET Stok = Stok - @jumlah WHERE Id = @prodId", conn, trx);

                    cmdUpdateStok.Parameters.AddWithValue("@jumlah", row.Cells["Jumlah"].Value); 
                    cmdUpdateStok.Parameters.AddWithValue("@prodId", row.Cells["ProdukId"].Value); 
                    cmdUpdateStok.ExecuteNonQuery();
                    
                }

                    trx.Commit();
                    MessageBox.Show("Transaksi berhasil disimpan!");
                    dgvItem.Rows.Clear();
                    HitungTotal();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private int GetStokProduk(int produkId)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Stok FROM Produk WHERE Id = @id", conn); // Asumsi ada kolom 'Stok'
                cmd.Parameters.AddWithValue("@id", produkId);
                return (int)cmd.ExecuteScalar();
            }
        }
    } 
}
