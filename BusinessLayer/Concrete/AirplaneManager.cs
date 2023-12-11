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
    public class AirplaneManager : IAirplaneService
    {
        private IAirplaneDal _airplaneDal;
        public AirplaneManager(IAirplaneDal airplaneDal)
        {
            _airplaneDal = airplaneDal;

        }
        public void Add(Airplane entity)
        {
            _airplaneDal.Add(entity);
        }

        public void Delete(Airplane entity)
        {
            _airplaneDal.Delete(entity);
        }

        public Airplane GetById(int id)
        {
            return _airplaneDal.GetByID(id);
        }

        public List<Airplane> GetList()
        {
            return _airplaneDal.GetList();
        }

        public void Update(Airplane entity)
        {
            _airplaneDal.Update(entity);
        }
    }
}
