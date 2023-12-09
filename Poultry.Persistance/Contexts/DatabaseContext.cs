using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;
using Poultry.Persistance.Configuration;

namespace Poultry.Persistance.Contexts
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<FoodService> FoodServices { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<HumiditySensor> HumiditySensors { get; set; }
        public DbSet<LightingStatus> LightingStatuses { get; set; }
        public DbSet<TemperatureSensor> TemperatureSensors { get; set; }
        public DbSet<VentilationSensor> VentilationSensors { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            #region Configs
            builder.ApplyConfiguration(new ChickenConfiguration());
            builder.ApplyConfiguration(new FoodServiceConfiguration());
            builder.ApplyConfiguration(new HealthStatusConfiguration());
            builder.ApplyConfiguration(new HumiditySensorConfiguration());
            builder.ApplyConfiguration(new LightingStatusConfiguration());
            builder.ApplyConfiguration(new TemperatureSensorConfiguration());
            builder.ApplyConfiguration(new VentilationSensorConfiguration());
            builder.ApplyConfiguration(new ZoneConfiguration());
            #endregion

            base.OnModelCreating(builder);
        }
    }
    
}
