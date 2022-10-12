using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestarauntReview> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OdeToFood.Models.RestarauntReview> RestarauntReview { get; set; }
    }
}
