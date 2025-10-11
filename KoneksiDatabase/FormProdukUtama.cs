using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoneksiDatabase
{
    public partial class FormProdukUtama : Form
    {
        public FormProdukUtama()
        {
            InitializeComponent();
        }

        private void FormProdukUtama_Load(object sender, EventArgs e)
        {
            LoadDataProduk();
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void dgvProduk_SelectionChanged(object sender, EventArgs e)
        {
            // Periksa apakah ada baris yang dipilih
            if (dgvProduk.SelectedRows.Count > 0)
            {
                // Jika ada, aktifkan tombol
                btnEdit.Enabled = true;
                btnHapus.Enabled = true;
            }
            else
            {
                // Jika tidak ada, nonaktifkan tombol
                btnEdit.Enabled = false;
                btnHapus.Enabled = false;
            }
        }

        private void LoadDataProduk()
        {
            dgvProduk.Rows.Clear();
            dgvProduk.Columns.Clear();

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT p.Id, p.NamaProduk, p.Harga, p.Stok, p.Deskripsi, k.NamaKategori
                                    FROM Produk p
                                    LEFT JOIN Kategori k ON p.KategoriId = k.Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Tambahkan kolom ke grid
                    dgvProduk.Columns.Add("Id", "ID");
                    dgvProduk.Columns.Add("NamaProduk", "Nama Produk");
                    dgvProduk.Columns.Add("Harga", "Harga");
                    dgvProduk.Columns.Add("Stok", "Stok");
                    dgvProduk.Columns.Add("Kategori", "Kategori");
                    dgvProduk.Columns.Add("Deskripsi", "Deskripsi"); // Kolom baru


                    if (dgvProduk.Columns["Harga"] != null)
                    {
                        dgvProduk.Columns["Harga"].DefaultCellStyle.Format = "c";
                        dgvProduk.Columns["Harga"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("id-ID");
                    }

                    while (reader.Read())
                    {
                        dgvProduk.Rows.Add(
                        reader["Id"],
                        reader["NamaProduk"],
                        reader["Harga"],
                        reader["Stok"],
                        reader["NamaKategori"],
                        reader["Deskripsi"] // Data baru
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menampilkan data: " + ex.Message);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FormProdukDetail frm = new FormProdukDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataProduk(); // refresh data setelah tambah
            }
        }
        private int? GetSelectedProductId()
        {
            if (dgvProduk.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvProduk.SelectedRows[0].Cells["Id"].Value);
            }
            return null;

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedProductId();
            if (id == null)
            {
                MessageBox.Show("Pilih produk yang ingin diedit.");
                return;
            }
            FormProdukDetail form = new FormProdukDetail();
            form.ProdukId = id;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataProduk();
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedProductId();
            if (id == null)
            {
                MessageBox.Show("Pilih produk yang ingin dihapus.");
                return;
            }
            DialogResult result = MessageBox.Show(
            "Yakin ingin menghapus produk ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Produk WHERE Id = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produk berhasil dihapus!");
                        LoadDataProduk();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus produk: " + ex.Message);
                    }
                }
            }
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FormKategori munculin = new FormKategori();
            munculin.ShowDialog();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataProduk();
            MessageBox.Show("Data telah berhasil diperbarui.", "Refresh Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}

