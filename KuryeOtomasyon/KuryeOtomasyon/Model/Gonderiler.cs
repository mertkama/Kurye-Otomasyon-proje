using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.Model
{
    public class Gonderiler:BaseModel
    {
        public int GonderiId { get; set; }
        public int SiparisId { get; set; }
        public int KuryeId { get; set; }
        public int Durum { get; set; }
        public Kurye Kurye { get; set; }
        public Siparis Siparis { get; set; }
    }
}
