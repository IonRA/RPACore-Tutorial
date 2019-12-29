using Microsoft.EntityFrameworkCore;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.MetadataDbContext
{
    public class RpaContext : DbContext
    {

        public RpaContext()
        {
        }

        public RpaContext(DbContextOptions<RpaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer(@"Data Source = ACASA\SQLEXPRESS; Initial Catalog = RpaPrototype;
                              Integrated Security = true; User ID = myName; Password = myPassword");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add specific data binding for your models, if needed
        }

        public DbSet<OpenApp> OpenAppComponents { get; set; }

        public DbSet<WriteApp> WriteAppComponents { get; set; }

        public DbSet<SaveApp> SaveAppComponents { get; set; }

        public DbSet<CloseApp> CloseAppComponents { get; set; }
    }
}
