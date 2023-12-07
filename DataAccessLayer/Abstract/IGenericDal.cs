using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        public void Insert(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public List<T> List();

    }
}
