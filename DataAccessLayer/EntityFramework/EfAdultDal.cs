using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    //Aşağıdaki gibi bütün entity'ler için yap.
    public class EfAdultDal:GenericRepository<Adult>,IAdultDal
    {
    }
}
