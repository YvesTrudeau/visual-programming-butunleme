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
    public partial class mdegis : Form
    {
        public mdegis()
        {
            InitializeComponent();
        }



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
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        private void mdegis_Load(object sender, EventArgs e)
        {
            try
            {
                ayar(dataGridView1);
                conn = new MySqlConnection(giris.con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM musteri", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.Columns[0].HeaderText = "İSİM";
            dataGridView1.Columns[1].HeaderText = "SOYİSİM";
            dataGridView1.Columns[2].HeaderText = "KULLANICI ADI";
            dataGridView1.Columns[3].HeaderText = "ŞİFRE";
            dataGridView1.Columns[4].HeaderText = "E-POSTA";
            dataGridView1.Columns[5].HeaderText = "TELEFON NUMARASI";
            dataGridView1.Columns[6].HeaderText = "T.C KİMLİK";
        }

        private void mdegis_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }
        string tut = "";
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tut = dataGridView1.CurrentRow.Cells[6].Value.ToString();
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
            DialogResult result1 = MessageBox.Show("HESAP BİLGİLERİNİ DEĞİŞTİRMEK İSTEDİĞİNİZE EMİNMİSİNİZ?", "DOĞAN EMLAK", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    conn = new MySqlConnection(giris.con);
                    string sql = "UPDATE musteri SET ad='" + textBox1.Text + "', soyad='" + textBox2.Text + "',ka='" + textBox3.Text + "',sf='" + textBox4.Text + "',posta='" + textBox5.Text + "',telefon='" + textBox6.Text + "',tc='" + textBox7.Text + "' where tc='" + tut + "'";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("HESAP BİLGİLERİ GÜNCELLENDİ.", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Clear();
                    conn.Open();
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }
    }
}
