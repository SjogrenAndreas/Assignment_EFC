using Infrastructur.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructur.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
    }

}
