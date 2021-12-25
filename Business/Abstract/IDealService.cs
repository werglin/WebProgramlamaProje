﻿using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDealService : IServiceRepository<RentDeal>
    {
        public IDataResult<List<RentDeal>> GetDealsOfCar(Car entity);
        public IDataResult<List<Car>> FilterListByDateTime(List<Car> cars, DateTime rentTime, DateTime deliverDate);
        public IDataResult<List<Car>> GetAvailableCars(DateTime rentTime, DateTime deliverDate);
        public IDataResult<List<RentDeal>> GetDealsOfUser(int userId);
    }
}
