using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [AllowAnonymous]//bu sayfa autorize dan muaf
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLoginIndex(Author p)
        {
            Context c=new Context();
            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (userinfo!= null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLoginIndex","Login");
            }
            
        }

        // GET: Login
        [HttpGet]
        public ActionResult AdminLoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLoginIndex(Admin p)
        {
            Context c = new Context();
            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLoginIndex", "Login");
            }

        }
    }
}