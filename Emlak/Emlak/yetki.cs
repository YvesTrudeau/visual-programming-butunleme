using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Emlak
{
    public partial class yetki : Form
    {
        public yetki()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        public void ayar(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        private void yetki_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (veri==0)
            {
                yanasayfa y = new yanasayfa();
                y.Show();
            }
            else
            {
                giris g = new giris();
                g.Show();
            }
            
        }

        private void yetki_Load(object sender, EventArgs e)
        {
            ayar(dataGridView1);
            try
            {
                conn = new MySqlConnection(giris.con);
                dt = new DataTable();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                conn.Open();
                if (comboBox1.SelectedItem.ToString() == "MÜŞTERİ")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button1.Text = "YÖNETİCİ YAP";
                }
                else if (comboBox1.SelectedItem.ToString() == "YÖNETİCİ")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ygiris", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    button1.Text = "MÜŞTERİ YAP";
                }
                else
                {
                    MessageBox.Show("comboBox1_SelectedIndexChanged KOD ALANINDA HATA VAR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

                dataGridView1.Columns[0].HeaderText = "İSİM";
                dataGridView1.Columns[1].HeaderText = "SOYİSİM";
                dataGridView1.Columns[2].HeaderText = "KULLANICI ADI";
                dataGridView1.Columns[3].HeaderText = "ŞİFRE";
                dataGridView1.Columns[4].HeaderText = "E-POSTA";
                dataGridView1.Columns[5].HeaderText = "TELEFON NUMARASI";
                dataGridView1.Columns[6].HeaderText = "T.C KİMLİK";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string ad, syd, ka, sf, posta, tel, tc;
        int veri = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (button1.Text == "YÖNETİCİ YAP")
                {
                    string sorgu = "Insert into ygiris values ('" + ad + "','" + syd + "','" + ka + "','" + sf + "','" + posta + "','" + tel + "','" + tc + "')";
                    cmd = new MySqlCommand(sorgu, conn);
                    cmd.ExecuteNonQuery();

                    string sql = "DELETE FROM musteri WHERE tc='" + tc + "'";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("YETKİLENDİRME BAŞARILI", "MÜŞTERİ EKLE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dt.Clear();
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (button1.Text == "MÜŞTERİ YAP")
                {
                    string sorgu = "Insert into musteri values ('" + ad + "','" + syd + "','" + ka + "','" + sf + "','" + posta + "','" + tel + "','" + tc + "')";
                    cmd = new MySqlCommand(sorgu, conn);
                    cmd.ExecuteNonQuery();

                    string sql = "DELETE FROM ygiris WHERE tc='" + tc + "'";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    if (ka == giris.ad.ToString())
                    {
                        MessageBox.Show("KENDİ HESABINIZIN YETKİSİNİ DEĞİŞTİRDİĞİNİZ\nLÜTFEN TEKRAR GİRİŞ YAPIN", "MÜŞTERİ EKLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veri = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("YETKİLENDİRME BAŞARILI", "MÜŞTERİ EKLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt.Clear();
                        adapter = new MySqlDataAdapter("SELECT * FROM ygiris", conn);
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                }
                else
                {
                    MessageBox.Show("button1_Click KOD ALANINDA HATA VAR", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ad = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            syd = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ka = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sf = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            posta = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tel = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tc = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
