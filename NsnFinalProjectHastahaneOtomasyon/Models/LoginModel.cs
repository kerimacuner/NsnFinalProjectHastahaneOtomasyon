using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsnFinalProjectHastahaneOtomasyon.Models
{
    public class LoginModel
    {
        public int CalisanID { get; set; }
        public int HastaID { get; set; }    

        public string KullaniciAdi { get; set; }
        public string Sifresi { get; set; }

    }
}
