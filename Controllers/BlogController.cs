using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Classes;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        BlogYorum yorum = new BlogYorum();
        Yorumlar yeniyorum=new Yorumlar();
      
        // GET: Blog
        public ActionResult Index()
        {
            using (Context context = new Context())
            {
               yorum.Deger1 = context.Blogs.ToList();
               yorum.Deger3 = context.Blogs.OrderByDescending(b => b.ID).Take(3).ToList();
                return View(yorum);

            }
        }
        
      
        public ActionResult BlogDetay(int id)
        {
            using (Context context = new Context())
            {
                yorum.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
                yorum.Deger2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
                yorum.Deger3 = context.Blogs.OrderByDescending(b => b.ID).Take(3).ToList();
                return View(yorum);
            }
        }
         
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.ID = id;    
            return PartialView();

        }


        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yeniyorum)
        {
            using (Context context = new Context())
            {
                context.Yorumlars.Add(yeniyorum);
                context.SaveChanges();
                return PartialView();

            }


        }

       
    }
}