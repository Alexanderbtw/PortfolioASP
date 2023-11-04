using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Database
{
    public class ClientContext : DbContext
    {
        public DbSet<ClientInfo> ClientsInfo { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientInfo>().Property(c => c.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
