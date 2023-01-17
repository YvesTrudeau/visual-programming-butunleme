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
    public partial class mtumgo : Form
    {
        public mtumgo()
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
        private void mtumgo_Load(object sender, EventArgs e)
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

            label1.Text = "TOPLAM " + (dataGridView1.RowCount - 1).ToString() + " MÜŞTERİ VAR";
            label1.Location = new Point((ClientSize.Width / 2) - (label1.Size.Width / 2), 9);
        }

        private void mtumgo_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa yan = new yanasayfa();
            yan.Show();
        }
    }
}
