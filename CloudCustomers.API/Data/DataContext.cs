using CloudCustomers.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudCustomers.API.Data
{
    public class DataContext : DbContext
    {
        DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

    }
}