using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Classes;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (Context context = new Context())
            {
                var blogImages=context.Blogs.OrderByDescending(b=>b.ID).Take(5).ToList();
                return View(blogImages);
            }
        }
        public PartialViewResult Partial1()
        {
            using (Context context = new Context())
            {
                var degerler= context.Blogs.OrderByDescending(b => b.ID).Take(3).ToList();

                return PartialView(degerler);

            }
        }
        public PartialViewResult Partial2()
        {
            using (Context context = new Context())
            {
                var degerler = context.Blogs.OrderByDescending(b => b.ID).Take(9).ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Partial3() {

            using (Context context = new Context())
            {
                var degerler=context.Blogs.Take(3).ToList();
                return PartialView(degerler);
            }
        }

        public PartialViewResult Partial4() {

            using (Context context = new Context())
            {
                var degerler= context.Blogs.OrderByDescending(b => b.ID).Take(3).ToList();

                return PartialView(degerler);
            }
        
        }
       
    }
}