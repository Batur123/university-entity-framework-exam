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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void AnaMenu_Load(object sender, EventArgs e)
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
