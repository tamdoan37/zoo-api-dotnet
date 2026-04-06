using Microsoft.EntityFrameworkCore;
using ZooApi.Models;

namespace ZooApi.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        // Removed the separate DbSet for MaintenanceRecords

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // All three are now flattened into the main Animal table
            mb.Entity<Animal>().OwnsOne(a => a.Location);
            mb.Entity<Animal>().OwnsOne(a => a.FeedingSchedule);
            mb.Entity<Animal>().OwnsOne(a => a.MaintenanceRecord);

            // Seed Main Animals
            mb.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Ellie", Species = "Elephant", Status = "open", Health = "Good" },
                new Animal { Id = 2, Name = "Rajah", Species = "Tiger", Status = "closed", Health = "Fair" },
                new Animal { Id = 3, Name = "Bao", Species = "Panda", Status = "open", Health = "Excellent" }
            );

            // Seed Location
            mb.Entity<Animal>().OwnsOne(a => a.Location).HasData(
                new { AnimalId = 1, Latitude = 34.0722, Longitude = -118.1254 },
                new { AnimalId = 2, Latitude = 34.073, Longitude = -118.1245 },
                new { AnimalId = 3, Latitude = 34.0725, Longitude = -118.1239 }
            );

            //  Seed Feeding Schedule
            mb.Entity<Animal>().OwnsOne(a => a.FeedingSchedule).HasData(
                new { AnimalId = 1, Time = "4:00 PM", Notes = "Grass and fruit" },
                new { AnimalId = 2, Time = "5:00 PM", Notes = "New York Steak, 10 lbs" },
                new { AnimalId = 3, Time = "3:00 PM", Notes = "Preminum Bamboo, 15 lbs" }
            );

            // Seed Maintenance Record (Now matches the others perfectly)
            mb.Entity<Animal>().OwnsOne(a => a.MaintenanceRecord).HasData(
                new { AnimalId = 1, Date = "2025-11-16", Notes = "Annual checkup" },
                new { AnimalId = 2, Date = "2025-11-15", Notes = "Claw trimming, medication" },
                new { AnimalId = 3, Date = "2025-11-9", Notes = "Habitat inspection, health check" }
            );
        }
    }
}