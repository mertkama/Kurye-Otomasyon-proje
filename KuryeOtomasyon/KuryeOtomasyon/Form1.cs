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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GonderiBll gonderiBll = new GonderiBll();
        KuryeBll kuryeBll = new KuryeBll();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvGonderiler.DataSource = gonderiBll.AktifGonderiler();

            cmbKurye.DataSource = kuryeBll.KuryeListele();
            cmbKurye.DisplayMember = "KuryeAd";
            cmbKurye.ValueMember = "KuryeId";

        }
        int gonderiId = 0;
        private void dgvGonderiler_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvGonderiler.SelectedRows)
            {
                gonderiId = Convert.ToInt32(item.Cells[0].Value);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sonuc = gonderiBll.KuryeAta(Convert.ToInt32(cmbKurye.SelectedValue), gonderiId);

            if (sonuc > 0)
                MessageBox.Show("Kurye Atandı");
            else
                MessageBox.Show("Bir hata oluştu.");

            dgvGonderiler.DataSource = gonderiBll.AktifGonderiler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<GonderiModel> gonderiListe = gonderiBll.AktifGonderiler();
            List<KuryeModel> kuryeListesi = kuryeBll.KuryeListele();

            for (int i = 0; i < gonderiListe.Count; i++)
            {
                gonderiBll.KuryeAta(kuryeListesi[i].KuryeId, gonderiListe[i].GonderiId);
            }           

        }
    }
}
