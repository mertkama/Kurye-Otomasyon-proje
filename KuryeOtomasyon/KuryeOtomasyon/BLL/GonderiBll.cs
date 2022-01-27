using KuryeOtomasyon.DataAccessLayer;
using KuryeOtomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.BLL
{
    public class GonderiBll
    {
        GonderiDal dal = new GonderiDal();

        public int GonderiEkle(Model.Gonderiler gonderi)
        {
            return dal.GonderiEkle(gonderi);
        }

        public int GonderiGuncelle(Model.Gonderiler gonderi)
        {
            return dal.GonderiGuncelle(gonderi);
        }

        public int GonderiSil(int id)
        {
            return dal.GonderiSil(id);
        }

        public List<Model.Gonderiler> GonderiListele()
        {
            return dal.GonderiListele();
        }

        public Model.Gonderiler GonderiGetir(int id)
        {
            return dal.GonderiGetir(id);
        }

        public List<GonderiModel> AktifGonderiler()
        {
            return dal.AktifGonderiListele();
        }

        public int KuryeAta(int kuryeId,int gonderiId)
        {
            return dal.KuryeAta(gonderiId, kuryeId);
        }
    }
}
