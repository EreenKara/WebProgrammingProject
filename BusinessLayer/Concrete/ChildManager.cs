using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChildManager: IChildService
    {
        private IChildDal _childDal;
        public ChildManager(IChildDal childDal)
        {
            _childDal = childDal;
        }

        public void Add(Child entity)
        {
            _childDal.Add(entity);
        }

        public void Delete(Child entity)
        {
            _childDal.Delete(entity);
        }

        public Child GetById(int id)
        {
            return _childDal.GetByID(id);
        }

        public List<Child> GetList()
        {
            return _childDal.GetList();
        }

        public void Update(Child entity)
        {
            _childDal.Update(entity);
        }
    }
}
