using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        
        public void Add(T entity)
        {
            using var c = new AirLineContext();
            c.Add(entity);
            c.SaveChanges();
        }
        public void Delete(T entity)
        {
            using var c = new AirLineContext();
            c.Remove(entity);
            c.SaveChanges();

        }

        public void Update(T entity)
        {
            using var c = new AirLineContext();
            c.Update(entity);
            c.SaveChanges(); // Buna gerek yok diyor ama bilemiyorum.

        }
        public List<T> GetList()
        {
            using var c = new AirLineContext();

            return c.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T,bool>> filter)
        {
            using var c =new AirLineContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            using var c = new AirLineContext();
            var veri = c.Set<T>().Find(id);
            if(veri == null) throw new SqlNullValueException();
            return veri;
        }
    }
}
