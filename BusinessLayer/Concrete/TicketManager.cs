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
    public class TicketManager : ITicketService
    {
        private ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void Add(Ticket entity)
        {
            _ticketDal.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _ticketDal.Delete(entity);
        }

        public Ticket GetById(int id)
        {
            return _ticketDal.GetByID(id);
        }

        public List<Ticket> GetList()
        {
            return _ticketDal.GetList();
        }

        public void Update(Ticket entity)
        {
            _ticketDal.Update(entity);
        }
    }
}
