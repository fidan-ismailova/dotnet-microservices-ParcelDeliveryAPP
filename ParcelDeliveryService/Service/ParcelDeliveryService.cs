using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParcelDeliveryService.Models;

namespace ParcelDeliveryService.Service
{
    public class ParcelDeliveryService
    {
        private readonly ParcelDeliveryDbContext _dbContext;

        public ParcelDeliveryService(ParcelDeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Parcel CreateParcel(Parcel parcel)
        {
            _dbContext.Parcels.Add(parcel);
            _dbContext.SaveChanges();
            return parcel;
        }

        public Delivery CreateDelivery(Delivery delivery)
        {
            _dbContext.Deliveries.Add(delivery);
            _dbContext.SaveChanges();
            return delivery;
        }

        public Parcel GetParcelById(int parcelId)
        {
            return _dbContext.Parcels.FirstOrDefault(p => p.Id == parcelId);
        }

        public Delivery GetDeliveryById(int deliveryId)
        {
            return _dbContext.Deliveries.FirstOrDefault(d => d.Id == deliveryId);
        }
    }
}