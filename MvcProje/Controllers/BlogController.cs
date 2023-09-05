using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var list=bm.GetList().ToPagedList(page,6);//birinci sayfadan başla her sayfada sadece 6 post göster.
            return PartialView(list);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.Post
            var posttitle1=bm.GetList().OrderByDescending(z=>z.BlogId).Where(x=>x.CategoryID==1).Select(y=>y.BlogTitle).FirstOrDefault();
            var postBlogID1=bm.GetList().OrderByDescending(z=>z.BlogId).Where(x=>x.CategoryID==1).Select(y=>y.BlogId).FirstOrDefault();
            var postimage1=bm.GetList().OrderByDescending(z=>z.BlogId).Where(x=>x.CategoryID==1).Select(y=>y.BlogImage).FirstOrDefault();
            var postdate1=bm.GetList().OrderByDescending(z=>z.BlogId).Where(x=>x.CategoryID==1).Select(y=>y.BlogDate).FirstOrDefault();
            var postcategory1=bm.GetList().OrderByDescending(z=>z.BlogId).Where(x=>x.CategoryID==1).Select(y=>y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle1=posttitle1;
            ViewBag.postBlogID1 = postBlogID1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.postcategory1 = postcategory1;
            //2.Post
            var posttitle2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogId).FirstOrDefault();
            var postimage2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postBlogID2 = postBlogID2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.postcategory2 = postcategory2;
            //3.Post
            var posttitle3 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID3 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogId).FirstOrDefault();
            var postimage3 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory3 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postBlogID3 = postBlogID3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.postcategory3 = postcategory3;
            //4.Post
            var posttitle4 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID4 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogId).FirstOrDefault();
            var postimage4 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory4 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postBlogID4 = postBlogID4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.postcategory4 = postcategory4;
            //5.Post(Orta kısım)
            var posttitle5 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID5 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogId).FirstOrDefault();
            var postimage5 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory5 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postBlogID5 = postBlogID5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.postcategory5 = postcategory5;
            return PartialView();

        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            //1.Post
            var posttitle1 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID1 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();
            var postimage1 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory1 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postBlogID1 = postBlogID1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.postcategory1 = postcategory1;
            //2.Post
            var posttitle2 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID2 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogId).FirstOrDefault();
            var postimage2 = bm.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory2 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postBlogID2 = postBlogID2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.postcategory2 = postcategory2;
            //3.Post
            var posttitle3 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID3 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogId).FirstOrDefault();
            var postimage3 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory3 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postBlogID3 = postBlogID3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.postcategory3 = postcategory3;
            //4.Post
            var posttitle4 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postBlogID4 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogId).FirstOrDefault();
            var postimage4 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postcategory4 = bm.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postBlogID4 = postBlogID4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.postcategory4 = postcategory4;
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = bm.GetById(id);
            return PartialView(blogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = bm.GetById(id);
            return PartialView(blogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id,int page = 1)
        {
            var blogcategory=bm.GetBlogByCategory(id).ToPagedList(page, 3);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.categoryName = CategoryName;
            var CategoryDescription = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.categoryDescription = CategoryDescription;
            return View(blogcategory);
        }

        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            
            List <SelectListItem> categorivalues = (from x in c.Categorys.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.CategoryName,
                                              Value=x.CategoryID.ToString()
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            var del=bm.GetById(id);
            bm.TDelete(del);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog=bm.GetById(id);
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommandByBlog(int id)
        {
            CommentManager cm=new CommentManager(new EfCommentDal());
            var commentList = cm.GetByIdList(id);
            return View(commentList);
        }

        public ActionResult BlogListByAuthor(int id)
        {
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}