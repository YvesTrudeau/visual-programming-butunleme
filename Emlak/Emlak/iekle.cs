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
    public partial class iekle : Form
    {
        public iekle()
        {
            InitializeComponent();
        }

        private void iekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUNUZ", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MySqlConnection baglan = new MySqlConnection(giris.con);
                    string sorgu = "Insert into ilanlar values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("İLAN BAŞARYILA KAYDEDİLDİ", "DOĞAN EMLAK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
