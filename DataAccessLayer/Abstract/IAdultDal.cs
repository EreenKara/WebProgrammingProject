using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Her bir entity için bir tane interface tanımlama ve aşağıdaki gibi yap
    internal interface IAdultDal:IGenericDal<Adult>
    {
    }
}
