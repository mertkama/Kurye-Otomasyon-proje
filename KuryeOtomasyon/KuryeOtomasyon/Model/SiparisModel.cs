using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.Model
{
    public class SiparisModel:BaseModel
    {
        public int SiparisId { get; set; }
        public string PaketAciklama { get; set; }
        public double Agirlik { get; set; }
        public double Fiyat { get; set; } //random cıkacak
        public string GonderiAdresi { get; set; }
        public int MusteriId { get; set; }
        public MusteriModel Musteri { get; set; }
        public int SiparisDurumu { get; set; }
    }
}
