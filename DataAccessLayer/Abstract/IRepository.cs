using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        T GetById(int id);
        List<T> List(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);
    }
}
