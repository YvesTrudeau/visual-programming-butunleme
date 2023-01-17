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
    public partial class yanasayfa : Form
    {
        public yanasayfa()
        {
            InitializeComponent();
        }

        private void anasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void mÜŞTERİLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        DataTable dt;
        private void anasayfa_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((ClientSize.Width / 2) - (label1.Size.Width / 2), label1.Location.Y);
            try
            {
                conn = new MySqlConnection(giris.con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT ad,soyad FROM ygiris where ka='"+giris.ad.ToString()+"'", conn);
                adapter.Fill(dt);
                conn.Close();
                dataGridView1.DataSource = dt;
                if (giris.deg==0)
                {
                    aDSOYADToolStripMenuItem.Text = dataGridView1.Rows[0].Cells[0].Value.ToString().ToUpper() + " " + dataGridView1.Rows[0].Cells[1].Value.ToString().ToUpper();
                }
                else
                {
                    aDSOYADToolStripMenuItem.Text = giris.isim.ToUpper() + " " + giris.soyad.ToUpper();
                }
                
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void yÖNETİCİYAPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hAKKIMIZDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris g = new giris();
            g.Show();
            this.Close();
        }

        private void eKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mekle m = new mekle();
            m.Show();
            this.Hide();
        }

        private void çIKARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mcikar m = new mcikar();
            m.Show();
            this.Hide();
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdegis m = new mdegis();
            m.Show();
            this.Hide();
        }

        private void tÜMÜNÜGÖRÜNTÜLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mtumgo m = new mtumgo();
            m.Show();
            this.Hide();
        }

        private void iLANDAKİEVLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iekle i = new iekle();
            i.Show();
            this.Hide();
        }

        private void iLANAKOYULCAKEVLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            icikar icikar = new icikar();
            icikar.Show();
            this.Hide();
        }

        private void iLANÇIKARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idegis i = new idegis();
            i.Show();
            this.Hide();
        }

        private void tÜMÜNÜGÖRÜNTÜLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            itumgo itumgo = new itumgo();
            itumgo.Show();
            this.Hide();
        }

        private void hESAPAYARLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hesabım h = new hesabım();
            h.Show();
            this.Hide();
        }

        private void yETKİVERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yetki y = new yetki();
            y.Show();
            this.Hide();
        }

        private void bİLGİLERİMİGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ayarguncelle ay = new ayarguncelle();
            ay.Show();
            this.Hide();

        }

        private void çIKIŞYAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkımızda hk = new hakkımızda();
            hk.Show();
            this.Hide();
        }
    }
}
