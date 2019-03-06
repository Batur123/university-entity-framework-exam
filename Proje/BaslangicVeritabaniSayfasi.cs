using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class BaslangicVeritabaniSayfasi : Form
    {
        public BaslangicVeritabaniSayfasi()
        {
            InitializeComponent();
        }

        public class Kullanici
        {
            public int ID { get; set; }
            public string KullaniciAdi { get; set; }
            public string KullaniciSifre { get; set; }
            public string Isim { get; set; }
            public string Soyisim { get; set; }            

        }

        public class Admin
        {
            public int ID { get; set; }
            public string AdminAd { get; set; }
            public string AdminSifre { get; set; }
            public string Isim { get; set; }
            public string Soyisim { get; set; }
        }
        public class AdminSifre
        {
            public int ID { get; set; }
            public string AdminGuvenlik { get; set; }
        }

        public class StokMiktarlari
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public int Miktar { get; set; }
            public int KilogramFiyati { get; set; }
            public string ResimURL { get; set; }
        }


        public class ProjeVeritabani : DbContext
        {
            public DbSet<Kullanici> KullaniciTablosu { get; set; }
            public DbSet<StokMiktarlari> StokMiktarlariTablosu { get; set; }
            public DbSet<Admin> AdminKullanici { get; set; }
            public DbSet<AdminSifre> AdminSifre { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;
            timer1.Interval = 5000;
            timer1.Start();
 



        }

        private void createdatabase()
        {

            try
            {
                ProjeVeritabani Veri = new ProjeVeritabani();
                Veri.Database.Create();

                MessageBox.Show("Veritabanımız başarıyla oluşturuldu.");
                GirisEkrani ac = new GirisEkrani();
                ac.Show();
                this.Hide();
            }
            catch (Exception mesaj)
            {
                MessageBox.Show("Bir hata oluştu" + mesaj);
            }
        }

        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 1)
            {
                createdatabase();

                timer1.Stop();
               
            }
        }
    }
}
