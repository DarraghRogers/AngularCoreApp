//using AngularCoreWebApp.Controllers.Resources;
using AngularCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCoreWebApp.Persistence
{
    public class AngularCoreWebAppDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        public AngularCoreWebAppDbContext(DbContextOptions<AngularCoreWebAppDbContext> options)
            :base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }

    }
}
