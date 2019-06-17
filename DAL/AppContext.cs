using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9K6B7B5\SQLEXPRESS;Initial Catalog=parserdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
