using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentDealDal : IEntityRepository<RentDeal>
    {
        public List<Car> GetUnorderedCarsFRList(List<Car> cars, DateTime dateTime);
        public List<Car> GetUnorderedCars(DateTime dateTime);
    }
}
