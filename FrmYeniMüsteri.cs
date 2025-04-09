using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Aycicegi_Pansiyon_ve_Dinlenme_Tesisleri
{
    public partial class FrmYeniMüsteri : Form
    {
        public FrmYeniMüsteri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-TDD49L4N\\SQLEXPRESS;Initial Catalog=AycicegiPansiyon;Integrated Security=True");

        // cift \\ yada @ isareti ile bir baglanti yolu oldugunu gösteririz
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnOda101_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "101";
        }

        private void BtnOda102_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "102";
        }

        private void BtnOda103_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "103";
        }

        private void BtnOda104_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "104";
        }

        private void BtnOda105_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "105";
        }

        private void BtnOda106_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "106";
        }

        private void BtnOda107_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "107";
        }

        private void BtnOda108_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "108";
        }

        private void BtnOda109_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "109";
        }

        private void BtnDoluOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rote Tasten zeigen belegte Räume an.");
        }

        private void BtnBosOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grüne Tasten zeigen leere Räume an.");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int Ucret;
            DateTime KucukTarih = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime BuyukTarih = Convert.ToDateTime(DtpCikisTarihi.Text);

            TimeSpan Sonuc = BuyukTarih - KucukTarih;

            label11.Text = Sonuc.TotalDays.ToString();

            Ucret = Convert.ToInt32(label11.Text) * 50;
            TxtUcret.Text = Ucret.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            /*
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into MusteriEkle (Adi,Soyadi,Cinsiyet) values ( ' " + TxtAdi.Text + " ' , ' " + TxtSoyadi.Text + " ' , ' " + comboBox1.Text + " ' )", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Die Kundenregistrierung ist abgeschlossen.");*/

            // , '" + MskTxtTelefon.Text + "','" + TxtMail.Text + "', '" + TxtKimlikNo.Text + "', '" + TxtOdaNo.Text + "', '" + TxtUcret.Text + "', '" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "', '" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "'



            /*PLAN B*/
            /*
            SqlCommand komut = new SqlCommand("INSERT INTO MusteriEkle (Adi, Soyadi, Cinsiyet) VALUES (@Adi, @Soyadi, @Cinsiyet)", baglanti);
            komut.Parameters.AddWithValue("@Adi", TxtAdi.Text);
            komut.Parameters.AddWithValue("@Soyadi", TxtSoyadi.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
            */

            /* PLAN C*/

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO MusteriEkle4 (Adi, Soyadi, Cinsiyet, Telefon, Mail, TC, OdaNo, Ucret, GirisTarihi, CikisTarihi) VALUES (@Adi, @Soyadi, @Cinsiyet, @Telefon, @Mail, @TC, @OdaNo, @Ucret, @GirisTarihi, @CikisTarihi)", baglanti);
                komut.Parameters.AddWithValue("@Adi", TxtAdi.Text);
                komut.Parameters.AddWithValue("@Soyadi", TxtSoyadi.Text);
                komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
                komut.Parameters.AddWithValue("@Telefon", MskTxtTelefon.Text);
                komut.Parameters.AddWithValue("@Mail", TxtMail.Text);
                komut.Parameters.AddWithValue("@TC", TxtKimlikNo.Text);
                komut.Parameters.AddWithValue("@OdaNo", TxtOdaNo.Text);
                komut.Parameters.AddWithValue("@Ucret", TxtUcret.Text);
                komut.Parameters.AddWithValue("@GirisTarihi", DtpGirisTarihi.Value.ToString("yyyy-MM-dd"));
                komut.Parameters.AddWithValue("@CikisTarihi", DtpCikisTarihi.Value.ToString("yyyy-MM-dd"));


                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Die Kundenregistrierung ist abgeschlossen.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Error: " + ex.Message);
                
            }


        }

        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            // oda 101
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from Oda101", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda101.Text = oku1["Adi"].ToString() + " " + oku1["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda101.Text != "101")
            {
                BtnOda101.BackColor = Color.Red;
                BtnOda101.Enabled = false;
            }

            ///// oda 102

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Oda102", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                BtnOda102.Text = oku2["Adi"].ToString() + " " + oku2["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda102.Text != "102")
            {
                BtnOda102.BackColor = Color.Red;
                BtnOda102.Enabled = false;
            }

            // oda 103
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from Oda103", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                BtnOda103.Text = oku3["Adi"].ToString() + " " + oku3["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda103.Text != "103")
            {
                BtnOda103.BackColor = Color.Red;
                BtnOda103.Enabled = false;
            }

            // oda 104
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from Oda104", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();

            while (oku4.Read())
            {
                BtnOda104.Text = oku4["Adi"].ToString() + " " + oku4["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda104.Text != "104")
            {
                BtnOda104.BackColor = Color.Red;
                BtnOda104.Enabled = false;
            }

            // oda 105
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from Oda105", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();

            while (oku5.Read())
            {
                BtnOda105.Text = oku5["Adi"].ToString() + " " + oku5["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda105.Text != "105")
            {
                BtnOda105.BackColor = Color.Red;
                BtnOda105.Enabled = false;
            }

            // oda 106
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from Oda106", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku6.Read())
            {
                BtnOda106.Text = oku6["Adi"].ToString() + " " + oku6["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda106.Text != "106")
            {
                BtnOda106.BackColor = Color.Red;
                BtnOda106.Enabled = false;
            }

            // oda 107
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select * from Oda107", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();

            while (oku7.Read())
            {
                BtnOda107.Text = oku7["Adi"].ToString() + " " + oku7["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda107.Text != "107")
            {
                BtnOda107.BackColor = Color.Red;
                BtnOda107.Enabled = false;
            }

            //oda 108
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("Select * from Oda108", baglanti);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku8.Read())
            {
                BtnOda108.Text = oku8["Adi"].ToString() + " " + oku8["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda108.Text != "108")
            {
                BtnOda108.BackColor = Color.Red;
                BtnOda108.Enabled = false;
            }

            // oda 109
            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("Select * from Oda109", baglanti);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku9.Read())
            {
                BtnOda109.Text = oku9["Adi"].ToString() + " " + oku9["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda109.Text != "109")
            {
                BtnOda109.BackColor = Color.Red;
                BtnOda109.Enabled = false;
            }

        }

        private void TxtKimlikNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmYeniMüsteri_Load(object sender, EventArgs e)
        {
            // ODA 101
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda101.Text = oku1["Adi"].ToString() + " " + oku1["Soyadi"].ToString();
            }

            baglanti.Close();

            if (BtnOda101.Text != "101")
            {
                BtnOda101.BackColor = Color.Red;
                BtnOda101.Enabled = false;
            }

            ///// oda 102

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Oda102", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                BtnOda102.Text = oku2["Adi"].ToString() + " " + oku2["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda102.Text != "102")
            {
                BtnOda102.BackColor = Color.Red;
                BtnOda102.Enabled = false;
            }

            // oda 103
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from Oda103", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                BtnOda103.Text = oku3["Adi"].ToString() + " " + oku3["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda103.Text != "103")
            {
                BtnOda103.BackColor = Color.Red;
                BtnOda103.Enabled = false;
            }

            // oda 104
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from Oda104", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();

            while (oku4.Read())
            {
                BtnOda104.Text = oku4["Adi"].ToString() + " " + oku4["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda104.Text != "104")
            {
                BtnOda104.BackColor = Color.Red;
                BtnOda104.Enabled = false;
            }

            // oda 105
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from Oda105", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();

            while (oku5.Read())
            {
                BtnOda105.Text = oku5["Adi"].ToString() + " " + oku5["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda105.Text != "105")
            {
                BtnOda105.BackColor = Color.Red;
                BtnOda105.Enabled = false;
            }

            // oda 106
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from Oda106", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku6.Read())
            {
                BtnOda106.Text = oku6["Adi"].ToString() + " " + oku6["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda106.Text != "106")
            {
                BtnOda106.BackColor = Color.Red;
                BtnOda106.Enabled = false;
            }

            // oda 107
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select * from Oda107", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();

            while (oku7.Read())
            {
                BtnOda107.Text = oku7["Adi"].ToString() + " " + oku7["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda107.Text != "107")
            {
                BtnOda107.BackColor = Color.Red;
                BtnOda107.Enabled = false;
            }

            //oda 108
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("Select * from Oda108", baglanti);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku8.Read())
            {
                BtnOda108.Text = oku8["Adi"].ToString() + " " + oku8["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda108.Text != "108")
            {
                BtnOda108.BackColor = Color.Red;
                BtnOda108.Enabled = false;


            }

            // oda 109
            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("Select * from Oda109", baglanti);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku9.Read())
            {
                BtnOda109.Text = oku9["Adi"].ToString() + " " + oku9["Soyadi"].ToString();
            }
            baglanti.Close();

            if (BtnOda109.Text != "109")
            {
                BtnOda109.BackColor = Color.Red;
                BtnOda109.Enabled = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void MskTxtTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtUcret_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtOdaNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSoyadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
// Data Source=LAPTOP-TDD49L4N\SQLEXPRESS;Initial Catalog=AycicegiPansiyon;Integrated Security=True