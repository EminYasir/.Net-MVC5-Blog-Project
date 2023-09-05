using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var deger=aboutManager.GetList();
            return View(deger);
        }
        public PartialViewResult Footer()
        {
            var deger = aboutManager.GetList();
            return PartialView(deger);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman=new AuthorManager(new EfAuthorDal());
            var deger=autman.GetList();
            return PartialView(deger);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var about= aboutManager.GetList();
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About a)
        {
            aboutManager.TUpdate(a);
            return RedirectToAction("UpdateAboutList");
        }
    }
}