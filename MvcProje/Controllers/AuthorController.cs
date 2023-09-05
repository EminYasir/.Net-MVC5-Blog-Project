using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager=new BlogManager(new EfBlogDal());
        AuthorManager authormanager=new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)//blogu sahip yazarı alıcağım için bm yi kullandım
        {
            var authordetail= blogmanager.GetById(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)//blog detail sayfasında ki yazarın postlarının listlenmesi
        {
            var blogAuthorId= blogmanager.GetList().Where(x=>x.BlogId==id).Select(y=>y.AuthorID).FirstOrDefault();
            var authorblogs= blogmanager.GetBlogByAuthor(blogAuthorId);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists=authormanager.GetList();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid)
            {
                authormanager.TAdd(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author=authormanager.GetById(id);
            ViewBag.img = author.AuthorImage;
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid)
            {
                authormanager.TUpdate(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }

        public ActionResult DeleteAuthor(int id)
        {
            var author=authormanager.GetById(id);
            authormanager.TDelete(author);
            return RedirectToAction("AuthorList");
        }

    }

}