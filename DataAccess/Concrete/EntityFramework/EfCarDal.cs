using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjeContext>, ICarDal
    {
       /* public List<CarDetailsDTO> GetCarDetails()
        {
            using (ProjeContext context = new ProjeContext())
            {
                var result = from c in context.Cars
                             join cd in context.CarDetails
                             on c.Id equals cd.Id
                             orderby c.DailyPrice
                             orderby c.Brand 
                             orderby c.ModelYear
                             select new CarDetailsDTO { 
                                 CarId = c.Id, 
                                 Brand = c.Brand,
                                 DailyPrice = c.DailyPrice, 
                                 FuelType = cd.FuelType, 
                                 Description = cd.Description, 
                                 ModelYear = c.ModelYear ,
                                 TypeOfGear = cd.TypeOfGear
                             };
                return result.ToList();
            }
        }*/
    }
}
