using System;

namespace KoneksiDatabase
{
    partial class FormKategori
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
            this.txtNamaKategori = new System.Windows.Forms.MaskedTextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvKategori = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProdukTerkait = new System.Windows.Forms.DataGridView();
            this.btnTutup = new System.Windows.Forms.Button();
            this.lblJumlahKategori = new System.Windows.Forms.Label();
            this.lblTotalSemuaProduk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukTerkait)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNamaKategori
            // 
            this.txtNamaKategori.Location = new System.Drawing.Point(615, 132);
            this.txtNamaKategori.Name = "txtNamaKategori";
            this.txtNamaKategori.Size = new System.Drawing.Size(258, 22);
            this.txtNamaKategori.TabIndex = 0;
            this.txtNamaKategori.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(615, 181);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(109, 34);
            this.btnTambah.TabIndex = 1;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(742, 181);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 34);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(615, 234);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(109, 34);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(612, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nama Produk";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kategori Produk";
            // 
            // dgvKategori
            // 
            this.dgvKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKategori.Location = new System.Drawing.Point(29, 83);
            this.dgvKategori.Name = "dgvKategori";
            this.dgvKategori.RowHeadersWidth = 51;
            this.dgvKategori.RowTemplate.Height = 24;
            this.dgvKategori.Size = new System.Drawing.Size(555, 304);
            this.dgvKategori.TabIndex = 6;
            this.dgvKategori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKategori_CellContentClick);
            this.dgvKategori.SelectionChanged += new System.EventHandler(this.dgvKategori_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Daftar Produk Terkait";
            // 
            // dgvProdukTerkait
            // 
            this.dgvProdukTerkait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdukTerkait.Location = new System.Drawing.Point(29, 450);
            this.dgvProdukTerkait.Name = "dgvProdukTerkait";
            this.dgvProdukTerkait.RowHeadersWidth = 51;
            this.dgvProdukTerkait.RowTemplate.Height = 24;
            this.dgvProdukTerkait.Size = new System.Drawing.Size(910, 233);
            this.dgvProdukTerkait.TabIndex = 8;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(742, 234);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(109, 34);
            this.btnTutup.TabIndex = 9;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // lblJumlahKategori
            // 
            this.lblJumlahKategori.AutoSize = true;
            this.lblJumlahKategori.Location = new System.Drawing.Point(590, 371);
            this.lblJumlahKategori.Name = "lblJumlahKategori";
            this.lblJumlahKategori.Size = new System.Drawing.Size(104, 16);
            this.lblJumlahKategori.TabIndex = 10;
            this.lblJumlahKategori.Text = "Total Kategori: 0";
            this.lblJumlahKategori.Click += new System.EventHandler(this.lblJumlahProduk_Click);
            // 
            // lblTotalSemuaProduk
            // 
            this.lblTotalSemuaProduk.AutoSize = true;
            this.lblTotalSemuaProduk.Location = new System.Drawing.Point(715, 371);
            this.lblTotalSemuaProduk.Name = "lblTotalSemuaProduk";
            this.lblTotalSemuaProduk.Size = new System.Drawing.Size(143, 16);
            this.lblTotalSemuaProduk.TabIndex = 11;
            this.lblTotalSemuaProduk.Text = "Total Semua Produk: 0";
            // 
            // FormKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 695);
            this.Controls.Add(this.lblTotalSemuaProduk);
            this.Controls.Add(this.lblJumlahKategori);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.dgvProdukTerkait);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvKategori);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtNamaKategori);
            this.Name = "FormKategori";
            this.Text = "FormKategori";
            this.Load += new System.EventHandler(this.FormKategori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukTerkait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MaskedTextBox txtNamaKategori;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvProdukTerkait;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Label lblJumlahKategori;
        private System.Windows.Forms.Label lblTotalSemuaProduk;
    }
}