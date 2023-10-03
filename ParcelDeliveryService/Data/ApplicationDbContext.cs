using Microsoft.EntityFrameworkCore;

namespace ParcelDeliveryService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}