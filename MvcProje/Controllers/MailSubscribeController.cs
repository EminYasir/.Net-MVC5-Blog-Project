using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeMailManager smm= new SubscribeMailManager(new EfMailSubscribeDal());
            smm.TAdd(p);
            return PartialView();
        }
    }
}