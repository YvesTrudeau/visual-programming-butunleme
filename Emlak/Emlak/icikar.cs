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
    public partial class icikar : Form
    {
        public icikar()
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
        private void icikar_Load(object sender, EventArgs e)
        {
            try
            {
                ayar(dataGridView1);
                conn = new MySqlConnection(giris.con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM ilanlar", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.Columns[0].HeaderText = "İL";
            dataGridView1.Columns[1].HeaderText = "İLÇE";
            dataGridView1.Columns[2].HeaderText = "AÇIK ADRES";
            dataGridView1.Columns[3].HeaderText = "ODA SAYISI";
            dataGridView1.Columns[4].HeaderText = "İLAN DURUM";
            dataGridView1.Columns[5].HeaderText = "KONUT ŞEKLİ";
            dataGridView1.Columns[6].HeaderText = "METREKARE(M2)";
            dataGridView1.Columns[1].HeaderText = "ISINMA TİPİ";
            dataGridView1.Columns[2].HeaderText = "KAT SAYISI";
            dataGridView1.Columns[3].HeaderText = "YAPININ DURUMU";
            dataGridView1.Columns[4].HeaderText = "TAKAS";
            dataGridView1.Columns[5].HeaderText = "YAKIT TİPİ";
            dataGridView1.Columns[6].HeaderText = "FİYAT";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("İLANI SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ?", "DOĞAN EMLAK", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    conn = new MySqlConnection(giris.con);
                    string sql = "DELETE FROM ilanlar WHERE adres='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("KAYIT SİLİNDİ", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt = new DataTable();
                    conn.Open();
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar", conn);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                conn.Open();
                if (comboBox1.SelectedItem.ToString() == "İL")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where sehir like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "İLÇE")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where ilce like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "AÇIK ADRES")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where adres like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "ODA SAYISI")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where oda like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "İLAN DURUM")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where durum like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "KONUT ŞEKLİ")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where konut like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "METREKARE")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where metrekare like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "ISINMA TİPİ")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where ısınma like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "KAT SAYISI")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where kat like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "YAPININ DURUMU")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where yapı like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "TAKAS")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where takas like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "YAKIT TİPİ")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where yakıt like '" + textBox1.Text + "%'", conn);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedItem.ToString() == "FİYAT")
                {
                    adapter = new MySqlDataAdapter("SELECT * FROM ilanlar where fiyat like '" + textBox1.Text + "%'", conn);
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
        }

        private void icikar_FormClosed(object sender, FormClosedEventArgs e)
        {
            yanasayfa yanasayfa = new yanasayfa();
            yanasayfa.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
