using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Proje
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }

        BaslangicVeritabaniSayfasi.ProjeVeritabani ct = new BaslangicVeritabaniSayfasi.ProjeVeritabani(); // Veritabanına erişmek için 2 tane nesne oluşturuyoruz.
        BaslangicVeritabaniSayfasi.Kullanici kisi = new BaslangicVeritabaniSayfasi.Kullanici();
        BaslangicVeritabaniSayfasi.Admin admin = new BaslangicVeritabaniSayfasi.Admin();
        BaslangicVeritabaniSayfasi.AdminSifre adminsifre = new BaslangicVeritabaniSayfasi.AdminSifre();


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string KullaniciAdi1 = kadibox.Text;
                string Sifre1 = ksifrebox.Text;
                string Ad1 = isimbox.Text;
                string Soyad1 = soyadbox.Text;


                if (checkBox1.Checked == true)
                {
                    if (kadibox.Text != string.Empty && ksifrebox.Text != string.Empty && isimbox.Text != string.Empty && soyadbox.Text != string.Empty && textBox1.Text != string.Empty)
                    {

                        var kontrol = ct.KullaniciTablosu.FirstOrDefault(b => b.KullaniciAdi.Equals(kadibox.Text));
                        var adminkontrol = ct.AdminSifre.FirstOrDefault(c => c.AdminGuvenlik.Equals(textBox1.Text));

                        if (adminkontrol != null)
                        {
                            admin.AdminAd = KullaniciAdi1;
                            admin.AdminSifre = Sifre1;
                            admin.Isim = Ad1;
                            admin.Soyisim = Soyad1;


                            ct.AdminKullanici.Add(admin);
                            ct.SaveChanges();
                            MessageBox.Show("Yetkili Kayıt işleminiz başarıyla tamamlandı. Yetkili kullanıcı adınız: " + KullaniciAdi1);

                            GirisEkrani a = new GirisEkrani();
                            a.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Yetkili kayıtı yapmak için gereken şifreyi yanlış girdiniz!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boş yer bırakmayınız!!!");
                    }
                }
                else
                {
                    if (kadibox.Text != string.Empty && ksifrebox.Text != string.Empty && isimbox.Text != string.Empty && soyadbox.Text != string.Empty)
                    {

                        var kontrol = ct.KullaniciTablosu.FirstOrDefault(b => b.KullaniciAdi.Equals(kadibox.Text));

                        if (kontrol != null)
                        {
                            MessageBox.Show("Bu kullanıcı adı ile kayıt olmuş birisi zaten bulunuyor. Lütfen başka isim alarak tekrar deneyiniz.");
                        }
                        else
                        {
                            kisi.KullaniciAdi = KullaniciAdi1;
                            kisi.KullaniciSifre = Sifre1;
                            kisi.Isim = Ad1;
                            kisi.Soyisim = Soyad1;

                            ct.KullaniciTablosu.Add(kisi);
                            ct.SaveChanges();
                            MessageBox.Show("Kullanıcı kayıt işleminiz başarıyla tamamlandı. Kullanıcı adınız: " + KullaniciAdi1);

                            GirisEkrani a = new GirisEkrani();
                            a.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boş yer bırakmayınız!!!");
                    }
                }



            }
            catch (Exception mesaj)
            {
                MessageBox.Show("Kayıt işleminizi tamamlamada bir hata oluştu." + mesaj);
            }


        }

        private void KayitOl_Load(object sender, EventArgs e)
        {

        }

        private void soyadbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = false;
                textBox1.Clear();
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string Sifre1 = textBox2.Text;

            adminsifre.AdminGuvenlik = Sifre1;
            ct.AdminSifre.Add(adminsifre);
            ct.SaveChanges();
            MessageBox.Show("Admin şifresi belirlendi");

            //1 seferlik admin şifresini mecbur böyle belirlemek zorundayız.

        }
    }
}
