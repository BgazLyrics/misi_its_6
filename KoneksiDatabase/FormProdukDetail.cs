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
    public partial class FormProdukDetail : Form
    {
        public FormProdukDetail()
        {
            InitializeComponent();

        }
        public int? ProdukId { get; set; } = null;
        private void FormProdukDetail_Load(object sender, EventArgs e)
        {
            // Isi ComboBox kategori
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, NamaKategori FROM Kategori";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var kategoriList = new List<KeyValuePair<int, string>>();
                    while (reader.Read())
                    {
                        kategoriList.Add(new KeyValuePair<int, string>(
                            Convert.ToInt32(reader["Id"]),
                            reader["NamaKategori"].ToString()
                        ));
                    }
                    reader.Close();
                    cmbKategori.DataSource = new BindingSource(kategoriList, null);
                    cmbKategori.DisplayMember = "Value";
                    cmbKategori.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat kategori: " + ex.Message);
                }
            }

            // Jika mode edit produk
            if (ProdukId == null) return;
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT NamaProduk, Harga, Stok, KategoriId
FROM Produk WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", ProdukId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNamaProduk.Text = reader["NamaProduk"].ToString();
                        txtNamaHarga.Text = reader["Harga"].ToString();
                        txtStok.Text = reader["Stok"].ToString();
                        cmbKategori.SelectedValue =
                        Convert.ToInt32(reader["KategoriId"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data produk: " + ex.Message);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNamaProduk.Text))
            {
                MessageBox.Show("Nama produk tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Hentikan eksekusi jika nama produk kosong
            }

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Produk (NamaProduk, Harga, Stok, KategoriId, Deskripsi)
                 VALUES (@nama, @harga, @stok, @kategori, @deskripsi)";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNamaProduk.Text);
                    cmd.Parameters.AddWithValue("@harga",
                    Convert.ToDecimal(txtNamaHarga.Text));
                    cmd.Parameters.AddWithValue("@stok",
                    Convert.ToInt32(txtStok.Text));
                    
                    cmd.Parameters.AddWithValue("@kategori", ((KeyValuePair<int,string>)cmbKategori.SelectedItem).Key);
                    
                    cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produk berhasil ditambahkan!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan produk: " + ex.Message);
                }
            }


        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            // Cek jika karakter yang ditekan BUKAN tombol kontrol (seperti backspace)
            // DAN BUKAN merupakan angka (digit).
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Jika kondisi terpenuhi (bukan kontrol dan bukan angka),
                // maka batalkan input karakter tersebut.
                e.Handled = true;
            }
        }

        private void txtNamaHarga_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Izinkan angka, tombol kontrol, dan satu buah titik/koma sebagai desimal.
            // Ganti '.' dengan ',' jika Anda menggunakan format Indonesia.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Hanya izinkan satu titik desimal.
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
    }

        private void txtNamaHarga_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

