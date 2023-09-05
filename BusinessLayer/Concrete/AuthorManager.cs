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
    public class AuthorManager:IAuthorService
    {
        IAuthorDal _authordal;

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }

        public List<Author> GetList()
        {
             return _authordal.List();
        }

        public Author GetById(int id)
        {
            return _authordal.GetById(id);
        }

        public void TAdd(Author par)
        {
            _authordal.Insert(par);
        }

        public void TDelete(Author par)
        {
            _authordal.Delete(par);
        }

        public void TUpdate(Author par)
        {
            _authordal.Update(par);
        }
    }
}
