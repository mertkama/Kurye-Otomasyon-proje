using KuryeOtomasyon.Model;
using KuryeOtomasyon.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.BLL
{
    public class KullaniciBll
    {
        KullaniciDal dal = new KullaniciDal();

        public string KullaniciEkle(KullaniciModel kullanici)
        {
            if(dal.KullaniciAdiKontrol(kullanici.KullaniciAdi))
            {               
                int sonuc = dal.KullaniciEkle(kullanici);

                if (sonuc > 0)
                    return "Kaydetme Başarılı";
                else
                    return "Kaydetme sırasında bir hata oluştu.";
            }
            else
            {
                return "Kullanıcı Adı sistemde Kayıtlı. Başka bir kullanıcı adı giriniz .";
            }

        }


        public KullaniciModel Giris(string kullaniciAdi,string sifre)
        {
            return dal.Giris(kullaniciAdi, sifre);
        }

        public KullaniciModel KullaniciGetir(int id)
        {
            return dal.KullaniciGetir(id);
        }

        public List<KullaniciModel> KullaniciListele()
        {
            return dal.KullaniciListele();
        }

        public int KullaniciSil(int id)
        {
            return dal.KullaniciSil(id);
        }

        public int KullaniciGuncelle(KullaniciModel kullanici)
        {
            return dal.KullaniciGuncelle(kullanici);
        }

        //public int KullaniciEkle(KullaniciModel kullanici)
        //{
        //    return dal.KullaniciEkle(kullanici);
        //}
    }
}
