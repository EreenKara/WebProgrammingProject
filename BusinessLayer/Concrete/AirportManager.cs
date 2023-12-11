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
    public class AirportManager : IAirportService
    {
        private IAirportDal _airportDal;
        public AirportManager(IAirportDal airportDal)
        {
            _airportDal = airportDal;
        }

        public void Add(Airport entity)
        {
            _airportDal.Add(entity);
        }

        public void Delete(Airport entity)
        {
            _airportDal.Delete(entity);
        }

        public Airport GetById(int id)
        {
            return _airportDal.GetByID(id);
        }

        public List<Airport> GetList()
        {
            return _airportDal.GetList();
        }

        public void Update(Airport entity)
        {
            _airportDal.Update(entity);
        }
    }
}
