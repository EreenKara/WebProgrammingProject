using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfFlightDal : GenericRepository<Flight>, IFlightDal
    {
        
        public List<Flight> GetFlightsWithJoin()
        {
            using var c = new AirLineContext();
            var liste = c.Flights.Include(x=>x.Airplane).Include(x=>x.ArrivalAirport).Include(x=>x.DepartureAirport).Include(x=>x.Tickets).ToList();
            return liste;
        }

        public Flight GetFlightWithJoinById(int id)
        {
            
            using var c = new AirLineContext();
            var ucus = c.Flights.Where(x=>x.ID==id).Include(x => x.Airplane)
                .Include(x => x.ArrivalAirport).Include(x => x.DepartureAirport).Include(x=>x.Tickets).FirstOrDefault();
            return ucus;
        }
    }
}
