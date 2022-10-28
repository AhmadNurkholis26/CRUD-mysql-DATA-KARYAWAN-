using DataKaryawan.controller;
using DataKaryawan.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataKaryawan
{
    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();
        Karyawan_m karyawan = new Karyawan_m();
        string id;

        public void Tampil()
        {
            dataTabel.DataSource = koneksi.ShowData("SELECT * FROM karyawan");

            dataTabel.Columns[0].HeaderText = "#";
            dataTabel.Columns[1].HeaderText = "NIK";
            dataTabel.Columns[2].HeaderText = "Nama Karyawan";
            dataTabel.Columns[3].HeaderText = "Jabatan";
            dataTabel.Columns[4].HeaderText = "Alamat";
            dataTabel.Columns[5].HeaderText = "Email";
            dataTabel.Columns[6].HeaderText = "Nomor telpon";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //method tampil
            Tampil();
            //menambah item pada jabatan
            comboJabatan.Items.Add("Fronted");
            comboJabatan.Items.Add("Backend");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtDataKaryawan.Text == "" || txtNIK.Text == "" || comboJabatan.SelectedIndex == -1 || txtEmail.Text == "" || txtAlamat.Text == "" || txtNomorTelepon.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Karyawan kr = new Karyawan();
                karyawan.Nik = txtNIK.Text;
                karyawan.Nama = txtDataKaryawan.Text;
                karyawan.Jabatan = comboJabatan.Text;
                karyawan.Alamat = txtAlamat.Text;
                karyawan.Email = txtEmail.Text;
                karyawan.Nohp = txtNomorTelepon.Text;

                kr.Insert(karyawan);
                txtNIK.Text = "";
                txtDataKaryawan.Text = "";
                comboJabatan.SelectedIndex = -1;
                txtAlamat.Text = " ";
                txtEmail.Text = "";
                txtNomorTelepon.Text = "";

                Tampil();


            }
        }

        private void dataTabel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataTabel.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNIK.Text = dataTabel.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDataKaryawan.Text = dataTabel.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboJabatan.Text = dataTabel.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAlamat.Text = dataTabel.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dataTabel.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtNomorTelepon.Text = dataTabel.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtDataKaryawan.Text == "" || txtNIK.Text == "" || comboJabatan.SelectedIndex == -1 || txtEmail.Text == "" || txtAlamat.Text == "" || txtNomorTelepon.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Karyawan kr = new Karyawan();
                karyawan.Nik = txtNIK.Text;
                karyawan.Nama = txtDataKaryawan.Text;
                karyawan.Jabatan = comboJabatan.Text;
                karyawan.Alamat = txtAlamat.Text;
                karyawan.Email = txtEmail.Text;
                karyawan.Nohp = txtNomorTelepon.Text;

                kr.Update(karyawan, id);
                txtNIK.Text = "";
                txtDataKaryawan.Text = "";
                comboJabatan.SelectedIndex = -1;
                txtAlamat.Text = " ";
                txtEmail.Text = "";
                txtNomorTelepon.Text = "";

                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Yakin ingin menghapus data?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if(pesan == DialogResult.Yes)
            {
                Karyawan kr = new Karyawan();
                kr.Delete(id);
                Tampil();
            }
        }

        private void txtCariData_TextChanged(object sender, EventArgs e)
        {
            dataTabel.DataSource = koneksi.ShowData("SELECT * FROM karyawan WHERE nik LIKE '%' '" + txtCariData.Text + "'  '%' OR nama LIKE '%' '" + txtCariData.Text + "' '%' ");
        }
    }
}
