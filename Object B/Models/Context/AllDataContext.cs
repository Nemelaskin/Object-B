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
        //public DbSet<RatingTable> RatingTable { get; set; }

        public AllDataContext(DbContextOptions<AllDataContext> options)
            : base(options)
        {

        }
        
    }
}
