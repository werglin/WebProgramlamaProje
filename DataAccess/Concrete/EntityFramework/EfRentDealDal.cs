using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDealDal : EfEntityRepositoryBase<RentDeal, ProjeContext>, IRentDealDal
    {
        public List<Car> GetUnorderedCars(DateTime rentTime, DateTime deliverTime)
        {
            using (ProjeContext context = new ProjeContext())
            {
                // left join car 
                var result = from c in context.Cars
                             join rd in context.RentDeals
                             on c.Id equals rd.Car.Id
                             into tgt
                             from rd in tgt.DefaultIfEmpty()
                             where rd == null || rd.DeliveryDate < rentTime || (rd.RentDate > rentTime && rd.RentDate > deliverTime)
                             orderby c.DailyPrice
                             orderby c.Brand
                             orderby c.ModelYear
                             select c; 
                return result.ToList();
            }
        }

        public List<Car> GetUnorderedCarsFRList(List<Car> cars, DateTime rentTime, DateTime deliverTime)
        {
            using (ProjeContext context = new ProjeContext())
            {
                // left join cars
                var result = from c in cars
                             join rd in context.RentDeals
                             on c.Id equals rd.Car.Id
                             into tgt
                             from rd in tgt.DefaultIfEmpty()
                             where rd == null || rd.DeliveryDate< rentTime || (rd.RentDate > rentTime && rd.RentDate > deliverTime ) 
                             orderby c.DailyPrice
                             orderby c.Brand
                             orderby c.ModelYear
                             select c;
                return result.ToList();
            }
        }
    }
}
