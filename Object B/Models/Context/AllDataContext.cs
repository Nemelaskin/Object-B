using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Object_B.Models.Context
{
    public class AllDataContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public AllDataContext(DbContextOptions<AllDataContext> options)
            : base(options)
        {

        }
        /*public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visit>().HasData(
                new Visit { VisitId = 1, UserId = 1, VisitTime = DateTime.Now },
                new Visit { VisitId = 2, UserId = 1, VisitTime = DateTime.Now },
                new Visit { VisitId = 3, UserId = 1, VisitTime = DateTime.Now }
                );
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, MapLink= "", }
                );
        }*/
    }
}
