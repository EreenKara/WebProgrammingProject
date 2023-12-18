using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAirplaneService:IGenericService<Airplane>
    {
        public Airplane GetAirplaneByModel(string model);
    }
}
