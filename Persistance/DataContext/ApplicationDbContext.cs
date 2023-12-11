using Event_System.Core.Entity.Models;
using Event_System.Core.Entity.UserModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Event_System.Persistance.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        DbSet<User> users { get; set; }
    }
}
