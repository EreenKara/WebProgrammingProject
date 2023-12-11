using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public List<T> GetList();
        public T GetByID(int id);
        public List<T> GetListByFilter(Expression<Func<T,bool>> filter);
    }
}
