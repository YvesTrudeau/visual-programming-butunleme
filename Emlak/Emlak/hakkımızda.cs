using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class hakkımızda : Form
    {
        public hakkımızda()
        {
            InitializeComponent();
        }

        private void hakkımızda_FormClosing(object sender, FormClosingEventArgs e)
        {
            yanasayfa y = new yanasayfa();
            y.Show();
        }

        private void hakkımızda_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((ClientSize.Width / 2) - (label1.Size.Width / 2), label1.Location.Y);
            label2.Location = new Point((ClientSize.Width / 2) - (label2.Size.Width / 2), label2.Location.Y);
            label3.Location = new Point((ClientSize.Width / 2) - (label3.Size.Width / 2), label3.Location.Y);
            label4.Location = new Point((ClientSize.Width / 2) - (label4.Size.Width / 2), label4.Location.Y);
            label5.Location = new Point((ClientSize.Width / 2) - (label5.Size.Width / 2), label5.Location.Y);
        }
    }
}
