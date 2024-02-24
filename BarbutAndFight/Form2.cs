using BarbutAndFight.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarbutAndFight
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SonucYazdir()
        {
            if (d.Can == 0)
            {
                MessageBox.Show("Oyunu Kaybettiniz");
                Application.Exit();
            }
            else if (d.Can <= 0 && b.Can <= 0)
            {
                MessageBox.Show("Bu Dünya Kimsye Kalmadı");
                Application.Exit();
            }
        }
        Dovuscu d = new Dovuscu();
        Bilgisayar b = new Bilgisayar();

        private void Form2_Load(object sender, EventArgs e)
        {
            lblOyuncuCani.Text = $" {d.Can} ";
            lblPcCani.Text = $" {b.Can} ";
            lblLevel1.Text = d.Level.ToString();
            lblLevel2.Text = b.Level.ToString();
        }

        public int BilgisayarKaybederseUygula(int ns)
        {
            if (b.Can <= 0)
            {
                d.OzelGucHak = 3;
                btnOzelSaldiri.Enabled = true;
                b.Level++;
                b.Can = 80 + b.Level;
                d.Can = 100;
                d.Level++;
                lblLevel1.Text = d.Level.ToString();
                lblOyuncuCani.Text = d.Can.ToString();
                lblPcCani.Text = b.Can.ToString();
                lblLevel2.Text = b.Level.ToString();
                if (d.Level > 1)
                {
                    ns += d.Level;
                }
            }

            return ns;
        }

        private void btnNormalSaldiri_Click(object sender, EventArgs e)
        {
            int ns = Convert.ToInt32(d.NormalVurus.Next(1, 11));
            int pcs = Convert.ToInt32(d.NormalVurus.Next(1, 11));
            b.Can -= ns;
            d.Can -= pcs;
            lblOyuncuCani.Text = d.Can.ToString();
            lblPcCani.Text = b.Can.ToString();
            SonucYazdir();
            BilgisayarKaybederseUygula(ns);
        }

        private void btnOzelSaldiri_Click(object sender, EventArgs e)
        {
            int ns = Convert.ToInt32(d.NormalVurus.Next(1, 11));
            int pcs = Convert.ToInt32(d.NormalVurus.Next(1, 11));
            d.OzelGucHak--;
            d.Can -= pcs;
            b.Can -= d.OzelVurus;
            lblOyuncuCani.Text = d.Can.ToString();
            lblPcCani.Text = b.Can.ToString();
            if (d.OzelGucHak == 0) btnOzelSaldiri.Enabled = false;
            else if (b.Level > 4) d.Can -= d.OzelVurus;
            else BilgisayarKaybederseUygula(ns);
            SonucYazdir();
        }
    }
}
