using Microsoft.EntityFrameworkCore;
using pinewood.shared.Models;

namespace pinewood.api
{
    public class CustomerDb : DbContext
    {
        public CustomerDb(DbContextOptions<CustomerDb> options)
            : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "First Customer Name",
                    EmailAddress = "First Customer EmailAddress",
                    PostalAddress = "First Customer PostalAddress",
                    PostalCode = "First Customer PostalCode",
                    TelephoneNumber = "First Customer TelephoneNumber",
                },
                new Customer
                {
                    Id = 2,
                    Name = "Second Customer Name",
                    EmailAddress = "Second Customer EmailAddress",
                    PostalAddress = "Second Customer PostalAddress",
                    PostalCode = "Second Customer PostalCode",
                    TelephoneNumber = "Second Customer TelephoneNumber",
                }
            );
        }
    }
}

