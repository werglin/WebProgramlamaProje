using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProje_Deneme1.Models
{
    public class FilterModel
    {
        public string Brand { get; set; }
        public string FuelType{ get; set; }
        public string TypeOfGear { get; set; }
        public uint DailyPrice { get; set; }
        public int BranchId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DeliverDate { get; set; }
    }
}
