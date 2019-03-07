using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class AdminAnaMenu : Form
    {
        public AdminAnaMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GirisEkrani a = new GirisEkrani();
            a.Show();
            this.Hide();
        }

        BaslangicVeritabaniSayfasi.ProjeVeritabani ct = new BaslangicVeritabaniSayfasi.ProjeVeritabani(); // Veritabanına erişmek için 2 tane nesne oluşturuyoruz.
        BaslangicVeritabaniSayfasi.StokMiktarlari stok = new BaslangicVeritabaniSayfasi.StokMiktarlari();

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string UrunAd = urunadibox.Text;
                double UrunFiyat = Convert.ToDouble(urunfiyatbox.Text);
                int UrunMiktar = Convert.ToInt32(urunmiktaribox.Text);



                if (urunadibox.Text != string.Empty && urunfiyatbox.Text != string.Empty && urunmiktaribox.Text != string.Empty)
                {

                    var kontrol = ct.StokMiktarlariTablosu.FirstOrDefault(b => b.Adi.Equals(urunadibox.Text));
                    var adminkontrol = ct.AdminSifre.FirstOrDefault(c => c.AdminGuvenlik.Equals(urunadibox.Text));

                    if (kontrol != null)
                    {
                        MessageBox.Show("Bu isimde kayıtlı bir ürün bulunmaktadır.");
                       
                    }
                    else
                    {
                        stok.Adi = UrunAd;
                        stok.KilogramFiyati = UrunFiyat;
                        stok.Miktar = UrunMiktar;


                        ct.StokMiktarlariTablosu.Add(stok);
                        ct.SaveChanges();
                        MessageBox.Show("Ürün ekleme başarıyla tamamlandı.");


                        dataGridView1.Refresh();

                        BaslangicVeritabaniSayfasi.ProjeVeritabani secim = new BaslangicVeritabaniSayfasi.ProjeVeritabani();
                        var urunler = from p in secim.StokMiktarlariTablosu
                                      select new
                                      {
                                          Ürün_Numarası = p.ID,
                                          Ürün_Adı = p.Adi,
                                          Ürün_Miktarı = p.Miktar,
                                          Kilogram_Fiyatı = p.KilogramFiyati

                                      };
                        dataGridView1.DataSource = urunler.ToList();


                    }
                }
                else
                {
                    MessageBox.Show("Boş yer bırakmayınız!!!");
                }
            }
            catch(Exception mesaj)
            {
                MessageBox.Show("Bir hata oluştu. " + mesaj);
            }
        }

        private void AdminAnaMenu_Load(object sender, EventArgs e)
        {
            BaslangicVeritabaniSayfasi.ProjeVeritabani secim = new BaslangicVeritabaniSayfasi.ProjeVeritabani();
            var urunler = from p in secim.StokMiktarlariTablosu
                            select new
                            {
                                Ürün_Numarası = p.ID,
                                Ürün_Adı = p.Adi,
                                Ürün_Miktarı = p.Miktar,
                                Kilogram_Fiyatı = p.KilogramFiyati

                            };

            dataGridView1.DataSource = urunler.ToList();
        }
    }
}