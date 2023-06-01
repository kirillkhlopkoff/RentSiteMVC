using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentSiteProject.Models.Users;

namespace RentSiteProject.Data
{
    public class UsersDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly IConfiguration _configuration;
        public UsersDbContext(DbContextOptions<UsersDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
