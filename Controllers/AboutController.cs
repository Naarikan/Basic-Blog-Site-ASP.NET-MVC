using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Classes;
namespace WebApplication1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
       
        public ActionResult Index()
        {
            using (Context c = new Context())
            {
                var degerler=c.Hakkimizdas.ToList();
                return View(degerler);
            }
        }
    }
}