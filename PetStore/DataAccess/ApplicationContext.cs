using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
