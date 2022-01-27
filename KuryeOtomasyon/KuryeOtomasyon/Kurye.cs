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
    public partial class Kurye : Form
    {
        public Kurye()
        {
            InitializeComponent();
        }

        KuryeBll bll = new KuryeBll();

        private void Kurye_Load(object sender, EventArgs e)
        {
            dgvKurye.DataSource = bll.KuryeListele();
            dtpDogumTarihi.Value = DateTime.Now;
            dtpEhliyetTarihi.Value = DateTime.Now;
        }

        private void dgvKuryeler_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvKurye.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                KuryeModel kurye = bll.KuryeGetir(id);
                txtAd.Text = kurye.KuryeAd;
                txtKuryeSoyad.Text = kurye.KuryeSoyad;
                dtpDogumTarihi.Value = kurye.DogumTarihi;
                dtpEhliyetTarihi.Value = kurye.EhliyetTarihi;
                lblId.Text = id.ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KuryeModel kurye = new KuryeModel();
            kurye.DogumTarihi = dtpDogumTarihi.Value;
            kurye.EhliyetTarihi = dtpEhliyetTarihi.Value;
            kurye.GuncellenmeTarihi = DateTime.Now;
            kurye.KuryeAd = txtAd.Text;
            kurye.KuryeSoyad = txtKuryeSoyad.Text;
            kurye.YuklenmeTarihi = DateTime.Now;

            int sonuc = bll.KuryeEkle(kurye);

            if (sonuc > 0)
                MessageBox.Show("Kurye Kaydedildi");
            else
                MessageBox.Show("Bir hata oluştu");

            dgvKurye.DataSource = bll.KuryeListele();
            KontrolleriBosalt();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(lblId.Text=="")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz");
                return;
            }

            KuryeModel kurye = new KuryeModel();

            kurye.DogumTarihi= dtpDogumTarihi.Value;
            kurye.EhliyetTarihi = dtpEhliyetTarihi.Value;
            kurye.GuncellenmeTarihi = DateTime.Now;
            kurye.KuryeAd = txtKuryeAdi.Text;
            kurye.KuryeSoyad = txtSoyad.Text;
            kurye.KuryeId = Convert.ToInt32(lblId.Text);


            int sonuc = bll.KuryeGuncelle(kurye);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Güncellendi");
            else
                MessageBox.Show("Bir hata oluştu.");

            dgvKurye.DataSource = bll.KuryeListele();
            KontrolleriBosalt();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);

            int sonuc = bll.KuryeSil(id);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Silindi");
            else
                MessageBox.Show("Bir hata oluştu.");

            dgvKurye.DataSource = bll.KuryeListele();
            KontrolleriBosalt();
        }

        public void KontrolleriBosalt()
        {
            dtpDogumTarihi.Value = DateTime.Now;
            dtpEhliyetTarihi.Value = DateTime.Now;
            txtKuryeAdi.Clear();
            txtSoyad.Clear();
            lblId.Text = "";
        }

        private void dgvKurye_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvKurye.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                KuryeModel kurye = bll.KuryeGetir(id);
                txtKuryeAdi.Text = kurye.KuryeAd;
                txtSoyad.Text = kurye.KuryeSoyad;
                dtpDogumTarihi.Value = kurye.DogumTarihi;
                dtpEhliyetTarihi.Value = kurye.EhliyetTarihi;
                lblId.Text = id.ToString();
            }
        }
    }
}
