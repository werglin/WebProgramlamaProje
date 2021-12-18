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
        public List<Car> GetUnorderedCars(DateTime dateTime)
        {
            using (ProjeContext context = new ProjeContext())
            {
                // left join car 
                var result = from c in context.Cars
                             join rd in context.RentDeals
                             on c.Id equals rd.Car.Id
                             into tgt
                             from subset in tgt.DefaultIfEmpty()
                             where subset.RentDate >= dateTime
                             orderby c.DailyPrice
                             orderby c.Brand
                             orderby c.ModelYear
                             select new Car { Id = subset.Car.Id, Branch = subset.Car.Branch, Brand = subset.Car.Brand, DailyPrice = subset.Car.DailyPrice, 
                             Description = subset.Car.Description, FuelType = subset.Car.FuelType, ModelYear = subset.Car.ModelYear, PhotoName = subset.Car.PhotoName, TypeOfGear = subset.Car.TypeOfGear};
                return result.ToList();
            }
        }

        public List<Car> GetUnorderedCarsFRList(List<Car> cars, DateTime dateTime)
        {
            using (ProjeContext context = new ProjeContext())
            {
                // left join cars
                var result = from c in cars
                             join rd in context.RentDeals
                             on c.Id equals rd.Car.Id
                             into tgt
                             from subset in tgt.DefaultIfEmpty()
                             where subset.RentDate >= dateTime
                             orderby c.DailyPrice
                             orderby c.Brand
                             orderby c.ModelYear
                             select new Car
                             {
                                 Id = subset.Car.Id,
                                 Branch = subset.Car.Branch,
                                 Brand = subset.Car.Brand,
                                 DailyPrice = subset.Car.DailyPrice,
                                 Description = subset.Car.Description,
                                 FuelType = subset.Car.FuelType,
                                 ModelYear = subset.Car.ModelYear,
                                 PhotoName = subset.Car.PhotoName,
                                 TypeOfGear = subset.Car.TypeOfGear
                             };
                return result.ToList();
            }
        }
    }
}
