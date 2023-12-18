using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IFlightDal : IGenericDal<Flight>
    {
        public List<Flight> GetFlightsWithJoin();
        public Flight GetFlightWithJoinById(int id);
        //public List<Flight> GetFlightsForBooking();
    }
}
