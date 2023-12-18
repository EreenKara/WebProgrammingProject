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
    public class EfAirplaneDal : GenericRepository<Airplane>, IAirplaneDal
    {
        public Airplane GetAirplaneByModel(string model)
        {
            using var c = new AirLineContext();
            Airplane airplane = c.Airplanes.FirstOrDefault(a => a.Model == model);
            return airplane;
        }
    }
}
