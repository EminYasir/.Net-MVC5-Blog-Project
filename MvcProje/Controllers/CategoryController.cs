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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
      
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues=cm.GetList();
            return PartialView(categoryvalues);
        }

        public ActionResult AdminCategoryList()
        {
            var categories=cm.GetList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidations = new CategoryValidator();
            ValidationResult result = categoryValidations.Validate(p);
            if (result.IsValid)
            {
                cm.TAdd(p);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidations = new CategoryValidator();
            ValidationResult result = categoryValidations.Validate(category);
            if (result.IsValid)
            {
                cm.TUpdate(category);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult CategoryDelete(int id)
        {
            cm.DeleteCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusTrueBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}