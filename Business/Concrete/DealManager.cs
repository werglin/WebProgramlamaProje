﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DealManager : IDealService
    {
        IRentDealDal _dealDal;
        public DealManager(IRentDealDal dealDal)
        {
            _dealDal = dealDal;
        }
        public IResult Add(RentDeal entity)
        {
            _dealDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(RentDeal entity)
        {
            _dealDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Car>> FilterListByDateTime( List<Car> cars,  DateTime dateTime)
        {
            return new SuccessDataResult<List<Car>>(_dealDal.GetUnorderedCarsFRList(cars, dateTime));
        }

        public IDataResult<List<RentDeal>> GetAll()
        {
            return new SuccessDataResult<List<RentDeal>>(_dealDal.GetAll(), Messages.ObjectSuccessfullyReturned);
        }

        public IDataResult<List<Car>> GetAvailableCars(ref DateTime dateTime)
        {
            return new SuccessDataResult<List<Car>>(_dealDal.GetUnorderedCars(dateTime));
        }

        public IDataResult<RentDeal> GetById(int id)
        {
            return new SuccessDataResult<RentDeal>(_dealDal.Get(x => x.Id == id));
        }

        public IDataResult<List<RentDeal>> GetDealsOfCar(Car entity)
        {
            if (entity == null)
            {
                return new ErrorDataResult<List<RentDeal>>(null, Messages.ObjectNotFound);
            }
            return new SuccessDataResult<List<RentDeal>>(_dealDal.GetAll(x => x.Car.Id == entity.Id), Messages.ObjectSuccessfullyReturned);
        }

        public IResult Update(RentDeal entity)
        {
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}