using Microsoft.EntityFrameworkCore;
using NewFeatureEFCore.Models;

namespace NewFeatureEFCore.Data
{
    public class ApplicationDbContext : DbContext
    {

        // a Db set is where we tell entity framework where to map a class (entity) to a table
        public DbSet<Customer> Customers { get; set; }
        // This is the run time configuration of 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        // ModelBuilder is the fluent mapping 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(a => a.RowVersion)
                .IsRowVersion(); // Cuncurrency property using fluent mapping
            base.OnModelCreating(modelBuilder);
        }
    }
}
