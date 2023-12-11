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
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public void Add(Person entity)
        {
            _personDal.Add(entity);
        }

        public void Delete(Person entity)
        {
            _personDal.Delete(entity);
        }

        public Person GetById(int id)
        {
            return _personDal.GetByID(id);
        }

        public List<Person> GetList()
        {
            return _personDal.GetList();
        }

        public void Update(Person entity)
        {
            _personDal.Update(entity);
        }
    }
}
