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

namespace Emlak
{
    public partial class ayarguncelle : Form
    {
        public ayarguncelle()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        private void ayarguncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }
        string tut;
        private void ayarguncelle_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(giris.con);
                dt = new DataTable();
                conn.Open();
                if (giris.deg == 0)
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ygiris where ka='" + giris.ad.ToString() + "'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ygiris where ka='" + giris.ka.ToString() + "'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                conn.Close();

                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tut = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox4.PasswordChar = '*';
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == dataGridView1.CurrentRow.Cells[0].Value.ToString() && textBox2.Text == dataGridView1.CurrentRow.Cells[1].Value.ToString() && textBox3.Text == dataGridView1.CurrentRow.Cells[2].Value.ToString() && textBox4.Text == dataGridView1.CurrentRow.Cells[3].Value.ToString() && textBox5.Text == dataGridView1.CurrentRow.Cells[4].Value.ToString() && textBox6.Text == dataGridView1.CurrentRow.Cells[5].Value.ToString() && textBox7.Text == dataGridView1.CurrentRow.Cells[6].Value.ToString())
            {
                MessageBox.Show("verileri değişmiyon niye butona basıyon mk");
            }
            else
            {
                string veri = textBox3.Text;
                try
                {
                    conn = new MySqlConnection(giris.con);
                    string sql = "UPDATE ygiris SET ad='" + textBox1.Text + "', soyad='" + textBox2.Text + "',ka='" + textBox3.Text + "',sf='" + textBox4.Text + "',posta='" + textBox5.Text + "',telefon='" + textBox6.Text + "',tc='" + textBox7.Text + "' where tc='" + tut + "'";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("HESAP BİLGİLERİ GÜNCELLENDİ.", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    giris.deg = 1;
                    dt.Clear();
                    conn.Open();
                    adapter = new MySqlDataAdapter("SELECT * FROM ygiris where ka='" + veri + "'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    tut = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                    giris.isim = textBox1.Text;
                    giris.soyad = textBox2.Text;
                    giris.ka = textBox3.Text;
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
