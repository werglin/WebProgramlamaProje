using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class RentDeal:IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        [Required]
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
