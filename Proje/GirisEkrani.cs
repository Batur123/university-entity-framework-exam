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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitOl a = new KayitOl();
            a.Show();
            this.Hide();
        }

        private void SifreGirisEkrani_Load(object sender, EventArgs e)
        {
      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaslangicVeritabaniSayfasi.ProjeVeritabani dc = new BaslangicVeritabaniSayfasi.ProjeVeritabani();

            if (checkBox1.Checked == true)
            {
                try
                {
                    if (kadibox.Text != string.Empty && sifrebox.Text != string.Empty)
                    {
                        
                        var kullanicikontrol = dc.AdminKullanici.FirstOrDefault(a => a.AdminAd.Equals(kadibox.Text));
                        if (kullanicikontrol != null)
                        {
                            if (kullanicikontrol.AdminSifre.Equals(sifrebox.Text))
                            {
                                MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                                AdminAnaMenu ac = new AdminAnaMenu();
                                ac.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir yönetici bulunamadı. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre kutusunu boş bırakmayınız!!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata" + ex);
                }
            }
            else
            {
                try
                {
                    if (kadibox.Text != string.Empty && sifrebox.Text != string.Empty)
                    {
                        //BaslangicVeritabaniSayfasi.ProjeVeritabani dc = new BaslangicVeritabaniSayfasi.ProjeVeritabani();
                        var kullanicikontrol = dc.KullaniciTablosu.FirstOrDefault(a => a.KullaniciAdi.Equals(kadibox.Text));
                        if (kullanicikontrol != null)
                        {
                            if (kullanicikontrol.KullaniciSifre.Equals(sifrebox.Text))
                            {
                                MessageBox.Show("Başarıyla giriş yaptınız!");
                                AnaMenu ac = new AnaMenu();
                                ac.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir kullanıcı bulunamadı. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre kutusunu boş bırakmayınız!!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata" + ex);
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
