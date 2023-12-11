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
    public class FlightManager : IFlightService
    {
        private IFlightDal _flightDal;

        public FlightManager(IFlightDal flightDal)
        {
            _flightDal = flightDal;
        }

        public void Add(Flight entity)
        {
            _flightDal.Add(entity);
        }

        public void Delete(Flight entity)
        {
            _flightDal.Delete(entity);
        }

        public Flight GetById(int id)
        {
            return _flightDal.GetByID(id);
        }

        public List<Flight> GetList()
        {
            return _flightDal.GetList();
        }

        public void Update(Flight entity)
        {
            _flightDal.Update(entity);
        }
    }
}
