using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
            // iş kuralları 
            // yetki varmı ? , girilen değerler geçerli mi (DailyPrice > 0 ?)

            if (entity.DailyPrice < 0)
            {
                return new ErrorResult(Messages.InvalidDailyPrice);
            }
            if (entity.ModelYear < 1769 || entity.ModelYear > 32767)
            {
                return new ErrorResult(Messages.InvalidModelYear);
            }
            _carDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Car entity)
        {
            // iş kuralları 
            // yetki varmı ? 
            _carDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ObjectSuccessfullyReturned);
        }

        public IDataResult<List<Car>> GetAllByPrice(uint max, uint min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }
        public IDataResult<Car> GetById(int id)
        {
            Car car = _carDal.Get(p => p.Id == id);
            if (car == null)
            {
                return new ErrorDataResult<Car>(car, Messages.ObjectNotFound);
            }
            return new SuccessDataResult<Car>(car , Messages.ObjectSuccessfullyReturned);
        }

        public IResult Update(Car entity)
        {
            // iş kuralları 
            // yetki varmı ? 
            _carDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
