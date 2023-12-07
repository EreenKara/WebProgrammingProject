using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdultManager : IAdultService
    {
        IAdultService _service;
        public AdultManager(IAdultService service)
        {
            _service = service;
        }

        public void Add(Adult entity)
        {
            _service.Add(entity);
        }

        public void Delete(Adult entity)
        {
            _service.Delete(entity);
        }

        public Adult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Adult> GetList()
        {
            return _service.GetList();
        }

        public void Update(Adult entity)
        {
            _service.Update(entity);
        }
    }
}
