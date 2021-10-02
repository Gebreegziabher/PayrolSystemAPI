using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PayrolSystemAPI.Models;
using System;


namespace PayrolSystemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("ModelBuilder is NULL");
            base.OnModelCreating(modelBuilder);
        }      
        public DbSet<Employee> Employees { get; set; }
    }
}
