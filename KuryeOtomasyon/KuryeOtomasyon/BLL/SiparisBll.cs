using KuryeOtomasyon.DataAccessLayer;
using KuryeOtomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.BLL
{
    public class SiparisBll
    {
        SiparisDal dal = new SiparisDal();

        public int SiparisEkle(SiparisModel siparis)
        {
            return dal.SiparisEkle(siparis);
        }

        public int SiparisGuncelle(SiparisModel siparis)
        {
            return dal.SiparisGuncelle(siparis);
        }

        public int SiparisSil(int id)
        {
            return dal.SiparisSil(id);
        }

        public List<SiparisModel> SiparisListele()
        {
            return dal.SiparisListele();
        }

        public SiparisModel SiparisGetir(int id)
        {
            return dal.SiparisGetir(id);
        }
    }
}
