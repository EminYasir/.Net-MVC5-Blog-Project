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
    public class CommentController : Controller
    {
        CommentManager cm=new CommentManager(new EfCommentDal());
        // GET: Comment
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var comment = cm.GetById(id);
            return PartialView(comment);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.TAdd(c);
            return PartialView();
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentlisttrue = cm.CommentByStatusTrue();
            return View(commentlisttrue);
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            Comment com=cm.GetById(id);
            cm.CommentStatusChangeToFalse(com);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentlistfalse = cm.CommentByStatusFalse();
            return View(commentlistfalse);
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            Comment com = cm.GetById(id);
            cm.CommentStatusChangeToTrue(com);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}