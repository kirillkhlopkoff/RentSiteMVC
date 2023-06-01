﻿using Microsoft.EntityFrameworkCore;
using RentSiteProject.Models;
using RentSiteProject.Models.Users;

namespace RentSiteProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Apartment> Apartments { get; set; }

    }
}
