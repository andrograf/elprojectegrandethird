using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bitfit.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace bitfit.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Add new database entities here,AND To UnitOfWork 
        public DbSet<Food> Foods { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<User> Users { get; set; }

    }
}