using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        
        public void Insert(T entity)
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
        public List<T> List()
        {
            using var c = new AirLineContext();

            return c.Set<T>().ToList();
        }


    }
}
