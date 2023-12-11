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
    public class AdultManager : IAdultService
    {
        private IAdultDal _adultDal;
        public AdultManager(IAdultDal adultDal)
        {
            _adultDal = adultDal;
        }

        public void Add(Adult entity)
        {
            _adultDal.Add(entity);
        }

        public void Delete(Adult entity)
        {
            _adultDal.Delete(entity);
        }

        public Adult GetById(int id)
        {
            return _adultDal.GetByID(id);
        }

        public List<Adult> GetList()
        {
            return _adultDal.GetList();
        }

        public void Update(Adult entity)
        {
            _adultDal.Update(entity);
        }
    }
}
