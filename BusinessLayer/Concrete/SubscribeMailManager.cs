using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager : ISubscribeMailService
    {

        IMailDal _mailDal;

        public SubscribeMailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Delete(SubscribeMail p)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail Find(Expression<Func<SubscribeMail, bool>> where)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(SubscribeMail p)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> List()
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> List(Expression<Func<SubscribeMail, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void TAdd(SubscribeMail par)
        {
           _mailDal.Insert(par);
        }

        public void TDelete(SubscribeMail par)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubscribeMail par)
        {
            throw new NotImplementedException();
        }

        public void Update(SubscribeMail p)
        {
            throw new NotImplementedException();
        }



        //public void BLAdd(SubscribeMail p)
        //{
        //    //@gmail.com
        //    if (p.Mail.Length <= 10 || p.Mail.Length >= 50)
        //    {
        //        return;
        //    }
        //     RepoSubscribeMail.Insert(p);
        //}


    }
}
