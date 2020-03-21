using Covid19Tracker.Entities.Tracker;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tracker.Data.DataContext
{
    public class Covid19TrackerDBContext : IdentityDbContext<ApplicationUser>
    {
        public Covid19TrackerDBContext(DbContextOptions<Covid19TrackerDBContext> dbContextOptions) 
            : base(dbContextOptions)
        {

        }
        public DbSet<CovidCase> Covid19Trackers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }


}
