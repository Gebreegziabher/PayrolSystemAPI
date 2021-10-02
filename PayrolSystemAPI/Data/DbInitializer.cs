using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayrolSystemAPI.Abstractions;
using System;

namespace PayrolSystemAPI.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceProvider serviceProvider;
        public IConfiguration Configuration { get; }

        public DbInitializer(IServiceProvider _serviceProvider, IConfiguration _configuration)
        {
            serviceProvider = _serviceProvider;
            Configuration = _configuration;
        }

        //Seed, Creat admin role and users, and assign privileges
        public async void Initialize()
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //create database schema if none exists
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
