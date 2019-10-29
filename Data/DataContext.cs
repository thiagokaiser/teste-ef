using Microsoft.EntityFrameworkCore;
using TesteEf.Models;

namespace TesteEf.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
    }
}