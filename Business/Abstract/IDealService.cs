using Core.Business;
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
        public IDataResult<List<Car>> FilterListByDateTime(List<Car> cars, DateTime dateTime);
        public IDataResult<List<Car>> GetAvailableCars(ref DateTime dateTime);
    }
}
