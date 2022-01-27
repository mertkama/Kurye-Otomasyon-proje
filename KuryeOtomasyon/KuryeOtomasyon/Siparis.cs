using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using KuryeOtomasyon.BLL;
using KuryeOtomasyon.Model;

namespace KuryeOtomasyon
{
    public partial class Siparis : Form
    {
        public Siparis()
        {
            InitializeComponent();
        }

        MusteriBll musteriBll = new MusteriBll();
        SiparisBll siparisBll = new SiparisBll();
        GonderiBll gonderiBll = new GonderiBll();

        private void Siparis_Load(object sender, EventArgs e)
        {
            cmbMusteri.DataSource = musteriBll.MusteriListele();
            cmbMusteri.DisplayMember = "MusteriAd";
            cmbMusteri.ValueMember = "MusteriId";

            List<SiparisDurum> durumlar = new List<SiparisDurum>();

            durumlar.Add(new SiparisDurum {
                Text="Yeni Sipariş",
                Value=0
            });
            durumlar.Add(new SiparisDurum
            {
                Text = "Gönderi Oluşturuldu",
                Value = 1
            });

            durumlar.Add(new SiparisDurum
            {
                Text = "Sipariş Tamamlandı",
                Value = 2
            });

            cmbSiparisDurumu.DataSource = durumlar;
            cmbSiparisDurumu.DisplayMember = "Text";
            cmbSiparisDurumu.ValueMember = "Value";


            dgvSiparisler.DataSource = siparisBll.SiparisListele();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SiparisModel siparis = new SiparisModel();
            siparis.Agirlik = Convert.ToDouble(txtAgirlik.Text);
            siparis.Fiyat = Convert.ToDouble(txtAgirlik.Text);
            siparis.GonderiAdresi = txtAdres.Text;
            siparis.GuncellenmeTarihi = DateTime.Now;
            siparis.MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue);
            siparis.PaketAciklama = txtAciklama.Text;
            siparis.SiparisDurumu = Convert.ToInt32(cmbSiparisDurumu.SelectedValue);
            siparis.YuklenmeTarihi = DateTime.Now;

            int sonuc = siparisBll.SiparisEkle(siparis);

            if (sonuc > 0)
                MessageBox.Show("İşlem kaydedildi.");
            else
                MessageBox.Show("Bir hata oluştu");

            dgvSiparisler.DataSource = siparisBll.SiparisListele();
        }

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvSiparisler.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                SiparisModel siparis = siparisBll.SiparisGetir(id);
                cmbMusteri.SelectedValue = siparis.MusteriId;
                txtAciklama.Text = siparis.PaketAciklama;
                txtAgirlik.Text=siparis.Agirlik.ToString();
                txtFiyat.Text = siparis.Fiyat.ToString();
                txtAdres.Text = siparis.GonderiAdresi;
                cmbSiparisDurumu.SelectedValue = siparis.SiparisDurumu;
                lblId.Text = id.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(lblId.Text=="")
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz");
                return;
            }


            SiparisModel siparis = new SiparisModel();
            siparis.Agirlik = Convert.ToDouble(txtAgirlik.Text);
            siparis.Fiyat = Convert.ToDouble(txtFiyat.Text);
            siparis.GonderiAdresi = txtAdres.Text;
            siparis.GuncellenmeTarihi = DateTime.Now;
            siparis.MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue);
            siparis.PaketAciklama = txtAciklama.Text;
            siparis.SiparisDurumu = Convert.ToInt32(cmbSiparisDurumu.SelectedValue);
            siparis.SiparisId = Convert.ToInt32(lblId.Text);

            int sonuc = siparisBll.SiparisGuncelle(siparis);

            if (siparis.SiparisDurumu == 1)
                GonderiKaydet(siparis.SiparisId);


            if (sonuc > 0)
                MessageBox.Show("İşlem Güncellendi");
            else
                MessageBox.Show("Bir hata oluştu");


            dgvSiparisler.DataSource = siparisBll.SiparisListele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "")
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz");
                return;
            }

            int id = Convert.ToInt32(lblId.Text);

            int sonuc = siparisBll.SiparisSil(id);

            if (sonuc > 0)
                MessageBox.Show("İşlem Silindi");
            else
                MessageBox.Show("Bir hata oluştu");


            dgvSiparisler.DataSource = siparisBll.SiparisListele();
        }

        private void GonderiKaydet(int siparisId)
        {
            Model.Gonderiler gonderi = new Model.Gonderiler();
            gonderi.Durum = 0;
            gonderi.GuncellenmeTarihi = DateTime.Now;
            gonderi.KuryeId = 0;
            gonderi.SiparisId = siparisId;
            gonderi.YuklenmeTarihi = DateTime.Now;

            gonderiBll.GonderiEkle(gonderi);
        }
    }
}
