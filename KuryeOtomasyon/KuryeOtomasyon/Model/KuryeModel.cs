using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.Model
{
    public class KuryeModel:BaseModel
    {
        public int KuryeId { get; set; }
        public string KuryeAd { get; set; }
        public string KuryeSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime EhliyetTarihi { get; set; }

    }
}
