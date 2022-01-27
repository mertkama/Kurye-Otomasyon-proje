using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuryeOtomasyon.DataAccessLayer;
using KuryeOtomasyon.Model;

namespace KuryeOtomasyon.BLL
{
    public class KuryeBll
    {
        KuryeDal dal = new KuryeDal();


        public int KuryeEkle(KuryeModel kurye)
        {
            return dal.KuryeEkle(kurye);
        }

        public int KuryeGuncelle(KuryeModel kurye)
        {
            return dal.KuryeGuncelle(kurye);
        }

        public int KuryeSil(int kuryeId)
        {
            return dal.KuryeSil(kuryeId);
        }


        public List<KuryeModel> KuryeListele()
        {
            return dal.KuryeListele();
        }

        public KuryeModel KuryeGetir(int id)
        {
            return dal.KuryeGetir(id);
        }

    }
}
