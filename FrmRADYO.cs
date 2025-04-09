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
    public partial class FrmRADYO : Form
    {
        public FrmRADYO()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wmp.URL = "https://liveradio.swr.de/sw282p3/swr1bw/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wmp.URL = "http://kralwmp.radyotvonline.com/";
        }
    }
}
