using DbModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EXLtestApp
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("AppDBContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Age = 35,
                    EmpEndDate = null,
                    EmpStartDate = new DateTime(2010, 10, 10),
                    JobTitle="Senior Developer",
                    Name = "Patric Jhons"
                }, new User
                {
                    Id = 2,
                    Age = 30,
                    EmpEndDate = null,
                    EmpStartDate = new DateTime(2012, 10, 10),
                    JobTitle = "Senior Developer",
                    Name = "Alen Mark"
                }, new User
                {
                    Id = 3,
                    Age = 37,
                    EmpEndDate = null,
                    EmpStartDate = new DateTime(2016, 10, 10),
                    JobTitle = "Senior Developer",
                    Name = "Nila Jhonson"
                }
            ); ;
        }

    }
}
