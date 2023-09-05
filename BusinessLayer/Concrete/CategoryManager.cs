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
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _catergoryDal;

        public CategoryManager(ICategoryDal catergoryDal)
        {
            _catergoryDal = catergoryDal;
        }
        
        public void DeleteCategoryBL(int id)
        {
            Category category = _catergoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            _catergoryDal.Update(category);

        }
        public void CategoryStatusTrueBL(int id)
        {
            Category category = _catergoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
             _catergoryDal.Update(category);

        }

        public List<Category> GetList()
        {
            return _catergoryDal.List();
        }

        public Category GetById(int id)
        {
            return _catergoryDal.GetById(id);
        }

        public void TAdd(Category par)
        {
            _catergoryDal.Insert(par);
        }

        public void TDelete(Category par)
        {
            _catergoryDal.Delete(par);
        }

        public void TUpdate(Category par)
        {
            _catergoryDal.Update(par);
        }
    }
}
