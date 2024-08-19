using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(int p = 1)
        {
            using (Context context = new Context())
            {
                var degerler = context.Blogs.ToList().ToPagedList(p, 5);

                return View(degerler);

            }
        }







        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }







        [HttpPost]
        public ActionResult BlogEkle(Blog blg)
        {

            if (ModelState.IsValid)
            {
                using (Context context = new Context())
                {
                    context.Blogs.Add(blg);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(blg);
        }

        public ActionResult BlogSil(int id)
        {
            using (Context context = new Context())
            {
                var blog = context.Blogs.Find(id);
                context.Blogs.Remove(blog);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        public ActionResult BlogGetir(int id)
        {
            using (Context context = new Context())
            {
                var deger = context.Blogs.Find(id);
                return View("BlogGetir", deger);


            }

        }
        public ActionResult BlogGuncelle(Blog b)
        {
            using (Context context = new Context())
            {
                var blog = context.Blogs.Find(b.ID);
                blog.Aciklama = b.Aciklama;
                blog.Tarih = b.Tarih;
                blog.BlogImage = b.BlogImage;
                blog.Baslik = b.Baslik;
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        public ActionResult Yorumlar()
        {
            using (Context context = new Context())
            {
                var yorums=context.Yorumlars.ToList();
                return View(yorums);
            }

        }

        public ActionResult Mesajlar()
        {
            using (Context context = new Context())
            {
                var mesajlar = context.Iletisims.ToList();
                return View(mesajlar);
            }
        }

    }
}
