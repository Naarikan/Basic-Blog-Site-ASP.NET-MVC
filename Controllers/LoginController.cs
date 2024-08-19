using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.Classes;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            using (Context context = new Context())
            {
                var user= context.Admins.FirstOrDefault(a=>a.Kullanici==admin.Kullanici && a.Sifre==admin.Sifre);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Kullanici, false);
                    Session["Kullanici"]=user.Kullanici.ToString();
                    return RedirectToAction("Index","Admin");
                }
                else { return View(); } 

            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}