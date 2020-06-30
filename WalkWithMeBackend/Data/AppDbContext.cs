using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkWithMeBackend.Model;

namespace WalkWithMeBackend.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GeoPoint> GeoPoints { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RouteGeoPoint> RouteGeoPoints { get; set; }

        public DbSet<CategoryPriority> CategoryPriorities { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Promocode> Promocodes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public DbSet<PointOfInterestCategory> PointOfInterestCategories { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyPoint> CompanyPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RouteGeoPoint>().HasKey(x => new { x.RouteId, x.GeoPointId });
            modelBuilder.Entity<CategoryPriority>().HasKey(x => new { x.AppUserId, x.CategoryId });
            modelBuilder.Entity<PointOfInterestCategory>().HasKey(x => new { x.PointOfInterestId, x.CategoryId });
        }
    }
}
