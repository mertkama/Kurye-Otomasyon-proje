using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeOtomasyon
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnKurye_Click(object sender, EventArgs e)
        {
            Kurye kurye = new Kurye();
            kurye.Show();
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();
            siparis.Show();
        }

        private void btnGonderi_Click(object sender, EventArgs e)
        {
            Gonderiler gonderiler = new Gonderiler();
            gonderiler.Show();
        }

        private void btnGonderiGecmisi_Click(object sender, EventArgs e)
        {
            GonderiGecmisleri gonderiGecmisleri = new GonderiGecmisleri();
            gonderiGecmisleri.Show();
        }

        private void btnGonderiAta_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            KullaniciForm kullanici = new KullaniciForm();
            kullanici.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Close();
        }
    }
}
