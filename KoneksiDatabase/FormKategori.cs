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
    public partial class FormKategori : Form
    {
        public FormKategori()
        {
            InitializeComponent();
        }
        private void LoadDataKategori()
        {
            dgvKategori.Rows.Clear();
            dgvKategori.Columns.Clear();
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, NamaKategori FROM Kategori";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                dgvKategori.Columns.Add("Id", "ID");
                dgvKategori.Columns.Add("NamaKategori", "Nama Kategori");
                while (reader.Read())
                {
                    dgvKategori.Rows.Add(reader["Id"], reader["NamaKategori"]);
                }
                reader.Close();

                lblJumlahKategori.Text = "Total Kategori: " + dgvKategori.Rows.Count.ToString();

                int jumlahKategori = dgvKategori.Rows.Count;
                if (jumlahKategori > 0)
                {
                    lblJumlahKategori.Text = "Total Kategori: " + (jumlahKategori - 1).ToString();
                }
                else
                {
                    lblJumlahKategori.Text = "Total Kategori: 0";
                }
            }
        }

        private void LoadTotalProduk()
        {
            try
            {
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    // Query ini sangat efisien karena hanya meminta database untuk menghitung,
                    // bukan mengirim semua data produk.
                    string query = "SELECT COUNT(*) FROM Produk";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // ExecuteScalar digunakan saat kita mengharapkan satu nilai tunggal sebagai hasilnya.
                    int jumlahProduk = (int)cmd.ExecuteScalar();

                    // Update teks labelnya
                    lblTotalSemuaProduk.Text = "Total Semua Produk: " + jumlahProduk.ToString();
                }
            }
            catch (Exception ex)
            {
                // Jika terjadi error, tampilkan pesan dan set label ke 0
                MessageBox.Show("Gagal memuat total produk: " + ex.Message);
                lblTotalSemuaProduk.Text = "Total Semua Produk: 0";
            }
        }
        private void FormKategori_Load(object sender, EventArgs e)
        {
            LoadDataKategori();
            LoadTotalProduk();
            dgvKategori.ClearSelection();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvKategori.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kategori yang ingin dihapus.");
                return;
            }
            int id = Convert.ToInt32(dgvKategori.SelectedRows[0].Cells["Id"].Value);
            DialogResult confirm = MessageBox.Show(
            "Yakin ingin menghapus kategori ini?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Kategori WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori berhasil dihapus.");
                    LoadDataKategori();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvKategori.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kategori terlebih dahulu.");
                return;
            }
            int id = Convert.ToInt32(dgvKategori.SelectedRows[0].Cells["Id"].Value);
            string nama = txtNamaKategori.Text.Trim();
            if (nama.Length < 3)
            {
                MessageBox.Show("Nama kategori minimal harus 3 karakter.");
                return;
            }
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong.");
                return;
            }
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Kategori SET NamaKategori = @nama WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategori berhasil diubah.");
                txtNamaKategori.Clear();
                LoadDataKategori();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaKategori.Text))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong.");
                return;
            }

            if (txtNamaKategori.TextLength < 3)
            {
                MessageBox.Show("Nama kategori minimal harus 3 karakter.");
                return;
            }

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Kategori (NamaKategori) VALUES (@nama)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNamaKategori.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategori berhasil ditambahkan!");
                txtNamaKategori.Clear();
                LoadDataKategori();
            }
        }

        private void dgvKategori_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKategori.SelectedRows.Count == 0) return;
            int kategoriId =
            Convert.ToInt32(dgvKategori.SelectedRows[0].Cells["Id"].Value);
            txtNamaKategori.Text =
            dgvKategori.SelectedRows[0].Cells["NamaKategori"].Value.ToString();
            dgvProdukTerkait.Rows.Clear();
            dgvProdukTerkait.Columns.Clear();
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                string query = "SELECT NamaProduk, Harga, Stok FROM Produk WHERE KategoriId = @kategoriId";
            SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kategoriId", kategoriId);
                SqlDataReader reader = cmd.ExecuteReader();
                dgvProdukTerkait.Columns.Add("NamaProduk", "Nama Produk");
                dgvProdukTerkait.Columns.Add("Harga", "Harga");
                dgvProdukTerkait.Columns.Add("Stok", "Stok");
                while (reader.Read())
                {
                    dgvProdukTerkait.Rows.Add(
                    reader["NamaProduk"],
                    reader["Harga"],
                    reader["Stok"]
                    );
                }
                reader.Close();
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvKategori.SelectedRows.Count == 0)
            {
                // Mengosongkan tampilan produk dan label jika tidak ada kategori terpilih
                dgvProdukTerkait.Rows.Clear();
                lblJumlahKategori.Text = "Jumlah Produk: 0";
                return;
            }

            int kategoriId = Convert.ToInt32(dgvKategori.SelectedRows[0].Cells["Id"].Value);
            
        }

        private void lblJumlahProduk_Click(object sender, EventArgs e)
        {

        }
    }

}
