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
    public partial class itumgo : Form
    {
        public itumgo()
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
        private void itumgo_Load(object sender, EventArgs e)
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

            label1.Text = "TOPLAM " + (dataGridView1.RowCount - 1).ToString() + " İLAN VAR";
            label1.Location = new Point((ClientSize.Width / 2) - (label1.Size.Width / 2), 9);
        }

        private void itumgo_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }
    }
}
