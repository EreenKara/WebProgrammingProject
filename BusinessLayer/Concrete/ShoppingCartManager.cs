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
    public class ShoppingCartManager : IShoppingCartService
    {
        private IShoppingCartDal _shoppingCartDal;
        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }

        public void Add(ShoppingCart entity)
        {
            _shoppingCartDal.Add(entity);
        }

        public void Delete(ShoppingCart entity)
        {
            _shoppingCartDal.Delete(entity);
        }

        public ShoppingCart GetById(int id)
        {
            return _shoppingCartDal.GetByID(id);
        }

        public List<ShoppingCart> GetList()
        {
            return _shoppingCartDal.GetList();
        }

        public void Update(ShoppingCart entity)
        {
            _shoppingCartDal.Update(entity);
        }
    }
}
