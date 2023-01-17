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
    public partial class hesabım : Form
    {
        public hesabım()
        {
            InitializeComponent();
        }

        private void hesabım_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (deger==1)
            {

            }
            else
            {
                yanasayfa y = new yanasayfa();
                y.Show();
            }
            
        }
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        private void hesabım_Load(object sender, EventArgs e)
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
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int deger;
        private void button1_Click(object sender, EventArgs e)
        {
            deger = 1;
            ayarguncelle ay = new ayarguncelle();
            ay.Show();
            this.Close();
            
        }
    }
}
