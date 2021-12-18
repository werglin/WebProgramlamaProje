using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace WebProgramlamaProje_Deneme1.Models
{
    public class FilterModel
    {
        public FilterModel()
        {
            Brand = "";
            FuelType = "";
            TypeOfGear = "";
            DailyPrice = 0;
            BranchId = -1;
            RentDate = DateTime.Today;
        }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public string TypeOfGear { get; set; }
        public uint DailyPrice { get; set; }
        public int BranchId { get; set; }
        public DateTime RentDate { get; set; }

        public List<Car> Filt(ICarService carService,IDealService dealService)
        {

            if (BranchId == -1)
            {
                return dealService.FilterListByDateTime( carService.GetAllWithLinq(x => x.Brand.Contains(Brand) &&
                                           x.DailyPrice > DailyPrice &&
                                           x.FuelType.Contains(FuelType) &&
                                           x.TypeOfGear.Contains(TypeOfGear)
                ).Data  , RentDate).Data;
            }


            return dealService.FilterListByDateTime(carService.GetAllWithLinq(x => x.Brand.Contains(Brand) &&
                                          x.DailyPrice > DailyPrice &&
                                          x.FuelType.Contains(FuelType) &&
                                          x.TypeOfGear.Contains(TypeOfGear) &&
                                          x.Branch.Id == BranchId
                ).Data, RentDate).Data;
        }
    }
}
