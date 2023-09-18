using Microsoft.EntityFrameworkCore;

namespace CCWebApp.Models
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
