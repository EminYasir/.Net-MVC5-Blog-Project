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
    public class BlogManager:IBlogService
    {

        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogdal.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogdal.List(x => x.CategoryID == id);
        }
       
        public List<Blog> GetList()
        {
            return _blogdal.List();
        }

        public Blog GetById(int id)
        {
            return _blogdal.GetById(id);
        }

        public void TAdd(Blog par)
        {
            _blogdal.Insert(par);
        }

        public void TDelete(Blog par)
        {
            _blogdal.Delete(par);
        }

        public void TUpdate(Blog par)
        {
            _blogdal.Update(par);
        }
    }
}
