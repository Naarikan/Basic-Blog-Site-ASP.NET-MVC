using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Classes
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public string KullaniciADi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }

        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; }
    }
}