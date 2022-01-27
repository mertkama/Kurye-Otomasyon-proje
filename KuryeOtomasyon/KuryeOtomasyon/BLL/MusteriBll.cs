using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuryeOtomasyon.DataAccessLayer;
using KuryeOtomasyon.Model;

namespace KuryeOtomasyon.BLL
{
    public class MusteriBll
    {
        MusteriDal dal = new MusteriDal();

        public int MusteriEkle(MusteriModel musteri)
        {
            return dal.MusteriEkle(musteri);
        }

        public int MusteriGuncelle(MusteriModel musteri)
        {
            return dal.MusteriGuncelle(musteri);
        }

        public int MusteriSil(int id)
        {
            return dal.MusteriSil(id);
        }

        public List<MusteriModel> MusteriListele()
        {
            return dal.MusteriListele();
        }

        public MusteriModel MusteriGetir(int id)
        {
            return dal.MusteriGetir(id);
        }
    }
}
