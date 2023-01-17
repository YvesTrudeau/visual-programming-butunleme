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
    public partial class idegis : Form
    {
        public idegis()
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
        private void idegis_Load(object sender, EventArgs e)
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

        private void idegis_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa yanasayfa = new yanasayfa();
            yanasayfa.Show();
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
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            tut = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("İLAN BİLGİLERİNİ DEĞİŞTİRMEK İSTEDİĞİNİZE EMİNMİSİNİZ?", "DOĞAN EMLAK", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    conn = new MySqlConnection(giris.con);
                    string sql = "UPDATE ilanlar SET sehir='" + textBox1.Text + "', ilce='" + textBox2.Text + "',adres='" + textBox3.Text + "',oda='" + textBox4.Text + "',durum='" + textBox5.Text + "',konut='" + textBox6.Text + "',metrekare='" + textBox7.Text + "' ,ısınma='" + textBox8.Text + "',kat='" + textBox9.Text + "',yapı='" + textBox10.Text + "',takas='" + textBox11.Text + "',yakıt='" + textBox12.Text + "',fiyat='" + textBox13.Text + "' where adres='" + tut + "'";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("İLAN BİLGİLERİ GÜNCELLENDİ.", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Clear();
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
    }
}
