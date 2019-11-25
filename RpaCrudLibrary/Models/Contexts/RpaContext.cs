using Microsoft.EntityFrameworkCore;

namespace RpaCrudLibrary.Models.Contexts
{
    public class RpaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source = ACASA\SQLEXPRESS; Initial Catalog = RpaPrototype;
                              Integrated Security = true; User ID = ion; Password = ion97fam4000");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add specific data binding for your models, if needed
        }

        public DbSet<OpenApp> OpenAppComponents { get; set; }

        public DbSet<OpenApp> WriteAppComponents { get; set; }

        public DbSet<OpenApp> SaveAppComponents { get; set; }

        public DbSet<OpenApp> CloseAppComponents { get; set; }
    }
}
