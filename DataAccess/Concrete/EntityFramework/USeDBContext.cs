using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityUSeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EntityUSe;Trusted_Connection=true");
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}

        