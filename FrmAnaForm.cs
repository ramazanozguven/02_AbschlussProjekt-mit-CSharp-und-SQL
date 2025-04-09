using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aycicegi_Pansiyon_ve_Dinlenme_Tesisleri
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdminGiris fr = new FrmAdminGiris();
            fr.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmYeniMüsteri fr = new FrmYeniMüsteri();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmOdalar fr = new FrmOdalar();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMusteriler fr = new FrmMusteriler();
            fr.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Das Sonnenblumen Hotel bedient Sie seit 1980 und unser oberstes Ziel ist die Zufriedenheit aller Kunden.       Die Kundenregistrierungssoftware für das Sonnenblumen Hotel wurde am 01.06.2023 von Herrn Özgüven erstellt.");
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmGazeteler fr = new FrmGazeteler();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            FrmRADYO fr = new FrmRADYO();
            fr.Show();
        }
    }
}
