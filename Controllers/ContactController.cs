using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Classes;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Iletisim iletisim)
        {
            using (Context context = new Context())
            {
              context.Iletisims.Add(iletisim);
            context.SaveChanges();
              return RedirectToAction("Index");
            }

        }
    }
}