using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KuryeOtomasyon.BLL;
using KuryeOtomasyon.Model;

namespace KuryeOtomasyon
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        MusteriBll bll = new MusteriBll();

        private void Musteri_Load(object sender, EventArgs e)
        {
            dgvMusteriler.DataSource = bll.MusteriListele();         
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvMusteriler.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                MusteriModel musteri = bll.MusteriGetir(id);
                txtMusteriAd.Text = musteri.MusteriAd;
                txtMusteriSoyad.Text = musteri.MusteriSoyad;
                txtAdres.Text = musteri.Adres;
                txtTelefon.Text = musteri.Telefon;
                cbOzelMusteri.Checked = musteri.OzelMusteri;
                lblId.Text = id.ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MusteriModel musteri = new MusteriModel();
            musteri.Adres = txtAdres.Text;
            musteri.GuncellenmeTarihi = DateTime.Now;
            musteri.MusteriAd = txtMusteriAd.Text;
            musteri.MusteriSoyad = txtMusteriSoyad.Text;
            musteri.OzelMusteri = cbOzelMusteri.Checked;
            musteri.Telefon = txtTelefon.Text;
            musteri.YuklenmeTarihi = DateTime.Now;


            int sonuc = bll.MusteriEkle(musteri);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Eklendi");
            else
                MessageBox.Show("Bir hata oluştu");


            dgvMusteriler.DataSource = bll.MusteriListele();
            KontrolleriBosalt();
        }

        public void KontrolleriBosalt()
        {
            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            cbOzelMusteri.Checked = false;
            lblId.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            MusteriModel musteri = new MusteriModel();
            musteri.Adres = txtAdres.Text;
            musteri.GuncellenmeTarihi = DateTime.Now;
            musteri.MusteriAd = txtMusteriAd.Text;
            musteri.MusteriSoyad = txtMusteriSoyad.Text;
            musteri.OzelMusteri = cbOzelMusteri.Checked;
            musteri.Telefon = txtTelefon.Text;
            musteri.YuklenmeTarihi = DateTime.Now;
            musteri.MusteriId = Convert.ToInt32(lblId.Text);


            int sonuc = bll.MusteriGuncelle(musteri);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Güncellendi.");
            else
                MessageBox.Show("Bir hata oluştu");


            dgvMusteriler.DataSource = bll.MusteriListele();
            KontrolleriBosalt();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);


            int sonuc = bll.MusteriSil(id);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Silindi.");
            else
                MessageBox.Show("Bir hata oluştu");


            dgvMusteriler.DataSource = bll.MusteriListele();
            KontrolleriBosalt();
        }
    }
}
