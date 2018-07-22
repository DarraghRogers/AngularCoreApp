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
        public AngularCoreWebAppDbContext(DbContextOptions<AngularCoreWebAppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
    }
}
