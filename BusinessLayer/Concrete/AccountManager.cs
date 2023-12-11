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
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
        public void Add(Account entity)
        {
            _accountDal.Add(entity);
        }

        public void Delete(Account entity)
        {
            _accountDal.Delete(entity);
        }

        public Account GetById(int id)
        {
            return _accountDal.GetByID(id);
        }

        public List<Account> GetList()
        {
            return _accountDal.GetList();
        }

        public void Update(Account entity)
        {
            _accountDal.Update(entity);
        }
    }
}
