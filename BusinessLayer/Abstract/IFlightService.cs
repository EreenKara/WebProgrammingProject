﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFlightService : IGenericService<Flight>
    {
        public List<Flight> GetFlightsWithJoin();
        public Flight GetFlightWithJoinById(int id);

    }
}
