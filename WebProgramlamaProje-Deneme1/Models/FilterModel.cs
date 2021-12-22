using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace WebProgramlamaProje_Deneme1.Models
{
    public class FilterModel
    {
        public string Brand = "";
        public string FuelType = "";
        public string TypeOfGear = "";
        public uint DailyPrice =0;
        public int BranchId = -1;
        public DateTime RentDate = DateTime.Today;
        public DateTime DeliverDate = DateTime.Today;

        public List<Car> Filt(ICarService carService,IDealService dealService)
        {

            if (BranchId == -1)
            {
                return dealService.FilterListByDateTime( carService.GetAllWithLinq(x => x.Brand.Contains(Brand) &&
                                           x.DailyPrice >= DailyPrice &&
                                           x.FuelType.Contains(FuelType) &&
                                           x.TypeOfGear.Contains(TypeOfGear)
                ).Data  , RentDate, DeliverDate).Data;
            }


            return dealService.FilterListByDateTime(carService.GetAllWithLinq(x => x.Brand.Contains(Brand) &&
                                          x.DailyPrice >= DailyPrice &&
                                          x.FuelType.Contains(FuelType) &&
                                          x.TypeOfGear.Contains(TypeOfGear) &&
                                          x.Branch.Id == BranchId
                ).Data, RentDate, DeliverDate).Data;
        }
    }
}
