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
    public partial class mcikar : Form
    {
        public mcikar()
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
        private void mcikar_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                dt.Clear();
                conn.Open();
                if (comboBox1.SelectedItem.ToString() == "AD")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where ad like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "SOYAD")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where soyad like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "KULLANICI AD")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where ka like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "ŞİFRE")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where sf like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "E-POSTA")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where posta like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "TELEFON NUMARASI")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where telefon like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "T.C KİMLİK")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM musteri where tc like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("HATA", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            try
            {


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("HESABI SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ?", "DOĞAN EMLAK", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    conn = new MySqlConnection(giris.con);
                    string sql = "DELETE FROM musteri WHERE ad='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("KAYIT SİLİNDİ", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
            }


        }

        private void mcikar_FormClosed(object sender, FormClosedEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
