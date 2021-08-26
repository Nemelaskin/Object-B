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
        public DbSet<News> News { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }

        public AllDataContext(DbContextOptions<AllDataContext> options)
            : base(options)
        {

        }
        
    }
}
