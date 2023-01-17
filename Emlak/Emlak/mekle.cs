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
    public partial class mekle : Form
    {
        public mekle()
        {
            InitializeComponent();
        }

        private void mekle_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUNUZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MySqlConnection baglan = new MySqlConnection(giris.con);
                    string sorgu = "Insert into musteri values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("MÜŞTERİ HESABI AÇILDI", "MÜŞTERİ EKLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void mekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }
    }
}
