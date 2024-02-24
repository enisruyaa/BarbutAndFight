using BarbutAndFight.Models;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Oyuncu o1 = new Oyuncu();
        Oyuncu o2 = new Oyuncu();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBahis2.Enabled = false;
            btnZar1.Enabled = false;
            btnZar2.Enabled = false;

            lblBakiye1.Text = o1.Bakiye.ToString();
            lblBakiye2.Text = o2.Bakiye.ToString();
        }

        private void btnBahis1_Click(object sender, EventArgs e)
        {
            if (o1.Bakiye <= 0)
            {
                MessageBox.Show("Bahiyeniz Yetersizdir.");
                Application.Exit();
            }

            else
            {
                o1.Bakiye -= 100;
                btnBahis1.Enabled = false;
                btnBahis2.Enabled = true;
                lblBakiye1.Text = o1.Bakiye.ToString();
                lblBakiye2.Text = o2.Bakiye.ToString();
            }
        }

        private void btnBahis2_Click(object sender, EventArgs e)
        {
            if (o2.Bakiye <= 0)
            {
                MessageBox.Show("Bakiyeniz Yetersizdir.");
                Application.Exit();
            }
            else
            {
                o2.Bakiye -= 100;
                btnZar1.Enabled = true;
                btnBahis2.Enabled = false;
                lblBakiye1.Text = o1.Bakiye.ToString();
                lblBakiye2.Text = o2.Bakiye.ToString();
            }
        }

        private void btnZar1_Click(object sender, EventArgs e)
        {
            lblZar1.Text = o1.ZarSonucuGoster();
            btnZar1.Enabled = false;
            btnZar2.Enabled = true;
            lblBakiye1.Text = o1.Bakiye.ToString();
            lblBakiye2.Text = o2.Bakiye.ToString();
        }

        private void btnZar2_Click(object sender, EventArgs e)
        {
            btnZar2.Enabled = false;
            lblZar2.Text = o2.ZarSonucuGoster();
            if (Convert.ToInt32(lblZar1.Text) > Convert.ToInt32(lblZar2.Text))
            {
                lblSonuc.Text = "1. Oyuncu Kazandı";
                o1.Bakiye += 200;
                if (o1.Bakiye == 0)
                {
                    MessageBox.Show("Oyunu İkinci Oyuncu Kazandı");
                    Application.Exit();
                }
                else
                {
                    btnBahis1.Enabled = true;
                    lblBakiye1.Text = o1.Bakiye.ToString();
                    lblBakiye2.Text = o2.Bakiye.ToString();
                }
            }
            else if (Convert.ToInt32(lblZar1.Text) < Convert.ToInt32(lblZar2.Text))
            {
                lblSonuc.Text = " 2. Oyuncu Kazandı ";
                o2.Bakiye += 200;
                if (o2.Bakiye == 0)
                {
                    MessageBox.Show("Oyunu Birinci Oyuncu Kazandı");
                }
                else
                {
                    btnBahis1.Enabled = true;
                    lblBakiye1.Text = o1.Bakiye.ToString();
                    lblBakiye2.Text = o2.Bakiye.ToString();
                }
            }
            else
            {
                lblSonuc.Text = " Durum Berabere Olduğu için Lütfen Tekrar Zar Atınız ";
                btnZar1.Enabled = true;
                lblBakiye1.Text = o1.Bakiye.ToString();
                lblBakiye2.Text = o2.Bakiye.ToString();
            }
        }
    }
}
