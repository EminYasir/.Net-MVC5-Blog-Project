using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager usp=new UserProfileManager();
        BlogManager bm=new BlogManager(new EfBlogDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];//sisteme girenin maili
            var author = usp.GetAuthorByMail(p);
            return PartialView(author);
        }

        public ActionResult BlogListByAuthor(string p)
        {
            p = (string)Session["Mail"];//sisteme girenin maili;
            int id=c.Authors.Where(x=>x.Mail==p).Select(y=>y.AuthorID).FirstOrDefault();
            var blogs=usp.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {

            List<SelectListItem> categorivalues = (from x in c.Categorys.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categorivalues = categorivalues;

            List<SelectListItem> authorvalues = (from x in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName,
                                                     Value = x.AuthorID.ToString()
                                                 }).ToList();
            ViewBag.authorvalues = authorvalues;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.TAdd(b);
            return RedirectToAction("BlogListByAuthor");
        }


        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog = bm.GetById(id);
            List<SelectListItem> categorivalues = (from x in c.Categorys.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categorivalues = categorivalues;

            List<SelectListItem> authorvalues = (from x in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName,
                                                     Value = x.AuthorID.ToString()
                                                 }).ToList();
            ViewBag.authorvalues = authorvalues;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            bm.TUpdate(b);
            return RedirectToAction("BlogListByAuthor");
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            usp.AuthorUpdateBL(p);
            return RedirectToAction("Index");

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLoginIndex", "Login");

        }
    }
}