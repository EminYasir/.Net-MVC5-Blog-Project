using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {

        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        //public void BLContactAdd(Contact c)
        //{
        //    if(c.Mail=="" || c.Message=="" || c.Name=="" || c.Subject=="" || c.Surname=="" || c.Mail.Length<=10 || c.Subject.Length <= 3)
        //    {
        //        return;
        //    }
        //    c.MessageDate= DateTime.Now;
        //     rc.Insert(c); 

        //}

        

        public Contact GetById(int id)
        {
            return _contactDal.Find(x => x.ContactID == id);
        }


        public List<Contact> GetList()
        {
           return _contactDal.List();
        }

        public void TAdd(Contact par)
        {
            _contactDal.Insert(par);
        }

        public void TDelete(Contact par)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact par)
        {
            throw new NotImplementedException();
        }
    }
}
