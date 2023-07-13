using DbExploration.Models;
using Microsoft.EntityFrameworkCore;

namespace DbExploration.Data{
    public class ApiDbContext : DbContext{
        
        public virtual DbSet<Driver> Drivers {get; set;}
        public virtual DbSet<Team> Teams {get; set;}
        
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>(entity => {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Driver_Team");

                entity.HasOne(d => d.DriverMedia)
                    .WithOne(i => i.Driver)
                    .HasForeignKey<DriverMedia>(b => b.DriverId);
            });
        }
    }
}