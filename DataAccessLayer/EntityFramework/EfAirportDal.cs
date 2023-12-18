using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAirportDal : GenericRepository<Airport>, IAirportDal
    {
        public Airport GetAiportByCode(string code)
        {
            using var c = new AirLineContext();
            Airport airport = c.Airports.FirstOrDefault(a => a.AirportCode == code);

            return airport;
        }

    }
}
