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
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();
        }

        KullaniciBll bll = new KullaniciBll();

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            dgvKullanicilar.DataSource = bll.KullaniciListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KullaniciModel kullanici = new KullaniciModel();
            kullanici.KullaniciAdi = txtKullaniciAdi.Text;
            kullanici.Sifre = txtSfire.Text;
            kullanici.YuklenmeTarihi = DateTime.Now;
            kullanici.GuncellenmeTarihi = DateTime.Now;

            string mesaj = bll.KullaniciEkle(kullanici);

            MessageBox.Show(mesaj);

            dgvKullanicilar.DataSource = bll.KullaniciListele();
            KontrolleriBosalt();
        }

        private void dgvKullanicilar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dgvKullanicilar.Rows[e.RowIndex];

           
           string v = row.Cells[0].Value.ToString();
            
        }

        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvKullanicilar.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                KullaniciModel kullanici = bll.KullaniciGetir(id);
                txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                txtSfire.Text = kullanici.Sifre;
                lblId.Text = id.ToString();

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(lblId.Text=="")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz");
                return;
            }


            KullaniciModel kullanici = new KullaniciModel();

            kullanici.KullaniciId = Convert.ToInt32(lblId.Text);
            kullanici.KullaniciAdi = txtKullaniciAdi.Text;
            kullanici.Sifre = txtSfire.Text;
            kullanici.GuncellenmeTarihi = DateTime.Now;

            int sonuc= bll.KullaniciGuncelle(kullanici);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Güncellendi.");
            else
                MessageBox.Show("Güncellenme sırasında bir hata oluştu");

            dgvKullanicilar.DataSource = bll.KullaniciListele();
            KontrolleriBosalt();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (lblId.Text == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz");
                return;
            }

            int id = Convert.ToInt32(lblId.Text);

            int sonuc = bll.KullaniciSil(id);

            if (sonuc > 0)
                MessageBox.Show("Kayıt Silindi.");
            else
                MessageBox.Show("Silme sırasında bir hata oluştu");

            dgvKullanicilar.DataSource = bll.KullaniciListele();
            KontrolleriBosalt();
        }

        public void KontrolleriBosalt()
        {
            txtKullaniciAdi.Clear();
            txtSfire.Clear();
            lblId.Text = "";
        }
    }
}
