﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Models;

namespace OdeToFood.Data
{
	public class ApplicationDbContext : IdentityDbContext<OdeToFoodUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
						: base(options)
		{
		}
		public DbSet<RestarauntReview> RestaurantReviews { get; set; }
		public DbSet<Restaurant> Restaurants { get; set; }
	}
}