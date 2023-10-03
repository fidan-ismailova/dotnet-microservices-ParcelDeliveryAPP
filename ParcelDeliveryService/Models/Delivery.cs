using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Parcel")]
        public int ParcelId { get; set; }
        
        public DateTime DeliveryDate { get; set; }
    }
}