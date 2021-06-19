using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsnFinalProjectHastahaneOtomasyon.Models
{
    public class CalisanModel:KullaniciModel
    {
        public int CalisanID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifresi { get; set; }

    }
}
