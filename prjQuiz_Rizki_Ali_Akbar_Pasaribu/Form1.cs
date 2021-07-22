using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//mysql library
using MySql.Data.MySqlClient;

namespace prjQuiz_Rizki_Ali_Akbar_Pasaribu
{
    public partial class Form1 : Form
    {
        //koneksi database
        MySqlConnection con = new MySqlConnection("server=localhost;database=dbquiz_rizki_ali_akbar_pasaribu;username=root;password=;sslmode=none");



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void ResetForm()
        {
            // buka kunci NIS
            TBX_NIS.ReadOnly = false;
            TBX_NIS.Text = null;
            TBX_Nama.Text = null;
            TBX_Alamat.Text = null;
            TBX_TempatLahir.Text = null;
            Date_TanggalLahir.Text = null;
            CBX_Agama.Text = null;
            TBX_NoTelpon.Text = null;
            RB_LakiLaki.Checked = false;
            RB_LakiLaki.Checked = false;
        }

        public void loadData()
        {
            ListData.Items.Clear();

            string sql = "SELECT * FROM tobat";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] Data = new string[8];
                Data[0] = reader.GetString("NIS");
                Data[1] = reader.GetString("Nama");
                Data[2] = reader.GetString("Alamat");
                Data[3] = reader.GetString("Tempat_Lahir");
                Data[4] = reader.GetString("Tgl_Lahir");
                Data[5] = reader.GetString("Jenis_Kelamin");
                Data[6] = reader.GetString("Agama");
                Data[7] = reader.GetString("No_Telepon");
                ListViewItem Item = new ListViewItem(Data);
                ListData.Items.Add(Item);
            }

            con.Close();
        }

        private void NIS_DoubleClick(object sender, EventArgs e)
        {
            TBX_NIS.Text = ListData.SelectedItems[0].SubItems[0].Text;
            TBX_Nama.Text = ListData.SelectedItems[0].SubItems[1].Text;
            TBX_Alamat.Text = ListData.SelectedItems[0].SubItems[2].Text;
            TBX_TempatLahir.Text = ListData.SelectedItems[0].SubItems[3].Text;
            Date_TanggalLahir.Text = ListData.SelectedItems[0].SubItems[4].Text;
            CBX_Agama.Text = ListData.SelectedItems[0].SubItems[6].Text;
            TBX_NoTelpon.Text = ListData.SelectedItems[0].SubItems[7].Text;
            if (ListData.SelectedItems[0].SubItems[5].Text == "Laki-Laki")
            {
                RB_LakiLaki.Checked = true;
            }
            else
            {
                RB_Perempuan.Checked = true;
            }

            //kunci NIS agar tidak di ubah
            TBX_NIS.ReadOnly = true;
        }
  
        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            //ngambil data dari form
            String JenisKelamin = RB_LakiLaki.Checked ? "Laki-Laki" : "Perempuan";
            String NIS = TBX_NIS.Text;
            String Nama = TBX_Nama.Text;
            String Alamat = TBX_Alamat.Text;
            String TempatLahir = TBX_TempatLahir.Text;
            String TanggalLahir = Date_TanggalLahir.Text;
            String Agama = CBX_Agama.Text;
            String NoTelpon = TBX_NoTelpon.Text;


            //insert data
            try
            {
                String sql = "INSERT INTO tobat VALUES ('"
                    + NIS+"', '"
                    + Nama +"', '"
                    + Alamat + "', '"
                    + TempatLahir +"', '"
                    + TanggalLahir + "', '" 
                    + JenisKelamin+ "', '" 
                    + Agama +"', '"
                    + NoTelpon +"')";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                ResetForm();
                loadData();
            }catch(Exception err)
            {
                con.Close();
                MessageBox.Show(err.Message);
            }
        }

        private void Btn_Ubah_Click(object sender, EventArgs e)
        {
            //ngambil data dari form
            String JenisKelamin = RB_LakiLaki.Checked ? "Laki-Laki" : "Perempuan";
            String NIS = TBX_NIS.Text;
            String Nama = TBX_Nama.Text;
            String Alamat = TBX_Alamat.Text;
            String TempatLahir = TBX_TempatLahir.Text;
            String TanggalLahir = Date_TanggalLahir.Text;
            String Agama = CBX_Agama.Text;
            String NoTelpon = TBX_NoTelpon.Text;

            //Update Data
            try
            { 
                String sql = "UPDATE tobat SET"
                             + " Nama = " + "'" + Nama + "',"
                             + " Alamat = " + "'" + Alamat + "',"
                             + " Tempat_Lahir = " + "'" + TempatLahir + "',"
                             + " Tgl_Lahir = " + "'" + TanggalLahir + "',"
                             + " Jenis_Kelamin = " + "'" + JenisKelamin + "',"
                             + " Agama = " + "'" + Agama + "',"
                             + " No_Telepon = " + "'" + NoTelpon + "'"
                             + " WHERE NIS = " + NIS;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                ResetForm();
                loadData();
            }catch (Exception err)
            {
                con.Close();
                MessageBox.Show(err.Message);
            }
        }

        private void Btn_Hapus_Click(object sender, EventArgs e)
        {
            try
            {
                String NIS = TBX_NIS.Text;
                String sql = "DELETE FROM tobat WHERE NIS = " + NIS;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                ResetForm();
                loadData();
            }catch (Exception err)
            {
                con.Close();
                MessageBox.Show(err.Message);
            }
        }

        private void Btn_Batal_Click(object sender, EventArgs e)
        {
            ResetForm();
            loadData();
        }

        private void Btn_Keluar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Anda Ingin Keluar", "Pesan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

    }
}
