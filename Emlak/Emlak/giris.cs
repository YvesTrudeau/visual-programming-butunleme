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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void giris_Load(object sender, EventArgs e)
        {
        }
        public static int deg = 0;
        public static string con = "Server=localhost;Database=emlaks;Uid=root;Pwd='';";
        public static string isim, soyad, ka;

        public static string ad;
        kontrol gkontrol = new kontrol();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("KULLANICI ADI VE ŞİFRENİZİ GİRİNİZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                MessageBox.Show("ŞİFRENİZİ GİRİNİZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox2.Focus();
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("KULLANICI ADI GİRİNİZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
            else
            {
                if (gkontrol.giris(textBox1.Text, textBox2.Text) == 1)
                {
                    MessageBox.Show("YÖNETİCİ GİRİŞİ BAŞARILI", "GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ad = textBox1.Text;
                    yanasayfa an = new yanasayfa();
                    an.Show();
                    this.Hide();
                }
                /* else if (gkontrol.giris(textBox1.Text, textBox2.Text) == 2)
                 {
                     MessageBox.Show("BAŞARILI GİRİŞ", "GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     ad = textBox1.Text;
                 }*/
                else
                {
                    MessageBox.Show("GİRİŞ BAŞARISIZ LÜTFEN \nHESAP BİLGİLERİNİ KONTROL EDİNİZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /* }
             catch
             {
                 MessageBox.Show("LÜTFEN TEKRAR DENEYİNİZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 textBox1.Text = "";
                 textBox2.Text = "";
                 textBox1.Focus();
             }*/



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
