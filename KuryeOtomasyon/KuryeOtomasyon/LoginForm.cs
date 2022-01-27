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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        KullaniciBll kullaniciBll = new KullaniciBll();

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciModel kullanici = kullaniciBll.Giris(txtAd.Text, txtSifre.Text);
            if (kullanici.KullaniciAdi != null)
            {
                MenuForm frm = new MenuForm();
                frm.Show();                
            }
            else
                MessageBox.Show("Giriş Bilgileri Hatalı");
        }
    }
}
