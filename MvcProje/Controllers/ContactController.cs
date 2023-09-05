using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm=new ContactManager(new EfContactDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            ContactValidator validator = new ContactValidator();
            ValidationResult result = validator.Validate(c);
            if (result.IsValid)
            {
                c.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.TAdd(c);
                return RedirectToAction("Index","Blog");
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
        public ActionResult SendBox()
        {
            var contact = cm.GetList();
            return View(contact);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact message=cm.GetById(id);
            return View(message);
        }


    }
}