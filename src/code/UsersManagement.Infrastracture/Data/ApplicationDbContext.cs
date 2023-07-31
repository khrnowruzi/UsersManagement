using Microsoft.EntityFrameworkCore;
using UsersManagement.Core.Entities;

namespace UsersManagement.Infrastracture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
