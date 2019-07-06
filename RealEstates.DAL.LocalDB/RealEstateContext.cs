using System;
using Microsoft.EntityFrameworkCore;
using RealEstates.Entities;
using RealEstates.Abstract;

namespace RealEstates.DAL.LocalDB
{
    public class RealEstateContext : DbContext, IDALContext
    {
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Region> Regions { get; set; }

        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
