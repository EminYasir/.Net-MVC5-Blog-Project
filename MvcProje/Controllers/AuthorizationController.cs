using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorizationController : Controller
    {
        AuthorizationManager authManager = new AuthorizationManager();
        // GET: Authorization
        public ActionResult Yetkilendirme()
        {
            var deger=authManager.GetAll(); 
            return View(deger);
        }

        public ActionResult AdminSil(int id)
        {
            authManager.DeleteAdminBl(id);
            return RedirectToAction("Yetkilendirme");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = authManager.FindAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            authManager.AdminUpdateBL(a);
            return RedirectToAction("Yetkilendirme");
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin p)
        {
            authManager.AdminAddBL(p);
            return RedirectToAction("Yetkilendirme");
        }

    }
}