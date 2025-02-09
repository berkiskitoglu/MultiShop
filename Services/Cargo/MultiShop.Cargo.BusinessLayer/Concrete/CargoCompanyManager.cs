using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoComponyDal _cargoComponyDal;

        public CargoCompanyManager(ICargoComponyDal cargoComponyDal)
        {
            _cargoComponyDal = cargoComponyDal;
        }

        public void TDelete(int id)
        {
            _cargoComponyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoComponyDal.GetAll();
        }

        public CargoCompany TGetByID(int id)
        {
            return _cargoComponyDal.GetByID(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoComponyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoComponyDal.Update(entity);
        }
    }
}
