using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.Model
{
    public class MusteriModel:BaseModel
    {
        public int MusteriId { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public bool OzelMusteri { get; set; }// fiyatta %10 indirim yapılsın

    }
}
